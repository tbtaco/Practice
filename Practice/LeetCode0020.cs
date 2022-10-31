/*
 * Author: Tyler Richey
 * LeetCode: 20
 * Title: Valid Parentheses
 * Description: Check for valid parentheses.
 * Difficulty: Easy
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 8/9/2021
 * Notes: 
 */

using System;
using System.Collections.Generic;

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
        // Test Cases
        public LeetCode0020()
        {
            try
            {
                List<List<String>> tests = new List<List<String>>();
                tests.Add(new List<String>() { "(){}[]", "True" });
                tests.Add(new List<String>() { "({[]})", "True" });
                tests.Add(new List<String>() { "(()", "False" });
                tests.Add(new List<String>() { "(", "False" });
                tests.Add(new List<String>() { "[]][][][[]][][][[]]", "False" });
                tests.Add(new List<String>() { "(()())", "True" });
                tests.Add(new List<String>() { "[({[]}{})()]", "True" });

                foreach (List<String> test in tests)
                    Console.WriteLine("Input: " + test[0] + ", Expected: " + test[1] + ", Output: " + IsValid(test[0]));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public bool IsValid(string s)
        {
            if (s.Length % 2 == 1)
                return false;

            List<char> openingChars = new List<char>(); // After completing, I see C# does have a Stack library which would be easier to use than using a List as a Stack.  Concept is the same here, but I could have simply Pushed and Popped.
            foreach(char c in s.ToCharArray())
            {
                if (c == '(' || c == '{' || c == '[')
                    openingChars.Add(c);
                else
                {
                    if (openingChars.Count == 0)
                        return false;
                    switch(openingChars[openingChars.Count - 1])
                    {
                        case '(':
                            if (c == ')')
                                openingChars.RemoveAt(openingChars.Count - 1);
                            else
                                return false;
                            break;
                        case '{':
                            if (c == '}')
                                openingChars.RemoveAt(openingChars.Count - 1);
                            else
                                return false;
                            break;
                        case '[':
                            if (c == ']')
                                openingChars.RemoveAt(openingChars.Count - 1);
                            else
                                return false;
                            break;
                    }
                }
            }

            return openingChars.Count == 0;
        }
    }
}
