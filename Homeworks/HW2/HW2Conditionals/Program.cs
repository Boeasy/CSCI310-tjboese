// See https://aka.ms/new-console-template for more information
using System;

namespace HW2Conditionals
{
    public class HW2Conditionals
    {
        static void Main(string[] args)
        {
            float income;
            double[] taxrate = [0,0,0];
            double totalTax = 0;
            
            //Money     <10000   10,000-10,000    >100,000
            //Tax Rate   5%          9.7%            14%

            taxrate[0] = 0.05;
            taxrate[1] = 0.097;
            taxrate[2] = 0.14;
            
            Console.WriteLine("Enter your income");
            income = Single.Parse(Console.ReadLine());
            Console.WriteLine(income.ToString("C"));

            if (income < 10000)
            {
                totalTax = income * taxrate[0];
                Console.WriteLine($"Tax Rate: {taxrate[0].ToString(format:"P1")}");
            }

            if (income > 100000)
            {
                totalTax = income * taxrate[2];
                Console.WriteLine($"Tax Rate: {taxrate[2].ToString(format:"P1")}");
            }
            if (income < 100000 & income > 10000)
            {
                totalTax = income * taxrate[1];
                Console.WriteLine($"Tax Rate: {taxrate[1].ToString(format:"P1")}");
            }
            Console.WriteLine($"Total Tax: {totalTax.ToString(format:"C")}");
            
            Console.WriteLine("Enter a number of lines to print for a triangle");
            int triangleNum;
            triangleNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < triangleNum; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = triangleNum; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            
            for (int i = 0; i < triangleNum; i++)
            {
                for (int j = 0; j < triangleNum; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}