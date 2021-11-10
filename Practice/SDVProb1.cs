/*
 * Tyler Richey
 * 11/10/2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Given a 2D array to represent space, where X denotes a wall or otherwise unusable location, S denotes the starting point,
E denotes an empty location, and C denotes an entity, I must write a program that finds all possible layouts such that
a player starting on S can travel along E and get within 1 block of C.  The player can only move up, down, left, right.  However the
player can reach all 8 adjacent cells.  The starting layout I need to solve for is below:

	Case 1 (Start on the Left)
    XXXXXXXXXXXXXXXXXXXX
    XXXSXXXXXXXXXXXXXXXX
    XX    X    X    XXXX
    X                 XX
    X                  X
    X                  X
    X                  X
    X                  X
    X                  X
    X                  X
    X                  X
    XX                 X
    XXXX               X
    XXXXXXXXXXXXXXXXXXXX

	Case 2 (Start on the Right)
    XXXXXXXXXXXXXXXXXXXX
    XXXXSXXXXXXXXXXXXXXX
    XX    X    X    XXXX
    X                 XX
    X                  X
    X                  X
    X                  X
    X                  X
    X                  X
    X                  X
    X                  X
    XX                 X
    XXXX               X
    XXXXXXXXXXXXXXXXXXXX
*/

namespace Practice
{
    class SDVProb1
    {
        public SDVProb1()
        {
            char[][] case1 = {
                new char[] {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
                new char[] {'X','X','X','S','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
                new char[] {'X','X','E','E','E','E','X','E','E','E','E','X','E','E','E','E','X','X','X','X'},
                new char[] {'X','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','X','X'},
                new char[] {'X','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','X'},
                new char[] {'X','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','X'},
                new char[] {'X','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','X'},
                new char[] {'X','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','X'},
                new char[] {'X','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','X'},
                new char[] {'X','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','X'},
                new char[] {'X','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','X'},
                new char[] {'X','X','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','X'},
                new char[] {'X','X','X','X','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','X'},
                new char[] {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'}};

            char[][] case2 = { //Could have modified case1 to move the start position
                new char[] {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
                new char[] {'X','X','X','X','S','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
                new char[] {'X','X','E','E','E','E','X','E','E','E','E','X','E','E','E','E','X','X','X','X'},
                new char[] {'X','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','X','X'},
                new char[] {'X','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','X'},
                new char[] {'X','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','X'},
                new char[] {'X','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','X'},
                new char[] {'X','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','X'},
                new char[] {'X','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','X'},
                new char[] {'X','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','X'},
                new char[] {'X','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','X'},
                new char[] {'X','X','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','X'},
                new char[] {'X','X','X','X','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','X'},
                new char[] {'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'}};

            char[][][] result1 = GetAllBestSolutions(case1);
            char[][][] result2 = GetAllBestSolutions(case2);

            //Will output solutions to look a little better than a lot of letters
            //Output a summary as well.  Count total spaces, used spaces, unused spaces, and number of solutions
















        }
        private char[][][] GetAllBestSolutions(char[][] map)
        {
            if (!IsValid(map))
                throw new Exception("Input map must have 1 start point and have a complete border containing only X.  " +
                    "Each array in the 2D array must also be the same length.");

            char[][][] solutions;
            int numberToTry = CountChars(map, 'E');


            throw new Exception("TODO");


            return null;
        }
        private char[][][] AddSolution(char[][][] solutions, char[][] s)
        {
            if (solutions == null)
                return new char[][][] { s };
            if(!AlreadyAdded(solutions, s))
            {
                char[][][] newSol = new char[solutions.Length + 1][][];
                for(int i = 0; i < newSol.Length; i++)
                {
                    if (i == newSol.Length - 1)
                        newSol[i] = s;
                    else
                        newSol[i] = solutions[i];
                }
                return newSol;
            }
            return solutions;
        }
        private bool AlreadyAdded(char[][][] solutions, char[][] s)
        {
            for (int i = 0; i < solutions.Length; i++)
                if (SolutionsAreTheSame(solutions[i], s))
                    return true;
            return false;
        }
        private bool SolutionsAreTheSame(char[][] s1, char[][] s2)
        {
            if (s1.Length != s2.Length)
                return false;
            for(int i = 0; i < s1.Length; i++)
            {
                if (s1[i].Length != s2[i].Length)
                    return false;
                for(int j = 0; j < s1[i].Length; j++)
                    if (s1[i][j] != s2[i][j])
                        return false;
            }
            return true;
        }
        private bool IsValid(char[][] map)
        {
            int length = 0;
            for(int i = 0; i < map.Length; i++)
            {
                if(i == 0)
                {
                    length = map[i].Length;
                    for (int j = 0; j < length; j++)
                        if (map[i][j] != 'X')
                            return false;
                }
                if (map[i].Length != length)
                    return false;
                if (i == map.Length - 1)
                {
                    for (int j = 0; j < length; j++)
                        if (map[i][j] != 'X')
                            return false;
                }
                else
                {
                    if (map[i][0] != 'X' || map[i][length - 1] != 'X')
                        return false;
                }
            }
            return CountChars(map, 'S') == 1;
        }
        private int CountChars(char[][] map, char c)
        {
            int count = 0;
            for (int i = 0; i < map.Length; i++)
                for (int j = 0; j < map[i].Length; j++)
                    if (map[i][j] == c)
                        count++;
            return count;
        }
    }
}
