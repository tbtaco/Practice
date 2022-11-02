/*
 * Author: Tyler Richey
 * LeetCode: 36
 * Title: Valid Sudoku
 * Description: Check that a Sudoku board is valid. Rows, Columns, and Blocks must contain only 1-9 without repetition.
 * Difficulty: Medium
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 10/18/2021
 * Notes: 
 */

using System;

/*
36. Valid Sudoku
Medium

Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:

    Each row must contain the digits 1-9 without repetition.
    Each column must contain the digits 1-9 without repetition.
    Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.

Note:

    A Sudoku board (partially filled) could be valid but is not necessarily solvable.
    Only the filled cells need to be validated according to the mentioned rules.

Example 1:

Input: board = 
[["5","3",".",".","7",".",".",".","."]
,["6",".",".","1","9","5",".",".","."]
,[".","9","8",".",".",".",".","6","."]
,["8",".",".",".","6",".",".",".","3"]
,["4",".",".","8",".","3",".",".","1"]
,["7",".",".",".","2",".",".",".","6"]
,[".","6",".",".",".",".","2","8","."]
,[".",".",".","4","1","9",".",".","5"]
,[".",".",".",".","8",".",".","7","9"]]
Output: true

Example 2:

Input: board = 
[["8","3",".",".","7",".",".",".","."]
,["6",".",".","1","9","5",".",".","."]
,[".","9","8",".",".",".",".","6","."]
,["8",".",".",".","6",".",".",".","3"]
,["4",".",".","8",".","3",".",".","1"]
,["7",".",".",".","2",".",".",".","6"]
,[".","6",".",".",".",".","2","8","."]
,[".",".",".","4","1","9",".",".","5"]
,[".",".",".",".","8",".",".","7","9"]]
Output: false
Explanation: Same as Example 1, except with the 5 in the top left corner being modified to 8.
Since there are two 8's in the top left 3x3 sub-box, it is invalid.

Constraints:

    board.length == 9
    board[i].length == 9
    board[i][j] is a digit 1-9 or '.'.
*/

namespace Practice
{
    class LeetCode0036
    {
        // Test Cases
        public LeetCode0036()
        {
            try
            {
                char[][] board = new char[9][];

                board[0] = new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' };
                board[1] = new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' };
                board[2] = new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' };
                board[3] = new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' };
                board[4] = new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' };
                board[5] = new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' };
                board[6] = new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' };
                board[7] = new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' };
                board[8] = new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' };
                Console.WriteLine("Example 1 should be True, and my code returns " + IsValidSudoku(board));

                board[0] = new char[] { '8', '3', '.', '.', '7', '.', '.', '.', '.' };
                board[1] = new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' };
                board[2] = new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' };
                board[3] = new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' };
                board[4] = new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' };
                board[5] = new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' };
                board[6] = new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' };
                board[7] = new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' };
                board[8] = new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' };
                Console.WriteLine("Example 2 should be False, and my code returns " + IsValidSudoku(board));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public bool IsValidSudoku(char[][] board)
        {
            bool[] blockCheck;

            for(int i = 0; i < board.Length; i++) // Rows
            {
                blockCheck = new bool[9];
                for(int j = 0; j < board[i].Length; j++)
                {
                    if(board[i][j] != '.')
                    {
                        int num = board[i][j] - '0';
                        if (blockCheck[num - 1] == true)
                            return false;
                        blockCheck[num - 1] = true;
                    }
                }
            }

            for (int i = 0; i < board.Length; i++) // Columns
            {
                blockCheck = new bool[9];
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[j][i] != '.')
                    {
                        int num = board[j][i] - '0';
                        if (blockCheck[num - 1] == true)
                            return false;
                        blockCheck[num - 1] = true;
                    }
                }
            }

            for (int iStart = 0; iStart < 9; iStart+=3) // Blocks
                for(int jStart = 0; jStart < 9; jStart+=3)
                {
                    blockCheck = new bool[9];
                    for (int i = iStart; i < iStart + 3; i++)
                        for(int j = jStart; j < jStart + 3; j++)
                            if (board[i][j] != '.')
                            {
                                int num = board[i][j] - '0';
                                if (blockCheck[num - 1] == true)
                                    return false;
                                blockCheck[num - 1] = true;
                            }
                }

            return true;
        }
    }
}
