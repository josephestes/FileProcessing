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
            int index = 0;
            int rangeCount;

            //Read the input file
            using (StreamReader reader = new StreamReader(FILENAME))
            {
                while (!reader.EndOfStream)
                {
                    if (int.TryParse(reader.ReadLine(), out numberIn))
                        numbers.Add(numberIn);
                }

                //Create the output file
                using (StreamWriter outFile = new StreamWriter("output.txt"))
                {
                    //Output details to user
                    WriteLine("Number Count: " + numbers.Count());
                    WriteLine("Smallest Number: " + numbers.Min());
                    WriteLine("Largest Number: " + numbers.Max());
                    WriteLine("Average of Numbers: " + numbers.Average());

                    //Output details to file
                    outFile.WriteLine("Number Count: " + numbers.Count());
                    outFile.WriteLine("Smallest Number: " + numbers.Min());
                    outFile.WriteLine("Largest Number: " + numbers.Max());
                    outFile.WriteLine("Average of Numbers: " + numbers.Average());

                    //Determine total numbers within each range
                    while (index < RANGE_LIMIT)
                    {
                        rangeCount = 0;

                        foreach (var number in numbers)
                        {
                            if (number >= index && number < (index + RANGE_INTERVAL))
                            {
                                rangeCount = rangeCount + 1;
                            }
                        }

                        //Output to user
                        WriteLine("There are {0} numbers within the range {1} - {2}", rangeCount, index, (index + RANGE_INTERVAL - 1));

                        //Output to file
                        outFile.WriteLine("There are {0} numbers within the range {1} - {2}", rangeCount, index, (index + RANGE_INTERVAL - 1));

                        index = index + RANGE_INTERVAL;
                    }

                    WriteLine("Output to file");
                }
            }
        }
    }
}