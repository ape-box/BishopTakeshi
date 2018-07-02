using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace BishopTakeshi.Api.Loggers
{
    public sealed class ApiLogger : IApiLogger
    {
        private readonly bool verbose;

        public ApiLogger(bool verbose = true)
        {
            this.verbose = verbose;
        }

        private void Write(string template)
            => Console.WriteLine($"[{DateTime.UtcNow}] "+template);

        public Task Message(string template)
        {
            var fg = Console.ForegroundColor;
            var bg = Console.BackgroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            Write(template);

            Console.ForegroundColor = fg;
            Console.BackgroundColor = bg;

            return Task.CompletedTask;
        }

        public Task Verbose(string template)
        {
            if (verbose)
            {
                var fg = Console.ForegroundColor;
                var bg = Console.BackgroundColor;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.DarkBlue;

                Write(template);

                Console.ForegroundColor = fg;
                Console.BackgroundColor = bg;
            }

            return Task.CompletedTask;
        }

        public async Task BeforeAction(int currentActionIndex, ActionExecutingContext context)
        {
            var fqnDescriptor = context.ActionDescriptor.DisplayName;
            var controllerName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ControllerName;
            var actionName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ActionName;
            var modelStateIsValid = context.ModelState.IsValid;
            var actionArguments = JsonConvert.SerializeObject(context.ActionArguments);

            await Message($"({currentActionIndex}) About to action {controllerName}/{actionName} with {modelStateIsValid} ModelState");
            await Verbose($"({currentActionIndex}) Action FQN '{fqnDescriptor}' with arguments '{actionArguments}'");
        }

        public async Task AfterAction(int currentActionIndex, ActionExecutedContext context)
        {
            var objResult = context.Result as ObjectResult;
            var statusCode = objResult?.StatusCode;
            var responseBody = JsonConvert.SerializeObject(objResult?.Value ?? string.Empty);

            await Message($"({currentActionIndex}) Action resulted in status {statusCode}");
            await Verbose($"({currentActionIndex}) Action result valued in '{responseBody}'");
        }
    }
}