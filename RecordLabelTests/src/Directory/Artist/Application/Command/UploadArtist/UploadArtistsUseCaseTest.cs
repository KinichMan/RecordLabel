using Moq;
using NUnit.Framework;
using RecordLabel.src.Directory.Artist.Application.Command.UploadArtitst;
using RecordLabel.src.Directory.Artist.Domain;
using RecordLabelTests.src.Directory.Artist.Domain.Stub;
using ArtistDomain = RecordLabel.src.Directory.Artist.Domain.Artist;

namespace RecordLabelTests.src.Directory.Artist.Application.Command.UploadArtist
{
    public class UploadArtistsUseCaseTest
    {
        [Test]
        public void ItShouldCallAddFromRepository()
        {
            Mock<IArtistRepository<ArtistDomain>> artistRepositoryMock = new Mock<IArtistRepository<ArtistDomain>>();
            UploadArtistsUseCase useCase = new UploadArtistsUseCase(artistRepositoryMock.Object);

            useCase.Execute(ArtistStub.GenerateListOfArtistsWith3Artists());

            artistRepositoryMock.Verify(m => m.Add(It.IsAny<ArtistDomain>()), Times.Exactly(3));
        }

      
    }
}
