using CMS.Data.EF.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CMS.Data.EF.AcceptanceTests
{
    public class TestCMSDbContextFactory
    {
        static readonly IServiceProvider serviceProvider;
        readonly ICMSDbContextFactory contextFactory;

        static TestCMSDbContextFactory() 
            => serviceProvider = ServiceProviderSetup.GetServiceProvider();

        public TestCMSDbContextFactory() 
            => contextFactory = serviceProvider.GetRequiredService<ICMSDbContextFactory>();

        public CMSDbContext CreateDbContext() 
            => DatabaseSetup.EnsureCMSSetupForTesting(contextFactory.CreateDbContext());
    }
}
