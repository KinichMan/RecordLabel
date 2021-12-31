using Microsoft.AspNetCore.Mvc;
using RecordLabel.src.Directory.Artist.Application.Command.UploadArtitst;
using RecordLabel.src.Directory.Artist.Infrastructure.FileReader;
using RecordLabel.src.Shared.Domain.Bus.Command;
using RecordLabel.src.Shared.UI.Rest.Controller;
namespace RecordLabel.src.Directory.Artist.UI
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/artists/upload")]
    [ApiController]
    [ControllerName("UploadArtistsByExcel")]
    public class UploadArtistsByExcel : CommandSyncControllerBase
    {
     
        public UploadArtistsByExcel(ICommandBus commandBus) : base(commandBus)
        {
        }

        [HttpPost()]
        public IActionResult UploadArtists(IUploadedFile FileUpload) {
            return Dispatch(new UploadArtistsCommand(FileUpload));
        }
    }
}
