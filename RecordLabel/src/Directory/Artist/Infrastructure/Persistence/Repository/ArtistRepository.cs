using Microsoft.Extensions.DependencyInjection;
using RecordLabel.src.Directory.Artist.Domain;
using RecordLabel.src.Shared.Infrastructure.Persistence.Context;
using RecordLabel.src.Shared.Infrastructure.Persistence.Repository;
using ArtistDomain = RecordLabel.src.Directory.Artist.Domain.Artist;

namespace RecordLabel.src.Directory.Artist.Infrastructure.Persistence.Repository
{
    public class ArtistRepository : EntityFrameworkRepository<ArtistDomain>, IArtistRepository<ArtistDomain>
    {
        public ArtistRepository(ELearningContext context, IServiceScopeFactory scopeFactory) : base(context, scopeFactory)
        {
        }
    }
}
