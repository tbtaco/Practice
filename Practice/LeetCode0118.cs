/*
 * Author: Tyler Richey
 * LeetCode: 118
 * Title: Pascal's Triangle
 * Description: Given an integer numRows, return the first numRows of Pascal's triangle.
 * Difficulty: Easy
 * Status: Solved
 * Time Complexity: O(n^2)
 * Date: 7/6/2023
 * Notes: 
 */

using System;
using System.Collections.Generic;

/*
118. Pascal's Triangle
Easy
Given an integer numRows, return the first numRows of Pascal's triangle.

In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:

Example 1:
Input: numRows = 5
Output: [[1],[1,1],[1,2,1],[1,3,3,1],[1,4,6,4,1]]

Example 2:
Input: numRows = 1
Output: [[1]]

Constraints:
    1 <= numRows <= 30
*/

namespace Practice
{
    class LeetCode0118
    {
        // Test Cases
        public LeetCode0118()
        {
            try
            {
                for (int i = 1; i <= 8; i++)
                {
                    Console.Write(i + ": [");
                    IList<IList<int>> result = Generate(i);
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
                    Console.WriteLine("]");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> result = new List<IList<int>>();

            for(int i = 0; i < numRows; i++)
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

            return result;
        }
    }
}
