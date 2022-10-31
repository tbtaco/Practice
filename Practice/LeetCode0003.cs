/*
 * Author: Tyler Richey
 * LeetCode: 3
 * Title: Longest Substring Without Repeating Characters
 * Description: Return the longest substring without repeating characters.
 * Difficulty: Medium
 * Status: Solved
 * Time Complexity: O(n^2)
 * Date: 6/24/2021
 * Notes: 
 */

using System;

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

0 <= s.length <= 5 * 10^4
s consists of English letters, digits, symbols and spaces.
*/

namespace Practice
{
    class LeetCode0003
    {
        // Test Case
        public LeetCode0003()
        {
            try
            {
                String testString = "Testing ABC12345 This is a test string to demonstrate that my LeetCode #3 solution works.  " +
                "Feel free to change this string to whatever you want.  I'm not going to design a random test for this one."; // 16
                Console.WriteLine("Input String: " + testString);
                Console.WriteLine("Length of longest substring: " + LengthOfLongestSubstring(testString));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
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
