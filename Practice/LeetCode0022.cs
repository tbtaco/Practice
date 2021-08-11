/*
 * Tyler Richey
 * LeetCode 22
 * 8/11/2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public LeetCode0022()
        {
            for(int i = 1; i <= 8; i++)
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
        private IList<String> output = new List<String>();
        private int n = 0;
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
