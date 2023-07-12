/*
 * Author: Tyler Richey
 * LeetCode: 121
 * Title: Best Time to Buy and Sell Stock
 * Description: You are given an array prices where prices[i] is the price of a given stock on the ith day.
 * Difficulty: Easy
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 7/11/2023
 * Notes: 
 */

using System;

/*
121. Best Time to Buy and Sell Stock
Easy
You are given an array prices where prices[i] is the price of a given stock on the ith day.

You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.
Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.

Example 1:
Input: prices = [7,1,5,3,6,4]
Output: 5
Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

Example 2:
Input: prices = [7,6,4,3,1]
Output: 0
Explanation: In this case, no transactions are done and the max profit = 0.

Constraints:
    1 <= prices.length <= 10^5
    0 <= prices[i] <= 10^4
*/

namespace Practice
{
    class LeetCode0121
    {
        // Test Cases
        public LeetCode0121()
        {
            try
            {
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

            int[] fromLeft = new int[prices.Length];
            int tempMin = prices[0];
            fromLeft[0] = tempMin;
            for(int i = 1; i < fromLeft.Length; i++)
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
        }
    }
}
