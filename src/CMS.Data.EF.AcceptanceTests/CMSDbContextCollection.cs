using Xunit;

namespace CMS.Data.EF.AcceptanceTests
{
    [CollectionDefinition(nameof(CMSDbContextCollection))]
    public class CMSDbContextCollection : ICollectionFixture<TestCMSDbContextFactory> { }
}
