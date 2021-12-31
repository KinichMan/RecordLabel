using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordLabel.src.Shared.Domain.Bus.Command.Midleware
{
    public interface IMiddlewareHandler
    {
        IMiddlewareHandler SetNext(IMiddlewareHandler handler);
        void Handle(ICommand command);
    }
}
