using MarsRover.Abstractions;
using MarsRover.Abstractions.Commands;
using MarsRover.RoverObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class Invoker : IInvoker
    {
        private readonly IDictionary<string, Action<ICommand>> _commandTypes;
        private IEnumerable<ICommand> _commands;
        private IPlateau _plateau;
        private IList<IRover> _rovers;

        public Invoker()
        {
            _commandTypes = new Dictionary<string, Action<ICommand>>
            {
                {nameof(IPlateauSizeCommand), InitPlateauSizeCommand},
                {nameof(IRoverMoveCommand), InitRoverMoveCommand},
                {nameof(IRoverSendCommand), InitRoverSendCommand}
            };
        }

        public void InitializePlateau(IPlateau plateau)
        {
            _plateau = plateau;
        }

        public void InitializeRovers(IList<IRover> rovers)
        {
            _rovers = rovers;
        }

        public void SetCommands(IEnumerable<ICommand> commands)
        {
            _commands = commands;
        }

        /// <summary>
        ///     Invokes all the given commands.
        /// </summary>
        public void InvokeCommands()
        {
            foreach (var command in _commands)
            {
                InitializeCommand(command);
                command.Execute();
            }
        }

        /// <summary>
        ///     Gets the latest rover locations that execute by commands.
        /// </summary>
        /// <returns></returns>
        public IList<string> GetLatestRoverLocations()
        {
            return _rovers.Select(x => $"{x.Location.X}, {x.Location.Y}, {(char) x.Location.CardinalPoint}").ToList();
        }

        #region Private Helpers

        /// <summary>
        ///     This method gets the interface name that initializes and gives to the command types dictionary as a key and then
        ///     invokes the encapsulated method in value.
        /// </summary>
        /// <param name="command"></param>
        private void InitializeCommand(ICommand command)
        {
            var name = command.GetType().GetInterfaces()[0].Name;
            _commandTypes[name].Invoke(command);
        }

        /// <summary>
        ///     Encapsulated method in command types dictionary. Sets the plateau to IPlateauSizeCommand.
        /// </summary>
        /// <param name="command"></param>
        private void InitPlateauSizeCommand(ICommand command)
        {
            var c = (IPlateauSizeCommand) command;
            c.Set(_plateau);
        }

        /// <summary>
        ///     Encapsulated method in command types dictionary. Sets the plateau and rover to IRoverSendCommand.
        /// </summary>
        /// <param name="command"></param>
        private void InitRoverSendCommand(ICommand command)
        {
            var rover = new Rover();
            _rovers.Add(rover);
            var c = (IRoverSendCommand) command;
            c.Set(_plateau, rover);
        }

        /// <summary>
        ///     Encapsulated method in command types dictionary. Sets the rover to IRoverMoveCommand.
        /// </summary>
        /// <param name="command"></param>
        private void InitRoverMoveCommand(ICommand command)
        {
            var c = (IRoverMoveCommand) command;
            c.Set(_rovers.LastOrDefault());
        }

        #endregion
    }
}