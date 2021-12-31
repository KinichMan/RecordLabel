
namespace RecordLabel.src.Directory.Artist.Infrastructure.FileReader.FileReaderResult
{
    public class ArtistsResult
    {
        public readonly string Address;
        public readonly int ContactNo;
        public readonly string Name;

        public ArtistsResult(string address, int contactNo, string name)
        {
            Address = address;
            ContactNo = contactNo;
            Name = name;
        }
    }
}
