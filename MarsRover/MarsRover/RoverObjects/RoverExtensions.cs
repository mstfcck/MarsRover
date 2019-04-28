namespace MarsRover.RoverObjects
{
    public static class RoverExtensions
    {
        public static void Movement(this Location location, Move move)
        {
            switch (move)
            {
                case Move.Forward:
                    MoveForward(location);
                    break;
                case Move.Left:
                    MoveLeft(location);
                    break;
                case Move.Right:
                    MoveRight(location);
                    break;
            }
        }

        private static void MoveForward(Location location)
        {
            switch (location.CardinalPoint)
            {
                case CardinalPoint.North:
                    location.Y += 1;
                    break;
                case CardinalPoint.West:
                    location.X -= 1;
                    break;
                case CardinalPoint.South:
                    location.Y -= 1;
                    break;
                case CardinalPoint.East:
                    location.X += 1;
                    break;
            }
        }

        private static void MoveLeft(Location location)
        {
            switch (location.CardinalPoint)
            {
                case CardinalPoint.North:
                    location.CardinalPoint = CardinalPoint.West;
                    break;
                case CardinalPoint.West:
                    location.CardinalPoint = CardinalPoint.South;
                    break;
                case CardinalPoint.South:
                    location.CardinalPoint = CardinalPoint.East;
                    break;
                case CardinalPoint.East:
                    location.CardinalPoint = CardinalPoint.North;
                    break;
            }
        }

        private static void MoveRight(Location location)
        {
            switch (location.CardinalPoint)
            {
                case CardinalPoint.North:
                    location.CardinalPoint = CardinalPoint.East;
                    break;
                case CardinalPoint.East:
                    location.CardinalPoint = CardinalPoint.South;
                    break;
                case CardinalPoint.South:
                    location.CardinalPoint = CardinalPoint.West;
                    break;
                case CardinalPoint.West:
                    location.CardinalPoint = CardinalPoint.North;
                    break;
            }
        }
    }
}