using CMS.Data.EF.Interfaces;
using CMS.Objects;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace CMS.Data.EF.AcceptanceTests
{
    internal static class ServiceProviderSetup
    {
        public static IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();
            RegisterServices(services);
            return services.BuildServiceProvider();
        }

        static void RegisterServices(IServiceCollection services)
        {
            //configuration
            var configRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            services.AddTransient<IConfiguration>(provider => configRoot);

            // context setup
            services.AddDbContextPool<CMSDbContext>(opt => { });
            services.AddDbContextFactory<CMSDbContext>();
            services.AddTransient<ICMSDbContextFactory, CMSDbContextFactory>();
            services.AddTransient<ICMSAuthInfo>(provider => new TestCMSAuthInfo());

            switch (configRoot.GetSection("Settings")["DbType"])
            {
                case "sqlite":
                    services.AddTransient<ICMSModelBuildProvider, CMSSQLiteModelBuildProvider>();
                    break;
                default:
                    services.AddTransient<ICMSModelBuildProvider, CMSMSSQLModelBuildProvider>();
                    break;
            }
        }
    }

    public class TestCMSAuthInfo : ICMSAuthInfo
    {
        public string SSOUserId { get; set; } = "Guest";
    }
}