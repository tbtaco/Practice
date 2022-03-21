/*
 * Tyler Richey
 * LeetCode 42
 * 3/21/2022
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
        private const int minLength = 30; //30
        private const int maxLength = 110; //110
        private const int minVal = 0; //0
        private const int maxVal = 25; //25
        private const int testCount = 5; //5
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
            int[] fromLeft = new int[height.Length];
            int tempMaxHeight = 0;
            for(int i = 0; i < fromLeft.Length; i++)
            {
                if (height[i] > tempMaxHeight)
                    tempMaxHeight = height[i];
                fromLeft[i] = tempMaxHeight;
            }
            int result = 0;
            tempMaxHeight = 0;
            for(int i = fromLeft.Length - 1; i >= 0; i--)
            {
                if (height[i] > tempMaxHeight)
                    tempMaxHeight = height[i];
                int lowest = tempMaxHeight;
                if (fromLeft[i] < lowest)
                    lowest = fromLeft[i];
                result += lowest - height[i];
            }
            return result;
        }
    }
}
