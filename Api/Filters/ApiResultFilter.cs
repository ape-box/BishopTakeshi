using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace BishopTakeshi.Api.Filters
{
    public class ApiResultFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            //var inputModel = JsonConvert.SerializeObject(context.ActionArguments);
            var result = await next();
            var responseBody = JsonConvert.SerializeObject((result.Result as ObjectResult)?.Value ?? string.Empty);
        }
    }
}
