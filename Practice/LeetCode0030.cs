/*
 * Tyler Richey
 * LeetCode 30
 * 1/18/2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
30. Substring with Concatenation of All Words
Hard

You are given a string s and an array of strings words of the same length. Return all starting indices of substring(s)
in s that is a concatenation of each word in words exactly once, in any order, and without any intervening characters.

You can return the answer in any order.

Example 1:

Input: s = "barfoothefoobarman", words = ["foo","bar"]
Output: [0,9]
Explanation: Substrings starting at index 0 and 9 are "barfoo" and "foobar" respectively.
The output order does not matter, returning [9,0] is fine too.

Example 2:

Input: s = "wordgoodgoodgoodbestword", words = ["word","good","best","word"]
Output: []

Example 3:

Input: s = "barfoofoobarthefoobarman", words = ["bar","foo","the"]
Output: [6,9,12]

Constraints:

    1 <= s.length <= 10^4
    s consists of lower-case English letters.
    1 <= words.length <= 5000
    1 <= words[i].length <= 30
    words[i] consists of lower-case English letters.
*/

namespace Practice
{
    class LeetCode0030
    {
        public LeetCode0030()
        {
            String s = "wordgoodgoodgoodbestword";
            String[] words = new string[] { "word", "good", "best", "good" };

            Console.WriteLine("s = " + s);
            Console.Write("words = ");
            for(int i = 0; i < words.Length; i++)
            {
                if (i > 0)
                    Console.Write(", ");
                Console.Write(words[i]);
            }
            Console.Write("\noutput = [");

            IList<int> output = FindSubstring(s, words);

            for (int i = 0; i < output.Count; i++)
            {
                if (i > 0)
                    Console.Write(", ");
                Console.Write(output[i]);
            }
            Console.WriteLine("]");
        }
        public IList<int> FindSubstring(string s, string[] words)
        {
            List<Word> newWords = new List<Word>();
            foreach (String w in words)
            {
                bool added = false;
                foreach(Word x in newWords)
                    if (x.ToString() == w && !added)
                    {
                        x.AddOne();
                        added = true;
                    }
                if(!added)
                    newWords.Add(new Word(w));
            }

            if (GetTotalLength(newWords) < s.Length)
                return new List<int>();

            return FindSubstring(s, newWords);
        }
        private IList<int> FindSubstring(String s, List<Word> words)
        {
            IList<int> result = new List<int>();









            return result;
        }
        private int GetTotalLength(List<Word> words)
        {
            int l = 0;
            foreach (Word w in words)
                l += w.TotalLength;
            return l;
        }
        /*
        public IList<int> FindSubstring(string s, string[] words, int totalLength)
        {
            IList<int> result = new List<int>();

            for (int i = 0; i + totalLength <= s.Length; i++)
                if (SubstringExists(s.Substring(i, totalLength), words))
                    result.Add(i);

            return result;
        }
        private bool SubstringExists(String s, String[] words) //Recursive Method
        {
            if (s.Length == 0 && words.Length == 0) //Exit condition for the recursion
                return true;

            for(int i = 0; i < words.Length; i++)
                if(words[i] != null && words[i].Length > 0)
                    if(s.Substring(0, words[i].Length) == words[i])
                    {
                        String[] tempWords = new string[words.Length - 1];
                        int k = 0;
                        for(int j = 0; j < words.Length; j++)
                            if(i != j)
                            {
                                tempWords[k] = words[j];
                                k++;
                            }
                        if(SubstringExists(s.Substring(words[i].Length, s.Length - words[i].Length), tempWords)) //Recursive Call
                            return true;
                    }
            return false; //Exit condition for the recursion
        }
        */
    }
    class Word
    {
        private String word;
        private int count = 1;
        public Word(String word)
        {
            this.word = word;
        }
        public Word(String word, int count)
        {
            this.word = word;
            this.count = count;
        }
        public int Length { get { return word.Length; } }
        public int TotalLength { get { return word.Length * count; } }
        public override string ToString()
        {
            return word;
        }
        public void AddOne()
        {
            count++;
        }
    }
}
