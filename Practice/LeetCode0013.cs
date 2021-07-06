/*
 * Tyler Richey
 * LeetCode 13
 * 7/6/2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
13. Roman to Integer
Easy

Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

Symbol       Value
I             1
V             5
X             10
L             50
C             100
D             500
M             1000

For example, 2 is written as II in Roman numeral, just two one's added together. 12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.

Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:

    I can be placed before V (5) and X (10) to make 4 and 9. 
    X can be placed before L (50) and C (100) to make 40 and 90. 
    C can be placed before D (500) and M (1000) to make 400 and 900.

Given a roman numeral, convert it to an integer.

Example 1:

Input: s = "III"
Output: 3

Example 2:

Input: s = "IV"
Output: 4

Example 3:

Input: s = "IX"
Output: 9

Example 4:

Input: s = "LVIII"
Output: 58
Explanation: L = 50, V= 5, III = 3.

Example 5:

Input: s = "MCMXCIV"
Output: 1994
Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.

Constraints:

    1 <= s.length <= 15
    s contains only the characters ('I', 'V', 'X', 'L', 'C', 'D', 'M').
    It is guaranteed that s is a valid roman numeral in the range [1, 3999].
*/

namespace Practice
{
    class LeetCode0013
    {
        public LeetCode0013()
        {
            Random r = new Random();
            List<int> tests = new List<int>();
            tests.Add(1);
            tests.Add(4);
            tests.Add(9);
            tests.Add(26);
            tests.Add(1000);
            for (int i = 0; i < 20; i++)
                tests.Add(r.Next(3999) + 1);
            List<String> t = new List<String>();
            foreach (int test in tests)
                t.Add(LeetCode0012.IntToRoman(test));
            foreach (String s in t)
                Console.WriteLine("Input: " + s + ", Output: " + RomanToInt(s));
        }
        public int RomanToInt(string s)
        {
            int result = 0;

            /* From LeetCode 12.  Just reverse it
            String result = "";

            int temp = num / 1000; //Block M
            for (int i = temp; i > 0; i--)
                result += "M";
            if (temp > 0)
                num -= temp * 1000;
            if (num >= 900)
            {
                result += "CM";
                num -= 900;
            }

            temp = num / 500; //Block D
            for (int i = temp; i > 0; i--)
                result += "D";
            if (temp > 0)
                num -= temp * 500;
            if (num >= 400)
            {
                result += "CD";
                num -= 400;
            }

            temp = num / 100; //Block C
            for (int i = temp; i > 0; i--)
                result += "C";
            if (temp > 0)
                num -= temp * 100;
            if (num >= 90)
            {
                result += "XC";
                num -= 90;
            }

            temp = num / 50; //Block L
            for (int i = temp; i > 0; i--)
                result += "L";
            if (temp > 0)
                num -= temp * 50;
            if (num >= 40)
            {
                result += "XL";
                num -= 40;
            }

            temp = num / 10; //Block X
            for (int i = temp; i > 0; i--)
                result += "X";
            if (temp > 0)
                num -= temp * 10;
            if (num >= 9)
            {
                result += "IX";
                num -= 9;
            }

            temp = num / 5; //Block V
            for (int i = temp; i > 0; i--)
                result += "V";
            if (temp > 0)
                num -= temp * 5;
            if (num >= 4)
            {
                result += "IV";
                num -= 4;
            }

            for (int i = num; i > 0; i--) //Block I
                result += "I";

            return result;
            */


            return result;
        }
    }
}
