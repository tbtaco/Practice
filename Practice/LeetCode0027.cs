/*
 * Tyler Richey
 * LeetCode 27
 * 9/1/2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
27. Remove Element
Easy

Given an integer array nums and an integer val, remove all occurrences of val in nums in-place.
The relative order of the elements may be changed.

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
int val = ...; // Value to remove
int[] expectedNums = [...]; // The expected answer with correct length.
                            // It is sorted with no values equaling val.

int k = removeElement(nums, val); // Calls your implementation

assert k == expectedNums.length;
sort(nums, 0, k); // Sort the first k elements of nums
for (int i = 0; i < actualLength; i++) {
    assert nums[i] == expectedNums[i];
}

If all assertions pass, then your solution will be accepted.

Example 1:

Input: nums = [3,2,2,3], val = 3
Output: 2, nums = [2,2,_,_]
Explanation: Your function should return k = 2, with the first two elements of nums being 2.
It does not matter what you leave beyond the returned k (hence they are underscores).

Example 2:

Input: nums = [0,1,2,2,3,0,4,2], val = 2
Output: 5, nums = [0,1,4,0,3,_,_,_]
Explanation: Your function should return k = 5, with the first five elements of nums containing 0, 0, 1, 3, and 4.
Note that the five elements can be returned in any order.
It does not matter what you leave beyond the returned k (hence they are underscores).

Constraints:

    0 <= nums.length <= 100
    0 <= nums[i] <= 50
    0 <= val <= 100
*/

namespace Practice
{
    class LeetCode0027
    {
        public int[] test = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
        public LeetCode0027() //Copied and modified from LeetCode0026.cs
        {
            Console.Write("Input: [");
            for (int i = 0; i < test.Length; i++)
                if (i == 0)
                    Console.Write(test[i]);
                else
                    Console.Write(", " + test[i]);
            int toRemove = 1;
            Console.Write("]\nTo Remove: " + toRemove + "\nOutput k: ");
            int k = RemoveElement(test, toRemove);
            Console.Write(k + "\nOutput: [");
            for (int i = 0; i < k; i++)
                if (i == 0)
                    Console.Write(test[i]);
                else
                    Console.Write(", " + test[i]);
            Console.WriteLine("]");
            Console.WriteLine("(Just 1 test this time, but this one is easy)");
        }
        public int RemoveElement(int[] nums, int val) //Entire thing is similar to LeetCode0026.cs
        {
            if (nums.Length == 0)
                return 0;
            int removed = 0;
            for (int i = 0; i < nums.Length - removed; i++)
                if (nums[i] == val)
                {
                    shiftNumsLeft(nums, i);
                    i--;
                    removed++;
                }
            return nums.Length - removed;
        }
        private void shiftNumsLeft(int[] nums, int index) //Copied from LeetCode0026.cs
        {
            for (int j = index; j < nums.Length - 1; j++)
                nums[j] = nums[j + 1];
        }
    }
}
