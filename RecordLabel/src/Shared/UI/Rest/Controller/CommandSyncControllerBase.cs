using Microsoft.AspNetCore.Mvc;
using RecordLabel.src.Shared.Domain.Bus.Command;
using System;

namespace RecordLabel.src.Shared.UI.Rest.Controller
{
    public class CommandSyncControllerBase : ControllerBase
    {
        private ICommandBus commandBus;

        public CommandSyncControllerBase(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }

        protected IActionResult Dispatch(ICommand command)
        {
            try
            {
                commandBus.Dispatch(command);
                return StatusCode(200);
            }
            catch (System.Exception Exception)
            {
                Console.Write(Exception.Message);
                return StatusCode(500);
            }
        }
    }
}
