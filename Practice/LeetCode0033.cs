/*
 * Tyler Richey
 * LeetCode 33
 * 11/8/2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
33. Search in Rotated Sorted Array
Medium

There is an integer array nums sorted in ascending order (with distinct values).

Prior to being passed to your function, nums is possibly rotated at an unknown pivot index k (1 <= k < nums.length)
such that the resulting array is [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed).
For example, [0,1,2,4,5,6,7] might be rotated at pivot index 3 and become [4,5,6,7,0,1,2].

Given the array nums after the possible rotation and an integer target,
return the index of target if it is in nums, or -1 if it is not in nums.

You must write an algorithm with O(log n) runtime complexity.

Example 1:

Input: nums = [4,5,6,7,0,1,2], target = 0
Output: 4

Example 2:

Input: nums = [4,5,6,7,0,1,2], target = 3
Output: -1

Example 3:

Input: nums = [1], target = 0
Output: -1

Constraints:

    1 <= nums.length <= 5000
    -10^4 <= nums[i] <= 10^4
    All values of nums are unique.
    nums is an ascending array that is possibly rotated.
    -10^4 <= target <= 10^4
*/

namespace Practice
{
    class LeetCode0033
    {
        public LeetCode0033()
        {
            const int numLengthMin = 1;
            const int numLengthMax = 5000;
            const int numValMin = -10000;
            const int numValMax = 10000;

            Random r = new Random();

            int numLength = r.Next(numLengthMax - numLengthMin + 1) + numLengthMin;

            int[] nums = new int[numLength];

            for (int i = 0; i < nums.Length; i++)
                nums[i] = numValMax + 1; //Initialize all to an impossible value

            for(int i = 0; i < nums.Length; i++)
            {
                int numVal = r.Next(numValMax - numValMin + 1) + numValMin;
                if (Search(nums, numVal) == -1)
                    nums[i] = numVal;
                else
                    i--; //Random number already present.  Try this index again
            }

            Sort(nums);

            Rotate(nums, r.Next(nums.Length));

            int target = r.Next(numValMax - numValMin + 1) + numValMin;

            int result = Search(nums, target);

            Console.Write("Searching for the index of the number " + target + " in the following array of numbers:\n[");
            for(int i = 0; i < nums.Length; i++)
            {
                if (i != 0)
                    Console.Write(", ");
                Console.Write(nums[i]);
            }
            Console.WriteLine("]");
            Console.WriteLine("Result: " + result);
        }
        private void Sort(int[] nums)
        {
            for(int i = 0; i < nums.Length - 1; i++)
                for(int j = 0; j < nums.Length - 1 - i; j++)
                    if (nums[j] > nums[j + 1])
                        Swap(nums, j, j + 1);
        }
        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
        private void Rotate(int[] nums, int r)
        {
            if (r == 0)
                return;
            if (r < 0)
                throw new Exception("Rotate int r is a negative number and must be positive!");

            int temp = nums[nums.Length - 1];
            for(int i = 0; i < nums.Length; i++)
            {
                int t = nums[i];
                nums[i] = temp;
                temp = t;
            }

            Rotate(nums, r - 1);
        }
        public int Search(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
                if (nums[i] == target)
                    return i;
            return -1;
        }
    }
}
