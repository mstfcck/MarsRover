using System.Collections.Generic;
using MarsRover.RoverObjects;

namespace MarsRover.Abstractions.Commands
{
    public interface IRoverMoveCommand : ICommand
    {
        IList<Move> Movements { get; set; }
        void Set(IRover rover);
    }
}