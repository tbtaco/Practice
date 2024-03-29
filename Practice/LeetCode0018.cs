﻿/*
 * Author: Tyler Richey
 * LeetCode: 18
 * Title: 4Sum
 * Description: Same as LeetCode0015.cs except with 4 numbers, not 3. As more numbers are added, timing becomes a larger factor.
 * Difficulty: Medium
 * Status: Solved
 * Time Complexity: O(n^3)
 * Date: 9/3/2021
 * Notes: 
 */

using System;
using System.Collections.Generic;

/*
18. 4Sum
Medium

Given an array nums of n integers, return an array of all the unique quadruplets [nums[a], nums[b], nums[c], nums[d]] such that:

    0 <= a, b, c, d < n
    a, b, c, and d are distinct.
    nums[a] + nums[b] + nums[c] + nums[d] == target

You may return the answer in any order.

Example 1:

Input: nums = [1,0,-1,0,-2,2], target = 0
Output: [[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]]

Example 2:

Input: nums = [2,2,2,2,2], target = 8
Output: [[2,2,2,2]]

Constraints:

    1 <= nums.length <= 200
    -10^9 <= nums[i] <= 10^9
    -10^9 <= target <= 10^9
*/

namespace Practice
{
    class LeetCode0018
    {
        // Test Cases
        public LeetCode0018()
        {
            try
            {
                const int minLength = 1; // These constants are just for testing and doesn't reflect the actual constraints
                const int maxLength = 50;
                const int minVal = -1000;
                const int maxVal = 1000;
                const int minTarget = minVal * 2;
                const int maxTarget = maxVal * 2;
                const int testCount = 5;

                Random r = new Random();

                for (int i = 0; i < testCount; i++)
                {
                    int[] nums = new int[r.Next(maxLength - minLength + 1) + minLength];
                    for (int j = 0; j < nums.Length; j++)
                        nums[j] = r.Next(maxVal - minVal + 1) + minVal;

                    Console.Write("Input: [");
                    for (int j = 0; j < nums.Length; j++)
                    {
                        if (j > 0)
                            Console.Write(", ");
                        Console.Write(nums[j]);
                    }

                    int target = r.Next(maxTarget - minTarget + 1) + minTarget;
                    Console.Write("]\nTarget: " + target + "\nOutput: [");

                    IList<IList<int>> result = FourSum(nums, target);
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
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (nums.Length < 4)
                return result;

            for(int i = 0; i < nums.Length - 1; i++)
                for (int j = 0; j < nums.Length - i - 1; j++)
                    if (nums[j] > nums[j + 1])
                    {
                        int t = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = t;
                    }

            // Approach:  In LeetCode0015.cs I solved 3Sum.  This is the same sort of problem, just with 4 numbers instead of 3.
            // So I'll copy my solution from there and modify it to obtain num1 and num2 in For loops, then use 3Sum on (num1 + num2) + num3 + num4 = target

            for(int i = 0; i < nums.Length - 3; i++)
            {
                for(int j = i + 1; j < nums.Length - 2; j++)
                {
                    int k = j + 1;
                    int l = nums.Length - 1;
                    while(k < l)
                    {
                        int sum = nums[i] + nums[j] + nums[k] + nums[l];
                        if(sum > target)
                        {
                            l--;
                            while (k < l && nums[l] == nums[l + 1])
                                l--;
                        }
                        else if(sum < target)
                        {
                            k++;
                            while (k < l && nums[k] == nums[k - 1])
                                k++;
                        }
                        else
                        {
                            List<int> n = new List<int> { nums[i], nums[j], nums[k], nums[l] };
                            bool alreadyAdded = false;
                            for (int x = 0; x < result.Count && !alreadyAdded; x++)
                                if (ListsEqual(result[x], n))
                                    alreadyAdded = true;
                            if (!alreadyAdded)
                                result.Add(n);
                            k++;
                            while (k < l && nums[k] == nums[k - 1])
                                k++;
                        }
                    }
                }
            }
            return result;
        }
        private bool ListsEqual(IList<int> l, IList<int> m)
        {
            for (int i = 0; i < l.Count; i++)
                if (l[i] != m[i])
                    return false;

            return true;
        }
    }
}
