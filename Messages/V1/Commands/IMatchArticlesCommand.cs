using System.Collections.Generic;

namespace BishopTakeshi.Messages.V1.Commands
{
    public interface IMatchArticlesCommand
    {
        IEnumerable<(string id, string[] tags)> Articles { get; set; }

        IEnumerable<string> Tags { get; set; }
    }
}
