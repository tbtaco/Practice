/*
 * Author: Tyler Richey
 * LeetCode: 34
 * Title: Find First and Last Position of Element in Sorted Array
 * Description: Find the first and last position of a target int in a sorted array of ints.
 * Difficulty: Medium
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 11/2/2021
 * Notes: 
 */

using System;

/*
34. Find First and Last Position of Element in Sorted Array
Medium

Given an array of integers nums sorted in non-decreasing order, find the starting and ending position of a given target value.

If target is not found in the array, return [-1, -1].

You must write an algorithm with O(log n) runtime complexity.

Example 1:

Input: nums = [5,7,7,8,8,10], target = 8
Output: [3,4]

Example 2:

Input: nums = [5,7,7,8,8,10], target = 6
Output: [-1,-1]

Example 3:

Input: nums = [], target = 0
Output: [-1,-1]

Constraints:

    0 <= nums.length <= 10^5
    -10^9 <= nums[i] <= 10^9
    nums is a non-decreasing array.
    -10^9 <= target <= 10^9
*/

namespace Practice
{
    class LeetCode0034
    {
        // Test Case
        public LeetCode0034()
        {
            try
            {
                int[] nums = new int[] { 0, 1, 2, 2, 3, 3, 4, 5, 6, 6, 7, 8, 9, 10 };
                int target = 6;

                Console.Write("Nums: [");
                for(int i = 0; i < nums.Length; i++)
                {
                    if (i > 0)
                        Console.Write(", ");
                    Console.Write(nums[i]);
                }
                Console.Write("]\nTarget: " + target + "\nOutput: [");

                int[] output = SearchRange(nums, target);

                for (int i = 0; i < output.Length; i++)
                {
                    if (i > 0)
                        Console.Write(", ");
                    Console.Write(output[i]);
                }
                Console.WriteLine("]");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public int[] SearchRange(int[] nums, int target)
        {
            int start = -1;
            int end = -1;

            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target)
                {
                    if (start == -1)
                        start = i;
                    end = i;
                }
                if (end != -1 && i > end)
                    break;
            }

            return new int[] { start, end };
        }
    }
}
