using NUnit.Framework;
using RecordLabel.src.Directory.Artist.Domain;
using RecordLabel.src.Shared.Domain.Exception;
using RecordLabelTests.src.Directory.Artist.Domain.Stub;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLabelTests.src.Directory.Artist.Domain
{
    public class AddressTest
    {
        [Test]
        public void ItShouldThrowInvalidAttributeExceptionIfAddressIsEmpty()
        {
            Assert.Throws<InvalidAttributeException>(() =>  new Address(""));
        }

        [Test]
        public void ItShouldThrowInvalidAttributeExceptionIfAddressHasInvalidLength()
        {
            string invalidLenght = "01234567890123456";
            Assert.Throws<InvalidAttributeException>(() => AddressStub.FromValue(invalidLenght));
        }
    }
}
