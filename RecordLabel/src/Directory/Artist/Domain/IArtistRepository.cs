
namespace RecordLabel.src.Directory.Artist.Domain
{
    public interface IArtistRepository<T>
    {
        void Add(T artist);
    }
}
