using System.Collections.Generic;
using MarsRover.RoverObjects;

namespace MarsRover.Abstractions
{
    public interface IRover
    {
        Location Location { get; set; }
        void Send(IPlateau plateau, Location location);
        void Move(IEnumerable<Move> movements);
    }
}