using RecordLabel.src.Directory.Artist.Infrastructure.FileReader;
using RecordLabel.src.Shared.Application.Service;
using RecordLabel.src.Shared.Domain.Exception;

namespace RecordLabel.src.Directory.Artist.Application.Service
{
    public class AllowedFilePropertiesSpecification : ISpecificationPattern<IUploadedFile>
    {
        public bool IsSatisfiedBy(IUploadedFile file)
        {
            if (file == null)
            {
                throw InvalidFileException.FromEmpty();
            }

            if (file.ContentType() != "application/vnd.ms-excel" && file.ContentType() != "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                throw InvalidFileException.FromFormat();
            }

            return true;
        }
    }
}
