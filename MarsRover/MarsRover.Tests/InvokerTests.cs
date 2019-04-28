using MarsRover.Abstractions;
using MarsRover.Abstractions.Commands;
using MarsRover.Commands;
using MarsRover.PlateauObjects;
using MarsRover.RoverObjects;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace MarsRover.Tests
{
    public class InvokerTests
    {
        public InvokerTests()
        {
            _invoker = Mock.Of<Invoker>();
            _plateau = Mock.Of<Plateau>();
            _rovers = Mock.Of<List<IRover>>();
            _commands = Mock.Of<List<ICommand>>();
        }

        private readonly IInvoker _invoker;
        private readonly IPlateau _plateau;
        private readonly IList<IRover> _rovers;
        private readonly IList<ICommand> _commands;

        [Fact]
        public void Invoker_Commands_ShouldBe_As_Expected()
        {
            _invoker.InitializePlateau(_plateau);
            _invoker.InitializeRovers(_rovers);

            var plateauSizeCommand = new PlateauSizeCommand(new Size(5, 5));
            var roverSendCommand = new RoverSendCommand(new Location(1, 2, CardinalPoint.North));
            var roverMoveCommand = new RoverMoveCommand(new List<Move> { Move.Forward });

            _commands.Add(plateauSizeCommand);
            _commands.Add(roverSendCommand);
            _commands.Add(roverMoveCommand);

            _invoker.SetCommands(_commands);
            _invoker.InvokeCommands();

            var latestRoverLocations = _invoker.GetLatestRoverLocations();

            Assert.Contains(latestRoverLocations, s => s == "1, 3, N");
        }
    }
}