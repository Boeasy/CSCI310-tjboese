/*
Create a Dictionary, Queue and Stack. 
Write methods to interface with those collections, 
one method should print out the collection. 
Demonstrate the collections working.

*/

using System;

namespace HW11Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Collections.Generic.Dictionary<int, string> dictionary = new System.Collections.Generic.Dictionary<int, string>();
            System.Collections.Generic.Queue<int> queue = new System.Collections.Generic.Queue<int>();
            System.Collections.Generic.Stack<int> stack = new System.Collections.Generic.Stack<int>();

            dictionary.Add(1, "One");
            dictionary.Add(2, "Two");
            dictionary.Add(3, "Three");
            dictionary.Add(4, "Four");
            dictionary.Add(5, "Five");

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            PrintDictionary(dictionary);
            PrintQueue(queue);
            PrintStack(stack);
        }

        static void PrintDictionary(System.Collections.Generic.Dictionary<int, string> dictionary)
        {
            Console.WriteLine("Printing Dictionary");
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        static void PrintQueue(System.Collections.Generic.Queue<int> queue)
        {
            Console.WriteLine("Printing Queue");
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }

        static void PrintStack(System.Collections.Generic.Stack<int> stack)
        {
            Console.WriteLine("Printing Stack");
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}