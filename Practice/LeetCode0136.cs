/*
 * Author: Tyler Richey
 * LeetCode: 136
 * Title: Single Number
 * Description: Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.
 * Difficulty: Easy
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 9/7/2023
 * Notes: 
 */

using System;
using System.Collections.Generic;

/*
136. Single Number
Easy
Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.

You must implement a solution with a linear runtime complexity and use only constant extra space.

Example 1:
Input: nums = [2,2,1]
Output: 1

Example 2:
Input: nums = [4,1,2,1,2]
Output: 4

Example 3:
Input: nums = [1]
Output: 1

Constraints:
    1 <= nums.length <= 3 * 10^4
    -3 * 10^4 <= nums[i] <= 3 * 10^4
    Each element in the array appears twice except for one element which appears only once.
*/

namespace Practice
{
    class LeetCode0136
    {
        // Test Cases
        public LeetCode0136()
        {
            try
            {
                int[] test = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

                Console.Write("Input: [");
                for(int i = 0; i < test.Length; i++)
                {
                    if (i > 0)
                        Console.Write(", ");
                    Console.Write(test[i]);
                }
                Console.WriteLine("]\nOutput: " + SingleNumber(test));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public int SingleNumber(int[] nums)
        {
            IList<int> stack = new List<int>();
            stack.Add(nums[0]);

            for(int i = 1; i < nums.Length; i++)
            {
                if (stack.Contains(nums[i]))
                    stack.Remove(nums[i]);
                else
                    stack.Add(nums[i]);
            }

            return stack[0];
        }
    }
}
