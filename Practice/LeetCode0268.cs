/*
 * Author: Tyler Richey
 * LeetCode: 268
 * Title: Missing Number
 * Description: Given an array nums containing n distinct numbers in the range [0, n], return the only number in the range that is missing from the array.
 * Difficulty: Easy
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 9/21/2023
 * Notes: 
 */

using System;

/*
268. Missing Number
Easy
Given an array nums containing n distinct numbers in the range [0, n], return the only number in the range that is missing from the array.

Example 1:
Input: nums = [3,0,1]
Output: 2
Explanation: n = 3 since there are 3 numbers, so all numbers are in the range [0,3]. 2 is the missing number in the range since it does not appear in nums.

Example 2:
Input: nums = [0,1]
Output: 2
Explanation: n = 2 since there are 2 numbers, so all numbers are in the range [0,2]. 2 is the missing number in the range since it does not appear in nums.

Example 3:
Input: nums = [9,6,4,2,3,5,7,0,1]
Output: 8
Explanation: n = 9 since there are 9 numbers, so all numbers are in the range [0,9]. 8 is the missing number in the range since it does not appear in nums.

Constraints:
    n == nums.length
    1 <= n <= 10^4
    0 <= nums[i] <= n
    All the numbers of nums are unique.

Follow up: Could you implement a solution using only O(1) extra space complexity and O(n) runtime complexity?
*/

namespace Practice
{
    class LeetCode0268
    {
        // Test Cases
        public LeetCode0268()
        {
            try
            {
                int[][] tests = new int[][] {
                    new int[] { 0, 1, 2, 3, 5 },
                    new int[] { 0, 1, 2, 3, 4, 5, 6, 7 },
                    new int[] { 3, 2, 1 } };

                foreach (int[] test in tests)
                {
                    Console.Write("Input: [");
                    for(int i = 0; i < test.Length; i++)
                    {
                        if (i > 0)
                            Console.Write(", ");
                        Console.Write(test[i]);
                    }
                    Console.WriteLine("], Output: " + MissingNumber(test));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public int MissingNumber(int[] nums)
        {
            int result = nums.Length;

            for(int i = 0; i < nums.Length; i++)
                result += i - nums[i];

            return result;
        }
    }
}
