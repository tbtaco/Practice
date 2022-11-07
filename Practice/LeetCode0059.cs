/*
 * Author: Tyler Richey
 * LeetCode: 59
 * Title: Spiral Matrix II
 * Description: Given a positive integer n, generate an n x n matrix filled with elements from 1 to n^2 in spiral order.
 * Difficulty: Medium
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 11/7/2022
 * Notes: 
 */

using System;
using System.Collections.Generic;
using System.Linq;

/*
59. Spiral Matrix II
Medium

Given a positive integer n, generate an n x n matrix filled with elements from 1 to n^2 in spiral order.

Example 1:

Input: n = 3
Output: [[1,2,3],[8,9,4],[7,6,5]]

Example 2:

Input: n = 1
Output: [[1]]

Constraints:

    1 <= n <= 20
*/

namespace Practice
{
    class LeetCode0059
    {
        // Test Cases
        public LeetCode0059()
        {
            try
            {
                for(int n = 1; n <= 20; n++)
                {
                    if (n >= 10)
                        Console.WriteLine(n + ": Creates a " + GenerateMatrix(n).Length + "^2 matrix (Code ran but not displayed)");

                    else
                    {
                        Console.Write(n + ":\n");

                        int[][] result = GenerateMatrix(n);

                        Console.Write("\t[");
                        for(int i = 0; i < result.Length; i++)
                        {
                            if (i > 0)
                                Console.Write(",\n\t ");
                            Console.Write("[");
                            for(int j = 0; j < result[i].Length; j++)
                            {
                                if (j > 0)
                                    Console.Write(", ");
                                Console.Write(result[i][j]);
                            }
                            Console.Write("]");
                        }
                        Console.Write("]\n\n");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public int[][] GenerateMatrix(int n) // Copied and modified solution from LeetCode 54
        {
            int[][] result = new int[n][];
            for(int i = 0; i < result.Length; i++)
                result[i] = new int[n];

            int shell = 0;
            int direction = 0;

            int goal = result.Length * result[0].Length;

            int x = 0;
            int y = 0;

            int num = 1;

            while (true)
            {
                result[y][x] = num;

                if (num >= goal)
                    break;

                switch (direction)
                {
                    case 0: // ->
                        if (x < result[y].Length - shell - 1)
                            x++;
                        else
                        {
                            direction++;
                            y++;
                        }
                        break;
                    case 1: // v
                        if (y < result.Length - shell - 1)
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

                num++;
            }

            return result;
        }
    }
}
