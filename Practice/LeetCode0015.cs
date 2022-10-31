/*
 * Author: Tyler Richey
 * LeetCode: 15
 * Title: 3Sum
 * Description: Given an integer array, return all triplets such that an indice is only used once per grouping, and the sum of the three is zero.
 * Difficulty: Medium
 * Status: Solved
 * Time Complexity: O(n^2)
 * Date: 8/2/2021
 * Notes: 
 */

using System;
using System.Collections.Generic;

/*
15. 3Sum
Medium

Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]]
such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
Notice that the solution set must not contain duplicate triplets.

Example 1:

Input: nums = [-1,0,1,2,-1,-4]
Output: [[-1,-1,2],[-1,0,1]]

Example 2:

Input: nums = []
Output: []

Example 3:

Input: nums = [0]
Output: []

Constraints:

    0 <= nums.length <= 3000
    -10^5 <= nums[i] <= 10^5
*/

namespace Practice
{
    class LeetCode0015
    {
        // Test Cases
        public LeetCode0015()
        {
            try
            {
                int maxLength = 3000; // Must be Positive
                int min = -10000; // Must be Negative
                int max = 10000; // Must be Positive
                int testCount = 4; // First will be length 0.  Rest will be random

                Random r = new Random();
                int nextLength = 0; // First test will be length of 0
                for (int i = 0; i < testCount; i++)
                {
                    int[] nums = new int[nextLength];
                    for (int j = 0; j < nums.Length; j++)
                        nums[j] = r.Next(max - min + 1) + min;

                    Console.Write("Input: [");
                    for (int j = 0; j < nums.Length; j++)
                    {
                        if (j > 0)
                            Console.Write(", ");
                        Console.Write(nums[j]);
                    }

                    Console.Write("] Output: [");
                    IList<IList<int>> result = ThreeSum(nums);
                    for (int j = 0; j < result.Count; j++)
                    {
                        if (j > 0)
                            Console.Write(", ");
                        Console.Write("[");
                        for (int k = 0; k < result[j].Count; k++)
                        {
                            if (k > 0)
                                Console.Write(", ");
                            Console.Write(result[j][k]);
                        }
                        Console.Write("]");
                    }
                    Console.WriteLine("]\n");

                    nextLength = r.Next(maxLength + 1);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> list = new List<IList<int>>();
            if (nums.Length < 3)
                return list;

            // A simple bubble sort
            for (int i = 0; i < nums.Length; i++)
                for (int j = 0; j < nums.Length - i - 1; j++)
                    if (nums[j] > nums[j + 1])
                    {
                        int t = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = t;
                    }

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int j = i + 1;
                int k = nums.Length - 1;
                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if (sum > 0)
                    {
                        k--;
                        while (j < k && nums[k] == nums[k + 1])
                            k--;
                    }
                    else if (sum < 0)
                    {
                        j++;
                        while (j < k && nums[j] == nums[j - 1])
                            j++;
                    }
                    else
                    {
                        List<int> l = new List<int> { nums[i], nums[j], nums[k] };
                        bool alreadyAdded = false;
                        for (int x = 0; x < list.Count; x++)
                            if (ListsEqual(list[x], l))
                                alreadyAdded = true;
                        if (!alreadyAdded)
                            list.Add(l);

                        j++;
                        while (j < k && nums[j] == nums[j - 1])
                            j++;
                    }
                }
            }
            return list;
        }
        private bool ListsEqual(IList<int> l, IList<int> m)
        {
            // Assumes lists have the same Count.  Adding in a check for this prevents my code from passing LeetCode's timing requirements...
            for (int i = 0; i < l.Count; i++)
                if (l[i] != m[i])
                    return false;

            return true;
        }
    }
}
