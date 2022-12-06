using CMS.Api.EDM;
using CMS.Data.EF;
using CMS.Data.EF.Interfaces;
using EventLibrary;
using Microsoft.AspNetCore.OData;

namespace CMS.Api
{
    public static partial class IServiceCollectionExtensions
    {
        static EventHub CMSEventHub = new EventHub();

        public static void AddCMS(this IServiceCollection services, string atPath)
        {
            services.AddDbContextPool<CMSDbContext>(opt => { });
            services.AddDbContextFactory<CMSDbContext>();
            services.AddTransient<ICMSDbContextFactory, CMSDbContextFactory>();

            services.AddSecurityServices();
            services.AddMasterdataServices();
            services.AddTransactionServices();
            services.AddImportServices();
            services.AddCMSApiLayer(atPath);
            services.AddEventing();
        }

        static void AddEventing(this IServiceCollection services)
            => services.AddSingleton<IEventHub>(CMSEventHub);

        public static void AddCMSApiLayer(this IServiceCollection services, string atPath)
        {
            services.AddControllers()
                .AddOData(opt =>
                {
                    opt.Expand().Count().Filter().Select().OrderBy().SetMaxTop(1000);
                    opt.AddRouteComponents(atPath, new CMSModelBuilder().Build().EDMModel);
                });
        }
    }
}