using System.Text.Json;
using Backend.DTOs;
using Backend.Models;
using Backend.Repositories;
using Backend.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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
            });
        var dbHost = configuration["DB_HOST"];
        var dbPort = configuration["DB_PORT"];
        var dbName = configuration["DB_NAME"];
        var dbUser = configuration["DB_USER"];
        var dbPassword = configuration["DB_PASSWORD"];
        var connectionString = $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPassword}";

        services.AddDbContext<Context>(options => options.UseNpgsql(connectionString));
        services.AddEndpointsApiExplorer();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IUserInfoRepository, UserInfoRepository>();
        services.AddScoped<IUSerRepository, UserRepository>();
        services.AddScoped<IUserService, Userservice>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IAuthorizationService, AuthorizationService>();
        services.AddScoped<ICookieService, CookieService>();
        services.AddScoped<IHashService, HashService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();
        services.AddScoped<AbstractValidator<RegistrDTO>, UserValidator>();
        services.AddHttpContextAccessor();
        services.AddScoped<ITokenAccessor, TokenAccessor>();
        services.Configure<JwtSettings>( configuration.GetSection("JwtSettings"));
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "UserService",
                Version = "v1"
            });

            options.AddSecurityDefinition("UserHeader", new OpenApiSecurityScheme
            {
                Description = "Введите X-User-Id (GUID пользователя)",
                Name = "X-User-Id",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "UserHeader"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "UserHeader"
                        }
                    },
                    new string[] {}
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

        app.MapControllers();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        return app;
    }
}
