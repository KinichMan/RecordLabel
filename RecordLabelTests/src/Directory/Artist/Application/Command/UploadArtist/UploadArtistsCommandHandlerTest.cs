using Moq;
using NUnit.Framework;
using RecordLabel.src.Directory.Artist.Application.Command.UploadArtitst;
using RecordLabel.src.Directory.Artist.Domain;
using RecordLabel.src.Directory.Artist.Infrastructure.FileReader;
using RecordLabel.src.Directory.Artist.Infrastructure.FileReader.Service;
using RecordLabel.src.Shared.Application.Service;
using RecordLabelTests.src.Directory.Artist.Domain.Stub;
using ArtistDomain = RecordLabel.src.Directory.Artist.Domain.Artist;

namespace RecordLabelTests.src.Directory.Artist.Application.Command.UploadArtist
{
    public class UploadArtistsCommandHandlerTest
    {
        [Test]
        public void ItShouldCallColaboratorsAtLeastoneTime()
        {
            Mock<ISpecificationPattern<IUploadedFile>> specificationMock = new Mock<ISpecificationPattern<IUploadedFile>>();
            Mock<ExcellFileManagementFactory> fileManagementFactoryMock = new Mock<ExcellFileManagementFactory>();
            Mock<IArtistRepository<ArtistDomain>> artistRepositoryMock = new Mock<IArtistRepository<ArtistDomain>>();
            UploadArtistsUseCase useCase = new UploadArtistsUseCase(artistRepositoryMock.Object);
            Mock<IUploadedFile> formFile = new Mock<IUploadedFile>();
            UploadArtistsCommandHandler uploadArtistsCommandHandler =
                new UploadArtistsCommandHandler(specificationMock.Object, fileManagementFactoryMock.Object, useCase);
            UploadArtistsCommand uploadArtistsCommand = new UploadArtistsCommand(formFile.Object);
            specificationMock.Setup(m => m.IsSatisfiedBy(It.IsAny<IUploadedFile>())).Returns(true);
            fileManagementFactoryMock.Setup(m => m.Create(It.IsAny<IUploadedFile>())).Returns(It.IsAny<IFilesManagement<ArtistDomain>>());

            uploadArtistsCommandHandler.Handle(uploadArtistsCommand);

            specificationMock.Verify(m => m.IsSatisfiedBy(formFile.Object), Times.Once);
        }


    }
}
