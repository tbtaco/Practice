/*
 * Author: Tyler Richey
 * LeetCode: 70
 * Title: Climbing Stairs
 * Description: You are climbing a staircase. It takes n steps to reach the top.
 * Difficulty: Easy
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 8/9/2023
 * Notes: 
 */

using System;
using System.Collections.Generic;

/*
70. Climbing Stairs
Easy
You are climbing a staircase. It takes n steps to reach the top.

Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

Example 1:
Input: n = 2
Output: 2
Explanation: There are two ways to climb to the top.
1. 1 step + 1 step
2. 2 steps

Example 2:
Input: n = 3
Output: 3
Explanation: There are three ways to climb to the top.
1. 1 step + 1 step + 1 step
2. 1 step + 2 steps
3. 2 steps + 1 step

Constraints:
    1 <= n <= 45
*/

namespace Practice
{
    class LeetCode0070
    {
        // Test Cases
        public LeetCode0070()
        {
            try
            {
                for(int test = 1; test <= 45; test++)
                    Console.WriteLine("Input: " + test + ", Output: " + ClimbStairs(test));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        private Dictionary<int, int> storedValues = new Dictionary<int, int>();
        public int ClimbStairs(int n)
        {
            // One thing to note here is ClimbStairs(n) = ClimbStairs(n - 1) + ClimbStairs(n - 2)
            // With that in mind, why don't I store some values so future calculations go smoother?  O(n)

            if (n <= 1)
                return 1;

            if (storedValues.ContainsKey(n))
                return storedValues[n];

            if (!storedValues.ContainsKey(n - 1))
                storedValues[n - 1] = ClimbStairs(n - 1);

            if (!storedValues.ContainsKey(n - 2))
                storedValues[n - 2] = ClimbStairs(n - 2);

            storedValues[n] = storedValues[n - 1] + storedValues[n - 2];
            return storedValues[n];
        }
    }
}
