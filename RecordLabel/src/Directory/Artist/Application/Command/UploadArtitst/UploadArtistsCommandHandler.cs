
using RecordLabel.src.Directory.Artist.Domain;
using RecordLabel.src.Directory.Artist.Infrastructure.FileReader;
using RecordLabel.src.Directory.Artist.Infrastructure.FileReader.Service;
using RecordLabel.src.Shared.Application.Service;
using RecordLabel.src.Shared.Domain.Bus.Command;
using System.Collections.Generic;
using ArtistDomain = RecordLabel.src.Directory.Artist.Domain.Artist;

namespace RecordLabel.src.Directory.Artist.Application.Command.UploadArtitst
{
    public class UploadArtistsCommandHandler : ICommandHandler<UploadArtistsCommand>
    {
        public readonly ISpecificationPattern<IUploadedFile> fileProperties;
        public readonly ExcellFileManagementFactory fileReaderFactory;
        public readonly UploadArtistsUseCase useCase;


        public UploadArtistsCommandHandler(
            ISpecificationPattern<IUploadedFile> fileProperties, 
            ExcellFileManagementFactory fileReaderFactory, 
            UploadArtistsUseCase useCase)
        {
            this.fileProperties = fileProperties;
            this.fileReaderFactory = fileReaderFactory;
            this.useCase = useCase;
        }

        public void Handle(UploadArtistsCommand command)
        {
            fileProperties.IsSatisfiedBy(command.FileUpload);
            IFilesManagement<ArtistDomain> fileManagement = fileReaderFactory.Create(command.FileUpload);
            fileManagement.SaveFile();
            List<ArtistDomain> artists = fileManagement.ReadFile();
            useCase.Execute(artists);
        }
    }
}
