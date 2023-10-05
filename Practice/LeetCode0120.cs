/*
 * Author: Tyler Richey
 * LeetCode: 120
 * Title: Triangle
 * Description: Given a triangle array, return the minimum path sum from top to bottom.
 * Difficulty: Medium
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 10/5/2013
 * Notes: 
 */

using System;
using System.Collections.Generic;

/*
120. Triangle
Medium
Given a triangle array, return the minimum path sum from top to bottom.

For each step, you may move to an adjacent number of the row below. More formally, if you are on index i on the current row, you may move to either index i or index i + 1 on the next row.

Example 1:
Input: triangle = [[2],[3,4],[6,5,7],[4,1,8,3]]
Output: 11
Explanation: The triangle looks like:
   2
  3 4
 6 5 7
4 1 8 3
The minimum path sum from top to bottom is 2 + 3 + 5 + 1 = 11 (underlined above).

Example 2:
Input: triangle = [[-10]]
Output: -10

Constraints:
    1 <= triangle.length <= 200
    triangle[0].length == 1
    triangle[i].length == triangle[i - 1].length + 1
    -10^4 <= triangle[i][j] <= 10^4

Follow up: Could you do this using only O(n) extra space, where n is the total number of rows in the triangle?
*/

namespace Practice
{
    class LeetCode0120
    {
        // Test Cases
        public LeetCode0120()
        {
            try
            {
                Random r = new Random();
                r.Next(); r.Next(); r.Next();

                for (int i = 0; i < 3; i++)
                {
                    IList<IList<int>> test = new List<IList<int>>();
                    for(int j = 0; j < r.Next(25); j++)
                    {
                        IList<int> row = new List<int>();
                        for(int k = 0; k < j + 1; k++)
                        {
                            row.Add(r.Next(10));
                        }
                        test.Add(row);
                    }
                    Console.WriteLine("Input Triangle " + (i + 1) + ":");
                    for(int j = 0; j < test.Count; j++)
                    {
                        for(int k = 0; k < test[j].Count; k++)
                        {
                            if (k == 0)
                            {
                                for (int l = 0; l < test.Count - j; l++)
                                    Console.Write(" ");
                                Console.Write(test[j][k]);
                                if (j == 0)
                                    Console.WriteLine();
                            }
                            else if (k == test[j].Count - 1)
                                Console.WriteLine(" " + test[j][k]);
                            else
                                Console.Write(" " + test[j][k]);
                        }
                    }
                    Console.Write("Output: " + MinimumTotal(test) + "\n\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        private IList<IList<IList<int>>> triangleWithSavedMins = null;
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            if (triangle == null || triangle.Count == 0)
                return 0;

            triangleWithSavedMins = null;

            return RecursiveMinimumTotal(triangle, 0, 0);
        }
        private int RecursiveMinimumTotal(IList<IList<int>> triangle, int startCol, int startRow)
        {
            if (startRow == triangle.Count)
                return 0;

            if (triangleWithSavedMins == null)
                triangleWithSavedMins = new List<IList<IList<int>>>();

            if (startRow == triangleWithSavedMins.Count)
                triangleWithSavedMins.Add(new List<IList<int>>());

            if (startCol == triangleWithSavedMins[startRow].Count)
                triangleWithSavedMins[startRow].Add(new List<int>());

            if (triangleWithSavedMins[startRow][startCol].Count == 0)
            {
                triangleWithSavedMins[startRow][startCol].Add(triangle[startRow][startCol]);
                int left = RecursiveMinimumTotal(triangle, startCol, startRow + 1);
                int right = RecursiveMinimumTotal(triangle, startCol + 1, startRow + 1);
                if (left < right)
                    triangleWithSavedMins[startRow][startCol].Add(triangleWithSavedMins[startRow][startCol][0] + left);
                else
                    triangleWithSavedMins[startRow][startCol].Add(triangleWithSavedMins[startRow][startCol][0] + right);
            }

            return triangleWithSavedMins[startRow][startCol][1];
        }
    }
}
