using System.Linq;
using BishopTakeshi.Messages.V1.Commands;

namespace BishopTakeshi.Service
{
    public class ValuesSumService
    {
        public int Consume(SumValues message)
            => message.Values.Aggregate((a, b) => a + b);
    }
}
