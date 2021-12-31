using RecordLabel.src.Directory.Artist.Infrastructure.FileReader;
using RecordLabel.src.Shared.Domain.Bus.Command;

namespace RecordLabel.src.Directory.Artist.Application.Command.UploadArtitst
{
    public class UploadArtistsCommand : ICommand
    {
        public readonly IUploadedFile FileUpload;

        public UploadArtistsCommand(IUploadedFile fileUpload)
        {
            FileUpload = fileUpload;
        }
    }
}
