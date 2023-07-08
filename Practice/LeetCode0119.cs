/*
 * Author: Tyler Richey
 * LeetCode: 119
 * Title: Pascal's Triangle II
 * Description: Given an integer rowIndex, return the rowIndexth (0-indexed) row of the Pascal's triangle.
 * Difficulty: Easy
 * Status: Solved
 * Time Complexity: O(n^2)
 * Date: 7/7/2023
 * Notes: I started with my solution to LeetCode 118 and modified to give just the last row.  I could then delete older rows that are no longer needed to minimize memory usage further.
 */

using System;
using System.Collections.Generic;

/*
119. Pascal's Triangle II
Easy
Given an integer rowIndex, return the rowIndexth (0-indexed) row of the Pascal's triangle.

In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:

Example 1:
Input: rowIndex = 3
Output: [1,3,3,1]

Example 2:
Input: rowIndex = 0
Output: [1]

Example 3:
Input: rowIndex = 1
Output: [1,1]

Constraints:
    0 <= rowIndex <= 33

Follow up: Could you optimize your algorithm to use only O(rowIndex) extra space?
*/

namespace Practice
{
    class LeetCode0119
    {
        // Test Cases
        public LeetCode0119()
        {
            try
            {
                for (int i = 1; i <= 20; i++)
                {
                    Console.Write(i + ": [");
                    IList<int> result = GetRow(i);
                    for (int j = 0; j < result.Count; j++)
                    {
                        if (j > 0)
                            Console.Write(", ");
                        Console.Write(result[j]);
                    }
                    Console.WriteLine("]");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public IList<int> GetRow(int rowIndex)
        {
            IList<IList<int>> result = new List<IList<int>>();

            for (int i = 0; i < rowIndex + 1; i++)
            {
                IList<int> row = new List<int>() { 1 };
                for (int j = 1; j < i + 1; j++)
                {
                    if (j == i)
                        row.Add(1);
                    else
                        row.Add(result[result.Count - 1][j - 1] + result[result.Count - 1][j]);
                }
                result.Add(row);
            }

            return result[result.Count - 1];
        }
    }
}
