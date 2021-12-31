
using RecordLabel.src.Directory.Artist.Domain;
using RecordLabel.src.Directory.Artist.Infrastructure.FileReader.FileReaderResult;
using System.Collections.Generic;
using ArtistDomain = RecordLabel.src.Directory.Artist.Domain.Artist;

namespace RecordLabel.src.Directory.Artist.Infrastructure.FileReader.Service
{
    public class ConvertCellsToListOfArtist
    {
        public List<ArtistDomain> Convert(List<ArtistsResult> artistResult)
        {
            List<ArtistDomain> artistsList = new List<ArtistDomain>();
            foreach (ArtistsResult artist in artistResult)
            {
                Address address = new Address(artist.Address);
                ContactNumber contactNumber = new ContactNumber(artist.ContactNo);
                Name name = new Name(artist.Name);
                ArtistDomain newArtist = ArtistDomain.CreateArtist(address, name, contactNumber);
                artistsList.Add(newArtist);
            }
            return artistsList;
        }
    }
}
