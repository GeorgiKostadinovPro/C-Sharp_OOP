using System;

namespace WildFarm.Exceptions
{
    public class InvalidFactoryTypeException : Exception
    {
        private const string DefaultMessage = "Invalid type!";

        public InvalidFactoryTypeException()
            : base(DefaultMessage)
        {

        }

        public InvalidFactoryTypeException(string message)
            : base(message)
        {

        }
    }
}
