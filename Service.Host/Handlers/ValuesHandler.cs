using System;
using System.Threading.Tasks;
using BishopTakeshi.Messages.V1.Commands;
using BishopTakeshi.Messages.V1.Events;
using MassTransit;

namespace BishopTakeshi.Service.ConsoleHost.Handlers
{
    public class ValuesHandler : IConsumer<SumValues>
    {
        private readonly ValuesSumService sumService;

        public ValuesHandler(ValuesSumService sumService)
        {
            this.sumService = sumService ?? throw new ArgumentNullException(nameof(sumService));
        }

        public async Task Consume(ConsumeContext<SumValues> context)
        {
            var t = context.Message.ConsistencyToken;
            Console.WriteLine($"[{t}] Received values '{string.Join(",", context.Message.Values)}'");
            await context.Publish(new ValuesReceived(context.Message.Values));

            var sum = sumService.Consume(context.Message);
            Console.WriteLine($"[{t}] Values sum is '{sum}'");
            await context.Publish(new ValuesSummed(context.Message.Values, sum));
        }
    }
}
