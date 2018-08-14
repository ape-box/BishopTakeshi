﻿using System;

namespace BishopTakeshi.Service.Aggregates.Events
{
    public class PollCreated : IPollEvent
    {
        public Guid PollIdentity { get; }
        public string Name { get; }

        public PollCreated(string name)
        {
            PollIdentity = Guid.NewGuid();
            Name = name;
        }
    }
}