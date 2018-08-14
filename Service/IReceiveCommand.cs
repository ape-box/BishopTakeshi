using System;
using System.Collections.Generic;
using BishopTakeshi.Service.Aggregates.Commands;
using BishopTakeshi.Service.Aggregates.Events;

namespace BishopTakeshi.Service.Aggregates
{
    public interface IReceiveCommand<in Cmd> 
        where Cmd : IPollCommand
    {
        Guid Execute(Cmd cmd);
    }
}