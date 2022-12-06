using CMS.Data.Brokers.Events.Import;
using CMS.Data.Brokers.Events.Import.Interfaces;
using CMS.Data.Brokers.Storages.Import;
using CMS.Data.Brokers.Storages.Import.Interfaces;
using CMS.Services.Coordination;
using CMS.Services.Coordination.Interfaces;
using CMS.Services.Foundation.Import;
using CMS.Services.Foundation.Import.Interfaces;
using CMS.Services.Orchestration.Import;
using CMS.Services.Orchestration.Import.Interfaces;
using CMS.Services.Processing.Import;
using CMS.Services.Processing.Import.Interfaces;
using CMS.Services.Transformation.Brokers;
using CMS.Services.Transformation.Brokers.Interfaces;
using CMS.Services.Transformation.Orchestration;
using CMS.Services.Transformation.Orchestration.Interfaces;
using DataLibrary;
using DataLibrary.Interfaces;

namespace CMS.Api
{
    public static partial class IServiceCollectionExtensions
    {
        static void AddImportServices(this IServiceCollection services)
        {
            services.AddImportBrokers();
            services.AddImportFoundationServices();
            services.AddImportProcessingServices();
            services.AddImportOrchestrationServices();

            services.AddTransient<ITransactionCoordinationService, TransactionCoordinationService>();
        }

        static void AddImportBrokers(this IServiceCollection services)
        {
            services.AddTransient<ICMSCSVDataParseBroker, CMSCSVDataParseBroker>();

            services.AddTransient<ICompanyCSVLineBroker, CompanyCSVLineBroker>();
            services.AddTransient<ICompanyCSVLineEventBroker, CompanyCSVLineEventBroker>();

            services.AddTransient<ITransactionCSVLineBroker, TransactionCSVLineBroker>();
            services.AddTransient<ITransactionCSVLineEventBroker, TransactionCSVLineEventBroker>();
        }

        static void AddImportFoundationServices(this IServiceCollection services)
        {
            services.AddTransient<ICompanyCSVLineEventService, CompanyCSVLineEventService>();
            services.AddTransient<ICompanyCSVLineService, CompanyCSVLineService>();

            services.AddTransient<ITransactionCSVLineEventService, TransactionCSVLineEventService>();
            services.AddTransient<ITransactionCSVLineService, TransactionCSVLineService>();
        }

        static void AddImportProcessingServices(this IServiceCollection services)
        {
            services.AddTransient<IParserProcessingService, ParserProcessingService>();

            services.AddTransient<ICompanyCSVLineEventProcessingService, CompanyCSVLineEventProcessingService>();
            services.AddTransient<ICompanyCSVLineProcessingService, CompanyCSVLineProcessingService>();

            services.AddTransient<ITransactionCSVLineEventProcessingService, TransactionCSVLineEventProcessingService>();
            services.AddTransient<ITransactionCSVLineProcessingService, TransactionCSVLineProcessingService>();
        }

        static void AddImportOrchestrationServices(this IServiceCollection services)
        {
            services.AddTransient<ICompanyCSVLineParserOrchestrationService, CompanyCSVLineParserOrchestrationService>();
            services.AddTransient<ITransactionCSVLineParserOrchestrationService, TransactionCSVLineParserOrchestrationService>();

            services.AddTransient<ICompanyCSVLineOrchestrationService, CompanyCSVLineOrchestrationService>();
            services.AddTransient<ITransactionCSVLineOrchestrationService, TransactionCSVLineOrchestrationService>();
        }
    }
}