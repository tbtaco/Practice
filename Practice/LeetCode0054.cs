/*
 * Author: Tyler Richey
 * LeetCode: 54
 * Title: Spiral Matrix
 * Description: Given an M x N matrix, return elements of the matrix in spiral order.
 * Difficulty: Medium
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 11/4/2022
 * Notes: 
 */

using System;
using System.Collections.Generic;

/*
54. Spiral Matrix
Medium

Given an m x n matrix, return all elements of the matrix in spiral order.

Example 1:

Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
Output: [1,2,3,6,9,8,7,4,5]

1 -> 2 -> 3
          v
4 -> 5    6
^         v
7 <- 8 <- 9

Example 2:

Input: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
Output: [1,2,3,4,8,12,11,10,9,5,6,7]

Constraints:

    m == matrix.length
    n == matrix[i].length
    1 <= m, n <= 10
    -100 <= matrix[i][j] <= 100
*/

namespace Practice
{
    class LeetCode0054
    {
        // Test Cases
        public LeetCode0054()
        {
            try
            {
                int[][][] tests = new int[][][]
                {
                    new int[][]
                    {
                        new int[] { 1, 2, 3 },
                        new int[] { 4, 5, 6 },
                        new int[] { 7, 8, 9 }
                    },
                    new int[][]
                    {
                        new int[] { 1, 2, 3, 4, 5 },
                        new int[] { 6, 7, 8, 9, 10 },
                        new int[] { 11, 12, 13, 14, 15 },
                        new int[] { 16, 17, 18, 19, 20 },
                        new int[] { 21, 22, 23, 24, 25 }
                    }
                };

                foreach (int[][] test in tests)
                {
                    Console.Write("Input: [");
                    for(int i = 0; i < test.Length; i++)
                    {
                        if (i > 0)
                            Console.Write(", ");
                        Console.Write("[");
                        for(int j = 0; j < test.Length; j++)
                        {
                            if (j > 0)
                                Console.Write(", ");
                            Console.Write(test[i][j]);
                        }
                        Console.Write("]");
                    }
                    Console.Write("]\nOutput: [");

                    IList<int> output = SpiralOrder(test);

                    for(int i = 0; i < output.Count; i++)
                    {
                        if (i > 0)
                            Console.Write(", ");
                        Console.Write(output[i]);
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
        public IList<int> SpiralOrder(int[][] matrix)
        {
            IList<int> result = new List<int>();

            int shell = 0;
            int direction = 0;

            int goal = matrix.Length * matrix[0].Length;

            int x = 0;
            int y = 0;

            while(true)
            {
                result.Add(matrix[y][x]);

                if (result.Count == goal)
                    break;

                switch(direction)
                {
                    case 0: // ->
                        if (x < matrix[y].Length - shell - 1)
                            x++;
                        else
                        {
                            direction++;
                            y++;
                        }
                        break;
                    case 1: // v
                        if (y < matrix.Length - shell - 1)
                            y++;
                        else
                        {
                            direction++;
                            x--;
                        }
                        break;
                    case 2: // <-
                        if (x > 0 + shell)
                            x--;
                        else
                        {
                            direction++;
                            y--;
                        }
                        break;
                    case 3: // ^
                        if (y > 0 + shell + 1)
                            y--;
                        else
                        {
                            direction = 0;
                            shell++;
                            x++;
                        }
                        break;
                }
            }

            return result;
        }
    }
}
