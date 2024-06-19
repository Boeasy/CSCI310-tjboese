/*
Create several methods to calculate the area and circumference of a circle. 
Then create a multicast delegate to run both methods with one call.
Next create methods to demonstrate the differences between Func, Action and Predicate.
*/

using System;

namespace HW14Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a delegate to run both methods with one call
            CircleDelegate circleDelegate = new CircleDelegate(CircleArea);
            circleDelegate += CircleCircumference;
            circleDelegate(5);

            // Demonstrate the differences between Func, Action and Predicate
            Func<int, int, int> func = (x, y) => x + y;
            Console.WriteLine(func(5, 6));

            Action<int, int> action = (x, y) => Console.WriteLine(x + y);
            action(5, 6);

            Predicate<int> predicate = x => x > 5;
            Console.WriteLine(predicate(6));
        }

        public delegate void CircleDelegate(int radius);

        public static void CircleArea(int radius)
        {
            Console.WriteLine($"The area of the circle with radius {radius} is {Math.PI * Math.Pow(2, radius)}");
        }

        public static void CircleCircumference(int radius)
        {
            Console.WriteLine($"The circumference of the circle with radius {radius} is {2 * Math.PI * radius}");
        }
    }
}