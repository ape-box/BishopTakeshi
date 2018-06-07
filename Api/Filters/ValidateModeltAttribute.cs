using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BishopTakeshi.Api.Filters
{
    public class ValidateModeltAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid) return;

            context.Result = new BadRequestObjectResult(context.ModelState);
            //context.Result = new ValidationFailedResult(context.ModelState);
            //throw new Exception("WIP");
        }
    }
}
