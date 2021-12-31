using Moq;
using NUnit.Framework;
using RecordLabel.src.Directory.Artist.Application.Service;
using RecordLabel.src.Directory.Artist.Infrastructure.FileReader;
using RecordLabel.src.Shared.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLabelTests.src.Directory.Artist.Application.Service
{
    public class AllowedFilePropertiesSpecificationTest
    {
        [Test]
        public void ItShouldThrowInvalidFileExceptionFromEmptyFile()
        {
            Mock<IUploadedFile> uploadedFileMock = new Mock<IUploadedFile>();
            AllowedFilePropertiesSpecification allowedFilePropertiesSpecification = new AllowedFilePropertiesSpecification();
            
            Assert.Throws<InvalidFileException>(() => allowedFilePropertiesSpecification.IsSatisfiedBy(null));
        }

        [Test]
        public void ItShouldThrowInvalidFileExceptionFromInvalidFormat()
        {
            Mock<IUploadedFile> uploadedFileMock = new Mock<IUploadedFile>();
            AllowedFilePropertiesSpecification allowedFilePropertiesSpecification = new AllowedFilePropertiesSpecification();
            uploadedFileMock.Setup(m => m.ContentType()).Returns("application/json");
            
            Assert.Throws<InvalidFileException>(() => allowedFilePropertiesSpecification.IsSatisfiedBy(uploadedFileMock.Object));
        }

        [TestCase("application/vnd.ms-excel")]
        [TestCase("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")]
        public void ItShouldReturnTrueByAllowedFileProperties(string validContentType)
        {
            Mock<IUploadedFile> uploadedFileMock = new Mock<IUploadedFile>();
            AllowedFilePropertiesSpecification allowedFilePropertiesSpecification = new AllowedFilePropertiesSpecification();
            uploadedFileMock.Setup(m => m.ContentType()).Returns(validContentType);

            bool actual = allowedFilePropertiesSpecification.IsSatisfiedBy(uploadedFileMock.Object);

            Assert.IsTrue(actual);
        }
    }
}
