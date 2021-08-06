/*
 * Tyler Richey
 * LeetCode 20
 * 8/6/2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
20. Valid Parentheses
Easy

Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:

    Open brackets must be closed by the same type of brackets.
    Open brackets must be closed in the correct order.

Example 1:

Input: s = "()"
Output: true

Example 2:

Input: s = "()[]{}"
Output: true

Example 3:

Input: s = "(]"
Output: false

Example 4:

Input: s = "([)]"
Output: false

Example 5:

Input: s = "{[]}"
Output: true

Constraints:

    1 <= s.length <= 104
    s consists of parentheses only '()[]{}'.
*/

namespace Practice
{
    class LeetCode0020
    {
        public LeetCode0020()
        {
            throw new Exception("TODO");
        }
        public bool IsValid(string s) //Only works if there is complete symmetry, which may not be the case
        {
            if (s.Length == 0)
                return true;
            switch(s[0])
            {
                case '(':
                    if (s[s.Length - 1] == ')')
                        return IsValid(s.Substring(1, s.Length - 2));
                    break;
                case '{':
                    if (s[s.Length - 1] == '}')
                        return IsValid(s.Substring(1, s.Length - 2));
                    break;
                case '[':
                    if (s[s.Length - 1] == ']')
                        return IsValid(s.Substring(1, s.Length - 2));
                    break;
            }
            return false;
        }
    }
}
