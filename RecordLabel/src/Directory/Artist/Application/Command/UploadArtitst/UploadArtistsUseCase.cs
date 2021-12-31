using ArtistDomain = RecordLabel.src.Directory.Artist.Domain.Artist;
using System.Collections.Generic;
using RecordLabel.src.Directory.Artist.Domain;

namespace RecordLabel.src.Directory.Artist.Application.Command.UploadArtitst
{
    public class UploadArtistsUseCase
    {
        public readonly IArtistRepository<ArtistDomain> artistRepository;

        public UploadArtistsUseCase(IArtistRepository<ArtistDomain> artistRepository)
        {
            this.artistRepository = artistRepository;
        }

        public void Execute(List<ArtistDomain> artists)
        {
            foreach (ArtistDomain artist in artists)
            {
                artistRepository.Add(artist);
            }
        }
    }
}
