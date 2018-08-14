using BishopTakeshi.Service.Aggregates.Events;
using BishopTakeshi.Service.State;
using System;
using System.Collections.Generic;

namespace BishopTakeshi.Service.Aggregates
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
