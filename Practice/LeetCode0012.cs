/*
 * Author: Tyler Richey
 * LeetCode: 12
 * Title: Integer to Roman
 * Description: Integer to Roman Numeral.
 * Difficulty: Medium
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 7/6/2021
 * Notes: 
 */

using System;

/*
12. Integer to Roman
Medium

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

Given an integer, convert it to a roman numeral.

Example 1:

Input: num = 3
Output: "III"

Example 2:

Input: num = 4
Output: "IV"

Example 3:

Input: num = 9
Output: "IX"

Example 4:

Input: num = 58
Output: "LVIII"
Explanation: L = 50, V = 5, III = 3.

Example 5:

Input: num = 1994
Output: "MCMXCIV"
Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.

Constraints:

1 <= num <= 3999
*/

namespace Practice
{
    class LeetCode0012
    {
        // Test Cases
        public LeetCode0012()
        {
            try
            {
                Random r = new Random();
                for (int i = 0; i < 15; i++)
                {
                    int num = r.Next(3999) + 1;
                    Console.WriteLine("Input: " + num + ", Output: " + IntToRoman(num));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public static string IntToRoman(int num)
        {
            String result = "";

            int temp = num / 1000; // Block M
            for (int i = temp; i > 0; i--)
                result += "M";
            if(temp > 0)
                num -= temp * 1000;
            if(num >= 900)
            {
                result += "CM";
                num -= 900;
            }

            temp = num / 500; // Block D
            for (int i = temp; i > 0; i--)
                result += "D";
            if (temp > 0)
                num -= temp * 500;
            if(num >= 400)
            {
                result += "CD";
                num -= 400;
            }

            temp = num / 100; // Block C
            for (int i = temp; i > 0; i--)
                result += "C";
            if (temp > 0)
                num -= temp * 100;
            if (num >= 90)
            {
                result += "XC";
                num -= 90;
            }

            temp = num / 50; // Block L
            for (int i = temp; i > 0; i--)
                result += "L";
            if (temp > 0)
                num -= temp * 50;
            if (num >= 40)
            {
                result += "XL";
                num -= 40;
            }

            temp = num / 10; // Block X
            for (int i = temp; i > 0; i--)
                result += "X";
            if (temp > 0)
                num -= temp * 10;
            if (num >= 9)
            {
                result += "IX";
                num -= 9;
            }

            temp = num / 5; // Block V
            for (int i = temp; i > 0; i--)
                result += "V";
            if (temp > 0)
                num -= temp * 5;
            if (num >= 4)
            {
                result += "IV";
                num -= 4;
            }

            for (int i = num; i > 0; i--) // Block I
                result += "I";

            return result;
        }
    }
}
