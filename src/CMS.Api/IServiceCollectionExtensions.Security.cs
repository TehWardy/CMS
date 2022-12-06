using CMS.Data.Brokers.Events.Security;
using CMS.Data.Brokers.Events.Security.Interfaces;
using CMS.Data.Brokers.Storages.Masterdata;
using CMS.Data.Brokers.Storages.Masterdata.Interfaces;
using CMS.Data.Brokers.Storages.Security;
using CMS.Data.Brokers.Storages.Security.Interfaces;
using CMS.Services.Foundation.Security;
using CMS.Services.Foundation.Security.Interfaces;
using CMS.Services.Orchestration.Security;
using CMS.Services.Orchestration.Security.Interfaces;
using CMS.Services.Processing.Security;
using CMS.Services.Processing.Security.Interfaces;

namespace CMS.Api
{
    public static partial class IServiceCollectionExtensions
    {
        static void AddSecurityServices(this IServiceCollection services)
        {
            services.AddSecurityBrokers();
            services.AddSecurityFoundationServices();
            services.AddSecurityProcessingServices();
            services.AddSecurityOrchestrationServices();
        }

        static void AddSecurityFoundationServices(this IServiceCollection services)
        {
            // event services
            services.AddTransient<ICMSRoleEventService, CMSRoleEventService>();

            // services
            services.AddTransient<ICMSUserService, CMSUserService>();
            services.AddTransient<ICMSRoleService, CMSRoleService>();
            services.AddTransient<ICMSUserRoleService, CMSUserRoleService>();
            services.AddTransient<IBucketRoleService, BucketRoleService>();
        }

        static void AddSecurityProcessingServices(this IServiceCollection services)
        {
            // event services
            services.AddTransient<ICMSRoleEventProcessingService, CMSRoleEventProcessingService>();

            // services
            services.AddTransient<ICMSUserProcessingService, CMSUserProcessingService>();
            services.AddTransient<ICMSRoleProcessingService, CMSRoleProcessingService>();
            services.AddTransient<ICMSUserRoleProcessingService, CMSUserRoleProcessingService>();
            services.AddTransient<IBucketRoleProcessingService, BucketRoleProcessingService>();
        }

        static void AddSecurityOrchestrationServices(this IServiceCollection services)
        {
            services.AddTransient<ICMSUserOrchestrationService, CMSUserOrchestrationService>();
            services.AddTransient<ICMSRoleOrchestrationService, CMSRoleOrchestrationService>();
            services.AddTransient<ICMSUserRoleOrchestrationService, CMSUserRoleOrchestrationService>();
            services.AddTransient<IBucketRoleOrchestrationService, BucketRoleOrchestrationService>();
        }

        static void AddSecurityBrokers(this IServiceCollection services)
        {
            services.AddTransient<ICMSUserBroker, CMSUserBroker>();
            services.AddTransient<ICMSRoleBroker, CMSRoleBroker>();
            services.AddTransient<ICMSUserRoleBroker, CMSUserRoleBroker>();
            services.AddTransient<IBucketRoleBroker, BucketRoleBroker>();
            services.AddTransient<ICMSAuthorizationBroker, CMSAuthorizationBroker>();

            services.AddTransient<ICMSRoleEventBroker, CMSRoleEventBroker>();
        }
    }
}