using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BishopTakeshi.Api.Loggers
{
    public interface IApiLogger
    {
        Task Message(string template);
        Task Verbose(string template);

        Task BeforeAction(int currentActionIndex, ActionExecutingContext context);
        Task AfterAction(int currentActionIndex, ActionExecutedContext context);
    }
}
