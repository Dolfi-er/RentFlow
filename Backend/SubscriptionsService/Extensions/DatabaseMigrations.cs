using FacilityService.Models;
using Microsoft.EntityFrameworkCore;

namespace SubscriptionsService.Extensions;

public static class DatabaseMigration
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var context = scope.ServiceProvider.GetService<Context>();
            context!.Database.Migrate();
        }
    }
}