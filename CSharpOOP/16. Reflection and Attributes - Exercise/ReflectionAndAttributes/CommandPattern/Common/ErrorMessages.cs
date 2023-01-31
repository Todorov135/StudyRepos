using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace CommandPattern.Common
{
    public static class ErrorMessages
    {
        public const string InvalidCommandType = "Provided type {0} does not exist or it does not inplement ICommand interface!";
    }
}
