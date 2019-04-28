using MarsRover.Abstractions;
using MarsRover.Exceptions;
using MarsRover.PlateauObjects;
using MarsRover.RoverObjects;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverTests
    {
        public RoverTests()
        {
            _plateau = Mock.Of<Plateau>();
            _plateau.SetSize(new Size(5, 5));
            _rover = Mock.Of<Rover>();
        }

        private readonly IPlateau _plateau;
        private readonly IRover _rover;

        [Fact]
        public void Rover_Location_Send_Throws_RoverLocationValidationException()
        {
            Assert.Throws<RoverLocationValidationException>(() =>
                _rover.Send(_plateau, new Location(6, 6, CardinalPoint.North)));
        }

        [Fact]
        public void Rover_Location_Send_ShouldBe_Same_As_Expected()
        {
            _rover.Send(_plateau, new Location(1, 2, CardinalPoint.North));
            var roverLocation = _rover.Location;
            Assert.Equal(1, roverLocation.X);
            Assert.Equal(2, roverLocation.Y);
            Assert.Equal(CardinalPoint.North, roverLocation.CardinalPoint);
        }

        [Fact]
        public void Rover_Movement_ShouldBe_Same_As_Expected()
        {
            _rover.Send(_plateau, new Location(1, 2, CardinalPoint.North));

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

            _rover.Move(movements);

            var roverLocation = _rover.Location;
            Assert.Equal(1, roverLocation.X);
            Assert.Equal(3, roverLocation.Y);
            Assert.Equal(CardinalPoint.North, roverLocation.CardinalPoint);
        }
    }
}