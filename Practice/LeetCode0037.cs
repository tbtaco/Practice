/*
 * Tyler Richey
 * LeetCode 37
 * 10/20/2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
37. Sudoku Solver
Hard

Write a program to solve a Sudoku puzzle by filling the empty cells.

A sudoku solution must satisfy all of the following rules:

    Each of the digits 1-9 must occur exactly once in each row.
    Each of the digits 1-9 must occur exactly once in each column.
    Each of the digits 1-9 must occur exactly once in each of the 9 3x3 sub-boxes of the grid.

The '.' character indicates empty cells.

Example 1:

Input: board = [
["5","3",".",".","7",".",".",".","."],
["6",".",".","1","9","5",".",".","."],
[".","9","8",".",".",".",".","6","."],
["8",".",".",".","6",".",".",".","3"],
["4",".",".","8",".","3",".",".","1"],
["7",".",".",".","2",".",".",".","6"],
[".","6",".",".",".",".","2","8","."],
[".",".",".","4","1","9",".",".","5"],
[".",".",".",".","8",".",".","7","9"]]

Output: [
["5","3","4","6","7","8","9","1","2"],
["6","7","2","1","9","5","3","4","8"],
["1","9","8","3","4","2","5","6","7"],
["8","5","9","7","6","1","4","2","3"],
["4","2","6","8","5","3","7","9","1"],
["7","1","3","9","2","4","8","5","6"],
["9","6","1","5","3","7","2","8","4"],
["2","8","7","4","1","9","6","3","5"],
["3","4","5","2","8","6","1","7","9"]]

Explanation: The input board is shown above and the only valid solution is shown below:

Constraints:

    board.length == 9
    board[i].length == 9
    board[i][j] is a digit or '.'.
    It is guaranteed that the input board has only one solution.
*/

