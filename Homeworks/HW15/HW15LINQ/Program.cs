/*
Create at least 5 different examples using LINQ and Lambda expressions. Demonstrate all of them working.
*/

using System;
using System.Text.RegularExpressions;

namespace HW15LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                numbers.Add(i);
            }

            // Even Numbers through lambda
            List<int> evenNumbers = numbers.FindAll(x => x % 2 == 0);

            // Odd Numbers through lambda
            List<int> oddNumbers = numbers.FindAll(x => x % 2 != 0);

            // Prime Numbers through lambda
            List<int> primeNumbers = numbers.FindAll(x => isPrime(x));

            // Numbers whos digits add up to 7
            List<int> numbersWithSeven = numbers.FindAll(x => x.ToString().Sum(c => c - '0') == 7);

            // Numbers that are multiples of 3 or 5
            List<int> multiplesOfThreeAndFive = numbers.FindAll(x => x != 0 && (x % 3 == 0 || x % 5 == 0));

            Console.WriteLine("Even Numbers: ");
            printList(evenNumbers);
            Console.WriteLine("Odd Numbers: ");
            printList(oddNumbers);
            Console.WriteLine("Prime Numbers: ");
            printList(primeNumbers);
            Console.WriteLine("Numbers whos digits add up to 7: ");
            printList(numbersWithSeven);
            Console.WriteLine("Numbers that are multiples of 3 or 5: ");
            printList(multiplesOfThreeAndFive);

            //LINQ

            List<string> pokemon = new List<string> { "Pikachu", "Charmander", "Bulbasaur", "Squirtle", "Jigglypuff", "Meowth", "Psyduck", "Snorlax", "Mewtwo", "Mew" };

            IEnumerable<string> pokemonwithdoubleletters = from mon in pokemon
                                                              where Regex.IsMatch(mon, @"(.)\1") //from stackoverflow.com/questions/38329987/regex-to-match-words-with-double-letters , changed over some things from sql
                                                              select mon;

            IEnumerable<string> pokemonInAllCaps = from mon in pokemon
                                                   select mon.ToUpper();
            IEnumerable<string> reversePokemon = from mon in pokemon
                                                  select new string(mon.Reverse().ToArray());
            IEnumerable<string> pokomon = from mon in pokemon
                                                          select Regex.Replace(mon, "[aeiou]", "o");
            IEnumerable<string> pokemonButOnlyVowels = from mon in pokemon
                                                        select Regex.Replace(mon, "[^aeiou]", "");
            Console.WriteLine("Pokemon with double letters: ");
            foreach (var mon in pokemonwithdoubleletters)
            {
                Console.WriteLine(mon);
            }
            Console.WriteLine();
            Console.WriteLine("Pokemon but yelling: ");
            foreach (var mon in pokemonInAllCaps)
            {
                Console.WriteLine(mon);
            }
            Console.WriteLine();
            Console.WriteLine("Pokemon reversed: ");
            foreach (var mon in reversePokemon)
            {
                Console.WriteLine(mon);
            }
            Console.WriteLine();
            Console.WriteLine("Pokemon with only 'o' vowels: ");
            foreach (var mon in pokomon)
            {
                Console.WriteLine(mon);
            }
            Console.WriteLine();
            Console.WriteLine("Pokemon but only vowels: ");
            foreach (var mon in pokemonButOnlyVowels)
            {
                Console.WriteLine(mon);
            }
            


        }

        static bool isPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            for (int i = 3; i < number; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        static void printList(List<int> list)
        {
            foreach (var number in list)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();
        }



    }
}