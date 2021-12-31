using RecordLabel.src.Directory.Artist.Domain;
using RecordLabel.src.Shared.Domain.Exception;
using ArtistDomain = RecordLabel.src.Directory.Artist.Domain.Artist;

namespace RecordLabel.src.Directory.Artist.Infrastructure.FileReader.Service
{
    public class ExcellFileManagementFactory
    {
        public readonly ConvertCellsToListOfArtist convertCellsToListOfArtist;
        public const string targetpath = "home/users/cust/";
        public ExcellFileManagementFactory(ConvertCellsToListOfArtist convertCellsToListOfArtist)
        {
            this.convertCellsToListOfArtist = convertCellsToListOfArtist;
        }

        public IFilesManagement<ArtistDomain> Create(IUploadedFile fileUpload)
        {
            string filename = fileUpload.FileName();
            if (!filename.EndsWith(".xlsx") && !filename.EndsWith(".xls"))
            {
                throw InvalidFileException.FromFormat();
            }
            string pathToExcelFile = targetpath + filename;
            string connectionString = "";
            if (filename.EndsWith(".xls"))
            {
                connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", pathToExcelFile);
            }
            if (filename.EndsWith(".xlsx"))
            {
                connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", pathToExcelFile);
                
            }
            return new ExcellFilesManagement(fileUpload, convertCellsToListOfArtist, connectionString, pathToExcelFile);
        }
    }
}
