using System;

namespace ConsoleApp2
{
    public class PhoneCannotBeDoundException : Exception
    {
        public PhoneCannotBeDoundException(string message) : base(message)
        {
        }
    }
}
