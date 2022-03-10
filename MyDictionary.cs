using System;
using System.Collections;
using System.Collections.Generic;

namespace WordSplitter
{
    internal class MyDictionary : IEnumerable<KeyValuePair<string, List<Pair>>>
    {
        SortedDictionary<string, List<Pair>> _dictionary;

        public MyDictionary()
        {
            _dictionary = new SortedDictionary<string, List<Pair>>();
        }

        public bool ContainsKey(string key)
        {
            return _dictionary.ContainsKey(key);
        }

        public void Add(string key, int line, int position)
        {
            List<Pair> pairs;

            if (ContainsKey(key))
            {
                _dictionary[key].Add(new Pair(line, position));
            }
            else
            {
                pairs = new List<Pair>();
                pairs.Add(new Pair(line, position));
                _dictionary.Add(key, pairs);
            }
        }

        // Indexer
        public List<Pair> this[string key]
        {
            get
            {
                return _dictionary[key];
            }
            set
            {
                _dictionary[key] = value;
            }
        }

        // Enumerator
        public IEnumerator<KeyValuePair<string, List<Pair>>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
