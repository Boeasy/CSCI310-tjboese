using System;

namespace HW1Types
{
    public class HW1Types
    {
        static void Main(string[] args)
        {
            int integer_variable = 42;
            decimal decimal_variable = 7;
            string string_variable = "hello, world";
            char char_var_stare = 'y';
            
            Console.WriteLine($"Int: {integer_variable} Dec: {decimal_variable} String: {string_variable} Char:{char_var_stare}");

            integer_variable = 99;
            decimal_variable = 82;
            string_variable = "goodbye, world";
            char_var_stare = 'n';
            
            Console.WriteLine($"Int: {integer_variable} Dec: {decimal_variable} String: {string_variable} Char:{char_var_stare}");
            
            //Heron's Formula
            //semi-perimeter s = 1/2 * A+B+C
            //area A = sqrt(s(s-A)(s-B)(s-C))

            double A, B, C, s, Area;
            
            Console.WriteLine("Enter in the lengths of the three sides of a triangle separated by a space");

            string input = Console.ReadLine();
            string[] splitInput = input.Split();

            A = double.Parse(splitInput[0]);
            B = double.Parse(splitInput[1]);
            C = double.Parse(splitInput[2]);

            s = (A + B + C) / 2;

            Area = Math.Sqrt(s * (s - A) * (s - B) * (s - C));
            
            Console.WriteLine($"The Area of this triangle is: {Area}");
        }
    }
}