using System;

namespace WordSplitter
{
    internal class Pair
    {
        public int Line { get; set; }
        public int Position { get; set; }

        public Pair() { }

        public Pair(int line, int position)
        {
            this.Line = line;
            this.Position = position;
        }
    };
}
