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


            using (StreamReader reader = new StreamReader("input.txt"))
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
            using (StreamWriter writer = new StreamWriter("output.txt"))
            {
                foreach (string line in parsedLines)
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
}