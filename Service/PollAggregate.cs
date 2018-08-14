using System;
using System.Collections.Generic;
using BishopTakeshi.Service.Events;
using BishopTakeshi.Service.State;

namespace BishopTakeshi.Service
{
    public class PollAggregate : IAggregatePollState
    {
        public IEnumerable<IPollEvent> CreateNewPoll(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            yield return new PollCreated(name);
        }
    }
}
