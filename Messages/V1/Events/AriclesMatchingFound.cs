using System.Collections.Generic;

namespace BishopTakeshi.Messages.V1.Events
{
    public class AriclesMatchingFound : MessageBase
    {
        public IEnumerable<string> Articles { get; set; }
        public IEnumerable<string> Tags { get; set; }

        public AriclesMatchingFound(IEnumerable<string> articles, IEnumerable<string> tags)
        {
            Articles = articles;
            Tags = tags;
        }
    }
}
