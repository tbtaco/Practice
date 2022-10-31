/*
 * Author: Tyler Richey
 * LeetCode: 5
 * Title: Longest Palindromic Substring
 * Description: Given a string, return the longest palindromic substring.
 * Difficulty: Medium
 * Status: Solved
 * Time Complexity: O(n^2)
 * Date: 6/25/2021
 * Notes: 
 */

using System;

/*
5. Longest Palindromic Substring
Medium

Given a string s, return the longest palindromic substring in s.

Example 1:

Input: s = "babad"
Output: "bab"
Note: "aba" is also a valid answer.

Example 2:

Input: s = "cbbd"
Output: "bb"

Example 3:

Input: s = "a"
Output: "a"

Example 4:

Input: s = "ac"
Output: "a"

Constraints:

1 <= s.length <= 1000
s consist of only digits and English letters (lower-case and/or upper-case),
*/

namespace Practice
{
    class LeetCode0005
    {
        // Test Case
        public LeetCode0005()
        {
            try
            {
                String input = "A palindrome is when something can be read the same forwards as backwards, so for example Racecar.";
                String output = LongestPalindrome(input);
                Console.WriteLine("Input: " + input);
                Console.WriteLine("Output: " + output);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public string LongestPalindrome(string s)
        {
            int x = 0;
            int length = 1;
            for(int i = 1; i < s.Length - 1; i++) // Checking for odd palindromes
            {
                int t = 1;
                while (i - t >= 0 && i + t < s.Length && s[i - t] == s[i + t])
                    t++;
                t--;
                if((t*2)+1>length)
                {
                    x = i - t;
                    length = (t * 2) + 1;
                }
            }
            for(int i = 0; i < s.Length - 1; i++) // Checking for even palindromes
                if(s[i] == s[i+1])
                {
                    int t = 1;
                    while (i - t >= 0 && i + t + 1 < s.Length && s[i - t] == s[i + t + 1])
                        t++;
                    t--;
                    if((t*2)+2>length)
                    {
                        x = i - t;
                        length = (t * 2) + 2;
                    }
                }
            return s.Substring(x, length);
        }
    }
}
