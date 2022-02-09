/*
 * Tyler Richey
 * LeetCode 32
 * 2/9/2022
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
32. Longest Valid Parentheses
Hard

Given a string containing just the characters '(' and ')', find the length of the longest valid (well-formed) parentheses substring.

Example 1:

Input: s = "(()"
Output: 2
Explanation: The longest valid parentheses substring is "()".

Example 2:

Input: s = ")()())"
Output: 4
Explanation: The longest valid parentheses substring is "()()".

Example 3:

Input: s = ""
Output: 0

Constraints:

    0 <= s.length <= 3 * 10^4
    s[i] is '(', or ')'.
*/

namespace Practice
{
    class LeetCode0032
    {
        public LeetCode0032()
        {
            String[] tests = new string[] { "()()()", "))(())", "(()()))", "()())" };
            for(int i = 0; i < tests.Length; i++)
                Console.WriteLine("Test " + (i + 1) + ": \"" + tests[i] + "\", Output: " + LongestValidParentheses(tests[i]));
        }
        public int LongestValidParentheses(string s)
        {
            if (s.Length <= 1)
                return 0;
            if (s[0] == ')')
                return LongestValidParentheses(s.Substring(1));
            if (s[s.Length - 1] == '(')
                return LongestValidParentheses(s.Substring(0, s.Length - 1));

            if (s.Length % 2 == 0 && IsValid(s))
                return s.Length;
            if (s.Length % 2 == 1 && (IsValid(s.Substring(1)) || IsValid(s.Substring(0, s.Length - 1))))
                return s.Length - 1;

            return LongestValidParentheses(s, 0);
        }
        private int LongestValidParentheses(String s, int count)
        {


            throw new Exception("TODO");













        }
        private bool IsValid(string s) //Modified From LeetCode 20
        {
            //if (s.Length % 2 == 1)
            //    return false;
            int openingCharsCount = 0;
            foreach (char c in s.ToCharArray())
                if (c == '(')
                    openingCharsCount++;
                else
                {
                    if (openingCharsCount == 0)
                        return false;
                    openingCharsCount--;
                }
            return openingCharsCount == 0;
        }
    }
}
