/*
 * Tyler Richey
 * LeetCode 34
 * 11/2/2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public LeetCode0034()
        {
            Console.WriteLine("This one was very easy.  Not going to write a test this time.");
            int[] output = SearchRange(new int[] { 0, 1, 2, 2, 3, 3, 4, 5, 6, 6, 7, 8, 9, 10 }, 6);
        }
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
