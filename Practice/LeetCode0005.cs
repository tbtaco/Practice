/*
 * Tyler Richey
 * LeetCode 5
 * 6/25/2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public LeetCode0005()
        {
            String input = "A palindrome is when something can be read the same forwards as backwards, so for example Racecar.";
            String output = LongestPalindrome(input);
            Console.WriteLine("Input: " + input);
            Console.WriteLine("Output: " + output);
        }
        public string LongestPalindrome(string s)
        {
            int x = 0;
            int length = 1;
            for(int i = 1; i < s.Length - 1; i++) //Checking for odd palindromes
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
            for(int i = 0; i < s.Length - 1; i++) //Checking for even palindromes
            {
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
            }
            return s.Substring(x, length);

            /*First attempt.  48/176 tests passed before the time limit was hit.  This does work though, just not as efficient
            for(int i = s.Length; i >= 0; i--) //Start at a max length of i and go down from there
                for(int j = 0; j + i <= s.Length; j++) //Start at 0 to i-1 and shift until there are no substrings of length i
                {
                    String sub = s.Substring(j, i).ToLower();
                    Boolean palindrome = true;
                    for(int x = 0; x < sub.Length / 2; x++)
                    {
                        int y = sub.Length - x - 1;
                        if (sub[x] != sub[y])
                            palindrome = false;
                    }
                    if (palindrome)
                        return s.Substring(j, i); //Returns the first one found since this will be the longest
                }
            return null;
            */
        }
    }
}
