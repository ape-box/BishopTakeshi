using System.Collections.Generic;

namespace BishopTakeshi.Messages.V1.Commands
{
    public interface IConsumeMatchingCommands
    {
        IEnumerable<string> Consume(IMatchArticlesCommand message);
    }
}
