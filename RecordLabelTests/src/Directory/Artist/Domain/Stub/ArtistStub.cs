using System.Collections.Generic;
using ArtistDomain = RecordLabel.src.Directory.Artist.Domain.Artist;

namespace RecordLabelTests.src.Directory.Artist.Domain.Stub
{
    public class ArtistStub
    {
        public static ArtistDomain ByDefault()
        {
            return ArtistDomain.CreateArtist(
                AddressStub.ByDefault(), 
                NameStub.ByDefault(), 
                ContactNumberStub.ByDefault());
        }

        public static ArtistDomain FromValues(
            string address = "",
            string name = "",
            int contactnumber = 0
            )
        {
            return ArtistDomain.CreateArtist(
               string.IsNullOrEmpty(address) ? AddressStub.ByDefault() : AddressStub.FromValue(address),
               string.IsNullOrEmpty(name) ? NameStub.ByDefault() : NameStub.FromValue(name),
               contactnumber.Equals(0) ? ContactNumberStub.ByDefault() : ContactNumberStub.FromValue(contactnumber)
                );
        }

        public static List<ArtistDomain> GenerateListOfArtistsWith3Artists()
        {
            List<ArtistDomain> listArtist = new List<ArtistDomain>();
            listArtist.Add(ArtistStub.ByDefault());
            listArtist.Add(ArtistStub.ByDefault());
            listArtist.Add(ArtistStub.ByDefault());
            return listArtist;
        }
    }
}
