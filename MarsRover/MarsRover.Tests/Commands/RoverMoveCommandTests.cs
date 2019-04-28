using MarsRover.Abstractions;
using MarsRover.Abstractions.Commands;
using MarsRover.Commands;
using MarsRover.PlateauObjects;
using MarsRover.RoverObjects;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace MarsRover.Tests.Commands
{
    public class RoverMoveCommandTests
    {
        public RoverMoveCommandTests()
        {
            _plateau = Mock.Of<Plateau>();
            _plateau.SetSize(new Size(5, 5));

            _rover = Mock.Of<Rover>();
        }

        private readonly IPlateau _plateau;
        private readonly IRover _rover;
        private IRoverMoveCommand _roverMoveCommand;

        [Fact]
        public void Rover_Movement_ShouldBe_As_Expected()
        {
            var movements = new List<Move>
            {
                Move.Left,
                Move.Forward,
                Move.Left,
                Move.Forward,
                Move.Left,
                Move.Forward,
                Move.Left,
                Move.Forward,
                Move.Forward
            };

            _roverMoveCommand = new RoverMoveCommand(movements);

            _rover.Send(_plateau, new Location(1, 2, CardinalPoint.North));
            _roverMoveCommand.Set(_rover);
            _roverMoveCommand.Execute();

            Assert.Equal(1, _rover.Location.X);
            Assert.Equal(3, _rover.Location.Y);
            Assert.Equal(CardinalPoint.North, _rover.Location.CardinalPoint);
        }
    }
}