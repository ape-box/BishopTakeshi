using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BishopTakeshi.Api.Middleware
{
    public class SomethingMiddleware
    {
        private readonly RequestDelegate next;

        public SomethingMiddleware(RequestDelegate next)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            await next.Invoke(context);
        }
    }
}
