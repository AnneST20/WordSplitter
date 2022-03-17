using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordSplitter
{
    internal class LineReader
    {
        //MyDictionary words;
        Dictionary<string, List<Pair>> words;

        public LineReader(string[] lines)
        {
            words  = new Dictionary<string, List<Pair>>();
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
            var regex = new Regex(@"(\w)[\'\-\w]*");
            var matches = regex.Matches(line);
            foreach (Match match in matches)
            {
                string word = match.Value.ToLower();
                if (!words.ContainsKey(word))
                {
                    words.Add(word, new List<Pair>());
                }
                words[word].Add(new Pair { Line = lineIndex, Position = totalIndex + match.Index });
            }
        }

        public Dictionary<string, List<Pair>> GetDictionary()
        {
            return words;
        }
    }
}
