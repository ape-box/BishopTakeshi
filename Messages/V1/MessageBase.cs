using System;

namespace BishopTakeshi.Messages.V1
{
    public abstract class MessageBase
    {
        public Guid ConsistencyToken { get; } = Guid.NewGuid();
    }
}
