using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;
using System.Threading.RateLimiting;
using DotNetEnv;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]!))
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("YARP"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("gateway", new OpenApiInfo
    {
        Title = "API Gateway",
        Version = "v1"
    });
    
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});
builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    options.OnRejected = async (context, token) =>
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
        await context.HttpContext.Response.WriteAsync("Слишком много запросов, попробуйте позже.");
    };

    options.AddPolicy("IpFixedWindow", httpContext =>
    {
        var ip = httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        return RateLimitPartition.GetFixedWindowLimiter(ip, _ => new FixedWindowRateLimiterOptions
        {
            PermitLimit = 100,
            Window = TimeSpan.FromSeconds(10),
            QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
            QueueLimit = 0  
        });
    });
});
var app = builder.Build();

app.UseAuthentication();
app.UseRateLimiter();
app.UseAuthorization();

app.Use(async (context, next) =>
{
    if (context.Request.Headers.TryGetValue("Authorization", out var authHeader))
    {
        var token = authHeader.ToString().Replace("Bearer ", "");
        var handler = new JwtSecurityTokenHandler();

        try
        {
            var jwt = handler.ReadJwtToken(token);
            var userId = jwt.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;

            if (!string.IsNullOrEmpty(userId))
                context.Request.Headers["X-User-Id"] = userId;
        }
        catch { }
    }

    await next();
});

string ModifySwaggerJson(string originalJson, string pathPrefix)
{
    using var doc = JsonDocument.Parse(originalJson);
    var root = doc.RootElement;
    
    using var stream = new MemoryStream();
    using var writer = new Utf8JsonWriter(stream, new JsonWriterOptions { Indented = true });
    
    writer.WriteStartObject();
    
    foreach (var property in root.EnumerateObject())
    {
        switch (property.Name)
        {
            case "paths":
                writer.WritePropertyName("paths");
                writer.WriteStartObject();
                
                foreach (var pathProp in property.Value.EnumerateObject())
                {
                    var newPath = pathProp.Name;
                    if (!string.IsNullOrEmpty(pathPrefix) && !pathProp.Name.StartsWith(pathPrefix))
                    {
                        newPath = pathPrefix + pathProp.Name;
                    }
                    
                    writer.WritePropertyName(newPath);
                    writer.WriteStartObject();
                    
                    foreach (var opProp in pathProp.Value.EnumerateObject())
                    {
                        writer.WritePropertyName(opProp.Name);
                        writer.WriteStartObject();
                        
             
                        foreach (var field in opProp.Value.EnumerateObject())
                        {
                            if (field.Name == "security")
                            {
                                writer.WritePropertyName("security");
                                writer.WriteStartArray();
                                foreach (var secItem in field.Value.EnumerateArray())
                                {
                                    secItem.WriteTo(writer);
                                }
                                writer.WriteStartObject();
                                writer.WritePropertyName("Bearer");
                                writer.WriteStartArray();
                                writer.WriteEndArray();
                                writer.WriteEndObject();
                                writer.WriteEndArray();
                            }
                            else
                            {
                                field.WriteTo(writer);
                            }
                        }
                        
     
                        if (!opProp.Value.TryGetProperty("security", out _))
                        {
                            writer.WritePropertyName("security");
                            writer.WriteStartArray();
                            writer.WriteStartObject();
                            writer.WritePropertyName("Bearer");
                            writer.WriteStartArray();
                            writer.WriteEndArray();
                            writer.WriteEndObject();
                            writer.WriteEndArray();
                        }
                        
                        writer.WriteEndObject(); 
                    }
                    
                    writer.WriteEndObject(); 
                }
                
                writer.WriteEndObject(); 
                break;
                
            case "components":
                writer.WritePropertyName("components");
                writer.WriteStartObject();
                
                bool hasSecuritySchemes = false;
                foreach (var compProp in property.Value.EnumerateObject())
                {
                    if (compProp.Name == "securitySchemes")
                    {
                        hasSecuritySchemes = true;
                        writer.WritePropertyName("securitySchemes");
                        writer.WriteStartObject();
                        
                        foreach (var schemeProp in compProp.Value.EnumerateObject())
                        {
                            schemeProp.WriteTo(writer);
                        }
                        
                        writer.WritePropertyName("Bearer");
                        writer.WriteStartObject();
                        writer.WriteString("type", "http");
                        writer.WriteString("scheme", "bearer");
                        writer.WriteString("bearerFormat", "JWT");
                        writer.WriteEndObject();
                        
                        writer.WriteEndObject();
                    }
                    else
                    {
                        compProp.WriteTo(writer);
                    }
                }
                
                if (!hasSecuritySchemes)
                {
                    writer.WritePropertyName("securitySchemes");
                    writer.WriteStartObject();
                    writer.WritePropertyName("Bearer");
                    writer.WriteStartObject();
                    writer.WriteString("type", "http");
                    writer.WriteString("scheme", "bearer");
                    writer.WriteString("bearerFormat", "JWT");
                    writer.WriteEndObject();
                    writer.WriteEndObject();
                }
                
                writer.WriteEndObject(); 
                break;
                
            default:
                property.WriteTo(writer);
                break;
        }
    }
    
    writer.WriteEndObject();
    writer.Flush();
    
    return Encoding.UTF8.GetString(stream.ToArray());
}

