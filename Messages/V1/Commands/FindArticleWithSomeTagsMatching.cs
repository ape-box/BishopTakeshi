﻿using System.Collections.Generic;

namespace BishopTakeshi.Messages.V1.Commands
{
    public class FindArticleWithSomeTagsMatching : MessageBase, IMatchArticlesCommand
    {
        public IEnumerable<(string id, string[] tags)> Articles { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public FindArticleWithSomeTagsMatching(IEnumerable<(string id, string[] tags)> articles, IEnumerable<string> tags)
        {
            Articles = articles;
            Tags = tags;
        }
    }
}
