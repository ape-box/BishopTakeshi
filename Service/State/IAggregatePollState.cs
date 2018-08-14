using BishopTakeshi.Service.Aggregates.Events;
using System.Collections.Generic;

namespace BishopTakeshi.Service.State
{
    public interface IAggregatePollState
    {
        IEnumerable<IPollEvent> CreateNewPoll(string name);
    }
}
