using RecordLabel.src.Directory.Artist.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLabelTests.src.Directory.Artist.Domain.Stub
{
    public class NameStub
    {
        public static Name FromValue(string value)
        {
            return new Name(value);
        }

        public static Name ByDefault()
        {
            return new Name("Uriel Mansilla");
        }
    }
}
