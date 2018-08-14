using System;
using System.Collections.Generic;
using BishopTakeshi.Service.State;

namespace BishopTakeshi.Service.Repositories
{
    public class PollInMemoryRepository : IRepository<Guid, PollState>
    {
        private Dictionary<Guid, PollState> storage = new Dictionary<Guid, PollState>();

        public bool Save(Guid identity, PollState resource)
        {
            if (storage.ContainsKey(identity))
            {
                storage[identity] = resource;
            }
            else
            {
                storage.Add(identity, resource);
            }

            return true;
        }

        public bool TryLoad(Guid identity, out PollState resource)
        {
            if (storage.ContainsKey(identity))
            {
                resource = storage[identity];
                return true;
            }

            resource = default(PollState);
            return false;
        }
    }
}