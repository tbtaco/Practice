/*
 * Author: Tyler Richey
 * LeetCode: 9
 * Title: Palindrome Number
 * Description: Return a boolean to say if an integer is a palindrome.
 * Difficulty: Easy
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 7/1/2021
 * Notes: 
 */

using System;

/*
9. Palindrome Number
Easy

Given an integer x, return true if x is palindrome integer.
An integer is a palindrome when it reads the same backward as forward. For example, 121 is palindrome while 123 is not.

Example 1:

Input: x = 121
Output: true

Example 2:

Input: x = -121
Output: false
Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.

Example 3:

Input: x = 10
Output: false
Explanation: Reads 01 from right to left. Therefore it is not a palindrome.

Example 4:

Input: x = -101
Output: false

Constraints:

-2^31 <= x <= 2^31 - 1
*/

namespace Practice
{
    class LeetCode0009
    {
        // Test Cases
        public LeetCode0009()
        {
            try
            {
                int[] tests = { 0, 123, 121, 128464821, 129384421, -1, -121, -21314256 };

                foreach (int test in tests)
                {
                    Console.Write("Test: " + test + ", ");
                    Console.WriteLine("Result: " + IsPalindrome(test));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public bool IsPalindrome(int x)
        {
            String s = "" + x;

            for(int i = 0; i < s.Length / 2; i++)
                if (s[i] != s[s.Length - 1 - i])
                    return false;

            return true;
        }
    }
}
