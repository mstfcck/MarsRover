using System;

namespace MarsRover.Exceptions
{
    public class CommandValidationException : InvalidOperationException
    {
        public CommandValidationException(string message) : base(message)
        {
        }
    }
}