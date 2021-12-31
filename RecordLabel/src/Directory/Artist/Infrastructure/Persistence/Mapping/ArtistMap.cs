using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ArtistDomain = RecordLabel.src.Directory.Artist.Domain.Artist;

namespace RecordLabel.src.Directory.Artist.Infrastructure.Persistence.Mapping
{
    public class ArtistMap : IEntityTypeConfiguration<ArtistDomain>
    {
        public void Configure(EntityTypeBuilder<ArtistDomain> builder)
        {
          
        }
    }
}
