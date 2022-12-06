using CMS.Data.Brokers.Storages.Financing;
using CMS.Data.Brokers.Storages.Financing.Interfaces;

namespace CMS.Api
{
    public static partial class IServiceCollectionExtensions
    {
        static void AddFinanceServices(this IServiceCollection services)
        {
            services.AddFinanceBrokers();
            services.AddFinanceFoundationServices();
            services.AddFinanceProcessingServices();
            services.AddFinanceOrchestrationServices();
        }

        static void AddFinanceFoundationServices(this IServiceCollection services)
        {
            
        }

        static void AddFinanceProcessingServices(this IServiceCollection services)
        {
            

        }

        static void AddFinanceOrchestrationServices(this IServiceCollection services)
        {
            
        }

        static void AddFinanceBrokers(this IServiceCollection services)
        {
            services.AddTransient<IFundingDetailBroker, FundingDetailBroker>();
            services.AddTransient<IOfferBroker, OfferBroker>();
            services.AddTransient<IOfferCompanyBroker, OfferCompanyBroker>();
            services.AddTransient<IOfferLineBroker, OfferLineBroker>();
            services.AddTransient<IOfferReferenceBroker, OfferReferenceBroker>();
        }
    }
}