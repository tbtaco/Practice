/*
 * Author: Tyler Richey
 * LeetCode: 13
 * Title: Roman to Integer
 * Description: Roman Numeral to Integer.
 * Difficulty: Easy
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 7/12/2021
 * Notes: 
 */

using System;
using System.Collections.Generic;

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

For example, 2 is written as II in Roman numeral, just two one's added together. 12 is written as XII, which is simply X + II.
The number 27 is written as XXVII, which is XX + V + II.

Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead,
the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine,
which is written as IX. There are six instances where subtraction is used:

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
        // Test Cases
        public LeetCode0013()
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public int RomanToInt(string s)
        {
            int result = 0;
            while(s.Length > 0)
            {
                Boolean edited = true;
                if(s.Length >= 2)
                    switch(s.Substring(0, 2))
                    {
                        case "CM": result += 900; break;
                        case "CD": result += 400; break;
                        case "XC": result += 90; break;
                        case "XL": result += 40; break;
                        case "IX": result += 9; break;
                        case "IV": result += 4; break;
                        default: edited = false; break;
                    }
                if(s.Length >= 2 && edited)
                    s = s.Substring(2);
                else
                {
                    switch(s.Substring(0, 1))
                    {
                        case "M": result += 1000; break;
                        case "D": result += 500; break;
                        case "C": result += 100; break;
                        case "L": result += 50; break;
                        case "X": result += 10; break;
                        case "V": result += 5; break;
                        case "I": result += 1; break;
                    }
                    s = s.Substring(1);
                }
            }
            return result;
        }
    }
}
