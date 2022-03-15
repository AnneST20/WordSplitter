using System;
using System.Linq;
using System.Collections.Generic;

namespace WordSplitter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileReader fileReader = new FileReader();
            string[] lines = fileReader.GetLines();
            LineReader lineReader = new LineReader(lines);

            Dictionary<string, List<Pair>> dictionary = lineReader.GetDictionary();

            // Sorting by occurences and by alphabeth
            var sortedDictionary = from item in dictionary
                                   orderby item.Key
                                   select item;

            sortedDictionary = from item in sortedDictionary
                         orderby item.Value.Count() descending
                         select item;

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

                if (!dictionary.ContainsKey(word))
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
