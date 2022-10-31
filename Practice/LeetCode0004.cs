/*
 * Author: Tyler Richey
 * LeetCode: 4
 * Title: Median of Two Sorted Arrays
 * Description: Given two sorted arrays, return the median.
 * Difficulty: Hard
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 6/25/2021
 * Notes: 
 */

using System;

/*
4. Median of Two Sorted Arrays
Hard

Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
The overall run time complexity should be O(log (m+n)).

Example 1:

Input: nums1 = [1,3], nums2 = [2]
Output: 2.00000
Explanation: merged array = [1,2,3] and median is 2.

Example 2:

Input: nums1 = [1,2], nums2 = [3,4]
Output: 2.50000
Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.

Example 3:

Input: nums1 = [0,0], nums2 = [0,0]
Output: 0.00000

Example 4:

Input: nums1 = [], nums2 = [1]
Output: 1.00000

Example 5:

Input: nums1 = [2], nums2 = []
Output: 2.00000

Constraints:

nums1.length == m
nums2.length == n
0 <= m <= 1000
0 <= n <= 1000
1 <= m + n <= 2000
-10^6 <= nums1[i], nums2[i] <= 10^6
*/

namespace Practice
{
    class LeetCode0004
    {
        // Test Cases
        public LeetCode0004()
        {
            try
            {
                Random r = new Random();
                int m = r.Next(1001);
                int n = r.Next(1001);
                if (m == n && m == 0)
                    m++;
                int[] nums1 = new int[m];
                int[] nums2 = new int[n];
                for (int i = 0; i < m; i++)
                    nums1[i] = r.Next(213) - 106;
                for (int i = 0; i < n; i++)
                    nums2[i] = r.Next(213) - 106;
                Sort(nums1);
                Sort(nums2);

                double result = FindMedianSortedArrays(nums1, nums2);

                Console.Write("Array 1: [");
                for (int i = 0; i < nums1.Length; i++)
                {
                    if (i != 0)
                        Console.Write(", ");
                    Console.Write(nums1[i]);
                }
                Console.WriteLine("]");
                Console.Write("Array 2: [");
                for (int i = 0; i < nums2.Length; i++)
                {
                    if (i != 0)
                        Console.Write(", ");
                    Console.Write(nums2[i]);
                }
                Console.WriteLine("]");
                Console.WriteLine("Median: " + result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        public void Sort(int[] n)
        {
            for(int i = 0; i < n.Length; i++)
            {
                int lowest = i;
                for(int j = i; j < n.Length; j++)
                    if (n[j] < n[lowest])
                        lowest = j;
                Swap(n, i, lowest);
            }
        }
        public void Swap(int[] n, int x, int y)
        {
            int temp = n[x];
            n[x] = n[y];
            n[y] = temp;
        }
        // Solution
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] combined = new int[nums1.Length + nums2.Length];
            int i = 0;
            int j = 0;
            for(int k = 0; k < nums1.Length + nums2.Length; k++)
            {
                if(i < nums1.Length && j < nums2.Length)
                {
                    if(nums1[i] < nums2[j])
                    {
                        combined[k] = nums1[i];
                        i++;
                    }
                    else
                    {
                        combined[k] = nums2[j];
                        j++;
                    }
                }
                else if(i < nums1.Length)
                {
                    combined[k] = nums1[i];
                    i++;
                }
                else
                {
                    combined[k] = nums2[j];
                    j++;
                }
            }
            double median = 0;
            if (combined.Length == 0)
                median = 0;
            else if (combined.Length % 2 == 0) // Even, so 2 numbers
                median = (combined[(combined.Length / 2) - 1] + combined[combined.Length / 2]) / 2.0;
            else // Odd
                median = combined[(combined.Length - 1) / 2];
            return median;
        }
    }
}
