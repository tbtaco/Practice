/*
 * Author: Tyler Richey
 * LeetCode: 69
 * Title: Sqrt(x)
 * Description: Given a non-negative integer x, return the square root of x rounded down to the nearest integer. The returned integer should be non-negative as well.
 * Difficulty: Easy
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 9/14/2023
 * Notes: 
 */

using System;
using System.Collections.Generic;

/*
69. Sqrt(x)
Easy
Given a non-negative integer x, return the square root of x rounded down to the nearest integer. The returned integer should be non-negative as well.

You must not use any built-in exponent function or operator.
For example, do not use pow(x, 0.5) in c++ or x ** 0.5 in python.

Example 1:
Input: x = 4
Output: 2
Explanation: The square root of 4 is 2, so we return 2.

Example 2:
Input: x = 8
Output: 2
Explanation: The square root of 8 is 2.82842..., and since we round it down to the nearest integer, 2 is returned.

Constraints:
    0 <= x <= 2^31 - 1
*/

namespace Practice
{
    class LeetCode0069
    {
        // Test Cases
        public LeetCode0069()
        {
            try
            {
                Random r = new Random();
                r.Next(); r.Next(); r.Next();

                for(int i = 0; i <= 10; i++)
                {
                    int test = r.Next(10000);
                    Console.WriteLine("Input: " + test + ", Output: " + MySqrt(test) + ", Correct Answer: " + Math.Floor(Math.Sqrt(test)));
                }

                int t1 = 2147395600;
                Console.WriteLine("Input: " + t1 + ", Output: " + MySqrt(t1) + ", Correct Answer: " + Math.Floor(Math.Sqrt(t1)));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        private List<int> lookupList = new List<int>();
        public int MySqrt(int x)
        {
            for(int i = 0; i < lookupList.Count; i++)
                if (x < lookupList[i])
                    return i - 1;

            while (lookupList.Count <= 46340) //Overflows after this value
            {
                lookupList.Add(lookupList.Count * lookupList.Count);

                if (x < lookupList[lookupList.Count - 1])
                    return lookupList.Count - 2;
            }

            return lookupList.Count - 1;
        }
    }
}
