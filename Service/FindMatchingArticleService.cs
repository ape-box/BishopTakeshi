using System;
using System.Collections.Generic;
using System.Linq;
using BishopTakeshi.Messages.V1.Commands;

namespace BishopTakeshi.Service
{
    public class FindMatchingArticleService : IConsumeMatchingCommands
    {
        public IEnumerable<string> Consume(FindArticleWithAllTagsMatching message)
            => message.Articles.Select(a => a.id);

        public IEnumerable<string> Consume(FindArticleWithSomeTagsMatching message)
            => message.Articles.Select(a => a.id);

        public IEnumerable<string> Consume(IMatchArticlesCommand message)
        {
            throw new Exception();
        }
    }
}
