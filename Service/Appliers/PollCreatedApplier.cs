using BishopTakeshi.Service.Aggregates.Events;
using BishopTakeshi.Service.State;

namespace BishopTakeshi.Service.Appliers
{
    public class PollCreatedApplier : IApplyEvent
    {
        public bool CanApply(IPollEvent evt) 
            => evt is PollCreated;

        public PollState Apply<TEvent>(PollState state, TEvent evt) where TEvent : IPollEvent
            => evt is PollCreated ? Apply(state, evt as PollCreated) : state;

        public PollState Apply(PollState state, PollCreated evt)
        {
            state.Identity = evt.PollIdentity;
            state.Name = evt.Name;

            return state;
        }
    }
}
