using System;
using System.Threading.Tasks;
using BishopTakeshi.Messages.V1.Events;
using MassTransit;

namespace BishopTakeshi.Application.Handlers
{
    public class ValuesHandler : IConsumer<ValueReceived>
    {
        public Task Consume(ConsumeContext<ValueReceived> context)
        {
            Console.WriteLine($"Received value '{context.Message.Value}'");

            return Task.FromResult(0);
        }
    }
}
