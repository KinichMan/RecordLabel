using NUnit.Framework;
using RecordLabel.src.Directory.Artist.Domain;
using RecordLabel.src.Shared.Domain.Exception;
using RecordLabelTests.src.Directory.Artist.Domain.Stub;

namespace RecordLabelTests.src.Directory.Artist.Domain
{
    public class NameTest
    {
        [Test]
        public void ItShouldThrowInvalidAttributeExceptionIIsEmpty()
        {
            Assert.Throws<InvalidAttributeException>(() => new Name(""));
        }

        [Test]
        public void ItShouldThrowInvalidAttributeExceptionIfNameHasInvalidLength()
        {
            string invalidLenght = "Uriel Mansilla Barrera Ultra";
            Assert.Throws<InvalidAttributeException>(() => NameStub.FromValue(invalidLenght));
        }
    }
}
