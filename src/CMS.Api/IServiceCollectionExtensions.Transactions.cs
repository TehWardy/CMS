using CMS.Data.Brokers.DateTime;
using CMS.Data.Brokers.Events.Payments;
using CMS.Data.Brokers.Events.Transactions;
using CMS.Data.Brokers.Events.Transactions.Interfaces;
using CMS.Data.Brokers.Storages.Auditing;
using CMS.Data.Brokers.Storages.Auditing.Interfaces;
using CMS.Data.Brokers.Storages.Transactions;
using CMS.Data.Brokers.Storages.Transactions.Interfaces;
using CMS.Services.Coordination;
using CMS.Services.Coordination.Interfaces;
using CMS.Services.Foundation.Interfaces;
using CMS.Services.Foundation.Payments;
using CMS.Services.Foundation.Payments.Interfaces;
using CMS.Services.Foundation.Transactions;
using CMS.Services.Management;
using CMS.Services.Management.Interfaces;
using CMS.Services.Orchestration.Masterdata;
using CMS.Services.Orchestration.Masterdata.Interfaces;
using CMS.Services.Orchestration.Payments;
using CMS.Services.Orchestration.Payments.Interfaces;
using CMS.Services.Orchestration.Transactions;
using CMS.Services.Orchestration.Transactions.Interfaces;
using CMS.Services.Processing.Interfaces;
using CMS.Services.Processing.Payments;
using CMS.Services.Processing.Payments.Interfaces;
using CMS.Services.Processing.Transactions;
using CMS.Services.Processing.Transactions.Interfaces;

namespace CMS.Api
{
    public static partial class IServiceCollectionExtensions
    {
        static void AddTransactionServices(this IServiceCollection services)
        {
            //utility brokers
            services.AddTransient<ICMSDateTimeOffsetBroker, CMSDateTimeOffsetBroker>();

            services.AddTransactionBrokers();
            services.AddTransactionFoundationServices();
            services.AddTransactionProcessingServices();
            services.AddTransactionOrchestrationServices();

            services.AddTransient<ITransactionCoordinationService, TransactionCoordinationService>();
            services.AddTransient<IBatchedTransactionCoordinationService, BatchedTransactionCoordinationService>();
            services.AddTransient<ITransactionManagementService, TransactionManagementService>();
        }

        static void AddTransactionFoundationServices(this IServiceCollection services)
        {
            services.AddTransient<IInvoiceService, InvoiceService>();
            services.AddTransient<IInvoiceLineService, InvoiceLineService>();
            services.AddTransient<IInvoiceReferenceService, InvoiceReferenceService>();
            services.AddTransient<IInvoiceCompanyService, InvoiceCompanyService>();
            services.AddTransient<IInvoiceAuditItemService, InvoiceAuditItemService>();
            services.AddTransient<IBucketInvoiceService, BucketInvoiceService>();
            services.AddTransient<IInvoiceEventService, InvoiceEventService>();

            services.AddTransient<ICreditService, CreditService>();
            services.AddTransient<ICreditLineService, CreditLineService>();
            services.AddTransient<ICreditReferenceService, CreditReferenceService>();
            services.AddTransient<ICreditCompanyService, CreditCompanyService>();
            services.AddTransient<ICreditAuditItemService, CreditAuditItemService>();
            services.AddTransient<IBucketCreditService, BucketCreditService>();
            services.AddTransient<ICreditEventService, CreditEventService>();

            services.AddTransient<IRemittanceAdviceService, RemittanceAdviceService>();
            services.AddTransient<IRemittanceAdviceLineService, RemittanceAdviceLineService>();
            services.AddTransient<IRemittanceAdviceReferenceService, RemittanceAdviceReferenceService>();
            services.AddTransient<IRemittanceAdviceCompanyService, RemittanceAdviceCompanyService>();
            services.AddTransient<IRemittanceAdviceAuditItemService, RemittanceAdviceAuditItemService>();
            services.AddTransient<IBucketRemittanceAdviceService, BucketRemittanceAdviceService>();
            services.AddTransient<IRemittanceAdviceEventService, RemittanceAdviceEventService>();
        }

        static void AddTransactionProcessingServices(this IServiceCollection services)
        {
            services.AddTransient<IInvoiceProcessingService, InvoiceProcessingService>();
            services.AddTransient<IInvoiceLineProcessingService, InvoiceLineProcessingService>();
            services.AddTransient<IInvoiceReferenceProcessingService, InvoiceReferenceProcessingService>();
            services.AddTransient<IInvoiceCompanyProcessingService, InvoiceCompanyProcessingService>();
            services.AddTransient<IInvoiceAuditItemProcessingService, InvoiceAuditItemProcessingService>();
            services.AddTransient<IBucketInvoiceProcessingService, BucketInvoiceProcessingService>();
            services.AddTransient<IInvoiceEventProcessingService, InvoiceEventProcessingService>();

            services.AddTransient<ICreditProcessingService, CreditProcessingService>();
            services.AddTransient<ICreditLineProcessingService, CreditLineProcessingService>();
            services.AddTransient<ICreditReferenceProcessingService, CreditReferenceProcessingService>();
            services.AddTransient<ICreditCompanyProcessingService, CreditCompanyProcessingService>();
            services.AddTransient<ICreditAuditItemProcessingService, CreditAuditItemProcessingService>();
            services.AddTransient<IBucketCreditProcessingService, BucketCreditProcessingService>();
            services.AddTransient<ICreditEventProcessingService, CreditEventProcessingService>();

            services.AddTransient<IRemittanceAdviceProcessingService, RemittanceAdviceProcessingService>();
            services.AddTransient<IRemittanceAdviceLineProcessingService, RemittanceAdviceLineProcessingService>();
            services.AddTransient<IRemittanceAdviceReferenceProcessingService, RemittanceAdviceReferenceProcessingService>();
            services.AddTransient<IRemittanceAdviceCompanyProcessingService, RemittanceAdviceCompanyProcessingService>();
            services.AddTransient<IRemittanceAdviceAuditItemProcessingService, RemittanceAdviceAuditItemProcessingService>();
            services.AddTransient<IBucketRemittanceAdviceProcessingService, BucketRemittanceAdviceProcessingService>();
            services.AddTransient<IRemittanceAdviceEventProcessingService, RemittanceAdviceEventProcessingService>();
        }

