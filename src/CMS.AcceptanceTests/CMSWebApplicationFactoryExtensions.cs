using CMS.Data.EF;
using CMS.Data.EF.Interfaces;
using CMS.Objects;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CMS.AcceptanceTests
{
    public static class CMSWebApplicationFactoryExtensions
    {
        static readonly object multiThreadedLock = new();

        public static void EnsureCMSSetupForTesting(this WebApplicationFactory<Program> appFactory)
        {
            lock (multiThreadedLock)
            {
                using var scope = appFactory.Services.CreateScope();
                var scopedServices = scope.ServiceProvider;

                using var db = new CMSDbContext(
                    scopedServices.GetRequiredService<IConfiguration>(), 
                    scopedServices.GetRequiredService<ICMSAuthInfo>(),
                    scopedServices.GetRequiredService<ICMSModelBuildProvider>());
                db.Migrate();
                SeedTestData(db);
            }
        }

        static void SeedTestData(CMSDbContext db)
        {

        }
    }
}
