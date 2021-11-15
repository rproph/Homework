using System;

namespace ConsoleApp2
{
    public class StoreCannotBeFoundException : Exception
    {
        public StoreCannotBeFoundException(string message) : base(message)
        {
        }
    }
}
