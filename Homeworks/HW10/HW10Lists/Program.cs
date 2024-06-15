/*
Create 2 lists of different types (one should be ints) and populate each list with some values 
(the int should be at least 10). Write a method to insert a value into the list passed as a parameter, 
should use BinarySearch to determine where to insert the value (the list must be sorted for BinarySearch 
to function correctly). 

Write a method to print out a list passed to it. 

Demonstrate your code working from Main.
*/

using System;

namespace HW10Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> intList = new List<int>();
            List<string> stringList = new List<string>();

            stringList.Add("Apple");
            stringList.Add("Banana");
            stringList.Add("Cherry");
            stringList.Add("Date");
            stringList.Add("Elderberry");

            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                intList.Add(random.Next(1, 51));;
            }
            PrintList(intList);
            Console.WriteLine("Sorted List: ");
            intList.Sort();
            PrintList(intList);

            Console.WriteLine("Enter a value to insert into the list");
            int tempvalue = Convert.ToInt32(Console.ReadLine());
            InsertValue(intList, tempvalue);

            // Write a method to print out a list passed to it.
            PrintList(intList);
            PrintList(stringList);
        }

        static void InsertValue(System.Collections.Generic.List<int> list, int value)
        {
            int index = list.BinarySearch(value);
            if (index < 0)
            {
                index = ~index;
            }
            list.Insert(index, value);
        }

        static void PrintList<T>(System.Collections.Generic.List<T> list)
        {
            Console.WriteLine($"Printing list of {typeof(T)}");
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
        }
    }
}