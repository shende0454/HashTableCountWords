using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashLib
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Table size is prime number near 500000
            //const int HASH_TABLE_SIZE = 524287;
            //HashWithLinearProbe<string, int> hashtable =
            //    new HashWithLinearProbe<string, int>(HASH_TABLE_SIZE);

            //using (WordStreamer words = new WordStreamer("../../../Frankenstein.txt"))
            //{
            //    bool endOfFile = false;
            //    while (!endOfFile)
            //    {
            //        string nextWord = words.getNextWord(out endOfFile);
            //        if (!hashtable.Contains(nextWord))
            //        {
            //            hashtable.Put(nextWord, 1);
            //        }
            //        else
            //        {
            //            int currentCount = hashtable.Get(nextWord);
            //            hashtable.Put(nextWord, currentCount + 1);
            //        }
            //    }
            //}

            //List<HashTableEntry<string, int>> allKeys = 
            //    new List<HashTableEntry<string, int>>();
            //foreach(HashTableEntry<string, int> entry in hashtable)
            //{
            //    allKeys.Add(entry);
            //}
            //allKeys.Sort();

            //foreach (HashTableEntry<string, int> entry in allKeys)
            //{
            //    Console.WriteLine("{0} {1}", entry.Key, entry.Payload);
            //}

            //Console.ReadLine();
        }
    }
}
