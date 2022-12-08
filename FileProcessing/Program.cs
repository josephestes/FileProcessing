/* 
 * This program reads a text file of numbers and outputs the number of numbers,
 * the largest number, the smallest number, and the average of these numbers,
 * and the number of numbers within ranges of 0 - 9999, 10000 - 19999 and so on up to 99999
 * to the user and a file.
 * 
 * Program uses loops
 * 
 * Program reads file from NumbersFileProcessing\bin\Debug\netcoreapp3.1\many.numbers.txt
 * Program outputs file to NumbersFileProcessing\bin\Debug\netcoreapp3.1\output.txt
 */

using System;
using static System.Console;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace NumbersFileProcessing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string FILENAME = "many.numbers.txt";
            const int RANGE_INTERVAL = 10000;
            const int RANGE_LIMIT = 100000;

            int numberIn;
            var numbers = new List<int>();

            // Read the input file
            string[] lines = File.ReadAllLines(FILENAME);

            foreach (var line in lines)
            {
                if (int.TryParse(line, out numberIn))
                {
                    numbers.Add(numberIn);
                }
            }

            // Create the output file
            using (StreamWriter outFile = new StreamWriter("output.txt"))
            {
                // Output details to user
                WriteLine($"Number Count: {numbers.Count()}");
                WriteLine($"Smallest Number: {numbers.Min()}");
                WriteLine($"Largest Number: {numbers.Max()}");
                WriteLine($"Average of Numbers: {numbers.Average()}");

                // Output details to file
                outFile.WriteLine($"Number Count: {numbers.Count()}");
                outFile.WriteLine($"Smallest Number: {numbers.Min()}");
                outFile.WriteLine($"Largest Number: {numbers.Max()}");
                outFile.WriteLine($"Average of Numbers: {numbers.Average()}");

                // Determine total numbers within each range
                for (int i = 0; i < RANGE_LIMIT; i += RANGE_INTERVAL)
                {
                    int rangeCount = 0;

                    foreach (var number in numbers)
                    {
                        if (number >= i && number < (i + RANGE_INTERVAL))
                        {
                            rangeCount++;
                        }
                    }

                    // Output to user
                    WriteLine($"There are {rangeCount} numbers within the range {i} - {i + RANGE_INTERVAL - 1}");

                    // Output to file
                    outFile.WriteLine($"There are {rangeCount} numbers within the range {i} - {i + RANGE_INTERVAL - 1}");
                }

                WriteLine("Output to file");
            }
        }
    }
}
