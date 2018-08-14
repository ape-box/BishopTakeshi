using System;
using BishopTakeshi.Service.Commands;

namespace BishopTakeshi.Service
{
    public interface IReceiveCommand<in Cmd> 
        where Cmd : IPollCommand
    {
        Guid Execute(Cmd cmd);
    }
}