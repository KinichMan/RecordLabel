using NUnit.Framework;
using RecordLabel.src.Directory.Artist.Domain;
using RecordLabel.src.Shared.Domain.Exception;
using RecordLabelTests.src.Directory.Artist.Domain.Stub;
using System;

namespace RecordLabelTests.src.Directory.Artist.Domain
{
    public class ContactNumberTest
    {

        [TestCase(-1)]
        [TestCase(12345)]
        [TestCase(12345678901)]
        public void ItShouldThrowInvalidAttributeExceptionByNegativeAndInvalidLengthValues(Int64 value)
        {
            Assert.Throws<InvalidAttributeException>(() => ContactNumberStub.FromValue(value));
        }
    }
}
