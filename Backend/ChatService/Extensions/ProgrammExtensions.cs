using System.Text.Json;
using Backend.Models;
using Backend.Repositories;
using Backend.Services;
using Backend.Hubs;
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

        var connectionString =
            $"Host={configuration["DB_HOST"]};Port={configuration["DB_PORT"]};Database={configuration["DB_NAME"]};Username={configuration["DB_USER"]};Password={configuration["DB_PASSWORD"]}";

        services.AddDbContext<Context>(options =>
            options.UseNpgsql(connectionString));

        services.AddSingleton<IMongoClient>(_ =>
            new MongoClient(Environment.GetEnvironmentVariable("MONGO_CONNECTION")!));

        services.AddSingleton<MongoContext>();

        services.AddSignalR();

        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .SetIsOriginAllowed(_ => true);
            });
        });

        services.AddHttpContextAccessor();
        services.AddScoped<ITokenAccessor, TokenAccessor>();

        services.AddScoped<IChatRepository, ChatRepository>();
        services.AddScoped<IChatService, Chatservice>();

        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<IMessageService, MessageService>();

        services.AddScoped<IMessageStatusRepository, MessageStatusRepository>();
        services.AddScoped<IMessageStatusService, MessageStatusService>();

        services.AddScoped<IApplicationRepository, ApplicationRepository>();
        services.AddScoped<IApplicationService, ApplicationService>();

        services.AddScoped<IFileRepository, FileRepository>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IContentTypeService, ContentTypeService>();

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
                        }
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
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            c.RoutePrefix = string.Empty;
        });

        app.ApplyMigrations();

        app.UseRouting();


        app.UseCors("AllowAll");

        app.UseHttpsRedirection();

        app.Use(async (context, next) =>
        {
            if (context.Request.Path.StartsWithSegments("/chatHub"))
            {
                var userId = context.Request.Headers["X-User-Id"].FirstOrDefault();

                if (!string.IsNullOrEmpty(userId))
                {
                    context.Items["UserId"] = userId;
                }
            }

            await next();
        });

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.MapHub<ChatHub>("/chatHub");

        return app;
    }
}