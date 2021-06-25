/*
 * Tyler Richey
 * LeetCode 3
 * 6/24/2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
3. Longest Substring Without Repeating Characters
Medium

Given a string s, find the length of the longest substring without repeating characters.

Example 1:

Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.

Example 2:

Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.

Example 3:

Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.

Example 4:

Input: s = ""
Output: 0

Constraints:

0 <= s.length <= 5 * 104
s consists of English letters, digits, symbols and spaces.
*/

namespace Practice
{
    class LeetCode0003
    {
        public LeetCode0003()
        {
            String testString = "Testing ABC12345 This is a test string to demonstrate that my LeetCode #3 solution works.  " +
                "Feel free to change this string to whatever you want.  I'm not going to design a random test for this one."; //16
            //testString = "AABCDEFGACB"; //7
            Console.WriteLine("Input String: " + testString);
            Console.WriteLine("Length of longest substring: " + LengthOfLongestSubstring(testString));
        }
        public int LengthOfLongestSubstring(string s)
        {
            int result = 0;
            for(int i = 0; i < s.Length; i++)
            {
                int tempResult = 0;
                for(int j = i; j < s.Length; j++)
                {
                    char currentChar = s[j];
                    if (!s.Substring(i, j - i).Contains(currentChar))
                        tempResult++;
                    else
                        j = s.Length;
                }
                if (tempResult > result)
                    result = tempResult;
            }
            return result;
        }
    }
}
