using CsvImporterModel.Data;
using Microsoft.EntityFrameworkCore;

namespace CsvImporterModel.Connection
{
    public class AcmeCorporationDbContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AcmeCorporationDbContext() { }

        /// <summary>
        /// Constructor with parameters for configuration 
        /// </summary>
        /// <param name="options"></param>
        public AcmeCorporationDbContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Acme_Corporation;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CsvImporter>()
                .HasNoKey();
        }

        public DbSet<CsvImporter> CsvImporter { get; set; }

    }
}
