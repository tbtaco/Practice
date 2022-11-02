/*
 * Author: Tyler Richey
 * LeetCode: 26
 * Title: Remove Duplicates from Sorted Array
 * Description: Given a sorted integer array, remove duplicates in-place and return how many integers remain.
 * Difficulty: Easy
 * Status: Solved
 * Time Complexity: O(n^2)
 * Date: 8/30/2021
 * Notes: 
 */

using System;

/*
26. Remove Duplicates from Sorted Array
Easy

Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place
such that each unique element appears only once. The relative order of the elements should be kept the same.

Since it is impossible to change the length of the array in some languages,
you must instead have the result be placed in the first part of the array nums.
More formally, if there are k elements after removing the duplicates,
then the first k elements of nums should hold the final result.
It does not matter what you leave beyond the first k elements.

Return k after placing the final result in the first k slots of nums.

Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.

Custom Judge:

The judge will test your solution with the following code:

int[] nums = [...]; // Input array
int[] expectedNums = [...]; // The expected answer with correct length

int k = removeDuplicates(nums); // Calls your implementation

assert k == expectedNums.length;
for (int i = 0; i < k; i++) {
    assert nums[i] == expectedNums[i];
}

If all assertions pass, then your solution will be accepted.

Example 1:

Input: nums = [1,1,2]
Output: 2, nums = [1,2,_]
Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
It does not matter what you leave beyond the returned k (hence they are underscores).

Example 2:

Input: nums = [0,0,1,1,1,2,2,3,3,4]
Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
It does not matter what you leave beyond the returned k (hence they are underscores).

Constraints:

    0 <= nums.length <= 3 * 10^4
    -100 <= nums[i] <= 100
    nums is sorted in non-decreasing order.
*/

namespace Practice
{
    class LeetCode0026
    {
        // Test Case
        public LeetCode0026()
        {
            try
            {
                int[] test = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };

                Console.Write("Input: [");
                for (int i = 0; i < test.Length; i++)
                    if (i == 0)
                        Console.Write(test[i]);
                    else
                        Console.Write(", " + test[i]);

                Console.Write("]\nOutput k: ");

                int k = RemoveDuplicates(test);

                Console.Write(k + "\nOutput: [");
                for (int i = 0; i < k; i++)
                    if (i == 0)
                        Console.Write(test[i]);
                    else
                        Console.Write(", " + test[i]);

                Console.WriteLine("]");

                Console.WriteLine("(Just 1 test this time, but this one is easy)");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length <= 1)
                return nums.Length;

            int removed = 0;
            for(int i = 0; i < nums.Length - removed - 1; i++)
                if(nums[i] == nums[i+1])
                {
                    shiftNumsLeft(nums, i);
                    i--;
                    removed++;
                }
            return nums.Length - removed;
        }
        private void shiftNumsLeft(int[] nums, int index)
        {
            for(int j = index; j < nums.Length - 1; j++)
                nums[j] = nums[j + 1];
        }
    }
}
