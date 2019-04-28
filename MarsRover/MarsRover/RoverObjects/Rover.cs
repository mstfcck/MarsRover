using System.Collections.Generic;
using MarsRover.Abstractions;
using MarsRover.Exceptions;

namespace MarsRover.RoverObjects
{
    /// <summary>
    ///     Robotic Rover
    /// </summary>
    public class Rover : IRover
    {
        public Location Location { get; set; }

        public void Send(IPlateau plateau, Location location)
        {
            if (plateau.IsValid(location))
                Location = location;
            else
                throw new RoverLocationValidationException("Rover location is not valid!");
        }

        public void Move(IEnumerable<Move> movements)
        {
            foreach (var movement in movements) Location.Movement(movement);
        }
    }
}