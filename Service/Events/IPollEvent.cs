using System;

namespace BishopTakeshi.Service.Aggregates.Events
{
    public interface IPollEvent
    {
        Guid PollIdentity { get; }
    }
}