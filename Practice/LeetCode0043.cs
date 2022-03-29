/*
 * Tyler Richey
 * LeetCode 43
 * 3/29/2022
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
43. Multiply Strings
Medium

Given two non-negative integers num1 and num2 represented as strings, return the product of num1 and num2, also represented as a string.
Note: You must not use any built-in BigInteger library or convert the inputs to integer directly.

Example 1:
Input: num1 = "2", num2 = "3"
Output: "6"

Example 2:
Input: num1 = "123", num2 = "456"
Output: "56088"

Constraints:

    1 <= num1.length, num2.length <= 200
    num1 and num2 consist of digits only.
    Both num1 and num2 do not contain any leading zero, except the number 0 itself.
*/

namespace Practice
{
    class LeetCode0043
    {
        public LeetCode0043()
        {
            String inputA = "1234";
            String inputB = "5678";
            String expectedResult = "7006652";
            Console.WriteLine(inputA + " x " + inputB + " = " + Multiply(inputA, inputB) + " (Should be " + expectedResult + ")");
        }
        public string Multiply(string num1, string num2)
        {
            String result = "";

            //Using Fast Fourier Transforms (FFT)
            /*
            Example
                                                  1  2  3  4
                                                  5  6  7  8
            -------------------------------------------------
            1234 x 8                              8  16 24 32
            Shift and 1234 x 7                 7  14 21 28
                                            6  12 18 24
                                         5  10 15 20
            -------------------------------------------------
                                         5  16 34 60 61 52 32
            -------------------------------------------------
                                        3 2
                                      5 2
                                    6 1
                                  6 0
                                3 4
                              1 6
                              5
            -------------------------------------------------
                              7 0 0 6 6 5 2
            */
            



















            return result;
        }
        private const int charOffset = 48; //'0' = 48, '1' = 49, and so on (from ASCII table)
        private String Add(String num1, String num2)
        {
            String result = "";
            bool carry = false;
            String longer = num1;
            String shorter = num2;
            if (longer.Length < shorter.Length)
            {
                longer = num2;
                shorter = num1;
            }
            for (int i = longer.Length - 1; i >= 0; i--)
            {
                char c1 = longer[i];
                char c2 = '0';
                if (shorter.Length > i)
                    c2 = shorter[i];
                int temp = c1 - charOffset + c2 - charOffset;
                if (carry)
                    temp++;
                char c3 = '0';
                if (temp >= 10)
                {
                    carry = true;
                    c3 = (char)(temp - 10 + charOffset);
                }
                else
                {
                    carry = false;
                    c3 = (char)(temp + charOffset);
                }
                result = c3 + result;
            }
            if (carry)
                result = '1' + result;
            return result;
        }
        private String Add(String num1, String num2, bool carry)
        {
            if (carry)
                return Add(num1, Add(num2, "1"));
            return Add(num1, num2);
        }
        private String Add(String num1, String num2, int carry)
        {
            if (carry > 0)
                return Add(num1, Add(num2, carry+""));
            return Add(num1, num2);
        }
    }
}
