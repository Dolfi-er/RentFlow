using System.Text.Json;
using Backend.Models;
using Backend.Repositories;
using Backend.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;

namespace Backend.Extensions;

public static class ProgrammExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllersWithViews()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = false;
                options.JsonSerializerOptions.Converters.Add(new ObjectIdConverter());
            });
        var dbHost = configuration["DB_HOST"];
        var dbPort = configuration["DB_PORT"];
        var dbName = configuration["DB_NAME"];
        var dbUser = configuration["DB_USER"];
        var dbPassword = configuration["DB_PASSWORD"];
        var connectionString = $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPassword}";

        services.AddScoped<IMessageStatusRepository, MessageStatusRepository>();
        services.AddScoped<IMessageStatusService, MessageStatusService>();
        services.AddHttpContextAccessor();
        services.AddScoped<ITokenAccessor, TokenAccessor>();
        services.AddScoped<IFileRepository, FileRepository>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IContentTypeService, ContentTypeService>();
        services.AddScoped<IChatRepository, ChatRepository>();
        services.AddScoped<IChatService, Chatservice>();
        services.AddScoped<IApplicationRepository, ApplicationRepository>();
        services.AddScoped<IApplicationService, ApplicationService>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<IMessageService, MessageService>();
        services.AddDbContext<Context>(options => options.UseNpgsql(connectionString));
        services.AddSingleton<IMongoClient>(sp =>
        {
            return new MongoClient(Environment.GetEnvironmentVariable("MONGO_CONNECTION")!);
        });
        services.AddSingleton<MongoContext>();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "ChatService",
                Version = "v1"
            });

            options.AddSecurityDefinition("ChatHeader", new OpenApiSecurityScheme
            {
                Description = "Введите X-User-Id (GUID пользователя)",
                Name = "X-User-Id",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "ChatHeader" 
                        },
                        In = ParameterLocation.Header
                    },
                    Array.Empty<string>()
                }
            });
        });
        return services;
    }

    public static WebApplication ConfigureApp(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", " v1");
            c.RoutePrefix = string.Empty; 
        });

        app.ApplyMigrations();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        return app;
    }
}
