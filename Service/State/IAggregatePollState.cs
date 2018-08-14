using System.Collections.Generic;
using BishopTakeshi.Service.Events;

namespace BishopTakeshi.Service.State
{
    public interface IAggregatePollState
    {
        IEnumerable<IPollEvent> CreateNewPoll(string name);
    }
}
