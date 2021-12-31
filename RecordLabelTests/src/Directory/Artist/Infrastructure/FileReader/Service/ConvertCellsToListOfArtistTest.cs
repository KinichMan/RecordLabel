
using ArtistDomain = RecordLabel.src.Directory.Artist.Domain.Artist;
using NUnit.Framework;
using RecordLabel.src.Directory.Artist.Infrastructure.FileReader.FileReaderResult;
using RecordLabel.src.Directory.Artist.Infrastructure.FileReader.Service;
using System.Collections.Generic;

namespace RecordLabelTests.src.Directory.Artist.Infrastructure.FileReader.Service
{
    public class ConvertCellsToListOfArtistTest
    {
        [Test]
        public void ItShouldReturnListOfArtists()
        {
            List<ArtistsResult> artistsResult = new List<ArtistsResult>()
            {
                new ArtistsResult("Address", 123123, "Name")
            };
            ConvertCellsToListOfArtist converter = new ConvertCellsToListOfArtist();

            Assert.IsInstanceOf<List<ArtistDomain>>(converter.Convert(artistsResult));
        }
    }
}