var usersHost = builder.Configuration["USERS_HOST"];
var usersPort = builder.Configuration["USERS_PORT"];
var chatHost = builder.Configuration["CHAT_HOST"];
var chatPort = builder.Configuration["CHAT_PORT"];
var facilityHost = builder.Configuration["FACILITY_HOST"];
var facilityPort = builder.Configuration["FACILITY_PORT"];
var subscriptionHost = builder.Configuration["SUBSCRIPTION_HOST"];
var subscriptionPort = builder.Configuration["SUBSCRIPTION_PORT"];

builder.Configuration["YARP:Clusters:userscluster:Destinations:users1:Address"] =
    $"http://{usersHost}:{usersPort}/";
builder.Configuration["YARP:Clusters:chatcluster:Destinations:chats1:Address"] =
    $"http://{chatHost}:{chatPort}/";
builder.Configuration["YARP:Clusters:facilitycluster:Destinations:facilities1:Address"] =
    $"http://{facilityHost}:{facilityPort}/";
builder.Configuration["YARP:Clusters:subscriptioncluster:Destinations:subscriptions1:Address"] =
    $"http://{subscriptionHost}:{subscriptionPort}/";
var httpClient = new HttpClient(new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslErrors) => true
});

async Task ProxySwagger(HttpContext context, string host, string port, string pathPrefix)
{
    var url = $"http://{host}:{port}/swagger/v1/swagger.json";
    try
    {
        var response = await httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode)
        {
            context.Response.StatusCode = (int)response.StatusCode;
            await context.Response.WriteAsync($"Ошибка {response.StatusCode} при запросе к {url}");
            return;
        }
        
        var originalJson = await response.Content.ReadAsStringAsync();
        var modifiedJson = ModifySwaggerJson(originalJson, pathPrefix);
        
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(modifiedJson);
    }
    catch (Exception ex)
    {
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync($"Не удалось получить swagger.json: {ex.Message}");
    }
}
app.MapGet("/swagger-proxy/users/swagger.json", async context =>
    await ProxySwagger(context, usersHost!, usersPort!, "/users"));

app.MapGet("/swagger-proxy/chats/swagger.json", async context =>
    await ProxySwagger(context, chatHost!, chatPort!, "/chats"));

app.MapGet("/swagger-proxy/facilities/swagger.json", async context =>
    await ProxySwagger(context, facilityHost!, facilityPort!, "/facilities"));

app.MapGet("/swagger-proxy/subscriptions/swagger.json", async context =>
    await ProxySwagger(context, subscriptionHost!, subscriptionPort!, "/subscriptions"));

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger-proxy/users/swagger.json", "Users Service");
    c.SwaggerEndpoint("/swagger-proxy/chats/swagger.json", "Chats Service");
    c.SwaggerEndpoint("/swagger-proxy/facilities/swagger.json", "Facilities Service");
    c.SwaggerEndpoint("/swagger-proxy/subscriptions/swagger.json", "Subscriptions Service");
    c.RoutePrefix = "";
});

app.MapReverseProxy().RequireRateLimiting("IpFixedWindow");

app.Run();