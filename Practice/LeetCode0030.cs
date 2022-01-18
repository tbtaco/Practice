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
            String s = "barfoofoobarthefoobarman";
            String[] words = new string[] { "bar", "foo", "the" };

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
            IList<int> result = new List<int>();

            int totalLength = 0;
            for (int i = 0; i < words.Length; i++)
                totalLength += words[i].Length;
            if (totalLength > s.Length)
                return result;

            //I think I'll go through s substrings and check them that way, instead of going through each word possibility
            //This way it should be rather simple and I can write methods to just check if that substring works with those words





            return result;
        }
        private bool FirstLetterAppears(String s, String[] words)
        {
            if (s == null || s.Length == 0)
                return false;
            for(int i = 0; i < words.Length; i++)
            {
                if (words[i] != null && words[i].Length > 0)
                    if (s[0] == words[i][0])
                        return true;
            }
            return false;
        }
    }
}
