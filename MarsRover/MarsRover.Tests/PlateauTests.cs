using MarsRover.Abstractions;
using MarsRover.PlateauObjects;
using MarsRover.RoverObjects;
using Moq;
using Xunit;

namespace MarsRover.Tests
{
    public class PlateauTests
    {
        public PlateauTests()
        {
            _plateau = Mock.Of<Plateau>();
        }

        private readonly IPlateau _plateau;

        [Fact]
        public void Plateau_IsValid_ShouldBe_False()
        {
            _plateau.SetSize(new Size(5, 5));

            var location = new Location(6, 1, CardinalPoint.North);

            Assert.Equal(false, _plateau.IsValid(location));
        }

        [Fact]
        public void Plateau_IsValid_ShouldBe_True()
        {
            _plateau.SetSize(new Size(5, 5));

            var location = new Location(1, 2, CardinalPoint.North);

            Assert.Equal(true, _plateau.IsValid(location));
        }

        [Fact]
        public void Plateau_SetSize_ShouldBe_Same_As_Expected()
        {
            _plateau.SetSize(new Size(5, 5));

            Assert.Equal(5, _plateau.Size.MaxX);
            Assert.Equal(5, _plateau.Size.MaxY);
        }
    }
}