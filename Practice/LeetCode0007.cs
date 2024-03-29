﻿/*
 * Author: Tyler Richey
 * LeetCode: 7
 * Title: Reverse Integer
 * Description: Reverse the digits of an integer.
 * Difficulty: Easy
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 6/29/2021
 * Notes: 
 */

using System;
using System.Collections.Generic;

/*
7. Reverse Integer
Easy

Given a signed 32-bit integer x, return x with its digits reversed.
If reversing x causes the value to go outside the signed 32-bit integer range [-2^31, 2^31 - 1], then return 0.
Assume the environment does not allow you to store 64-bit integers (signed or unsigned).

Example 1:

Input: x = 123
Output: 321

Example 2:

Input: x = -123
Output: -321

Example 3:

Input: x = 120
Output: 21

Example 4:

Input: x = 0
Output: 0

Constraints:

-2^31 <= x <= 2^31 - 1
*/

namespace Practice
{
    class LeetCode0007
    {
        // Test Case
        public LeetCode0007()
        {
            try
            {
                Random r = new Random();
                int input = r.Next(500000) - 250000;

                int result = Reverse(input);

                Console.WriteLine("Input: " + input);
                Console.WriteLine("Output: " + result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public int Reverse(int x)
        {
            List<int> nums = new List<int>();

            Boolean negative = x < 0;
            if (negative)
                x *= -1;

            while(x != 0)
            {
                nums.Add(x % 10);
                x /= 10;
            }

            if (nums.Count >= 10 && nums[0] > 2)
                return 0;

            int mult = 1;
            int result = 0;
            for(int i = nums.Count - 1; i >= 0; i--)
            {
                if (Int32.MaxValue - result - nums[i] * mult <= 0)
                    return 0;
                result += nums[i] * mult;
                mult *= 10;
            }

            if (negative)
                result *= -1;

            return result;
        }
    }
}
