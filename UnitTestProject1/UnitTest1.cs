using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HashLib;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        // This test just reads data from a file.  It should already work.
        public void T001_readWordTest()
        {
            // Read the first word from the file.
            using (WordStreamer words = new WordStreamer("../../../Frankenstein.txt"))
            {
                bool endOfFile = false;
                string firstWord = words.getNextWord(out endOfFile);
                Assert.AreEqual("project", firstWord);
            }
        }

        //// All the remaining tests should be implemented using an open hash with
        //// linear probe.  You must implement this hashtable as described to get
        //// get credit for the lab.

        [TestMethod]
        public void T002_containsTest()
        {
            // Create a hashtable with size HASH_TABLE_SIZE
            const int HASH_TABLE_SIZE = 19;
            HashWithLinearProbe<string, int> hashtable =
                new HashWithLinearProbe<string, int>(HASH_TABLE_SIZE);
            // Add one word to the table
            using (WordStreamer words = new WordStreamer("../../../Frankenstein.txt"))
            {
                bool endOfFile = false;
                string firstWord = words.getNextWord(out endOfFile);
                // The word should not exist in the empty symbol table.
                Assert.IsFalse(hashtable.Contains(firstWord));
            }
        }

        [TestMethod]
        public void T003_insertTest()
        {
            const int HASH_TABLE_SIZE = 19;
            HashWithLinearProbe<string, int> hashtable =
                new HashWithLinearProbe<string, int>(HASH_TABLE_SIZE);
            using (WordStreamer words = new WordStreamer("../../../Frankenstein.txt"))
            {
                bool endOfFile = false;
                string firstWord = words.getNextWord(out endOfFile);
                hashtable.Put(firstWord, 0);
                // The table contains the single word that was added.
                Assert.IsTrue(hashtable.Contains(firstWord));
            }
        }

        [TestMethod]
        public void T004_lookupTest()
        {
            const int HASH_TABLE_SIZE = 19;
            HashWithLinearProbe<string, int> hashtable =
                new HashWithLinearProbe<string, int>(HASH_TABLE_SIZE);
            using (WordStreamer words = new WordStreamer("../../../Frankenstein.txt"))
            {
                bool endOfFile = false;
                string firstWord = words.getNextWord(out endOfFile);
                const int FIRST_WORD_VALUE = 10;
                hashtable.Put(firstWord, FIRST_WORD_VALUE);
                Assert.IsTrue(hashtable.Contains(firstWord));
                Assert.AreEqual(FIRST_WORD_VALUE, hashtable.Get(firstWord));
            }
        }

        [TestMethod]
        public void T005_insertWithCollisions()
        {
            const int HASH_TABLE_SIZE = 31;
            HashWithLinearProbe<string, int> hashtable =
                new HashWithLinearProbe<string, int>(HASH_TABLE_SIZE);
            using (WordStreamer words = new WordStreamer("../../../Frankenstein.txt"))
            {
                bool endOfFile = false;
                List<string> word = new List<string>();
                while (word.Count < HASH_TABLE_SIZE)
                {
                    string nextWord = words.getNextWord(out endOfFile);
                    if (!word.Contains(nextWord))
                    {
                        word.Add(nextWord);
                        hashtable.Put(nextWord, word.Count);
                        Assert.IsTrue(hashtable.Contains(nextWord));
                        Assert.AreEqual(word.Count, hashtable.Get(nextWord));
                    }
                }

                // Find all the words in the hashtable
                for (int i = 0; i < HASH_TABLE_SIZE; i++)
                {
                    Assert.IsTrue(hashtable.Contains(word[i]));
                    Assert.AreEqual(i + 1, hashtable.Get(word[i]));
                }
            }
        }

        [TestMethod]
        public void T006_deleteTest()
        {
            const int HASH_TABLE_SIZE = 31;
            HashWithLinearProbe<string, int> hashtable =
                new HashWithLinearProbe<string, int>(HASH_TABLE_SIZE);
            using (WordStreamer words = new WordStreamer("../../../Frankenstein.txt"))
            {
                bool endOfFile = false;
                List<string> word = new List<string>();
                while (word.Count < HASH_TABLE_SIZE)
                {
                    string nextWord = words.getNextWord(out endOfFile);
                    if (!word.Contains(nextWord))
                    {
                        word.Add(nextWord);
                        hashtable.Put(nextWord, word.Count);
                    }
                }

                for (int i = 0; i < HASH_TABLE_SIZE; i++)
                {
                    hashtable.Delete(word[i]);
                    Assert.IsFalse(hashtable.Contains(word[i]));

                    for (int j = i + 1; j < HASH_TABLE_SIZE; j++)
                    {
                        Assert.IsTrue(hashtable.Contains(word[j]));
                        Assert.AreEqual(j + 1, hashtable.Get(word[j]));
                    }
                }
            }
        }


        [TestMethod]
        public void T007_countWords()
        {
            // Table size is prime number near 500000
            const int HASH_TABLE_SIZE = 524287;
            HashWithLinearProbe<string, int> hashtable =
                new HashWithLinearProbe<string, int>(HASH_TABLE_SIZE);

            int frankCount = 0;
            int theCount = 0;
            using (WordStreamer words = new WordStreamer("../../../Frankenstein.txt"))
            {
                bool endOfFile = false;
                while (!endOfFile)
                {
                    string nextWord = words.getNextWord(out endOfFile);
                    if (nextWord == "frankenstein") ++frankCount;
                    if (nextWord == "the") ++theCount;
                    if (!hashtable.Contains(nextWord))
                    {
                        hashtable.Put(nextWord, 1);
                    }
                    else
                    {
                        int currentCount = hashtable.Get(nextWord);
                        hashtable.Put(nextWord, currentCount + 1);
                    }
                }
            }
            Assert.AreEqual(frankCount, hashtable.Get("frankenstein"));
            Assert.AreEqual(theCount, hashtable.Get("the"));
            // end T007_countWords()
        }
    }
}