        static void AddTransactionOrchestrationServices(this IServiceCollection services)
        {
            services.AddTransient<IInvoiceOrchestrationService, InvoiceOrchestrationService>();
            services.AddTransient<IInvoiceLineOrchestrationService, InvoiceLineOrchestrationService>();
            services.AddTransient<IInvoiceReferenceOrchestrationService, InvoiceReferenceOrchestrationService>();
            services.AddTransient<IInvoiceCompanyOrchestrationService, InvoiceCompanyOrchestrationService>();
            services.AddTransient<IInvoiceAuditItemOrchestrationService, InvoiceAuditItemOrchestrationService>();
            services.AddTransient<IBucketInvoiceOrchestrationService, BucketInvoiceOrchestrationService>();

            services.AddTransient<ICreditOrchestrationService, CreditOrchestrationService>();
            services.AddTransient<ICreditLineOrchestrationService, CreditLineOrchestrationService>();
            services.AddTransient<ICreditReferenceOrchestrationService, CreditReferenceOrchestrationService>();
            services.AddTransient<ICreditCompanyOrchestrationService, CreditCompanyOrchestrationService>();
            services.AddTransient<ICreditAuditItemOrchestrationService, CreditAuditItemOrchestrationService>();
            services.AddTransient<IBucketCreditOrchestrationService, BucketCreditOrchestrationService>();

            services.AddTransient<IRemittanceAdviceOrchestrationService, RemittanceAdviceOrchestrationService>();
            services.AddTransient<IRemittanceAdviceLineOrchestrationService, RemittanceAdviceLineOrchestrationService>();
            services.AddTransient<IRemittanceAdviceReferenceOrchestrationService, RemittanceAdviceReferenceOrchestrationService>();
            services.AddTransient<IRemittanceAdviceCompanyOrchestrationService, RemittanceAdviceCompanyOrchestrationService>();
            services.AddTransient<IRemittanceAdviceAuditItemOrchestrationService, RemittanceAdviceAuditItemOrchestrationService>();
            services.AddTransient<IBucketRemittanceAdviceOrchestrationService, BucketRemittanceAdviceOrchestrationService>();
        }

        static void AddTransactionBrokers(this IServiceCollection services)
        {
            services.AddTransient<IActiveTransactionBroker, ActiveTransactionBroker>();
            services.AddTransient<ICreditBroker, CreditBroker>();
            services.AddTransient<ICreditCompanyBroker, CreditCompanyBroker>();
            services.AddTransient<ICreditLineBroker, CreditLineBroker>();
            services.AddTransient<ICreditReferenceBroker, CreditReferenceBroker>();
            services.AddTransient<ICreditTypeBroker, CreditTypeBroker>();
            services.AddTransient<ICreditAuditItemBroker, CreditAuditItemBroker>();

            services.AddTransient<IInvoiceBroker, InvoiceBroker>();
            services.AddTransient<IInvoiceCompanyBroker, InvoiceCompanyBroker>();
            services.AddTransient<IInvoiceLineBroker, InvoiceLineBroker>();
            services.AddTransient<IInvoiceReferenceBroker, InvoiceReferenceBroker>();
            services.AddTransient<IInvoiceTypeBroker, InvoiceTypeBroker>();
            services.AddTransient<IInvoiceAuditItemBroker, InvoiceAuditItemBroker>();

            services.AddTransient<IPurchaseOrderBroker, PurchaseOrderBroker>();
            services.AddTransient<IPurchaseOrderCompanyBroker, PurchaseOrderCompanyBroker>();

            services.AddTransient<IRemittanceAdviceBroker, RemittanceAdviceBroker>();
            services.AddTransient<IRemittanceAdviceCompanyBroker, RemittanceAdviceCompanyBroker>();
            services.AddTransient<IRemittanceAdviceLineBroker, RemittanceAdviceLineBroker>();
            services.AddTransient<IRemittanceAdviceReferenceBroker, RemittanceAdviceReferenceBroker>();
            services.AddTransient<IRemittanceAdviceTypeBroker, RemittanceAdviceTypeBroker>();
            services.AddTransient<IRemittanceAdviceAuditItemBroker, RemittanceAdviceAuditItemBroker>();

            services.AddTransient<ICreditEventBroker, CreditEventBroker>();
            services.AddTransient<IInvoiceEventBroker, InvoiceEventBroker>();
            services.AddTransient<IRemittanceAdviceEventBroker, RemittanceAdviceEventBroker>();
        }
    }
}