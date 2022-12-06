using CMS.Data.EF.Interfaces;
using CMS.Objects;
using Microsoft.Extensions.Configuration;

namespace CMS.Data.EF
{
    // This Wrapper in case we want to take a different approach to the EF factory for our context instancing 
    // or just want a single place to call the ctor to avoid affecting a lot of files when the ctor changes.
    public class CMSDbContextFactory : ICMSDbContextFactory
    {
/*        readonly IDbContextFactory<CMSDbContext> externalFactory;

        public CMSDbContextFactory(IDbContextFactory<CMSDbContext> externalFactory)
            => this.externalFactory = externalFactory;

        public CMSDbContext CreateDbContext()
            => externalFactory.CreateDbContext();*/

        readonly IConfiguration configuration;
        readonly ICMSAuthInfo authInfo;
        readonly ICMSModelBuildProvider modelBuildProvider;

        public CMSDbContextFactory(IConfiguration configuration, ICMSAuthInfo authInfo, ICMSModelBuildProvider modelBuildProvider)
        {
            this.configuration = configuration;
            this.authInfo = authInfo;
            this.modelBuildProvider = modelBuildProvider;
        }

        public CMSDbContext CreateDbContext()
            => new(configuration, authInfo, modelBuildProvider);
    }
}