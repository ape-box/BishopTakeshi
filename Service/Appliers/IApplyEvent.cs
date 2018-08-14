using BishopTakeshi.Service.Aggregates.Events;
using BishopTakeshi.Service.State;

namespace BishopTakeshi.Service.Appliers
{
    public interface IApplyEvent
    {
        bool CanApply(IPollEvent evt);

        PollState Apply<TEvent>(PollState state, TEvent evt)
            where TEvent : IPollEvent;
    }
}