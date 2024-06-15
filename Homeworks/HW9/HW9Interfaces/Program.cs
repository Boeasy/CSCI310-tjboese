/*
Create an interface with at least 2 methods. Create a class that implements the interface. 
Demonstrate that the class with interface functions as expected.
*/

using System;

namespace HW9Interfaces
{
    interface InterfaceWithAtLeastTwoMethods
    {
        void Method1();
        void Method2();
    }

    class ClassThatImplementsTheInterface : InterfaceWithAtLeastTwoMethods
    {
        public void Method1()
        {
            Console.WriteLine("Method1");
        }

        public void Method2()
        {
            Console.WriteLine("Method2");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ClassThatImplementsTheInterface myClass = new ClassThatImplementsTheInterface();
            myClass.Method1();
            myClass.Method2();
        }
    }
}