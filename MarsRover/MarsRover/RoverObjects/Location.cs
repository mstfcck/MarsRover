namespace MarsRover.RoverObjects
{
    /// <summary>
    ///     Rover's x and y co-ordinates and cardinal compass point.
    /// </summary>
    public class Location
    {
        public Location(int x, int y, CardinalPoint cardinalPoint)
        {
            X = x;
            Y = y;
            CardinalPoint = cardinalPoint;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public CardinalPoint CardinalPoint { get; set; }
    }
}