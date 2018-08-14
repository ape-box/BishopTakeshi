using System;
using System.Threading.Tasks;
using BishopTakeshi.Messages.V1.Commands;
using BishopTakeshi.Messages.V1.Events;
using MassTransit;

namespace BishopTakeshi.Service.ConsoleHost.Handlers
{
    public class ValuesHandler :
        IConsumer<FindArticleWithAllTagsMatching>,
        IConsumer<FindArticleWithSomeTagsMatching>
    {
        private readonly IConsumeMatchingCommands articlesService;

        //public ValuesHandler(FindMatchingArticleService sumService)
        //{
        //    this.articlesService = sumService ?? throw new ArgumentNullException(nameof(sumService));
        //}

        public Task Consume(ConsumeContext<FindArticleWithAllTagsMatching> context)
            => Consume(context, context.Message);

        public Task Consume(ConsumeContext<FindArticleWithSomeTagsMatching> context)
            => Consume(context, context.Message);

        private Task Consume<T>(IPublishEndpoint bus, T message)
            where  T : IMatchArticlesCommand
            => bus.Publish(
                new AriclesMatchingFound(
                    articlesService.Consume(message), message.Tags));

        //public async Task Consume(ConsumeContext<FindArticleWithAllTagsMatching> context)
        //{
        //    var t = context.Message.ConsistencyToken;
        //    Console.WriteLine($"[{t}] Received values '{string.Join(",", context.Message.Values)}'");
        //    await context.Publish(new ValuesReceived(context.Message.Values));

        //    var sum = articlesService.Consume(context.Message);
        //    Console.WriteLine($"[{t}] Values sum is '{sum}'");
        //    await context.Publish(new ValuesSummed(context.Message.Values, sum));
        //}
    }
}
