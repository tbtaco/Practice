﻿/*
 * Author: Tyler Richey
 * LeetCode: 11
 * Title: Container With Most Water
 * Description: Given a list of integers representing heights and locations of barriers, return the max area/volume possible between barriers. "Container With Most Water"
 * Difficulty: Medium
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 7/6/2021
 * Notes: 
 */

using System;
using System.Diagnostics;

/*
11. Container With Most Water
Medium

Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate (i, ai).
n vertical lines are drawn such that the two endpoints of the line i is at (i, ai) and (i, 0).
Find two lines, which, together with the x-axis forms a container, such that the container contains the most water.
Notice that you may not slant the container.

Example 1:

Input: height = [1,8,6,2,5,4,8,3,7]
Output: 49
Explanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7].
In this case, the max area of water (blue section) the container can contain is 49.

Example 2:

Input: height = [1,1]
Output: 1

Example 3:

Input: height = [4,3,2,1,4]
Output: 16

Example 4:

Input: height = [1,2,1]
Output: 2

Constraints:

n == height.length
2 <= n <= 10^5
0 <= height[i] <= 10^4
*/

namespace Practice
{
    class LeetCode0011
    {
        // Test Cases
        public LeetCode0011()
        {
            const int MaxLengthToDisplay = 500;

            try
            {
                int[][] tests = new int[][]
                {
                new int[] { 1, 2, 3 },
                new int[] { 1, 1, 2 },
                new int[] { 7, 2, 7, 8, 1, 1, 1, 9 },
                new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 },
                new int[] { 0, 0, 0 },
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                new int[] { 10, 1, 10, 1000, 1, 1000 },
                GetNums(30),
                GetNums(200),
                GetNums(100000)
                };

                foreach (int[] test in tests)
                {
                    if(test.Length <= MaxLengthToDisplay)
                    {
                        Console.Write("Test: [" + test[0]);
                        for (int i = 1; i < test.Length; i++)
                            Console.Write(", " + test[i]);
                        Console.WriteLine("] Result: " + MaxArea(test));
                    }
                    else
                        Console.Write("Test: (Length is greater than " + MaxLengthToDisplay + " so skipping this) Result: " + MaxArea(test));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        private int[] GetNums(int max)
        {
            Random r = new Random();
            int[] result = new int[max];
            for (int i = 0; i < result.Length; i++)
                result[i] = r.Next(10000 + 1);
            return result;
        }
        // Solution
        public int MaxArea(int[] height)
        {
            int max = 0;
            int i = 0;
            int j = height.Length - 1;

            while(i < j)
            {
                int h = height[i];
                if (height[j] < h)
                    h = height[j];
                h *= j - i;

                if (h > max)
                    max = h;

                if (height[i] > height[j])
                    j--;

                else
                    i++;
            }
            return max;
        }
    }
}
