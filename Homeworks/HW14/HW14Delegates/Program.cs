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
            Console.WriteLine("Enter the radius of the circle: ");
            int radius = Convert.ToInt32(Console.ReadLine());

            // Create a delegate to run both methods with one call
            CircleDelegate circleDelegate = printRadius;
            circleDelegate += CircleArea;
            circleDelegate += printDiameter;
            circleDelegate += CircleCircumference;

            circleDelegate(radius);
            

            // Demonstrate the differences between Func, Action and Predicate
            Func<int, double> func = circleFunc;
            Console.WriteLine($"Area(func): {func(radius)}");

            Action<int> action = CircleArea;
            action(radius);

            Predicate<int> positive = isPositive;
            Console.WriteLine($"Is positive(predicate): {positive(radius)}");
        }

        public delegate void CircleDelegate(int radius);

        public static void printRadius(int radius)
        {
            Console.WriteLine($"Radius: {radius}");
        }

        public static void CircleArea(int radius)
        {
            Console.WriteLine($"Area: {Math.PI * radius * radius}");
        }
        public static void printDiameter(int radius)
        {
            Console.WriteLine($"Diameter: {2 * radius}");
        }
        public static void CircleCircumference(int radius)
        {
            Console.WriteLine($"Circumference: {2 * Math.PI * radius}");
        }

        static double circleFunc(int radius)
        {
            return Math.PI * radius * radius;
        }

        static bool isPositive(int number)
        {
            return number > 0;
        }

    }
}