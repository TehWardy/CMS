namespace CMS.Data.EF.Interfaces
{
    public interface ICMSDbContextFactory
    {
        CMSDbContext CreateDbContext();
    }
}