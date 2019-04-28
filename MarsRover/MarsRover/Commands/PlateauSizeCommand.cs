using MarsRover.Abstractions;
using MarsRover.Abstractions.Commands;
using MarsRover.PlateauObjects;

namespace MarsRover.Commands
{
    public class PlateauSizeCommand : IPlateauSizeCommand
    {
        private IPlateau _plateau;

        public PlateauSizeCommand(Size size)
        {
            Size = size;
        }

        public Size Size { get; }

        public void Set(IPlateau plateau)
        {
            _plateau = plateau;
        }

        public void Execute()
        {
            _plateau.SetSize(Size);
        }
    }
}