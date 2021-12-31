
using RecordLabel.src.Directory.Artist.Domain;
using RecordLabel.src.Directory.Artist.Infrastructure.FileReader.FileReaderResult;
using RecordLabel.src.Directory.Artist.Infrastructure.FileReader.Service;
using System.Collections.Generic;
using ArtistDomain = RecordLabel.src.Directory.Artist.Domain.Artist;

namespace RecordLabel.src.Directory.Artist.Infrastructure.FileReader
{
    public class ExcellFilesManagement : IFilesManagement<ArtistDomain>
    {
        public readonly IUploadedFile fileUpload;
        public readonly ConvertCellsToListOfArtist convertCellsToListOfArtist;
        public readonly string connection;
        public readonly string pathToExcelFile;
        private const string sheetName = "Sheet1";


        public ExcellFilesManagement(IUploadedFile fileUpload, ConvertCellsToListOfArtist convertCellsToListOfArtist, string connection, string pathToExcelFile)
        {
            this.fileUpload = fileUpload;
            this.convertCellsToListOfArtist = convertCellsToListOfArtist;
            this.connection = connection;
            this.pathToExcelFile = pathToExcelFile;
        }

        public void SaveFile()
        {
            this.fileUpload.SaveAs(pathToExcelFile);
        }

        public List<ArtistDomain> ReadFile()
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "ExcelTable");
            DataTable dtable = ds.Tables["ExcelTable"];
            ExcelQueryFactor excelFile = new ExcelQueryFactory(pathToExcelFile);
            List<ArtistsResult> artistResult = from a in excelFile.Worksheet<ArtistDomain>(sheetName) select a;

            return convertCellsToListOfArtist.Convert(artistResult);
        }

        
    }
}
