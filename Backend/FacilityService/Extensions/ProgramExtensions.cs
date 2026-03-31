using System.Text.Json;
using FacilityService.Models;
using FacilityService.Repositories;
using FacilityService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace FacilityService.Extensions;

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

        string dbHost = configuration["DB_HOST"]!;
        string dbPort = configuration["DB_PORT"]!;
        string dbName = configuration["DB_NAME"]!;
        string dbUser = configuration["DB_USER"]!;
        string dbPassword = configuration["DB_PASSWORD"]!;
        string connectionString = $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPassword}";

        services.AddDbContext<Context>(options => options.UseNpgsql(connectionString));

        services.AddScoped<IStatusRepository, StatusRepository>();
        services.AddScoped<ITypeRepository, TypeRepository>();

        services.AddScoped<IStatusService, StatusService>();
        services.AddScoped<ITypeService, TypeService>();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "UserService",
                Version = "v1"
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
