using CMS.Data.EF.Interfaces;
using CMS.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CMS.Data.EF
{
    public partial class CMSDbContext : DbContext
    {
        public ICMSAuthInfo AuthInfo { get; }

        readonly ICMSModelBuildProvider modelBuildProvider;
        readonly IConfiguration configuration;

        public CMSDbContext(IConfiguration configuration, ICMSAuthInfo authInfo, ICMSModelBuildProvider modelBuildProvider)
        { 
            this.configuration = configuration;
            AuthInfo = authInfo;
            this.modelBuildProvider = modelBuildProvider;  
        }

        public void Migrate() 
            => modelBuildProvider.MigrateDatabase(Database);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuildProvider.Create(modelBuilder);
            ApplyFilters(modelBuilder);
            SeedDatabase(modelBuilder);
        }

        void ApplyFilters(ModelBuilder modelBuilder)
        {
            
        }

        void SeedDatabase(ModelBuilder modelBuilder)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = configuration.GetConnectionString("CMS");
            modelBuildProvider.Configure(configuration, optionsBuilder);

            optionsBuilder.LogTo((message) => {
                if (message.Contains("Executing") || message.Contains("transaction"))
                    System.Diagnostics.Debug.WriteLine(message);
            });
        }
    }
}