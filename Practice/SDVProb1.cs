/*
 * Tyler Richey
 * 11/15/2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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

            char[][][] result1 = GetAllBestSolutions(case1);
            
            for(int i = 0; i < result1.Length; i++)
            {
                Console.WriteLine("\nSolution " + (i + 1) + ":");
                PrintMap(result1[i]);
            }



            throw new Exception("TODO");



            char[][] case2 = {
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

            char[][][] result2 = GetAllBestSolutions(case2);

            for (int i = 0; i < result2.Length; i++)
            {
                Console.WriteLine("\nSolution " + (i + 1) + ":");
                PrintMap(result2[i]);
            }

            











        }
        private void PrintMap(char[][] map)
        {
            for (int i = 0; i < map.Length; i++)
            {
                Console.Write("[");
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (j != 0)
                        Console.Write(", ");
                    Console.Write(map[i][j]);
                }
                Console.WriteLine("]");
            }
        }
        private char[][][] GetAllBestSolutions(char[][] map)
        {
            if (!IsValid(map))
                throw new Exception("Input map must have 1 start point and have a complete border containing only X.  " +
                    "Each array in the 2D array must also be the same length.");

            char[][][] solutions = new char[0][][];

            /*
            Notes

            I believe my code will now work the way I intended.  It'll just take an insanely long amount of time to get the solution.
            Main reason for this is there are billions (and higher) of permutations for each amount of C added to the map.
            Everytime int i is incremented, it doubles the base time and also exponentially increases the calculation time.
            While int i is very low, or very high (close to CountChars(map, 'E')) there are fewer permutations to check.
            It will take the most time when int i is equal to CountChars(map, 'E') / 2, meaning there are an equal number of E and C.
            The solution I'm looking for will probably fall within this range so either I'll try running the program on a faster device
            for several days, or I'll need to find a way to narrow down permutations.  One easy fix would be if there is a
            C right below S, my test case shows that this would result in very few accessable C meaning it won't be a solution.
            Such a simple assumption (that holds true for my test cases only, but will work for what I want to find) will already cut
            calculation times in half!  (Removes a bit, meaning half the permutations)  I'm sure there are other ways of narrowing
            down the possibilities, but I plan on leaving things as they are for now.  The next step I'd be very interested in taking
            would be utilizing multiple threads to power through the calculations.  For now I'll try running the program starting
            at specific int i values and see if I can get results.  If it's taking too long and I find more spare time, I'll
            consider multiple threads more.
            */

            for(int i = 130; i >= 0; i--) // CountChars(map, 'E') instead of the constant I'm using now during testing
            {
                Console.WriteLine("Starting loop " + i);

                if (solutions.Length > 0)
                    return solutions;
                if (i == 0)
                    return AddSolution(solutions, map);
                bool[] p = InitializePermutation(CountChars(map, 'E'), i);
                while (true)
                {
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

                    if (!NextPermutation(p))
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
        public bool NextPermutation(bool[] p) //Base idea from LeetCode0031.cs
        {
            if (p.Length <= 1)
                return false;

            bool alreadyOrdered = true;
            for (int k = 0; k < p.Length - 1; k++)
                if (!p[k] && p[k + 1])
                    alreadyOrdered = false;
            if (alreadyOrdered)
                return false;

            int i = p.Length - 2;
            while (i > 0 && ((p[i] && !p[i + 1]) || (p[i] && p[i + 1]) || (!p[i] && !p[i + 1])))
                i--;
            int j = p.Length - 1;
            while (!p[j])
                j--;
            bool temp = p[i];
            p[i] = p[j];
            p[j] = temp;
            Reverse(p, i + 1);

            return true;
        }
        private void Reverse(bool[] p, int start) //Base idea from LeetCode0031.cs
        {
            int i = start;
            int j = p.Length - 1;
            while (i < j)
            {
                bool temp = p[i];
                p[i] = p[j];
                p[j] = temp;
                i++;
                j--;
            }
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
            bool[][] possibilities = new bool[map.Length][]; //Keeps track of C seen
            bool[][] checkedMap = new bool[map.Length][]; //Keeps track of E or S visited
            for (int i = 0; i < possibilities.Length; i++)
            {
                possibilities[i] = new bool[map[i].Length];
                checkedMap[i] = new bool[map[i].Length];
                for (int j = 0; j < possibilities[i].Length; j++)
                {
                    checkedMap[i][j] = false;
                    if (map[i][j] == 'C')
                        possibilities[i][j] = false;
                    else
                        possibilities[i][j] = true;
                }
            }

            for (int i = 0; i < map.Length; i++)
                for (int j = 0; j < map[i].Length; j++)
                    if (map[i][j] == 'S') //Only 1 possible, so the above loops are just to find the coords
                        AddPossibilities(map, possibilities, i, j, checkedMap);

            bool result = true;
            for (int i = 0; i < map.Length; i++)
                for (int j = 0; j < map[i].Length; j++)
                    if (!possibilities[i][j] && map[i][j] == 'C')
                        result = false;
            return result;
        }
        private void AddPossibilities(char[][] map, bool[][] possibilities, int i, int j, bool[][] checkedMap)
        {
            if (checkedMap[i][j])
                return;
            if(map[i][j] == 'E' || map[i][j] == 'S')
            {
                for (int x = -1; x <= 1; x++)
                    for (int y = -1; y <= 1; y++)
                        if (!(x == 0 && y == 0) && !possibilities[i + x][j + y])
                            possibilities[i + x][j + y] = map[i + x][j + y] == 'C';
                checkedMap[i][j] = true;
                AddPossibilities(map, possibilities, i + 1, j, checkedMap);
                AddPossibilities(map, possibilities, i - 1, j, checkedMap);
                AddPossibilities(map, possibilities, i, j + 1, checkedMap);
                AddPossibilities(map, possibilities, i, j - 1, checkedMap);
            }
        }
        private char[][][] AddSolution(char[][][] solutions, char[][] s)
        {
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
