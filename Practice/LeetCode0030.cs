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

            /*
            At this point I see that I've made the wrong assumption.  Each word can only be used as many times as it appears in
            the words array.  If "good" appears twice, it will be used twice.  From previous tests, I thought for some reason
            that words could be used any number of times, but up to the max length, or something like that.  Doesn't make any
            since now of course.  Next I think I'll be rewriting my code to support key value pairs {word, count} and do things that way.
            */





            //String s = "barfoofoobarthefoobarman";
            String s = "wordgoodgoodgoodbestword";
            //String[] words = new string[] { "bar", "foo", "the" };
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
            int totalLength = 0;
            for (int i = 0; i < words.Length; i++)
                totalLength += words[i].Length;
            if (totalLength > s.Length)
                return new List<int>();

            List<String> simplifiedWords = new List<String>(); //Remove duplicates
            for (int i = 0; i < words.Length; i++)
                if (!simplifiedWords.Contains(words[i]))
                    simplifiedWords.Add(words[i]);
            if (simplifiedWords.Count < words.Length)
            {
                String[] newWords = new string[simplifiedWords.Count];
                for (int i = 0; i < newWords.Length; i++)
                    newWords[i] = simplifiedWords[i];
                words = newWords;
            }

            return FindSubstring(s, words, totalLength);
        }
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
    }
}
