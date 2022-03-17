using System;
using System.Linq;
using System.Collections.Generic;

namespace WordSplitter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileReader = new FileReader();
            var lines = fileReader.GetLines();
            var lineReader = new LineReader(lines);
            var dictionary = lineReader.GetDictionary();

            // Sorting by occurrences and by alphabet
            var sortedDictionary = dictionary.OrderByDescending(d => d.Value.Count)
                                             .ThenBy(d => d.Key);

            dictionary = new Dictionary<string, List<Pair>>(sortedDictionary);
            PrintWords(dictionary);
            PrintInfo(dictionary);
        }

        static void PrintWords(Dictionary<string, List<Pair>> dictionary)
        {
            Console.WriteLine("\n Here's the list of the words:");
            foreach (var word in dictionary)
            {
                Console.Write("\n   < ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(word.Key);
                Console.ResetColor();
                Console.Write(" > - frequency: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(word.Value.Count);
                Console.ResetColor();
            }
        }

        static void PrintInfo(Dictionary<string, List<Pair>> dictionary)
        {
            Console.WriteLine();
            Console.WriteLine();
            bool wordIsEntered = false;
            string word = null;

            do
            {
                if (wordIsEntered)
                {
                    ConsoleCleaner.ClearConsoleLine();
                    Console.Write(" There's no such word in the list. Try again: ");
                }
                else
                {
                    Console.Write(" Enter the word from the list: ");
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                word = Console.ReadLine();
                wordIsEntered = true;
                Console.ResetColor();

                if (word != null && !dictionary.ContainsKey(word))
                {
                    word = null;
                }
            }
            while(word == null);

            Console.WriteLine();

            foreach(var pair in dictionary[word])
            {
                Console.WriteLine("   Line: {0}, position: {1}", pair.Line, pair.Position);
            }
        }


    }
}
