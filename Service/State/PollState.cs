using System;
using System.Collections.Generic;

namespace BishopTakeshi.Service.State
{
    public struct PollState
    {
        public Guid Identity { get; set; }
        public string Name { get; set; }
        public IReadOnlyDictionary<Guid, string> PollOptions { get; set; }
    }
}
