/*
Create a text file. Read in the file using either a StringReader or FileStream.
 Manipulate some of the data and write out to a different file. 
 You should use the using keywork for any streams.

*/

using System;

namespace HW13Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> parsedLines = new List<string>();


            using (System.IO.StreamReader reader = new System.IO.StreamReader("input.txt"))
            {
                string line = reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {                
                    Console.WriteLine($"input line: {line}");
                    string parsedLine = "";
                    foreach (char c in line)
                    {
                        if (char.IsLetterOrDigit(c))
                        {
                            parsedLine += c;
                        }
                    }
                Console.WriteLine($"parsed line: {parsedLine}");
                parsedLines.Add(parsedLine);
                }
            }

            Console.WriteLine("Writing to file...");
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter("output.txt"))
            {
                foreach (string line in parsedLines)
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
}