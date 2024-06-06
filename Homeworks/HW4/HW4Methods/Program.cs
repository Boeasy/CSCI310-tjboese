/*
Create a void which outputs some text based on the parameters.
Create a method that returns some sort of data back to the call and then is printed out from Main.
Create a method that swaps two numbers via ref.
Create a method that finds the nth Fibonacci number (you can use a for loop or recursion) and then returns that number to be printed out.
Create a method that determines if a number is prime or not and prints out the result from Main.
*/

using System;

namespace HW4Methods
{
    class HW4Methods
    {
        void OutputText(string text)
        {
            Console.WriteLine(text);
        }

        int ReturnData()
        {
            int data = 42;
            return data;
        }

        void SwapNumbers(ref int num1, ref int num2)
        {
            int temp = num1;
            num1 = num2;
            num2 = temp;
        }

        int Fibonacci(int n)
        {
            if (n <= 0)
            {
                return n;
            }
            else if (n == 1)
            {
                return n;
            }
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        bool IsPrime(int num)
        {
            if (num <= 1)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            int num1 = 5;
            int num2 = 10;
            int tempnum = 0;
            HW4Methods hw4 = new HW4Methods();
            hw4.OutputText("Hello World!");
            Console.WriteLine(hw4.ReturnData());

            Console.WriteLine($" Pre-switch: num1: {num1}, num2: {num2}");
            hw4.SwapNumbers(ref num1, ref num2);
            Console.WriteLine($"Post-Switch: num1: {num1}, num2: {num2}");

            Console.WriteLine("Enter in a number to find its Fibonacci number: ");
            tempnum = int.Parse(Console.ReadLine());

            Console.WriteLine($"Position {tempnum} in the Fibonnaci sequence is: {hw4.Fibonacci(tempnum-1)}");

            Console.WriteLine("Enter in a number to see if it is prime: ");
            tempnum = int.Parse(Console.ReadLine());
            if (hw4.IsPrime(tempnum))
            {
                Console.WriteLine($"{tempnum} is prime");
            }
            else
            {
                Console.WriteLine($"{tempnum} is not prime");
            }
    }
    }
}