using RecordLabel.src.Directory.Artist.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLabelTests.src.Directory.Artist.Domain.Stub
{
    public class ContactNumberStub
    {
        public static ContactNumber FromValue(Int64 value)
        {
            return new ContactNumber(value);
        }

        public static ContactNumber ByDefault()
        {
            return new ContactNumber(12345678);
        }
    }
}
