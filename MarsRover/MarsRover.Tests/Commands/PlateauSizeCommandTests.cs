using MarsRover.Abstractions;
using MarsRover.Abstractions.Commands;
using MarsRover.Commands;
using MarsRover.PlateauObjects;
using Moq;
using Xunit;

namespace MarsRover.Tests.Commands
{
    public class PlateauSizeCommandTests
    {
        public PlateauSizeCommandTests()
        {
            _plateau = Mock.Of<Plateau>();
        }

        private readonly IPlateau _plateau;
        private IPlateauSizeCommand _plateauSizeCommand;

        [Fact]
        public void Plateau_Size_ShouldBe_Same_With_CommandSize()
        {
            _plateauSizeCommand = new PlateauSizeCommand(new Size(5, 5));
            _plateauSizeCommand.Set(_plateau);
            _plateauSizeCommand.Execute();

            Assert.Equal(5, _plateau.Size.MaxX);
            Assert.Equal(5, _plateau.Size.MaxY);
        }
    }
}