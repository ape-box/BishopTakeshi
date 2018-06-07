using System.Collections.Generic;

namespace BishopTakeshi.Messages.V1.Events
{
    public class ValuesReceived : MessageBase
    {
        public IEnumerable<int> Values { get; set; }

        public ValuesReceived(IEnumerable<int> values)
        {
            Values = values;
        }
    }
}
