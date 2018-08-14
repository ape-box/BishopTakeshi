using BishopTakeshi.Service.Aggregates;
using BishopTakeshi.Service.Aggregates.Commands;
using BishopTakeshi.Service.Aggregates.Events;
using BishopTakeshi.Service.Appliers;
using BishopTakeshi.Service.State;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BishopTakeshi.Service
{
    public class PollsHandler :
        IReceiveCommand<CreatePoll>
    {
        private readonly IAggregatePollState pollAggregate;
        private readonly List<IApplyEvent> eventsAppliers;
        private readonly IRepository<Guid, PollState> pollRepository;

        public PollsHandler(IAggregatePollState pollAggregate, List<IApplyEvent> eventsAppliers, IRepository<Guid, PollState> pollRepository)
        {
            this.pollAggregate = pollAggregate;
            this.eventsAppliers = eventsAppliers;
            this.pollRepository = pollRepository;
        }

        public Guid Execute(CreatePoll cmd)
        {
            var events = pollAggregate.CreateNewPoll(cmd.Name);
            var state = default(PollState);
            foreach (var evt in events)
            {
                var applier = eventsAppliers.FirstOrDefault(t => t.CanApply(evt));
                if (applier != null)
                {
                    state = applier.Apply(default(PollState), evt);
                }
            }

            pollRepository.Save(state.Identity, state);

            return state.Identity;
        }
    }
}
