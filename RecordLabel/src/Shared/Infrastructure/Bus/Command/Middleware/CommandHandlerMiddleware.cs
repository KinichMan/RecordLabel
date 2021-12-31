using RecordLabel.src.Shared.Domain.Bus.Command;

namespace RecordLabel.src.Shared.Infrastructure.Bus.Command.Middleware
{
    public class CommandHandlerMiddleware : MiddlewareHandler
    {
        private readonly ICommandHandler<ICommand> commandHandler;

        public CommandHandlerMiddleware(ICommandHandler<ICommand> commandHandler)
        {
            this.commandHandler = commandHandler;
        }

        public override void Handle(ICommand command)
        {
            commandHandler.Handle(command);
        }
    }
}
