
using Moq;
using NUnit.Framework;
using RecordLabel.src.Directory.Artist.Infrastructure.FileReader;
using RecordLabel.src.Directory.Artist.Infrastructure.FileReader.Service;
using RecordLabel.src.Shared.Domain.Exception;

namespace RecordLabelTests.src.Directory.Artist.Infrastructure.FileReader.Service
{
    public class ExcellFileManagementFactoryTest
    {
        [Test]
        public void ItShouldTrowInvalidFileExceptionFromInvalidExtension()
        {
            Mock<IUploadedFile> uploadedFileMock = new Mock<IUploadedFile>();
            ConvertCellsToListOfArtist converter = new ConvertCellsToListOfArtist();
            uploadedFileMock.Setup(m => m.FileName()).Returns("myFile.txt");
            ExcellFileManagementFactory factory = new ExcellFileManagementFactory(converter);

            Assert.Throws<InvalidFileException>(() => factory.Create(uploadedFileMock.Object));
        }
    }
}
