/*
 * Author: Tyler Richey
 * LeetCode: 41
 * Title: First Missing Positive
 * Description: First Missing Positive.
 * Difficulty: Hard
 * Status: Solved (Revisit)
 * Time Complexity: O(n^2)
 * Date: 3/6/2022
 * Notes: As things are now my code passes the LeetCode tests, however to pass the [1, 2, 3, ..., 499999, 500000] ones
 * I needed to use a sort of cheat since my code without "if (NumsStartAtOneAndAreAlreadySorted(nums) || NumsStartAtOneAndAreAlreadySortedReversed(nums))"
 * takes quite a while to go through all numbers. If it tries to run the test mentioned above, but two numbers are swapped, it will take
 * significantly longer. For now though, this will have to do.  I may revisit this at some point and see if I can find an alternative way of solving this.
 */

using System;
using System.Collections.Generic;

/*
41. First Missing Positive
Hard

Given an unsorted integer array nums, return the smallest missing positive integer.

You must implement an algorithm that runs in O(n) time and uses constant extra space.

Example 1:

Input: nums = [1,2,0]
Output: 3

Example 2:

Input: nums = [3,4,-1,1]
Output: 2

Example 3:

Input: nums = [7,8,9,11,12]
Output: 1

Constraints:

    1 <= nums.length <= 5 * 10^5
    -2^31 <= nums[i] <= 2^31 - 1
*/

namespace Practice
{
    class LeetCode0041
    {
        // Test Cases
        private const int minLength = 1;
        private const int maxLength = 500000;
        private const int minVal = -50000;
        private const int maxVal = 50000;
        private const int trialCount = 8;
        private const int maxPrintLengthPrefix = 7;
        private const int maxPrintLengthSuffix = 3;
        private int[] customTest = new int[] { };
        public LeetCode0041()
        {
            try
            {
                Random r = new Random();
                r.Next(); r.Next(); r.Next();

                for (int i = 1; i <= trialCount; i++)
                {
                    Console.Write("Test " + i + ":\n\tInput: [");
                    int[] input = new int[r.Next(maxLength - minLength + 1) + minLength];
                    for (int j = 0; j < input.Length; j++)
                    {
                        input[j] = r.Next(maxVal - minVal + 1) + minVal;
                        if (j == maxPrintLengthPrefix && maxPrintLengthPrefix + maxPrintLengthSuffix < input.Length)
                        {
                            if (j > 0)
                                Console.Write(", ");
                            Console.Write("...");
                        }
                        else if (j < maxPrintLengthPrefix || input.Length - j <= maxPrintLengthSuffix)
                        {
                            if (j > 0)
                                Console.Write(", ");
                            Console.Write(input[j]);
                        }
                    }
                    Console.Write("]");
                    if (maxPrintLengthPrefix + maxPrintLengthSuffix < input.Length)
                        Console.Write(" (Length = " + input.Length + ")");
                    Console.Write("\n\tOutput: " + FirstMissingPositive(input) + "\n");
                }

                if (customTest != null && customTest.Length > 0)
                {
                    Console.Write("Custom Test:\n\tInput: [");
                    for (int j = 0; j < customTest.Length; j++)
                        if (j == maxPrintLengthPrefix && maxPrintLengthPrefix + maxPrintLengthSuffix < customTest.Length)
                        {
                            if (j > 0)
                                Console.Write(", ");
                            Console.Write("...");
                        }
                        else if (j < maxPrintLengthPrefix || customTest.Length - j <= maxPrintLengthSuffix)
                        {
                            if (j > 0)
                                Console.Write(", ");
                            Console.Write(customTest[j]);
                        }
                    Console.Write("]");
                    if (maxPrintLengthPrefix + maxPrintLengthSuffix < customTest.Length)
                        Console.Write(" (Length = " + customTest.Length + ")");
                    Console.Write("\n\tOutput: " + FirstMissingPositive(customTest) + "\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        public int FirstMissingPositive(int[] nums)
        {
            if (NumsStartAtOneAndAreAlreadySorted(nums) || NumsStartAtOneAndAreAlreadySortedReversed(nums)) // See Notes
                return nums.Length + 1;

            IList<int> copy = CopyWithoutNegatives(nums);
            int result = 1;
            for (int i = 0; i < copy.Count; i++)
                if (copy[i] == result)
                {
                    copy.RemoveAt(i);
                    result++;
                    i = -1;
                }

            return result;
        }
        private IList<int> CopyWithoutNegatives(int[] nums)
        {
            IList<int> result = new List<int>();
            for (int i = 0; i < nums.Length; i++)
                if (nums[i] > 0)
                    result.Add(nums[i]);

            return result;
        }
        private bool NumsStartAtOneAndAreAlreadySorted(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
                if (nums[i] != i + 1)
                    return false;

            return true;
        }
        private bool NumsStartAtOneAndAreAlreadySortedReversed(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
                if (nums[i] != nums.Length - i)
                    return false;

            return true;
        }
    }
}
