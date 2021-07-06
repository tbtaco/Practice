/*
 * Tyler Richey
 * LeetCode 11
 * 7/6/2021
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
11. Container With Most Water
Medium

Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate (i, ai).
n vertical lines are drawn such that the two endpoints of the line i is at (i, ai) and (i, 0).
Find two lines, which, together with the x-axis forms a container, such that the container contains the most water.
Notice that you may not slant the container.

Example 1:

Input: height = [1,8,6,2,5,4,8,3,7]
Output: 49
Explanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7].
In this case, the max area of water (blue section) the container can contain is 49.

Example 2:

Input: height = [1,1]
Output: 1

Example 3:

Input: height = [4,3,2,1,4]
Output: 16

Example 4:

Input: height = [1,2,1]
Output: 2

Constraints:

n == height.length
2 <= n <= 10^5
0 <= height[i] <= 10^4
*/

namespace Practice
{
    class LeetCode0011
    {
        public LeetCode0011()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            int[][] tests = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 1, 1, 2 },
                new int[] { 7, 2, 7, 8, 1, 1, 1, 9 },
                new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 },
                new int[] { 0, 0, 0 },
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                new int[] { 10, 1, 10, 1000, 1, 1000 },
                GetNums(30),
                GetNums(200),
                GetNums(100000)
            };

            foreach(int[] test in tests)
            {
                if(test.Length < 500)
                {
                    Console.Write("Test: [" + test[0]);
                    for (int i = 1; i < test.Length; i++)
                        Console.Write(", " + test[i]);
                    Console.WriteLine("] Result: " + MaxArea(test));
                }
            }

            sw.Stop(); //About 15ms before changes (After my changes it's slower for short arrays, but could probably be sped up by changing how I handle variables.  Change it to use the Math class more for example)
            Console.WriteLine("Total Time: " + sw.ElapsedMilliseconds + "ms");
            Console.WriteLine("Starting new timer.  This may take a while...");
            sw.Restart();

            Console.WriteLine("Final Test Result: " + MaxArea(tests[tests.Length - 1]));

            sw.Stop(); //About 15.8s before changes (Not ms!) (After my changes, it runs larger arrays in 5ms or less)
            Console.WriteLine("Total Time: " + sw.ElapsedMilliseconds + "ms");
        }
        private int[] GetNums(int max)
        {
            Random r = new Random();
            int[] result = new int[max];
            for (int i = 0; i < result.Length; i++)
                result[i] = r.Next(10000 + 1);
            return result;
        }
        public int MaxArea(int[] height)
        {
            int max = 0;
            int i = 0;
            int j = height.Length - 1;

            while(i < j)
            {
                int h = height[i];
                if (height[j] < h)
                    h = height[j];
                h *= j - i;
                if (h > max)
                    max = h;

                if (height[i] > height[j]) //Doing it this way saves a Lot of time on larger arrays
                    j--;
                else
                    i++;
            }
            return max;
        }

        /* My first attempt works, but is slow.  Slow enough that the LeetCode system does not accept it.  Redoing above
        public int MaxArea(int[] height)
        {
            int max = 0;
            for(int i = 0; i < height.Length; i++)
                for (int j = i + 1; j < height.Length; j++)
                {
                    int h = height[i];
                    if (height[j] < h)
                        h = height[j];
                    h *= j - i;
                    if (h > max)
                        max = h;
                }
            return max;
        }
        */
    }
}
