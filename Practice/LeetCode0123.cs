/*
 * Author: Tyler Richey
 * LeetCode: 123
 * Title: Best Time to Buy and Sell Stock III
 * Description: You are given an array prices where prices[i] is the price of a given stock on the ith day.
 * Difficulty: Hard
 * Status: Work In Progress
 * Time Complexity: TBD
 * Date: 8/7/2023
 * Notes: Similar to LeetCode 121 and 122 but I can complete at most 2 transactions to get my result.
 */

using System;

/*
123. Best Time to Buy and Sell Stock III
Hard
You are given an array prices where prices[i] is the price of a given stock on the ith day.

Find the maximum profit you can achieve. You may complete at most two transactions.
Note: You may not engage in multiple transactions simultaneously (i.e., you must sell the stock before you buy again).

Example 1:
Input: prices = [3,3,5,0,0,3,1,4]
Output: 6
Explanation: Buy on day 4 (price = 0) and sell on day 6 (price = 3), profit = 3-0 = 3.
Then buy on day 7 (price = 1) and sell on day 8 (price = 4), profit = 4-1 = 3.

Example 2:
Input: prices = [1,2,3,4,5]
Output: 4
Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit = 5-1 = 4.
Note that you cannot buy on day 1, buy on day 2 and sell them later, as you are engaging multiple transactions at the same time. You must sell before buying again.

Example 3:
Input: prices = [7,6,4,3,1]
Output: 0
Explanation: In this case, no transaction is done, i.e. max profit = 0.

Constraints:
    1 <= prices.length <= 10^5
    0 <= prices[i] <= 10^5
*/

namespace Practice
{
    class LeetCode0123
    {
        // Test Cases
        public LeetCode0123()
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
            if (prices.Length <= 1)
                return 0;

            int highestSell = 0;
            int secondHighestSell = 0;

            int currentBuy = prices[0];
            for(int i = 1; i < prices.Length; i++)
            {
                // I'll come back to this later.
            }

            return highestSell + secondHighestSell;
        }
    }
}
