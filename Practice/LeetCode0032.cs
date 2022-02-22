/*
 * Tyler Richey
 * LeetCode 32
 * 2/22/2022
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            for (int i = 0; i < tests.Length; i++)
                Console.WriteLine("Test " + (i + 1) + ": \"" + tests[i] + "\", Output: " + LongestValidParentheses(tests[i]));
        }
        public int LongestValidParentheses(string s)
        {
            int result = 0;

            //From the left
            int left = 0;
            int right = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    left++;
                else if (s[i] == ')')
                    right++;
                if (left == right && left + right > result)
                    result = left + right;
                if (left < right)
                {
                    left = 0;
                    right = 0;
                }
            }

            //From the right
            left = 0;
            right = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '(')
                    left++;
                else if (s[i] == ')')
                    right++;
                if (left == right && left + right > result)
                    result = left + right;
                if (left > right)
                {
                    left = 0;
                    right = 0;
                }
            }

            return result;
        }
    }
}
