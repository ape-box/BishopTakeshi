using System.Collections.Generic;

namespace BishopTakeshi.Messages.V1.Events
{
    public class ValuesSummed : MessageBase
    {
        public IEnumerable<int> Values { get; set; }
        public int Sum { get; set; }

        public ValuesSummed(IEnumerable<int> values, int sum)
        {
            Values = values;
            Sum = sum;
        }
    }
}
