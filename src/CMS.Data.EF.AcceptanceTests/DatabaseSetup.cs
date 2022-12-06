namespace CMS.Data.EF.AcceptanceTests
{
    public static class DatabaseSetup
    {
        static readonly object multiThreadedLock = new();

        public static CMSDbContext EnsureCMSSetupForTesting(CMSDbContext db)
        {
            lock (multiThreadedLock)
            {
                db.Migrate();
                SeedTestData(db);
            }

            return db;
        }

        static void SeedTestData(CMSDbContext db)
        {

        }
    }
}
