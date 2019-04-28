namespace MarsRover.Abstractions.Commands
{
    public interface IPlateauSizeCommand : ICommand
    {
        void Set(IPlateau plateau);
    }
}