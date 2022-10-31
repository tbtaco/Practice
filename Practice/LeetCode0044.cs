/*
 * Author: Tyler Richey
 * LeetCode: 44
 * Title: Wildcard Matching
 * Description: Wildcard Matching.
 * Difficulty: Hard
 * Status: Work In Progress
 * Time Complexity: TBD
 * Date: 4/18/2022
 * Notes: My solution works, however I need to redo it to improve performance. As is, LeetCode does not accept it.
 */

using System;

/*
44. Wildcard Matching
Hard

Given an input string (s) and a pattern (p), implement wildcard pattern matching with support for '?' and '*' where:

    '?' Matches any single character.
    '*' Matches any sequence of characters (including the empty sequence).

The matching should cover the entire input string (not partial).

Example 1:
Input: s = "aa", p = "a"
Output: false
Explanation: "a" does not match the entire string "aa".

Example 2:
Input: s = "aa", p = "*"
Output: true
Explanation: '*' matches any sequence.

Example 3:
Input: s = "cb", p = "?a"
Output: false
Explanation: '?' matches 'c', but the second letter is 'a', which does not match 'b'.

Constraints:

    0 <= s.length, p.length <= 2000
    s contains only lowercase English letters.
    p contains only lowercase English letters, '?' or '*'.
*/

namespace Practice
{
    class LeetCode0044
    {
        // Test Cases
        public LeetCode0044()
        {
            try
            {
                String[][] inputs = new String[][] {
                new String[] { "aa", "a" },
                new String[] { "aa", "*" },
                new String[] { "cb", "?a" },
                new String[] { "cb", "?b" },
                new String[] { "abc", "a?c" },
                new String[] { "testing", "*test*" },
                new String[] { "testing", "*te2st*" },
                new String[] { "", "************" },
                new String[] { "babbbbaabababaabbababaababaabbaabababbaaababbababaaaaaabbabaaaabababbabbababbbaaaababbbabbbbbbbbbbaabbb",
                    "b**bb**a**bba*b**a*bbb**aba***babbb*aa****aabb*bbb***a" } };

                for (int i = 0; i < inputs.Length; i++)
                {
                    Console.Write("Test " + (i + 1) + ": \n\tString: " + inputs[i][0] + "\n\tPattern: " + inputs[i][1] + "\n\tOutput: ");
                    Console.WriteLine(IsMatch(inputs[i][0], inputs[i][1]));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public bool IsMatch(string s, string p)
        {
            while (p.Length >= 2 && p[0] == '*' && p[1] == '*')
                return IsMatch(s, p.Substring(1));

            if (s.Length == 0 && p.Length == 0)
                return true;

            if (p == "*")
                return true;

            if (s.Length == 0 && p.Length > 0)
                return false;

            if (s.Length > 0 && p.Length == 0)
                return false;

            if (s[0] == p[0] || p[0] == '?')
                return IsMatch(s.Substring(1), p.Substring(1));

            if (s[s.Length - 1] == p[p.Length - 1] || p[p.Length - 1] == '?')
                return IsMatch(s.Substring(0, s.Length - 1), p.Substring(0, p.Length - 1));

            if(p[0] == '*') // I need to find a faster way to do this section.  There are currently far too many recursive calls
            {
                String temp = "";
                bool result = false;
                int countNormalChars = 0;
                for (int i = 0; i < s.Length; i++)
                    if (s[i] != '*')
                        countNormalChars++;

                if (s.Length < countNormalChars)
                    return false;

                while(!result && temp.Length < s.Length)
                {
                    if(IsMatch(s, temp + p.Substring(1)))
                        result = true;
                    temp = temp + s[temp.Length];
                }

                return result;
            }

            return false;
        }
    }
}
