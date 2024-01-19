using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ChallengeApi.DataContext
{
    
    public static class MigrationManager
    {
        public static IHost MigrateDatabase<TContext>(this IHost host) where TContext : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var db = services.GetRequiredService<TContext>();
                try
                {
                    db.Database.Migrate();
                }
                catch (Exception ex)
                {
                    // Log the error or handle it as needed
                    // Consider logging the exception and not rethrowing it if you want the application to start even if migration fails
                    throw;
                }
            }

            return host;
        }
    }
}
