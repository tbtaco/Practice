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

            throw new Exception("TODO: Output");





        }
        private char[][][] GetAllBestSolutions(char[][] map)
        {
            if (!IsValid(map))
                throw new Exception("Input map must have 1 start point and have a complete border containing only X.  " +
                    "Each array in the 2D array must also be the same length.");

            char[][][] solutions = new char[0][][];

            for(int i = CountChars(map, 'E'); i >= 0; i--)
            {
                Console.WriteLine("For loop for i = " + i);

                if (solutions.Length > 0)
                    return solutions;
                if (i == 0)
                    return AddSolution(solutions, map);
                bool[] p = InitializePermutation(CountChars(map, 'E'), i);
                while (true)
                {
                    PrintPermutation(p, i);

                    char[][] newMap = new char[map.Length][];
                    int index = 0;
                    for(int j = 0; j < newMap.Length; j++)
                    {
                        newMap[j] = new char[map[j].Length];
                        for (int k = 0; k < map[j].Length; k++)
                        {
                            if (map[j][k] == 'E')
                            {
                                if (p[index])
                                    newMap[j][k] = 'C';
                                else
                                    newMap[j][k] = 'E';
                                index++;
                            }
                            else
                                newMap[j][k] = map[j][k];
                        }
                    }
                    if (AllEntitiesAccessable(newMap))
                        solutions = AddSolution(solutions, newMap);

                    if (!NextPermutation(p, i))
                        break;
                }
            }
            return null;
        }
        private bool[] InitializePermutation(int t, int n)
        {
            bool[] p = new bool[t];
            for(int i = 0; i < p.Length; i++)
            {
                if(p.Length - n - i <= 0)
                    p[i] = true;
                else
                    p[i] = false;
            }
            return p;
        }
        private bool NextPermutation(bool[] p, int n)
        {
            if (Count(p) == p.Length)
                return false;
            for(int i = p.Length - 1; i >= 0; i--)
            {
                if(!p[i])
                {
                    p[i] = true;
                    for (int j = i + 1; j < p.Length; j++)
                        p[j] = false;
                    break;
                }
            }

            //Just brainstorming, I'll look at this more later
            //The problem is I'm currently going through each permutation one by one running far too much code
            //It takes forever and this can definitely be sped up quite a bit.  I have ideas, just need time

            //add true values to the lsb false values until count == n
            //if count == length return true for now but it'll be false next time this runs.  don't recursive call if count == length?  or maybe it's fine since count != n

            //what if count is higher than n, not lower?  return next permutation maybe?



            return true;
        }
        private void PrintPermutation(bool[] p, int n)
        {
            Console.Write("i: " + n + " [");
            if(p.Length <= 20)
                for(int i = 0; i < p.Length; i++)
                {
                    if (i > 0)
                        Console.Write(", ");
                    if(p[i])
                        Console.Write("1");
                    else
                        Console.Write("0");
                }
            else
            {
                for (int i = 0; i < 7; i++)
                {
                    if (i > 0)
                        Console.Write(", ");
                    if (p[i])
                        Console.Write("1");
                    else
                        Console.Write("0");
                }
                Console.Write("...");
                for (int i = p.Length - 8; i < p.Length; i++)
                    if (p[i])
                        Console.Write(", 1");
                    else
                        Console.Write(", 0");
            }
            Console.WriteLine("] c: " + Count(p));
        }
        private int Count(bool[] p)
        {
            int count = 0;
            foreach (bool b in p)
                if (b)
                    count++;
            return count;
        }
        private bool AllEntitiesAccessable(char[][] map)
        {
            bool[][] possibilities = new bool[map.Length][];
            for(int i = 0; i < possibilities.Length; i++)
            {
                possibilities[i] = new bool[map[i].Length];
                for(int j = 0; j < possibilities[i].Length; j++)
                    if (map[i][j] == 'C')
                        possibilities[i][j] = false;
                    else
                        possibilities[i][j] = true;
            }
            for(int i = 0; i < map.Length; i++)
                for(int j = 0; j < map[i].Length; j++)
                    if(map[i][j] == 'S') //Only 1 possible, so the above loops are just to find the coords
                        AddPossibilities(map, possibilities, i, j, 200);
            bool result = true;
            for (int i = 0; i < map.Length; i++)
                for (int j = 0; j < map[i].Length; j++)
                    if (!possibilities[i][j])
                        result = false;
            return result;
        }
        private void AddPossibilities(char[][] map, bool[][] possibilities, int i, int j, int limit)
            //To prevent going forever, I'll assume the longest path is somewhere around 200 movements.  I'll use this to recursively call
            //this function and add all possibilities that way.  It'll be called a LOT more than needed, but should find what I want it to find
            //I'll consider redoing this someday to not check any location that's already been checked
        {
            if (map[i][j] != 'E' || map[i][j] != 'S' || limit <= 0)
                return;
            for(int x = -1; x <= 1; x++)
                for(int y = -1; y <= 1; y++)
                    if (x != 0 && y != 0 && !possibilities[i + x][j + y])
                        possibilities[i + x][j + y] = map[i + x][j + y] == 'C';
            AddPossibilities(map, possibilities, i + 1, j, limit - 1);
            AddPossibilities(map, possibilities, i - 1, j, limit - 1);
            AddPossibilities(map, possibilities, i, j + 1, limit - 1);
            AddPossibilities(map, possibilities, i, j - 1, limit - 1);
        }
        private char[][][] AddSolution(char[][][] solutions, char[][] s)
        {
            Console.WriteLine("Adding Solution...");

            if (solutions.Length == 0)
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
