using System.Collections.Generic;

namespace RecordLabel.src.Directory.Artist.Domain
{
    public interface IFilesManagement<T>
    {
        void SaveFile();
        List<T> ReadFile();
    }
}
