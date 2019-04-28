using MarsRover.Abstractions;
using MarsRover.Abstractions.Commands;
using MarsRover.Commands;
using MarsRover.Exceptions;
using MarsRover.PlateauObjects;
using MarsRover.RoverObjects;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace MarsRover.Tests
{
    public class CommandGeneratorTests
    {
        public CommandGeneratorTests()
        {
            _funcPlateauSizeCommand = Mock.Of<Func<Size, IPlateauSizeCommand>>();
            _funcRoverSendCommand = Mock.Of<Func<Location, IRoverSendCommand>>();
            _funcRoverMoveCommand = Mock.Of<Func<IList<Move>, IRoverMoveCommand>>();
        }

        private readonly Func<Size, IPlateauSizeCommand> _funcPlateauSizeCommand;
        private readonly Func<Location, IRoverSendCommand> _funcRoverSendCommand;
        private readonly Func<IList<Move>, IRoverMoveCommand> _funcRoverMoveCommand;

        private IPlateauSizeCommand _plateauSizeCommand;
        private IRoverMoveCommand _roverMoveCommand;
        private IRoverSendCommand _roverSendCommand;

        private ICommandGenerator _commandGenerator;

        [Fact]
        public void Command_ShouldBe_PlateauSizeCommand()
        {
            _commandGenerator =
                new CommandGenerator(_funcPlateauSizeCommand, _funcRoverSendCommand, _funcRoverMoveCommand);
            _plateauSizeCommand = new PlateauSizeCommand(new Size(5, 5));

            var commands = new List<ICommand> {_plateauSizeCommand};
            Assert.All(commands, command => _commandGenerator.Parse("5 5"));
        }

        [Fact]
        public void Command_ShouldBe_RoverMoveCommand()
        {
            _commandGenerator =
                new CommandGenerator(_funcPlateauSizeCommand, _funcRoverSendCommand, _funcRoverMoveCommand);
            _roverMoveCommand = new RoverMoveCommand(new List<Move>());

            var commands = new List<ICommand> {_roverMoveCommand};
            Assert.All(commands, command => _commandGenerator.Parse("1 2 N"));
        }

        [Fact]
        public void Command_ShouldBe_RoverSendCommand()
        {
            _commandGenerator =
                new CommandGenerator(_funcPlateauSizeCommand, _funcRoverSendCommand, _funcRoverMoveCommand);
            _roverSendCommand = new RoverSendCommand(new Location(1, 2, CardinalPoint.North));

            var commands = new List<ICommand> {_roverSendCommand};
            Assert.All(commands, command => _commandGenerator.Parse("LMLMLMLMM"));
        }

        [Fact]
        public void Command_Throws_CommandValidationException()
        {
            _commandGenerator =
                new CommandGenerator(_funcPlateauSizeCommand, _funcRoverSendCommand, _funcRoverMoveCommand);
            Assert.Throws<CommandValidationException>(() => _commandGenerator.Parse("THIS_IS_NOT_A_VALID_COMMAND"));
        }
    }
}