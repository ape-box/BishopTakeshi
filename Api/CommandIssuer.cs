using System;
using System.Linq;
using System.Threading.Tasks;
using BishopTakeshi.Api.Controllers;
using BishopTakeshi.Messages.V1.Commands;
using MassTransit;

namespace BishopTakeshi.Api
{
    public interface ICommandIssuer
    {
        Task<Guid> IssueCommand(ValuesModel valuesModel);
    }

    public class CommandIssuer : ICommandIssuer
    {
        private readonly ISendEndpoint valuesSummerQueue;

        public CommandIssuer(ISendEndpoint sendEndpoint)
        {
            this.valuesSummerQueue = sendEndpoint ?? throw new ArgumentNullException(nameof(sendEndpoint));
        }

        public async Task<Guid> IssueCommand(ValuesModel valuesModel)
        {
            var command = new SumValues(valuesModel.ValuesToSum.Select(int.Parse));
            await valuesSummerQueue.Send(command);

            return command.ConsistencyToken;
        }
    }
}
