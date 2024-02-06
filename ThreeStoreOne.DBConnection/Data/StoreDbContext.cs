using Microsoft.EntityFrameworkCore;
using KlubHub.Model;

namespace KlubHub.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }
        public DbSet<UserRole>? UserRoles { get; set; }
        public DbSet<Company>? Companies { get; set; }
        public DbSet<CompanyUser>? CompanyUsers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            //optionBuilder.UseCosmos("https://my-store.documents.azure.com:443/", "YgxODINC4PiJahCiG6J7rOgolfsPySeXmKwUdnInDuXzq5S6hkGsilCHa6cfh9NEMKoAN2PleEcUACDb8nqVag==", "three-store-one");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().ToContainer("UserRole").HasPartitionKey(x => x.CompanyId).HasKey(x => x.Id);
            modelBuilder.Entity<Company>().ToContainer("Company").HasPartitionKey(x => x.CompanyId).HasKey(x => x.Id);
            modelBuilder.Entity<CompanyUser>().ToContainer("CompanyUser").HasPartitionKey(x => x.UserId).HasKey(x => x.Id);
        }
    }
}
