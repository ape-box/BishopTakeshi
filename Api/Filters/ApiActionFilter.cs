using System.Threading.Tasks;
using BishopTakeshi.Api.Loggers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BishopTakeshi.Api.Filters
{
    public class ApiActionFilter : IAsyncActionFilter
    {
        public static IApiLogger ApiLogger { get; set; }

        private static int currentActionIndex = 0;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cai = currentActionIndex++;
            await ApiLogger.BeforeAction(cai, context);

            var result = await next();

            await ApiLogger.AfterAction(cai, result);
        }
    }
}
