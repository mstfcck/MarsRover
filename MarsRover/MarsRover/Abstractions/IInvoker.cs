using System.Collections.Generic;
using MarsRover.Abstractions.Commands;

namespace MarsRover.Abstractions
{
    /// <summary>
    ///     The 'Invoker' class
    /// </summary>
    public interface IInvoker
    {
        void InitializePlateau(IPlateau plateau);
        void InitializeRovers(IList<IRover> rovers);
        void SetCommands(IEnumerable<ICommand> commands);
        void InvokeCommands();
        IList<string> GetLatestRoverLocations();
    }
}