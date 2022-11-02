/*
 * Author: Tyler Richey
 * LeetCode: 38
 * Title: Count and Say
 * Description: Count digits and "say" them in a string.  For example 4 as an input would start with "1" (1/4), which is one 1 so "11" (2/4), which is two 1s so "21" (3/4), which is one 2 and one 1 so "1211" (4/4).
 * Difficulty: Medium
 * Status: Solved
 * Time Complexity: O(2^n)
 * Date: 11/9/2021
 * Notes: 
 */

using System;

/*
38. Count and Say
Medium

The count-and-say sequence is a sequence of digit strings defined by the recursive formula:

    countAndSay(1) = "1"
    countAndSay(n) is the way you would "say" the digit string from countAndSay(n-1),
        which is then converted into a different digit string.

To determine how you "say" a digit string, split it into the minimal number of groups so that each group is a
contiguous section all of the same character. Then for each group, say the number of characters, then say the character.
To convert the saying into a digit string, replace the counts with a number and concatenate every saying.

For example, the saying and conversion for digit string "3322251":

Given a positive integer n, return the nth term of the count-and-say sequence.

Example 1:

Input: n = 1
Output: "1"
Explanation: This is the base case.

Example 2:

Input: n = 4
Output: "1211"
Explanation:
countAndSay(1) = "1"
countAndSay(2) = say "1" = one 1 = "11"
countAndSay(3) = say "11" = two 1's = "21"
countAndSay(4) = say "21" = one 2 + one 1 = "12" + "11" = "1211"

Constraints:

    1 <= n <= 30
*/

namespace Practice
{
    class LeetCode0038
    {
        // Test Cases
        public LeetCode0038()
        {
            try
            {
                const int start = 1;
                const int end = 20; // 30


                for (int i = start; i <= end; i++)
                {
                    Console.Write("n = " + i + ": ");
                    if (i < 10) // Max of 30 so I'll align to 2 digits only
                        Console.Write(" ");

                    Console.WriteLine(CountAndSay(i));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public string CountAndSay(int n)
        {
            if (n == 1)
                return "1";

            String s = CountAndSay(n - 1);
            String result = "";

            while(s.Length > 0)
            {
                int count = CountNext(s);
                result += count;
                result += s[0];
                s = s.Substring(count, s.Length - count);
            }
            return result;
        }
        private int CountNext(String s)
        {
            char c = s[0];
            int count = 1;
            for (int i = 1; i < s.Length && s[i] == c; i++)
                count++;

            return count;
        }
    }
}
