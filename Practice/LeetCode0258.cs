/*
 * Author: Tyler Richey
 * LeetCode: 258
 * Title: Add Digits
 * Description: Given an integer num, repeatedly add all its digits until the result has only one digit, and return it.
 * Difficulty: Easy
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 9/7/2023
 * Notes: 
 */

using System;

/*
258. Add Digits
Easy
Given an integer num, repeatedly add all its digits until the result has only one digit, and return it.

Example 1:
Input: num = 38
Output: 2
Explanation: The process is
38 --> 3 + 8 --> 11
11 --> 1 + 1 --> 2 
Since 2 has only one digit, return it.

Example 2:
Input: num = 0
Output: 0

Constraints:
    0 <= num <= 2^31 - 1

Follow up: Could you do it without any loop/recursion in O(1) runtime?
*/

namespace Practice
{
    class LeetCode0258
    {
        // Test Cases
        public LeetCode0258()
        {
            try
            {
                Random r = new Random();
                r.Next(); r.Next(); r.Next();

                for(int i = 1; i <= 7; i++)
                {
                    Console.Write("Test " + i + ":\n\tInput: ");
                    int input = r.Next(int.MaxValue);
                    Console.WriteLine(input + "\n\tOutput: " + AddDigits(input));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public int AddDigits(int num)
        {
            if (num <= 9)
                return num;

            int next = 0;
            while(num > 0)
            {
                next += num % 10;
                num /= 10;
            }
            return AddDigits(next);
        }
    }
}
