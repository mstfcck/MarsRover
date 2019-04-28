using MarsRover.RoverObjects;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverExtensionsTests
    {
        [Fact]
        public void Location_CardinalPoint_East_ShouldBe_North_When_Turns_Left()
        {
            var location = new Location(1, 2, CardinalPoint.East);
            location.Movement(Move.Left);
            Assert.Equal(CardinalPoint.North, location.CardinalPoint);
        }

        [Fact]
        public void Location_CardinalPoint_East_ShouldBe_South_When_Turns_Right()
        {
            var location = new Location(1, 2, CardinalPoint.East);
            location.Movement(Move.Right);
            Assert.Equal(CardinalPoint.South, location.CardinalPoint);
        }

        [Fact]
        public void Location_CardinalPoint_North_ShouldBe_East_When_Turns_Right()
        {
            var location = new Location(1, 2, CardinalPoint.North);
            location.Movement(Move.Right);
            Assert.Equal(CardinalPoint.East, location.CardinalPoint);
        }

        [Fact]
        public void Location_CardinalPoint_North_ShouldBe_West_When_Turns_Left()
        {
            var location = new Location(1, 2, CardinalPoint.North);
            location.Movement(Move.Left);
            Assert.Equal(CardinalPoint.West, location.CardinalPoint);
        }

        [Fact]
        public void Location_CardinalPoint_South_ShouldBe_East_When_Turns_Left()
        {
            var location = new Location(1, 2, CardinalPoint.South);
            location.Movement(Move.Left);
            Assert.Equal(CardinalPoint.East, location.CardinalPoint);
        }

        [Fact]
        public void Location_CardinalPoint_South_ShouldBe_West_When_Turns_Right()
        {
            var location = new Location(1, 2, CardinalPoint.South);
            location.Movement(Move.Right);
            Assert.Equal(CardinalPoint.West, location.CardinalPoint);
        }

        [Fact]
        public void Location_CardinalPoint_West_ShouldBe_North_When_Turns_Right()
        {
            var location = new Location(1, 2, CardinalPoint.West);
            location.Movement(Move.Right);
            Assert.Equal(CardinalPoint.North, location.CardinalPoint);
        }

        [Fact]
        public void Location_CardinalPoint_West_ShouldBe_South_When_Turns_Left()
        {
            var location = new Location(1, 2, CardinalPoint.West);
            location.Movement(Move.Left);
            Assert.Equal(CardinalPoint.South, location.CardinalPoint);
        }

        /// <summary>
        ///     1 1 N
        ///     LMLMLMLMM
        /// </summary>
        [Fact]
        public void Location_Position_11N_ShouldBe_13N()
        {
            var location = new Location(1, 2, CardinalPoint.North);

            location.Movement(Move.Left);
            location.Movement(Move.Forward);
            location.Movement(Move.Left);
            location.Movement(Move.Forward);
            location.Movement(Move.Left);
            location.Movement(Move.Forward);
            location.Movement(Move.Left);
            location.Movement(Move.Forward);
            location.Movement(Move.Forward);

            Assert.Equal(CardinalPoint.North, location.CardinalPoint);
            Assert.Equal(1, location.X);
            Assert.Equal(3, location.Y);
        }

        /// <summary>
        ///     3 3 E
        ///     MMRMMRMRRM
        /// </summary>
        [Fact]
        public void Location_Position_33E_ShouldBe_51E()
        {
            var location = new Location(3, 3, CardinalPoint.East);

            location.Movement(Move.Forward);
            location.Movement(Move.Forward);
            location.Movement(Move.Right);
            location.Movement(Move.Forward);
            location.Movement(Move.Forward);
            location.Movement(Move.Right);
            location.Movement(Move.Forward);
            location.Movement(Move.Right);
            location.Movement(Move.Right);
            location.Movement(Move.Forward);

            Assert.Equal(CardinalPoint.East, location.CardinalPoint);
            Assert.Equal(5, location.X);
            Assert.Equal(1, location.Y);
        }

        [Fact]
        public void Location_Position_00E_ShouldBe_10E_When_Move_Forward()
        {
            var location = new Location(0, 0, CardinalPoint.East);
            location.Movement(Move.Forward);
            Assert.Equal(CardinalPoint.East, location.CardinalPoint);
            Assert.Equal(1, location.X);
            Assert.Equal(0, location.Y);
        }

        [Fact]
        public void Location_Position_00N_ShouldBe_01N_When_Move_Forward()
        {
            var location = new Location(0, 0, CardinalPoint.North);
            location.Movement(Move.Forward);
            Assert.Equal(CardinalPoint.North, location.CardinalPoint);
            Assert.Equal(0, location.X);
            Assert.Equal(1, location.Y);
        }

        [Fact]
        public void Location_Position_55E_ShouldBe_45E_When_Move_Forward()
        {
            var location = new Location(5, 5, CardinalPoint.West);
            location.Movement(Move.Forward);
            Assert.Equal(CardinalPoint.West, location.CardinalPoint);
            Assert.Equal(4, location.X);
            Assert.Equal(5, location.Y);
        }

        [Fact]
        public void Location_Position_55S_ShouldBe_54E_When_Move_Forward()
        {
            var location = new Location(5, 5, CardinalPoint.South);
            location.Movement(Move.Forward);
            Assert.Equal(CardinalPoint.South, location.CardinalPoint);
            Assert.Equal(5, location.X);
            Assert.Equal(4, location.Y);
        }
    }
}