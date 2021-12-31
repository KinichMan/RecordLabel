
using Microsoft.EntityFrameworkCore;
using RecordLabel.src.Directory.Artist.Domain;
using RecordLabel.src.Directory.Artist.Infrastructure.Persistence.Mapping;

namespace RecordLabel.src.Shared.Infrastructure.Persistence.Context
{
    public class ELearningContext : DbContext
    {
        public ELearningContext(DbContextOptions opt) : base(opt) { }

        public DbSet<Artist> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArtistMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
