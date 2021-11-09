/*
 * Tyler Richey
 * LeetCode 38
 * 11/9/2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public LeetCode0038()
        {
            for(int i = 1; i <= 20; i++) //1 to 30 to fully test the constraints
            {
                Console.Write("n = " + i + ": ");
                if (i < 10)
                    Console.Write(" ");
                Console.WriteLine(CountAndSay(i));
            }
        }
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
