using Account.Api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Account.Api.Infrastructure
{
    //This class is responsible for migrating the updated entity to the sql database once service runs
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                    }
                    catch  
                    {
                        throw;
                    }
                }
            }

            return host;
        }
    }
}
