﻿/*
 * Author: Tyler Richey
 * LeetCode: 122
 * Title: Best Time to Buy and Sell Stock II
 * Description: You are given an integer array prices where prices[i] is the price of a given stock on the ith day.
 * Difficulty: Medium
 * Status: Work In Progress
 * Time Complexity: TBD
 * Date: 7/12/2023
 * Notes: Similar to LeetCode 121 except I can buy and sell multiple times instead of just one pair.
 */

using System;

/*
122. Best Time to Buy and Sell Stock II
Medium
You are given an integer array prices where prices[i] is the price of a given stock on the ith day.

On each day, you may decide to buy and/or sell the stock. You can only hold at most one share of the stock at any time. However, you can buy it then immediately sell it on the same day.
Find and return the maximum profit you can achieve.

Example 1:
Input: prices = [7,1,5,3,6,4]
Output: 7
Explanation: Buy on day 2 (price = 1) and sell on day 3 (price = 5), profit = 5-1 = 4.
Then buy on day 4 (price = 3) and sell on day 5 (price = 6), profit = 6-3 = 3.
Total profit is 4 + 3 = 7.

Example 2:
Input: prices = [1,2,3,4,5]
Output: 4
Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit = 5-1 = 4.
Total profit is 4.

Example 3:
Input: prices = [7,6,4,3,1]
Output: 0
Explanation: There is no way to make a positive profit, so we never buy the stock to achieve the maximum profit of 0.

Constraints:
    1 <= prices.length <= 3 * 10^4
    0 <= prices[i] <= 10^4
*/

namespace Practice
{
    class LeetCode0122
    {
        // Test Cases
        public LeetCode0122()
        {
            try
            {
                // From LeetCode 121
                Random r = new Random();
                r.Next(); r.Next(); r.Next();

                Console.Write("Input: [");
                int[] input = new int[r.Next(30)];
                for (int i = 0; i < input.Length; i++)
                {
                    input[i] = r.Next(10);
                    if (i > 0)
                        Console.Write(", ");
                    Console.Write(input[i]);
                }
                Console.WriteLine("]\nOutput: " + MaxProfit(input));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public int MaxProfit(int[] prices)
        {
            /* Thoughts
            Low on time tonight so I'll continue this tomorrow.  I think my first approach to this will be use LeetCode 121's solution to
            get the max profit of a small section.  Modify the solution to return the buy and sell indexes, or better yet return two arrays
            from before and after these purchases.  Call the same on those until I get no profit at all from the arrays.
            This may not give the result I want but it's a start.  Until tomorrow.
            */

            throw new Exception("TODO");

            /* From LeetCode 121
            if (prices.Length <= 1)
                return 0;

            int[] fromLeft = new int[prices.Length];
            int tempMin = prices[0];
            fromLeft[0] = tempMin;
            for (int i = 1; i < fromLeft.Length; i++)
            {
                if (prices[i] < tempMin)
                    tempMin = prices[i];
                fromLeft[i] = tempMin;
            }

            int tempMax = 0;
            int overallMax = 0;
            for (int i = fromLeft.Length - 1; i >= 0; i--)
            {
                if (prices[i] > tempMax)
                    tempMax = prices[i];
                if (overallMax < tempMax - fromLeft[i])
                    overallMax = tempMax - fromLeft[i];
            }

            return overallMax;
            */
        }
    }
}
