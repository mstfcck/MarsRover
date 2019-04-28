using System.Collections.Generic;
using MarsRover.Abstractions;
using MarsRover.Abstractions.Commands;
using MarsRover.RoverObjects;

namespace MarsRover.Commands
{
    public class RoverMoveCommand : IRoverMoveCommand
    {
        private IRover _rover;

        public RoverMoveCommand(IList<Move> movements)
        {
            Movements = movements;
        }

        public IList<Move> Movements { get; set; }

        public void Set(IRover rover)
        {
            _rover = rover;
        }

        public void Execute()
        {
            _rover.Move(Movements);
        }
    }
}