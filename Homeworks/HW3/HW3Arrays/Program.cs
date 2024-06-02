using System;

namespace HW3Arrays
{
    public class HW3Arrays
    {
        static void Main(string[] args)
        {
            /*
             * Create 1D array of 10 random numbers between 0-100 using random class, create an instance of the class.
             * use a for loop to populate array with instance.Next(100).
             * Print out the array, sort it, print it out again
             * reverse the array, print out again
             *
             * create a 3x3 rectangular array with some values.
             * create a jagged array with at least 3 rows.
             */

            Random temp_rand = new Random();

            int[] random_nums = new int[10];
            
            //populate array with loop and Next
            for (int i = 0; i < random_nums.Length; i++)
            {
                random_nums[i] = temp_rand.Next(0, 100);
            }
            //print array
            Console.WriteLine();
            Console.WriteLine("Random Numbers Array: ");
            foreach (var num in random_nums)
            {
                Console.Write($"{num}, ");
            }
            //sort array
            for (int i = 0; i < random_nums.Length; i++)
            {
                for (int j = 0; j < random_nums.Length - i - 1; j++)
                {
                    if (random_nums[j] > random_nums[j + 1])
                    {
                        int temp = random_nums[j];
                        random_nums[j] = random_nums[j + 1];
                        random_nums[j + 1] = temp;
                    }
                }
            }
            //print array
            Console.WriteLine();
            Console.WriteLine("Random Numbers Array Sorted (ascending): ");
            foreach (var num in random_nums)
            {
                Console.Write($"{num}, ");
            }
            //reverse array
            for (int i = 0; i < random_nums.Length; i++)
            {
                for (int j = 0; j < random_nums.Length - i - 1; j++)
                {
                    if (random_nums[j] < random_nums[j + 1])
                    {
                        int temp = random_nums[j];
                        random_nums[j] = random_nums[j + 1];
                        random_nums[j + 1] = temp;
                    }
                }
            }
            
            //print array
            Console.WriteLine();
            Console.WriteLine("Random Numbers Array Sorted (Descending): ");
            foreach (var num in random_nums)
            {
                Console.Write($"{num}, ");
            }
            
            //create a 3x3 rectangular array with some values
            int[,] rectangular_array = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            
            //print array
            Console.WriteLine();
            Console.WriteLine("Rectangular Array: ");
            foreach (var num in rectangular_array)
            {
                Console.Write($"{num}, ");
            }
            

            //create a jagged array with at least 3 rows
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[7];
            jaggedArray[1] = new int[3];
            jaggedArray[2] = new int[1];
            jaggedArray[0][6] = 42;
            
            //print array
            Console.WriteLine();
            Console.WriteLine("Jagged Array: ");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}