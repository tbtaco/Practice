/*
 * Author: Tyler Richey
 * LeetCode: 17
 * Title: Letter Combinations of a Phone Number
 * Description: Given an input of numbers saved as a string, return all possible combinations of letter mappings as if it were keyed into a phone.
 * Difficulty: Medium
 * Status: Solved
 * Time Complexity: O(n^2)
 * Date: 8/3/2021
 * Notes: 
 */

using System;
using System.Collections.Generic;

/*
17. Letter Combinations of a Phone Number
Medium

Given a string containing digits from 2-9 inclusive,
return all possible letter combinations that the number could represent.
Return the answer in any order.

A mapping of digit to letters (just like on the telephone buttons) is given below.
Note that 1 does not map to any letters.

Example 1:

Input: digits = "23"
Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]

Example 2:

Input: digits = ""
Output: []

Example 3:

Input: digits = "2"
Output: ["a","b","c"]

Constraints:

    0 <= digits.length <= 4
    digits[i] is a digit in the range ['2', '9'].
*/

namespace Practice
{
    class LeetCode0017
    {
        // Test Cases
        public LeetCode0017()
        {
            try
            {
                List<String> tests = new List<String>();
                Random r = new Random();
                for (int i = 0; i < 10; i++)
                {
                    String s = "";
                    for (int j = 0; j < r.Next(5); j++)
                        s += r.Next(8) + 2;
                    tests.Add(s);
                }
                foreach (String test in tests)
                {
                    Console.Write("Input: " + test + ", Output: [");
                    IList<String> result = LetterCombinations(test);
                    for (int i = 0; i < result.Count; i++)
                    {
                        if (i > 0)
                            Console.Write(", ");
                        Console.Write(result[i]);
                    }
                    Console.WriteLine("]");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public IList<string> LetterCombinations(string digits)
        {
            IList<String> result = new List<String>();
            for(int i = 0; i < digits.Length; i++)
                switch(digits[i])
                {
                    case '2': result = addOptions(new char[] { 'a', 'b', 'c' }, result); break;
                    case '3': result = addOptions(new char[] { 'd', 'e', 'f' }, result); break;
                    case '4': result = addOptions(new char[] { 'g', 'h', 'i' }, result); break;
                    case '5': result = addOptions(new char[] { 'j', 'k', 'l' }, result); break;
                    case '6': result = addOptions(new char[] { 'm', 'n', 'o' }, result); break;
                    case '7': result = addOptions(new char[] { 'p', 'q', 'r', 's' }, result); break;
                    case '8': result = addOptions(new char[] { 't', 'u', 'v' }, result); break;
                    case '9': result = addOptions(new char[] { 'w', 'x', 'y', 'z' }, result); break;
                    default: throw new Exception("Number not supported");
                }
            return result;
        }
        private IList<String> addOptions(char[] chars, IList<String> result)
        {
            IList<String> newResult = new List<String>();
            if(result.Count == 0)
                foreach (char c in chars)
                    newResult.Add("" + c);
            else
                foreach(String s in result)
                    foreach(char c in chars)
                        newResult.Add(s + c);
            return newResult;
        }
    }
}
