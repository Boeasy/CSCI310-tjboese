/*
Create a user-defined exception and demonstrate throwing the exception.
*/

using System;

namespace HW12Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new MyException("I take exception to that");
            }
            catch (MyException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    class MyException : Exception
    {
        public MyException(string message) : base(message)
        {
        }
    }
}