using System;

namespace MarsRover.Exceptions
{
    public class RoverLocationValidationException : InvalidOperationException
    {
        public RoverLocationValidationException(string message) : base(message)
        {
        }
    }
}