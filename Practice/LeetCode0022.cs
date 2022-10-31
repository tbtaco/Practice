/*
 * Author: Tyler Richey
 * LeetCode: 22
 * Title: Generate Parentheses
 * Description: Given an integer, generate a list containing all combinations of valid parentheses using that number of opening/closing parentheses pairs.
 * Difficulty: Medium
 * Status: Solved
 * Time Complexity: O(2^n)
 * Date: 8/11/2021
 * Notes: 
 */

using System;
using System.Collections.Generic;

/*
22. Generate Parentheses
Medium

Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

Example 1:

Input: n = 3
Output: ["((()))","(()())","(())()","()(())","()()()"]

Example 2:

Input: n = 1
Output: ["()"]

Constraints:

    1 <= n <= 8
*/

namespace Practice
{
    class LeetCode0022
    {
        // Test Cases
        public LeetCode0022()
        {
            try
            {
                for (int i = 1; i <= 8; i++)
                {
                    Console.WriteLine("Input: " + i + ", Output Count (Edit Code For Full Results): " + GenerateParenthesis(i).Count);

                    /*
                    Console.Write("Input: " + i + ", Output: [");
                    IList<String> output = GenerateParenthesis(i);
                    Console.Write(output[0]);
                    output.RemoveAt(0);
                    foreach (String s in output)
                        Console.Write(", " + s);
                    Console.WriteLine("]");
                    */
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        private IList<String> output = new List<String>();
        private int n = 0;
        // Solution
        public IList<string> GenerateParenthesis(int n)
        {
            output.Clear();
            this.n = n;

            GPRecursive("", 0, 0);

            return output;
        }
        private void GPRecursive(String s, int openingP, int closingP)
        {
            if (openingP == n && closingP == n)
            {
                output.Add(s);
                return;
            }

            if (openingP < n)
                GPRecursive(s + "(", openingP + 1, closingP);

            if (closingP < openingP)
                GPRecursive(s + ")", openingP, closingP + 1);
        }
    }
}
