using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Messages
{
    public class ErrorMessages
    {
        public const string InvalidCommandType
            = "The given type - {0} is either not presented in the assembly or does not implement the interface - ICommand!";
    }
}
