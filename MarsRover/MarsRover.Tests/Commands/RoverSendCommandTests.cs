using MarsRover.Abstractions;
using MarsRover.Abstractions.Commands;
using MarsRover.Commands;
using MarsRover.PlateauObjects;
using MarsRover.RoverObjects;
using Moq;
using Xunit;

namespace MarsRover.Tests.Commands
{
    public class RoverSendCommandTests
    {
        public RoverSendCommandTests()
        {
            _plateau = Mock.Of<Plateau>();
            _plateau.SetSize(new Size(5, 5));

            _rover = Mock.Of<Rover>();
        }

        private readonly IPlateau _plateau;
        private readonly IRover _rover;
        private IRoverSendCommand _roverSendCommand;

        [Fact]
        public void Rover_Send_ShouldBe_Same_As_Expected()
        {
            _roverSendCommand = new RoverSendCommand(new Location(1, 2, CardinalPoint.North));
            _roverSendCommand.Set(_plateau, _rover);
            _roverSendCommand.Execute();

            Assert.Equal(1, _rover.Location.X);
            Assert.Equal(2, _rover.Location.Y);
            Assert.Equal(CardinalPoint.North, _rover.Location.CardinalPoint);
        }
    }
}