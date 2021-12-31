
namespace RecordLabel.src.Directory.Artist.Infrastructure.FileReader
{
    public interface IUploadedFile
    {
        string ContentType();
        string ContentDisposition();

        long Length();
        string Name();
        string FileName();
        void SaveAs(object p);
    }
}
