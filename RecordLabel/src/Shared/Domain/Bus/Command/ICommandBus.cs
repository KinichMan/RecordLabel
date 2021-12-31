using RecordLabel.src.Directory.Artist.Application.Command.UploadArtitst;
using RecordLabel.src.Shared.Domain.Bus.Command.Midleware;

namespace RecordLabel.src.Shared.Domain.Bus.Command
{
    public interface ICommandBus
    {
        void Subscribe(ICommandHandler<ICommand> commandHandler);

        void AddMiddleware(IMiddlewareHandler middlewareHandler);

        void Dispatch(ICommand command);
    }
}
