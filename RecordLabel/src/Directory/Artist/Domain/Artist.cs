

namespace RecordLabel.src.Directory.Artist.Domain
{
    public class Artist
    {
        public Address address { get; private set;}
        public Name name { get; private set; }
        public ContactNumber contactNumber { get; private set; }

        private Artist(Address address, Name name, ContactNumber contactNumber)
        {
            this.address = address;
            this.name = name;
            this.contactNumber = contactNumber;
        }

        public static Artist CreateArtist(Address address, Name name, ContactNumber contactNumber)
        {
            return new Artist(address, name, contactNumber);
        }
    }
}
