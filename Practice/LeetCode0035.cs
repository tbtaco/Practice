/*
 * Tyler Richey
 * LeetCode 35
 * 10/11/2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
35. Search Insert Position
Easy

Given a sorted array of distinct integers and a target value, return the index if the target is found.
If not, return the index where it would be if it were inserted in order.

You must write an algorithm with O(log n) runtime complexity.

Example 1:

Input: nums = [1,3,5,6], target = 5
Output: 2

Example 2:

Input: nums = [1,3,5,6], target = 2
Output: 1

Example 3:

Input: nums = [1,3,5,6], target = 7
Output: 4

Example 4:

Input: nums = [1,3,5,6], target = 0
Output: 0

Example 5:

Input: nums = [1], target = 0
Output: 0

Constraints:

    1 <= nums.length <= 10^4
    -10^4 <= nums[i] <= 10^4
    nums contains distinct values sorted in ascending order.
    -10^4 <= target <= 10^4
*/

namespace Practice
{
    class LeetCode0035
    {
        public LeetCode0035()
        {
            Random r = new Random();
            for(int i = 0; i < 10; i++)
            {
                Console.Write("Input: [");
                int[] input = new int[r.Next(15)];
                for(int j = 0; j < input.Length; j++)
                {
                    if (j == 0)
                        input[j] = r.Next(100) - r.Next(100);
                    else
                    {
                        input[j] = input[j - 1] + r.Next(20) + 1;
                        Console.Write(", ");
                    }
                    Console.Write(input[j]);
                }
                Console.Write("] Target: ");
                int target = r.Next(150);
                Console.Write(target + " Output: ");
                int output = SearchInsert(input, target);
                Console.WriteLine(output);
            }
        }
        public int SearchInsert(int[] nums, int target)
        {
            for(int i = 0; i < nums.Length; i++)
            {
                if (target <= nums[i])
                    return i;
                if (i == nums.Length - 1)
                    return i + 1;
            }
            return 0;
        }
    }
}
