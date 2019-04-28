using MarsRover.PlateauObjects;
using MarsRover.RoverObjects;

namespace MarsRover.Abstractions
{
    /// <summary>
    ///     The 'Receiver' class
    /// </summary>
    public interface IPlateau
    {
        Size Size { get; set; }
        void SetSize(Size size);
        bool IsValid(Location location);
    }
}