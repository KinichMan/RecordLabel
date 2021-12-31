

using RecordLabel.src.Directory.Artist.Domain;

namespace RecordLabelTests.src.Directory.Artist.Domain.Stub
{
    public class AddressStub
    {
        public static Address FromValue(string value)
        {
            return new Address(value);
        }

        public static Address ByDefault()
        {
            return new Address("Polanco");
        }
    }
}
