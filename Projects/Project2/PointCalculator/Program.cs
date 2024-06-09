/*
Create a class to store points from a cartesian coordinate system (x, y).
Create an operator overload to add 2 points together and return a point.
Create an operator to multiply a point with a scale and then return the point.
Create an operator to multiply 2 points together, same as you would add 2 points together.
Create a ToString method to return a string of a point.
Overload == and != to compare 2 points.

Create 2 points in Main and demonstrate your class and overloaded operators.
*/

using System;

namespace PointCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Point Calculator");
            Console.WriteLine("Enter the x and y coordinates of the first point, separated by a comma:");
            string[] temporarypoint = Console.ReadLine().Split(",");
            Point point1 = new Point(int.Parse(temporarypoint[0]), int.Parse(temporarypoint[1]));
            Console.WriteLine("Enter the x and y coordinates of the second point, separated by a comma:");
            temporarypoint = Console.ReadLine().Split(",");
            Point point2 = new Point(int.Parse(temporarypoint[0]), int.Parse(temporarypoint[1]));

            Console.WriteLine($"Point 1: {point1.ToString()}");
            Console.WriteLine($"Point 2: {point2.ToString()}");

            Console.WriteLine($"Point 1 + Point 2: {point1 + point2}");
            Console.WriteLine($"Point 1 * 7: {point1 * 7}");
            Console.WriteLine($"Point 1 * Point 2: {point1 * point2}");
            if (point1 == point2)
            {
                Console.WriteLine("Point 1 is equal to Point 2.");
            }
            else if (point1 != point2)
            {
                Console.WriteLine("Point 1 is not equal to Point 2.");
            }
            else
            {
                Console.WriteLine("Error with == operators...");
            }
            
        }
    }

    public class Point
    {
        private int x;
        private int y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X {get; set;}

        public int Y {get; set;}

        public static Point operator +(Point leftHandSide, Point rightHandSide)
        {
            Point newPoint = new Point(0, 0);
            newPoint.X = leftHandSide.X + rightHandSide.X;
            newPoint.Y = leftHandSide.Y + rightHandSide.Y;
            return newPoint;
        }

        public static Point operator *(Point point, int scale)
        {
            Point newPoint = new Point(0, 0);
            newPoint.X = point.X * scale;
            newPoint.Y = point.Y * scale;
            return newPoint;
        }

        public static Point operator *(Point leftHandSide, Point rightHandSide)
        {
            Point newPoint = new Point(0, 0);
            newPoint.X = leftHandSide.X * rightHandSide.X;
            newPoint.Y = leftHandSide.Y * rightHandSide.Y;
            return newPoint;
        }

        public override string ToString()
        {
            return $"({this.X}, {this.Y})";
        }

        public static bool operator ==(Point leftHandSide, Point rightHandSide)
        {
            return leftHandSide.X == rightHandSide.X && leftHandSide.Y == rightHandSide.Y;
        }

        public static bool operator !=(Point leftHandSide, Point rightHandSide)
        {
            return leftHandSide.X != rightHandSide.X ||
                     leftHandSide.Y != rightHandSide.Y;
        }
    }
}
