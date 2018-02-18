using System;
namespace EasyReturnValues
{
    public class FailedException : Exception
    {

        public FailedException(String message) : base(message)
        {
        }

    }
}
