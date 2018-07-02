using System;
using System.Threading.Tasks;
using BishopTakeshi.Api.Controllers;
using BishopTakeshi.Messages.V1;
using BishopTakeshi.Messages.V1.Commands;
using MassTransit;

namespace BishopTakeshi.Api.ServicePlugs
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
            MessageBase command;
            switch (valuesModel.Operation)
            {
                case ServiceOperation.FindArticleWithAllTagsMatching:
                    command = new FindArticleWithAllTagsMatching(valuesModel.Articles, valuesModel.Tags);
                    break;
                case ServiceOperation.FindArticleWithSomeTagsMatching:
                    command = new FindArticleWithSomeTagsMatching(valuesModel.Articles, valuesModel.Tags);
                    break;
                default:
                    throw new InvalidServiceOperation();
            }
            await valuesSummerQueue.Send(command);

            return command.ConsistencyToken;
        }
    }
}
