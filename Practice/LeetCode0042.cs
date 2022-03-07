/*
 * Tyler Richey
 * LeetCode 42
 * 3/7/2022
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
42. Trapping Rain Water
Hard

Given n non-negative integers representing an elevation map where the width of each bar is 1,
compute how much water it can trap after raining.

Example 1:

Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
Output: 6
Explanation: The above elevation map (black section) is represented by array [0,1,0,2,1,0,1,3,2,1,2,1].
In this case, 6 units of rain water (blue section) are being trapped.

Example 2:

Input: height = [4,2,0,3,2,5]
Output: 9

Constraints:

    n == height.length
    1 <= n <= 2 * 10^4
    0 <= height[i] <= 10^5
*/

namespace Practice
{
    class LeetCode0042
    {
        private const int minLength = 30;
        private const int maxLength = 110;
        private const int minVal = 0;
        private const int maxVal = 25;
        private const int testCount = 5;
        public LeetCode0042()
        {
            Random r = new Random();
            r.Next(); r.Next(); r.Next();

            for(int i = 1; i <= testCount; i++)
            {
                Console.Write("Test " + i + ":\n\tInput: [");
                int[] input = new int[r.Next(maxLength - minLength + 1) + minLength];
                for(int j = 0; j < input.Length; j++)
                {
                    if (j > 0)
                        Console.Write(", ");
                    input[j] = r.Next(maxVal - minVal + 1) + minVal;
                    Console.Write(input[j]);
                }
                Console.Write("]\n\n");
                PrintLayout(input);
                Console.WriteLine("\n\tOutput: " + Trap(input));
            }
        }
        private void PrintLayout(int[] height)
        {
            int maxHeight = 0;
            foreach (int i in height)
                if (i > maxHeight)
                    maxHeight = i;

            for (int i = maxHeight; i >= 0; i--)
            {
                Console.Write("\t");
                for (int j = 0; j < height.Length; j++)
                    if (height[j] >= i)
                        Console.Write("#");
                    else
                        Console.Write(".");
                Console.Write("\n");
            }
        }
        public int Trap(int[] height)
        {
            int maxHeight = 0;
            foreach (int i in height)
                if (i > maxHeight)
                    maxHeight = i;

            bool[][] mapLeft = new bool[maxHeight][];
            bool[][] mapRight = new bool[maxHeight][];

            int result = 0;


            //Computer is bugging out.  Done for now but I'll be back soon to follow through with these ideas


            /*
            int i = 0;
            bool cont = true;
            while (cont)
            {
                cont = false;
                int start = -1;
                int end = start;
                int invalidMiddleCount = 0;

                for (int j = 0; j < height.Length; j++)
                    if (height[j] >= i)
                    {
                        if (start < 0)
                        {
                            start = j;
                            cont = true;
                        }
                        else
                            invalidMiddleCount++;
                        end = j;
                    }

                if (start == end)
                    cont = false;
                result += end - start - invalidMiddleCount;
                i++;
            }
            */

            return result;
        }
        /*
        My new solution to this is much cleaner and I would have thought it'd run fast enough but I still get through 318 / 321 and fail due to
        the time limit being exceeded.  As is, I go through the array once to get the max height, then [max height] number of times checking each level.
        I've limited the number of complex objects I've created and simplified my math as much as I can imagine for now.
        I guess, do I even need a max height if I start from the ground and go up?  I'll make those changes now...

        Next I'll create a bool[][] from left, bool[][] from right, and when a && b add 1 to result
        I'll be going through the array twice, and each bool array quite a bit, but I'd like to try this approach...
        */
        /*
        public int Trap(int[] height)
        {
            int result = 0;

            int i = 0;
            bool cont = true;
            while(cont)
            {
                cont = false;
                int start = -1;
                int end = start;
                int invalidMiddleCount = 0;

                for (int j = 0; j < height.Length; j++)
                    if (height[j] >= i)
                    {
                        if (start < 0)
                        {
                            start = j;
                            cont = true;
                        }
                        else
                            invalidMiddleCount++;
                        end = j;
                    }

                if (start == end)
                    cont = false;
                result += end - start - invalidMiddleCount;
                i++;
            }

            return result;
        }
        */
        /*
        public int Trap(int[] height) //318 of 321 tests passed.  Time limit exceeded.  Think of a way to speed it up slightly...
        {
            int maxHeight = 0;
            foreach (int i in height)
                if (i > maxHeight)
                    maxHeight = i;

            bool[][] map = new bool[maxHeight + 1][];
            //Added a start and end to speed up GetSpaceCount() some.  I'll be able to ignore leading and/or trailing blank spaces
            int[] start = new int[maxHeight + 1];
            int[] end = new int[maxHeight + 1];
            for(int i = 0; i < maxHeight + 1; i++)
            {
                start[i] = -1;
                end[i] = -1;
            }
            for(int i = maxHeight; i >= 0; i--)
            {
                map[i] = new bool[height.Length];
                for (int j = 0; j < height.Length; j++)
                    if (height[j] >= i) //Else false, but it is initialized to all false so I'll leave that off
                    {
                        map[i][j] = true;
                        if (start[i] < 0)
                            start[i] = j;
                        end[i] = j;
                    }
            }

            int result = 0;
            for(int i = 0; i < map.Length; i++)
                result += GetSpaceCount(map[i], start[i], end[i]);

            return result;
        }
        private int GetSpaceCount(bool[] b, int start, int end)
        {
            int result = 0;
            int tempCount = 0;

            for(int i = start + 1; i <= end; i++)
                if(b[i])
                {
                    result += tempCount;
                    tempCount = 0;
                }
                else
                    tempCount++;

            return result;
        }
        */
    }
}
