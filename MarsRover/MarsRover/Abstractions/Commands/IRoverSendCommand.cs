namespace MarsRover.Abstractions.Commands
{
    public interface IRoverSendCommand : ICommand
    {
        void Set(IPlateau plateau, IRover rover);
    }
}