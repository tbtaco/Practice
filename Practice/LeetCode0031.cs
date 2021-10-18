﻿/*
 * Tyler Richey
 * LeetCode 31
 * 10/18/2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
31. Next Permutation
Medium

Implement next permutation, which rearranges numbers into the lexicographically next greater permutation of numbers.

If such an arrangement is not possible, it must rearrange it as the lowest possible order (i.e., sorted in ascending order).

The replacement must be in place and use only constant extra memory.

Example 1:

Input: nums = [1,2,3]
Output: [1,3,2]

Example 2:

Input: nums = [3,2,1]
Output: [1,2,3]

Example 3:

Input: nums = [1,1,5]
Output: [1,5,1]

Example 4:

Input: nums = [1]
Output: [1]

Constraints:

    1 <= nums.length <= 100
    0 <= nums[i] <= 100
*/

namespace Practice
{
    class LeetCode0031
    {
        private int[] nums;
        public LeetCode0031()
        {
            Random r = new Random();
            const int minLength = 1;
            const int maxLength = 100;
            const int minVal = 0;
            const int maxVal = 100;
            for(int i = 0; i < 10; i++)
            {
                nums = new int[r.Next(maxLength - minLength + 1) + minLength];
                Console.Write("Input: [");
                for (int j = 0; j < nums.Length; j++)
                {
                    nums[j] = r.Next(maxVal - minVal + 1) + minVal;
                    if (j != 0)
                        Console.Write(", ");
                    Console.Write(nums[j]);
                }
                Console.Write("]\nOutput: [");
                NextPermutation(nums);
                for(int j = 0; j < nums.Length; j++)
                {
                    if (j != 0)
                        Console.Write(", ");
                    Console.Write(nums[j]);
                }
                Console.Write("]\n\n");
            }
            //AnotherTest();
        }
        private void AnotherTest()
        {
            nums = new int[] { 1, 2, 3 }; //6 permutations
            for(int i = 0; i < 12; i++)
            {
                Console.Write("[");
                for (int j = 0; j < nums.Length; j++)
                {
                    if (j != 0)
                        Console.Write(", ");
                    Console.Write(nums[j]);
                }
                Console.WriteLine("]");
                NextPermutation(nums);
            }
        }
        public void NextPermutation(int[] nums)
        {
            if (nums.Length <= 1)
                return;

            bool alreadyOrdered = true;
            for(int k = 0; k < nums.Length - 1; k++)
                if (nums[k] < nums[k + 1])
                    alreadyOrdered = false;
            if (alreadyOrdered)
            {
                Reverse(nums, 0);
                return;
            }

            int i = nums.Length - 2;
            while (i > 0 && nums[i] >= nums[i + 1])
                i--;
            //var i is now the index of the num that is lower than the one on it's right
            //next I need the first index from the right that's higher than this num, as I can't assume it's right next to it
            int j = nums.Length - 1;
            while (nums[i] >= nums[j])
                j--;
            //var j is now the index of the num that is higher than var i
            //swap these two numbers, then reverse everything to the right of i
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
            Reverse(nums, i + 1);
        }
        private void Reverse(int[] nums, int start)
        {
            int i = start;
            int j = nums.Length - 1;
            while(i < j)
            {
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
                i++;
                j--;
            }
        }
    }
}
