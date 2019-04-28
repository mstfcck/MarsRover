using MarsRover.Abstractions;
using MarsRover.Abstractions.Commands;
using MarsRover.Exceptions;
using MarsRover.PlateauObjects;
using MarsRover.RoverObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MarsRover
{
    public class CommandGenerator : ICommandGenerator
    {
        private readonly IDictionary<char, CardinalPoint> _cardinalPointGenerator;
        private readonly IDictionary<string, Func<string, ICommand>> _commandGenerator;

        private readonly IDictionary<string, string> _commandTypes;
        private readonly Func<Size, IPlateauSizeCommand> _funcPlateauSizeCommand;
        private readonly Func<IList<Move>, IRoverMoveCommand> _funcRoverMoveCommand;
        private readonly Func<Location, IRoverSendCommand> _funcRoverSendCommand;
        private readonly IDictionary<char, Move> _movementGenerator;

        public CommandGenerator(Func<Size, IPlateauSizeCommand> funcPlateauSizeCommand,
            Func<Location, IRoverSendCommand> funcRoverSendCommand,
            Func<IList<Move>, IRoverMoveCommand> funcRoverMoveCommand)
        {
            _funcPlateauSizeCommand = funcPlateauSizeCommand;
            _funcRoverSendCommand = funcRoverSendCommand;
            _funcRoverMoveCommand = funcRoverMoveCommand;

            _commandTypes = new Dictionary<string, string>
            {
                {@"^\d+ \d+$", nameof(IPlateauSizeCommand)},
                {@"^[LRM]+$", nameof(IRoverMoveCommand)},
                {@"^\d+ \d+ [NSEW]$", nameof(IRoverSendCommand)}
            };

            _commandGenerator = new Dictionary<string, Func<string, ICommand>>
            {
                {nameof(IPlateauSizeCommand), InitializePlateauSizeCommand},
                {nameof(IRoverMoveCommand), InitializeRoverMoveCommand},
                {nameof(IRoverSendCommand), InitializeRoverSendCommand}
            };

            _cardinalPointGenerator = new Dictionary<char, CardinalPoint>
            {
                {'N', CardinalPoint.North},
                {'W', CardinalPoint.West},
                {'S', CardinalPoint.South},
                {'E', CardinalPoint.East}
            };

            _movementGenerator = new Dictionary<char, Move>
            {
                {'M', Move.Forward},
                {'L', Move.Left},
                {'R', Move.Right}
            };
        }

        public IEnumerable<ICommand> Parse(string instructions)
        {
            var instructionLines = instructions.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
            return instructionLines.Select(instruction => _commandGenerator[GetCommandType(instruction)].Invoke(instruction)).ToList();
        }

        #region Private Helpers

        /// <summary>
        ///     This method validates the instruction and returns command interface name.
        /// </summary>
        /// <param name="instruction">Instruction input</param>
        /// <returns>
        ///     <seealso cref="IPlateauSizeCommand" />
        /// </returns>
        private string GetCommandType(string instruction)
        {
            try
            {
                return _commandTypes.First(pair => new Regex(pair.Key).IsMatch(instruction)).Value;
            }
            catch (InvalidOperationException)
            {
                throw new CommandValidationException("'{0}' is not a valid instruction");
            }
        }

        /// <summary>
        ///     This method separates instruction and returns IPlateauSizeCommand.
        /// </summary>
        /// <param name="instruction">Instruction example: "5 5"</param>
        /// <returns>
        ///     <seealso cref="IPlateauSizeCommand" />
        /// </returns>
        private ICommand InitializePlateauSizeCommand(string instruction)
        {
            // Sample instruction input: "5 5"
            var c = instruction.Split(' '); // 5, 5
            var x = int.Parse(c[0]); // 5
            var y = int.Parse(c[1]); // 5
            return _funcPlateauSizeCommand(new Size(x, y));
        }

        /// <summary>
        ///     This method separates instruction and returns IRoverMoveCommand.
        /// </summary>
        /// <param name="instruction">Instruction example: "LMMRMMLM"</param>
        /// <returns>
        ///     <seealso cref="IRoverMoveCommand" />
        /// </returns>
        private ICommand InitializeRoverMoveCommand(string instruction)
        {
            // Sample instruction input: "LMMRMMLM"
            var c = instruction.ToCharArray(); // L, M, M, R, M, M, L, M
            var m = c.Select(argument => _movementGenerator[argument]).ToList();
            return _funcRoverMoveCommand(m);
        }

        /// <summary>
        ///     This method separates instruction and returns IRoverSendCommand.
        /// </summary>
        /// <param name="instruction">Instruction example: "1 2 N"</param>
        /// <returns>
        ///     <seealso cref="IRoverSendCommand" />
        /// </returns>
        private ICommand InitializeRoverSendCommand(string instruction)
        {
            // Sample instruction input: "1 2 N"
            var c = instruction.Split(' '); // 1, 2, N
            var x = int.Parse(c[0]); // 1
            var y = int.Parse(c[1]); // 2
            var d = c[2][0]; // N
            var cardinalPoint = _cardinalPointGenerator[d];
            return _funcRoverSendCommand(new Location(x, y, cardinalPoint));
        }

        #endregion
    }
}