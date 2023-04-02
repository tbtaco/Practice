/*
 * Author: Tyler Richey
 * LeetCode: 67
 * Title: Add Binary
 * Description: Given two binary strings a and b, return their sum as a binary string.
 * Difficulty: Easy
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 4/1/2023
 * Notes: 
 */

using System;

/*
67. Add Binary
Easy

Given two binary strings a and b, return their sum as a binary string.

Example 1:

Input: a = "11", b = "1"
Output: "100"

Example 2:

Input: a = "1010", b = "1011"
Output: "10101"

Constraints:

    1 <= a.length, b.length <= 104
    a and b consist only of '0' or '1' characters.
    Each string does not contain leading zeros except for the zero itself.
*/

namespace Practice
{
    class LeetCode0067
    {
        // Test Cases
        public LeetCode0067()
        {
            try
            {
                String a = "1010";
                String b = "1011";

                Console.WriteLine(a + " + " + b + " = " + AddBinary(a, b));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public string AddBinary(string a, string b)
        {
            String result = "";

            bool carry = false;
            int i = 0;
            while(a.Length > i || b.Length > i)
            {
                bool aa = false;
                if (a.Length > i && a[a.Length - i - 1] == '1')
                    aa = true;
                bool bb = false;
                if (b.Length > i && b[b.Length - i - 1] == '1')
                    bb = true;

                if (carry && !aa & !bb || !carry && aa && !bb || !carry && !aa & bb || carry && aa && bb)
                {
                    result = '1' + result;
                    if (!(carry && aa && bb))
                        carry = false;
                }
                else
                {
                    result = '0' + result;
                    if (aa && bb)
                        carry = true;
                }

                i++;
            }

            if (carry)
                result = '1' + result;

            if (result.Length == 0)
                result = "0";

            return result;
        }
    }
}
