using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Otter.Common.Entities;
using Otter.Common.Tools;
using Otter.DataAccess.SQLServer.Configurations;

namespace Otter.DataAccess.SQLServer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ConfigurationEntityConfiguration());
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<PolicyFile> PolicyFiles { get; set; }
        public DbSet<SpeakerTestNumber> SpeakerTestNumbers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Agent> Agents { get; set; }
    }
}