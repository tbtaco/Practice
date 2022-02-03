/*
 * Tyler Richey
 * LeetCode 30
 * 2/3/2022
 */

using System;
using System.Collections.Generic;

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

            IList<int> result = new List<int>();

            if (GetTotalLength(newWords) > s.Length)
                return result;

            for (int i = 0; i <= s.Length - GetTotalLength(newWords); i++)
            {
                IList<Word> tempWords = CopyList(newWords);
                if (ValidSubstring(s.Substring(i, GetTotalLength(tempWords)), tempWords))
                    result.Add(i);
            }

            return result;
        }
        /*
        private String ListToString(IList<Word> words)
        {
            String result = "[";
            for(int i = 0; i < words.Count; i++)
            {
                if (i > 0)
                    result += ", ";
                result += words[i].ToString() + ":" + words[i].Count;
            }
            result += "]";
            return result;
        }
        */
        private IList<Word> CopyList(IList<Word> words)
        {
            IList<Word> newWords = new List<Word>();
            for (int i = 0; i < words.Count; i++)
                newWords.Add(new Word(words[i].ToString(), words[i].Count));
            return newWords;
        }
        private bool ValidSubstring(String s, IList<Word> words)
        {
            if (GetTotalLength(words) == 0 && s.Length == 0)
                return true;
            for(int i = 0; i < words.Count; i++)
                if(s.Substring(0, words[i].Length) == words[i].ToString())
                    if (ValidSubstring(s.Substring(words[i].Length), RemoveOneWord(CopyList(words), i)))
                        return true;
            return false;
        }
        private IList<Word> RemoveOneWord(IList<Word> words, int i)
        {
            if (words[i].Count > 1)
                words[i].RemoveOne();
            else
                words.RemoveAt(i);
            return words;
        }
        private int GetTotalLength(IList<Word> words)
        {
            int l = 0;
            foreach (Word w in words)
                l += w.TotalLength;
            return l;
        }
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
        public int Count { get { return count; } }
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
        public void RemoveOne()
        {
            count--;
            if (count <= 0)
                throw new Exception("Word count hit zero!");
        }
    }
}
