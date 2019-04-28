using MarsRover.Abstractions.Commands;
using System.Collections.Generic;

namespace MarsRover.Abstractions
{
    public interface ICommandGenerator
    {
        /// <summary>
        ///     Parses all instructions and returns the command interface list.
        /// </summary>
        /// <param name="instructions"></param>
        IEnumerable<ICommand> Parse(string instructions);
    }
}