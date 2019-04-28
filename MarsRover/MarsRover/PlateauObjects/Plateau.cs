using MarsRover.Abstractions;
using MarsRover.RoverObjects;

namespace MarsRover.PlateauObjects
{
    /// <inheritdoc />
    /// <summary>
    ///     Plateau on Mars
    /// </summary>
    public class Plateau : IPlateau
    {
        public Size Size { get; set; }

        public void SetSize(Size size)
        {
            Size = size;
        }

        public bool IsValid(Location location)
        {
            return location != null && location.X >= 0 && location.X <= Size.MaxX && location.Y >= 0 && location.Y <= Size.MaxY;
        }
    }
}