/*
 * Tyler Richey
 * LeetCode 43
 * 4/11/2022
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

/*
To solve this one, I'll be using Fast Fourier Transforms (FFT)
Example to help me visualize it:
                                        1  2  3  4
                                     x  5  6  7  8
---------------------------------------------------
1234 x 8                                8  16 24 32
Shift and 1234 x 7                   7  14 21 28
                                  6  12 18 24
                            +  5  10 15 20
---------------------------------------------------
                               5  16 34 60 61 52 32
---------------------------------------------------
                                               3  2
                                            5  2
                                         6  1
                                      6  0
                                   3  4
                                1  6
                             +  5
---------------------------------------------------
Final:                          7  0  0  6  6  5  2
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
        private const int charOffset = 48; //'0' = 48, '1' = 49, and so on (from ASCII table)
        public string Multiply(string num1, string num2)
        {
            IList<IList<int>> tempResults1 = new List<IList<int>>();
            for(int i = num2.Length - 1; i >= 0; i--)
            {
                tempResults1.Add(new List<int>());
                for(int j = num1.Length - 1; j >= 0; j--)
                    tempResults1[tempResults1.Count - 1].Add((num1[j] - charOffset) * (num2[i] - charOffset));
            }

            IList<int> tempResults2 = new List<int>();
            for (int i = num1.Length + num2.Length - 2; i >= 0; i--)
            {
                int temp = 0;
                for(int j = 0; j < num2.Length; j++)
                    if (i - j < tempResults1[j].Count && i - j >= 0)
                        temp += tempResults1[j][i - j];
                tempResults2.Add(temp);
            }

            String result = "";
            int carry = 0;
            for(int i = tempResults2.Count - 1; i >= 0; i--)
            {
                int temp = tempResults2[i] + carry;
                carry = temp / 10;
                result = temp % 10 + result;
            }
            if (carry > 0)
                result = carry + result;

            while (result.Length >= 2 && result[0] == '0')
                result = result.Substring(1);

            return result;
        }
    }
}
