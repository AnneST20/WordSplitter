using System;
using System.Text.RegularExpressions;

namespace WordSplitter
{
    internal class LineReader
    {
        MyDictionary words;

        public LineReader(string[] lines)
        {
            words = new MyDictionary();
            ReadLines(lines);
        }
        /// <summary>
        /// Read all the lines and adds all words to the dictionary
        /// </summary>
        /// <param name="lines">Array with all string lines</param>
        void ReadLines(string[] lines)
        {
            int lineIndex = 1;
            int totalIndex = 0;

            foreach (string line in lines)
            {
                ReadLine(line, totalIndex, lineIndex);
                totalIndex += line.Length;
                lineIndex++;
            }
        }
        /// <summary>
        /// Reads every word in the line that matches a special word-regex.
        /// Adds each word to the dictionary.
        /// </summary>
        /// <param name="line">A string with words</param>
        /// <param name="totalIndex">The sum of previous lines' length</param>
        /// <param name="lineIndex">The number of current line</param>
        void ReadLine(string line, int totalIndex, int lineIndex)
        {
            Regex regex = new Regex(@"(\w)[\'\-\w]*");
            Match match = regex.Match(line);
            while (match.Success)
            {
                string word = match.Value.ToLower();
                int location = match.Index;
                words.Add(word, lineIndex, location + totalIndex);

                match = match.NextMatch();
            }
        }

        public MyDictionary GetDictionary()
        {
            return words;
        }
    }
}