namespace Practice
{
    class LeetCode0037
    {
        private char[][] board;
        public LeetCode0037()
        {
            board = new char[9][];
            board[0] = new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' };
            board[1] = new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' };
            board[2] = new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' };
            board[3] = new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' };
            board[4] = new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' };
            board[5] = new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' };
            board[6] = new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' };
            board[7] = new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' };
            board[8] = new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' };
            Console.WriteLine("Sudoku puzzle 1 before solving:\n");
            PrintBoard(board);
            SolveSudoku(board);
            Console.WriteLine("\nSudoku puzzle 1 after solving:\n");
            PrintBoard(board);

            board[0] = new char[] { '.', '.', '9', '7', '4', '8', '.', '.', '.' };
            board[1] = new char[] { '7', '.', '.', '.', '.', '.', '.', '.', '.' };
            board[2] = new char[] { '.', '2', '.', '1', '.', '9', '.', '.', '.' };
            board[3] = new char[] { '.', '.', '7', '.', '.', '.', '2', '4', '.' };
            board[4] = new char[] { '.', '6', '4', '.', '1', '.', '5', '9', '.' };
            board[5] = new char[] { '.', '9', '8', '.', '.', '.', '3', '.', '.' };
            board[6] = new char[] { '.', '.', '.', '8', '.', '3', '.', '2', '.' };
            board[7] = new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '6' };
            board[8] = new char[] { '.', '.', '.', '2', '7', '5', '9', '.', '.' };
            Console.WriteLine("\nSudoku puzzle 2 before solving:\n");
            PrintBoard(board);
            SolveSudoku(board);
            Console.WriteLine("\nSudoku puzzle 2 after solving:\n");
            PrintBoard(board);
        }
        private SudokuCell[][] cells = new SudokuCell[9][];
        public void SolveSudoku(char[][] board)
        {
            cells = new SudokuCell[9][];
            for(int i = 0; i < 9; i++)
            {
                cells[i] = new SudokuCell[9];
                for(int j = 0; j < 9; j++)
                    cells[i][j] = new SudokuCell(board[i][j]);
            }
            int loop = 1;
            while(!BoardSolved(board))
            {
                for (int i = 0; i < 9; i++) //Adds limits on cells of a row.  A solved number can't be used in this row again
                    for (int j = 0; j < 9; j++)
                        for (int k = 0; k < 9; k++)
                            if (j != k)
                                cells[i][j].AddLimit(board[i][k]);

                for(int i = 0; i < 9; i++) //Adds limits on cells of a column.  A solved number can't be used in this column again
                    for (int j = 0; j < 9; j++)
                        for(int k = 0; k < 9; k++)
                            if (j != k)
                                cells[j][i].AddLimit(board[k][i]);

                for (int iStart = 0; iStart < 9; iStart += 3) //Adds limits on cells of a block.  A solved number can't be used in this block again
                    for (int jStart = 0; jStart < 9; jStart += 3)
                        for (int i = iStart; i < iStart + 3; i++)
                            for (int j = jStart; j < jStart + 3; j++)
                                for (int k = jStart; k < jStart + 3; k++)
                                    if (j != k)
                                        cells[i][j].AddLimit(board[i][k]);

                for (int i = 0; i < 9; i++) //Checks possibilities of a row to see if we can narrow down possibilities any
                    for (int num = 1; num <= 9; num++)
                    {
                        int numCount = 0;
                        for (int j = 0; j < 9; j++)
                            if (cells[i][j].HasPossibility(num))
                                numCount++;
                        if(numCount == 0)
                            throw new Exception("This row can't be solved for!  Is the Sudoku puzzle valid?");
                        if(numCount == 1) //We can rule out all other possibilities for this cell
                            for (int j = 0; j < 9; j++)
                                if (cells[i][j].HasPossibility(num))
                                    for(int k = 1; k <= 9; k++)
                                        if (k != num)
                                            cells[i][j].AddLimit(k);
                    }

                for(int i = 0; i < 9; i++) //Checks possibilities of a column to see if we can narrow down possibilities any
                    for (int num = 1; num <= 9; num++)
                    {
                        int numCount = 0;
                        for (int j = 0; j < 9; j++)
                            if (cells[j][i].HasPossibility(num))
                                numCount++;
                        if (numCount == 0)
                            throw new Exception("This row can't be solved for!  Is the Sudoku puzzle valid?");
                        if (numCount == 1) //We can rule out all other possibilities for this cell
                            for (int j = 0; j < 9; j++)
                                if (cells[j][i].HasPossibility(num))
                                    for (int k = 1; k <= 9; k++)
                                        if (k != num)
                                            cells[j][i].AddLimit(k);
                    }

                for (int iStart = 0; iStart < 9; iStart += 3) //Checks possibilities of a block to see if we can narrow down possibilities any
                    for (int jStart = 0; jStart < 9; jStart += 3)
                        for (int num = 1; num <= 9; num++)
                        {
                            int numCount = 0;
                            for (int i = iStart; i < iStart + 3; i++)
                                for (int j = jStart; j < jStart + 3; j++)
                                    if (cells[i][j].HasPossibility(num))
                                        numCount++;
                            if (numCount == 0)
                                throw new Exception("This block can't be solved for!  Is the Sudoku puzzle valid?");
                            if (numCount == 1) //We can rule out all other possibilities for this cell
                                for (int i = iStart; i < iStart + 3; i++)
                                    for (int j = jStart; j < jStart + 3; j++)
                                        if (cells[i][j].HasPossibility(num))
                                            for (int k = 1; k <= 9; k++)
                                                if (k != num)
                                                    cells[i][j].AddLimit(k);
                        }

                loop++;
                if (loop > 1000)
                {
                    Console.WriteLine("\nCurrent Board:\n");
                    PrintBoard(board);
                    Console.WriteLine("");
                    for(int i = 1; i <= 9; i++)
                    {
                        Console.WriteLine("Possibilities for the number " + i + "\n");
                        PrintPossibilities(cells, i);
                        Console.WriteLine("");
                    }

                    throw new Exception("Loop limit exceeded!");
                }
            }
        }
        private void PrintBoard(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                    Console.Write(board[i][j] + "  ");
                Console.WriteLine("");
            }
        }
        private void PrintPossibilities(SudokuCell[][] cells, int num)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                    if (cells[i][j].HasPossibility(num))
                    {
                        if ((int)(cells[i][j].GetVal() - '0') == num)
                            Console.Write(num + "  ");
                        else
                            Console.Write("?" + "  ");
                    }
                    else
                        Console.Write("." + "  ");
                Console.WriteLine("");
            }
        }
        private bool BoardSolved(char[][] board)
        {
            bool result = true;
            for (int i = 0; i < 9; i++) //If the board has an unsolved cell, check if there's only 1 possibility left for that cell and set it if so
                for (int j = 0; j < 9; j++)
                    if (board[i][j] == '.')
                    {
                        if (cells[i][j].Validate())
                        {
                            board[i][j] = cells[i][j].GetVal();

                            Console.WriteLine("Cell [" + i + "][" + j + "] has been set to " + cells[i][j].GetVal());
                            Console.WriteLine("\nCurrent Board:\n");
                            PrintBoard(board);
                            Console.WriteLine("\nPossibilities for the number " + (int)(cells[i][j].GetVal() - '0') + "\n");
                            PrintPossibilities(cells, (int)(cells[i][j].GetVal() - '0'));
                            Console.WriteLine("");
                        }
                        else
                            result = false;
                    }
            return result;
        }
    }
    class SudokuCell
    {
        private bool[] possibilities = new bool[9];
        private int value = 0;
        public SudokuCell(char c)
        {
            if (c == '.')
                for (int i = 0; i < 9; i++)
                    possibilities[i] = true;
            else
            {
                value = c - '0';
                possibilities[value - 1] = true;
            }
        }
        public bool Validate() //Returns True if the cell has been solved for.  False if more work needs to be done
        {
            if (value > 0)
                return true;
            int trueVals = 0;
            for (int i = 0; i < 9; i++)
                if (possibilities[i])
                    trueVals++;
            if(trueVals == 0)
                throw new Exception("This cell can't be solved for!  Is the Sudoku puzzle valid?");
            if (trueVals > 1)
                return false;
            for (int i = 0; i < 9; i++)
                if (possibilities[i])
                    value = i + 1;
            return true;
        }
        public char GetVal()
        {
            return (char)('0' + value);
        }
        public void AddLimit(char c)
        {
            if (c == '.')
                return;
            try
            {
                possibilities[c - '0' - 1] = false;
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
        }
        public void AddLimit(int i)
        {
            if (i == 0)
                return;
            possibilities[i - 1] = false;
        }
        public bool HasPossibility(int num)
        {
            return possibilities[num - 1];
        }
    }
}
