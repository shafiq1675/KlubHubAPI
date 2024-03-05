using Microsoft.EntityFrameworkCore;
using KlubHub.Model;

namespace KlubHub.Data
{
    public class KlubHubDbContext : DbContext
    {
        public KlubHubDbContext(DbContextOptions<KlubHubDbContext> options) : base(options)
        {
        }
        public DbSet<MemberRole>? MemberRoles { get; set; }
        public DbSet<Member>? Member { get; set; }
        public DbSet<Club>? Club { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            //optionBuilder.UseCosmos("my url", "YgxODINC4PiJahCiG6J7rOgolfsPySeXmKwUdnInDuXzq5S6hkGsilCHa6cfh9NEMKoAN2PleEcUACDb8nqVag==", "three-store-one");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<MemberRole>().ToContainer("MemberRole").HasPartitionKey(x => x.CompanyId).HasKey(x => x.Id);
            //modelBuilder.Entity<Company>().ToContainer("Company").HasPartitionKey(x => x.CompanyId).HasKey(x => x.Id);
            //modelBuilder.Entity<Member>().ToContainer("Member").HasPartitionKey(x => x.UserId).HasKey(x => x.Id);
        }
    }
}
