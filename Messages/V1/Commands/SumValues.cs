using System.Collections.Generic;

namespace BishopTakeshi.Messages.V1.Commands
{
    public class SumValues : MessageBase
    {
        public IEnumerable<int> Values { get; set; }

        public SumValues(IEnumerable<int> values)
        {
            Values = values;
        }
    }
}
