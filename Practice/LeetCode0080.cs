/*
 * Author: Tyler Richey
 * LeetCode: 80
 * Title: Remove Duplicates from Sorted Array II
 * Description: Given an integer array nums sorted in non-decreasing order, remove some duplicates in-place such that each unique element appears at most twice. The relative order of the elements should be kept the same.
 * Difficulty: Medium
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 7/9/2023
 * Notes: 
 */

using System;

/*
80. Remove Duplicates from Sorted Array II
Medium
Given an integer array nums sorted in non-decreasing order, remove some duplicates in-place such that each unique element appears at most twice. The relative order of the elements should be kept the same.

Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the first part of the array nums. More formally, if there are k elements after removing the duplicates,
then the first k elements of nums should hold the final result. It does not matter what you leave beyond the first k elements.
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
Input: nums = [1,1,1,2,2,3]
Output: 5, nums = [1,1,2,2,3,_]
Explanation: Your function should return k = 5, with the first five elements of nums being 1, 1, 2, 2 and 3 respectively.
It does not matter what you leave beyond the returned k (hence they are underscores).

Example 2:
Input: nums = [0,0,1,1,1,1,2,3,3]
Output: 7, nums = [0,0,1,1,2,3,3,_,_]
Explanation: Your function should return k = 7, with the first seven elements of nums being 0, 0, 1, 1, 2, 3 and 3 respectively.
It does not matter what you leave beyond the returned k (hence they are underscores).

Constraints:
    1 <= nums.length <= 3 * 10^4
    -10^4 <= nums[i] <= 10^4
    nums is sorted in non-decreasing order.
*/

namespace Practice
{
    class LeetCode0080
    {
        // Test Cases
        public LeetCode0080()
        {
            try
            {
                Random r = new Random();
                r.Next(); r.Next(); r.Next();

                Console.Write("Input:\n  [");
                int[] test = new int[r.Next(25)];
                for(int i = 0; i < test.Length; i++)
                {
                    if (i == 0)
                        test[i] = r.Next(50);
                    else
                        test[i] = test[i - 1] + r.Next(2);

                    if (i > 0)
                        Console.Write(", ");
                    Console.Write(test[i]);
                }

                int k = RemoveDuplicates(test);

                Console.Write("]\nResult:\n  k = " + k + "\n  [");
                for(int i = 0; i < k; i++)
                {
                    if (i > 0)
                        Console.Write(", ");
                    Console.Write(test[i]);
                }
                for(int i = k; i < test.Length; i++)
                {
                    if (i > 0)
                        Console.Write(", ");
                    Console.Write('_');
                }
                Console.WriteLine("]");
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

            int i = 0;
            int j = i + 2;
            int removed = 0;

            while(j < nums.Length)
            {
                if (nums[i] == nums[j])
                {
                    removed++;
                    j++;
                }
                else
                {
                    nums[j - removed] = nums[j];
                    if (j + 1 < nums.Length)
                        nums[j - removed + 1] = nums[j + 1];
                    i = j - removed;
                    j += 2;

                    if (i >= 1 && nums[i] == nums[i - 1])
                    {
                        i--;
                        j--;
                    }
                }
            }

            return nums.Length - removed;
        }
    }
}
