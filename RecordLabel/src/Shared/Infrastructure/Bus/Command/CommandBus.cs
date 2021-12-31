using RecordLabel.src.Shared.Domain.Bus.Command;
using RecordLabel.src.Shared.Domain.Bus.Command.Midleware;
using RecordLabel.src.Shared.Infrastructure.Bus.Command.Middleware;
using RecordLabel.src.Shared.Infrastructure.Bus.Helper;
using System.Collections.Generic;

namespace RecordLabel.src.Shared.Infrastructure.Bus.Command
{
    public class CommandBus : ICommandBus
    {
        private Dictionary<string, ICommandHandler<ICommand>> commandHandlers;
        private List<IMiddlewareHandler> middlewareHandlers;

        public CommandBus()
        {
            this.commandHandlers = new Dictionary<string, ICommandHandler<ICommand>>();
            this.middlewareHandlers = new List<IMiddlewareHandler>();
        }

        public void Subscribe(ICommandHandler<ICommand> commandHandler)
        {
            string commandHandlerFullName = ObjectProperties.GetObjectFullName(commandHandler);
            commandHandlers.Add(commandHandlerFullName, commandHandler);
        }


        public void AddMiddleware(IMiddlewareHandler middlewareHandler)
        {
            middlewareHandlers.Add(middlewareHandler);
        }


        public void Dispatch(ICommand command)
        {
            string requestNamespace = ObjectProperties.GetObjectNamespace(command);
            string requestName = ObjectProperties.GetObjectName(command);
            string commandHandlerName = requestName.Replace("Command", "CommandHandler");
            string commandHandlerFullName = requestNamespace + "." + commandHandlerName;

            ICommandHandler<ICommand> commandHandler = commandHandlers[commandHandlerFullName];

            IMiddlewareHandler middlewareHandler = new CommandHandlerMiddleware(commandHandler);
            middlewareHandler = loadHandlers(middlewareHandler);
            middlewareHandler.Handle(command);
        }

        private IMiddlewareHandler loadHandlers(IMiddlewareHandler middlewareHandler)
        {
            foreach (IMiddlewareHandler handler in middlewareHandlers)
            {
                handler.SetNext(middlewareHandler);
                middlewareHandler = handler;
            }

            return middlewareHandler;
        }
  

    }
}
