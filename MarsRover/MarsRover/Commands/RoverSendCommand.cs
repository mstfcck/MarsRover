using MarsRover.Abstractions;
using MarsRover.Abstractions.Commands;
using MarsRover.RoverObjects;

namespace MarsRover.Commands
{
    public class RoverSendCommand : IRoverSendCommand
    {
        private readonly Location _location;
        private IPlateau _plateau;
        private IRover _rover;

        public RoverSendCommand(Location location)
        {
            _location = location;
        }

        public void Set(IPlateau plateau, IRover rover)
        {
            _plateau = plateau;
            _rover = rover;
        }

        public void Execute()
        {
            _rover.Send(_plateau, _location);
        }
    }
}