/*
 * Author: Tyler Richey
 * LeetCode: 1
 * Title: Two Sum
 * Description: Given an array of integers, return the indices for the two numbers that add to equal a target.
 * Difficulty: Easy
 * Status: Solved
 * Time Complexity: O(n^2)
 * Date: 6/23/2021
 * Notes: 
 */

using System;

/*
1. Two Sum
Easy

Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
You may assume that each input would have exactly one solution, and you may not use the same element twice.
You can return the answer in any order.

Example 1:

Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Output: Because nums[0] + nums[1] == 9, we return [0, 1].

Example 2:

Input: nums = [3,2,4], target = 6
Output: [1,2]

Example 3:

Input: nums = [3,3], target = 6
Output: [0,1]
 
Constraints:

2 <= nums.length <= 10^4
-10^9 <= nums[i] <= 10^9
-10^9 <= target <= 10^9
Only one valid answer exists.
*/

namespace Practice
{
    class LeetCode0001
    {
        // Test Cases
        public LeetCode0001()
        {
            try
            {
                Random r = new Random();
                int size = r.Next(103) + 2;
                int[] nums = new int[size];
                for (int i = 0; i < size; i++)
                    nums[i] = r.Next(219) - 109;
                int firstNum = r.Next(size + 1);
                int secondNum = r.Next(size + 1);
                while (secondNum == firstNum)
                    secondNum = r.Next(size + 1);
                int target = nums[firstNum] + nums[secondNum];

                int[] result = TwoSum(nums, target);

                Console.Write("nums: {" + nums[0]);
                for (int i = 1; i < size; i++)
                    Console.Write(", " + nums[i]);
                Console.WriteLine("}");
                Console.WriteLine("target: " + target);
                Console.Write("result: {" + result[0] + ", " + result[1] + "}");
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
                for (int j = i + 1; j < nums.Length; j++)
                    if (nums[i] + nums[j] == target)
                        return new int[] { i, j };
            return null; // If no solution, which should never happen in this case.
        }
    }
}
