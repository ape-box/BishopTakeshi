using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BishopTakeshi.Api.ServicePlugs;

namespace BishopTakeshi.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ICommandIssuer cmdIssuer;

        public ValuesController(ICommandIssuer sendEndpoint)
        {
            this.cmdIssuer = sendEndpoint ?? throw new ArgumentNullException(nameof(sendEndpoint));
        }

        [HttpPost]
        public Task Post([FromBody]ValuesModel valuesModel)
            => cmdIssuer.IssueCommand(valuesModel);
    }
}
