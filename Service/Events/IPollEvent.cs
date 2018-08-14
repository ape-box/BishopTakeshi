using System;

namespace BishopTakeshi.Service.Events
{
    public interface IPollEvent
    {
        Guid PollIdentity { get; }
    }
}