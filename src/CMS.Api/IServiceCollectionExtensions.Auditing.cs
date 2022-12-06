using CMS.Data.Brokers.Storages.Auditing;
using CMS.Data.Brokers.Storages.Auditing.Interfaces;

namespace CMS.Api
{
    public static partial class IServiceCollectionExtensions
    {
        static void AddAuditingServices(this IServiceCollection services)
        {
            services.AddAuditingBrokers();
            services.AddAuditingFoundationServices();
            services.AddAuditingProcessingServices();
            services.AddAuditingOrchestrationServices();
        }

        static void AddAuditingFoundationServices(this IServiceCollection services)
        {
            
        }

        static void AddAuditingProcessingServices(this IServiceCollection services)
        {
            

        }

        static void AddAuditingOrchestrationServices(this IServiceCollection services)
        {
            
        }

        static void AddAuditingBrokers(this IServiceCollection services)
        {
            services.AddTransient<IAuditItemLevelBroker, AuditItemLevelBroker>();
            services.AddTransient<ICreditAuditItemBroker, CreditAuditItemBroker>();
            services.AddTransient<IInvoiceAuditItemBroker, InvoiceAuditItemBroker>();
            services.AddTransient<IOfferAuditItemBroker, OfferAuditItemBroker>();
            services.AddTransient<IPurchaseOrderAuditItemBroker, PurchaseOrderAuditItemBroker>();
            services.AddTransient<IRemittanceAdviceAuditItemBroker, RemittanceAdviceAuditItemBroker>();
        }
    }
}