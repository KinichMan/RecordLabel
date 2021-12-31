using RecordLabel.src.Shared.Domain.Bus.Command;
using RecordLabel.src.Shared.Domain.Bus.Command.Midleware;

namespace RecordLabel.src.Shared.Infrastructure.Bus.Command.Middleware
{
    public class MiddlewareHandler : IMiddlewareHandler
    {
        private IMiddlewareHandler nextHandler;

        public IMiddlewareHandler SetNext(IMiddlewareHandler handler)
        {
            nextHandler = handler;
            return handler;
        }

        public virtual void Handle(ICommand command)
        {
            nextHandler.Handle(command);
        }

    }
}
