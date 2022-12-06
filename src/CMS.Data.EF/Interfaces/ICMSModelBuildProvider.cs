using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace CMS.Data.EF.Interfaces
{
    public interface ICMSModelBuildProvider
    {
        void Configure(IConfiguration configuration, DbContextOptionsBuilder optionsBuilder);
        void Create(ModelBuilder modelBuilder);
        void MigrateDatabase(DatabaseFacade database);
    }
}