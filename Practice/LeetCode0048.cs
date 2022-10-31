/*
 * Author: Tyler Richey
 * LeetCode: 48
 * Title: Rotate Image
 * Description: Given a square 2D matrix representing an image, rotate the image by 90 degrees clockwise.
 * Difficulty: Medium
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 7/11/2022
 * Notes: 
 */

using System;

/*
48. Rotate Image
Medium

You are given an n x n 2D matrix representing an image, rotate the image by 90 degrees (clockwise).
You have to rotate the image in-place, which means you have to modify the input 2D matrix directly. DO NOT allocate another 2D matrix and do the rotation.

Example 1:

Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
Output: [[7,4,1],[8,5,2],[9,6,3]]

Example 2:

Input: matrix = [[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]]
Output: [[15,13,2,5],[14,3,4,1],[12,6,8,9],[16,7,10,11]]

Constraints:

    n == matrix.length == matrix[i].length
    1 <= n <= 20
    -1000 <= matrix[i][j] <= 1000
*/

namespace Practice
{
    class LeetCode0048
    {
        // Test Case
        public LeetCode0048()
        {
            try
            {
                int[][] test = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } };
                Output("Input", test);

                Rotate(test);
                Output("Output Rotated Once", test);

                Rotate(test);
                Output("Output Rotated Twice", test);

                Rotate(test);
                Output("Output Rotated Three Times", test);

                Rotate(test);
                Output("Output Rotated Four Times (Should Equal Original Input)", test);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        private void Output(String s, int[][] matrix)
        {
            Console.Write(s + ":\n\t");
            for (int i = 0; i < matrix.Length; i++)
            {
                if (i > 0)
                    Console.Write("\n\t");
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (j > 0)
                        Console.Write(", ");
                    Console.Write(matrix[i][j]);
                }
            }
            Console.Write("\n\n");
        }
        // Solution
        public void Rotate(int[][] matrix)
        {
            for(int i = 0; i < matrix.Length / 2; i++) // Select Shell
            {
                for(int j = 0; j < matrix.Length - (2 * i) - 1; j++) // Traverse Shell
                {
                    /*
                        1   2

                        3   4

                    1   matrix[i + j][i]
                    2   matrix[i][matrix.Length - 1 - i - j]
                    3   matrix[matrix.Length - 1 - i][i + j]
                    4   matrix[matrix.Length - 1 - i - j][matrix.Length - 1 - i]
                    */

                    int temp = matrix[i + j][i]; // Cell 1

                    matrix[i + j][i] = matrix[matrix.Length - 1 - i][i + j]; // Cell 1 = Cell 3

                    matrix[matrix.Length - 1 - i][i + j] = matrix[matrix.Length - 1 - i - j][matrix.Length - 1 - i]; // Cell 3 = Cell 4

                    matrix[matrix.Length - 1 - i - j][matrix.Length - 1 - i] = matrix[i][matrix.Length - 1 - i - j]; // Cell 4 = Cell 2

                    matrix[i][matrix.Length - 1 - i - j] = temp; // Cell 2 = Original Cell 1
                }
            }
        }
    }
}
