/*
 * Tyler Richey
 * LeetCode 10
 * 7/4/2021
 * 
 * Note: I was stuck on this one for a good while and ended up asking others for some ideas on a direction to go to solve this
 * Credit for this solution should go to https://redquark.org/leetcode/0010-regular-expression-matching/
 * My original way of solving this was needlessly complex and would still run into issues if multiple * or .* were inserted with normal chars at the end
 * My last attempt was going to use recursive calls to tackle it little by little, but that became a mess very quickly
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
10. Regular Expression Matching
Hard

Given an input string (s) and a pattern (p), implement regular expression matching with support for '.' and '*' where: 
'.' Matches any single character.​​​​
'*' Matches zero or more of the preceding element.
The matching should cover the entire input string (not partial).

Example 1:

Input: s = "aa", p = "a"
Output: false
Explanation: "a" does not match the entire string "aa".

Example 2:

Input: s = "aa", p = "a*"
Output: true
Explanation: '*' means zero or more of the preceding element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".

Example 3:

Input: s = "ab", p = ".*"
Output: true
Explanation: ".*" means "zero or more (*) of any character (.)".

Example 4:

Input: s = "aab", p = "c*a*b"
Output: true
Explanation: c can be repeated 0 times, a can be repeated 1 time. Therefore, it matches "aab".

Example 5:

Input: s = "mississippi", p = "mis*is*p*."
Output: false

Constraints:

0 <= s.length <= 20
0 <= p.length <= 30
s contains only lowercase English letters.
p contains only lowercase English letters, '.', and '*'.
It is guaranteed for each appearance of the character '*', there will be a previous valid character to match.
*/

namespace Practice
{
    class LeetCode0010
    {
        public LeetCode0010()
        {
            String[][] tests = { //S, P, Expected
                new String[] { "aaa", "ab*a*c*a", "True" },
                new String[] { "abc", ".*c", "True"},
                new String[] { "aaa", "a*a", "True"},
                new String[] { "aaa", "ab*a", "False"},
                new String[] { "aa", "a", "False"},
                new String[] { "aa", "a*", "True"},
                new String[] { "ab", ".*", "True"},
                new String[] { "aab", "c*a*b", "True"},
                new String[] { "mississippi", "mis*is*p*.", "False"},
                new String[] { "testing testing one two three", "....... ....... ... ... .....", "True"},
                new String[] { "this is a test string aaaaaaaaaaaaaaaaaaabc", "this is a test string a*bc", "True"},
                new String[] { "aaaaaabbbbbbbbbbcccccccccccddddddddddddeeefg", "a*b*c*d*e*f*g*", "True"},
                new String[] { "this one should always be true for anything", ".*", "True"},
                new String[] { "programming is fun", "prog..m*ing....fun.", "False"}};
            foreach(String[] test in tests)
                Console.WriteLine("S: \"" + test[0] + "\", P: \"" + test[1] + "\", Result: " + IsMatch(test[0], test[1]) +
                    ", Expected: " + test[2]);
        }
        public bool IsMatch(string s, string p)
        {

            throw new Exception("Note: I can't take credit for this solution.  See my comments in LeetCode0010.cs for more info.  " +
                "Comment out this thrown exception on line 93 and 94 of LeetCode0010.cs to run the solution anyway.");

            #pragma warning disable CS0162
            if (s.Length == 0 && p.Length == 0) //Both strings are empty
                return true;
            if (p.Length == 0) //p is empty, but s is not
                return false;

            Boolean[][] testTable = new Boolean[s.Length + 1][]; //A 2D array will be used to keep track of tests.
            for (int i = 0; i < testTable.Length; i++) //0 and 0 will represent an empty char "" and everything else is a char of s or p
                testTable[i] = new Boolean[p.Length + 1];
            for (int i = 0; i < testTable.Length; i++) //Initialize (good habit at least, even if all cells are false by default)
                for (int j = 0; j < testTable[i].Length; j++)
                    testTable[i][j] = false;

            testTable[0][0] = true; //Matching "" to ""

            for (int i = 2; i < p.Length + 1; i++) //Matching "" to "*"
                if (p[i - 1] == '*')
                    testTable[0][i] = testTable[0][i - 2];

            for(int i = 1; i < s.Length + 1; i++)
                for(int j = 1; j < p.Length + 1; j++)
                    if (s[i - 1] == p[j - 1] || p[j - 1] == '.') //Check the site included on line 7 above for credit for this if/else if section
                        testTable[i][j] = testTable[i - 1][j - 1]; //They include a full explanation that is worth a reading
                    else if (j > 1 && p[j - 1] == '*')
                    {
                        testTable[i][j] = testTable[i][j - 2];
                        if (p[j - 2] == '.' || p[j - 2] == s[i - 1])
                            testTable[i][j] = testTable[i][j] || testTable[i - 1][j];
                    }

            return testTable[s.Length][p.Length];
        }

        /* Below is one of my failed attempts at solving this problem
        public bool IsMatch(string s, string p)
        {
            int i = 0;
            int j = 0;
            while (i < s.Length && j < p.Length)
                if (p[j] == '.')
                {
                    i++;
                    j++;
                }
                else if (p[j] == '*')
                {
                    if (p[j - 1] == '.')
                    {
                        if (j + 1 == p.Length)
                            return true;
                        while (i < s.Length && s[i] != p[j + 1])
                        {
                            i++;
                            if (i < s.Length && s[i] == p[j + 1])
                                return IsMatch(s.Substring(i), p.Substring(j + 1));
                        }
                        return false;
                    }
                    if (i - 1 >= 0 && j > 0 && s[i] == p[j - 1])
                        i++;
                    else if (i - 1 < 0)
                        i++;
                    else
                        j++;
                }
                else
                {
                    if (s[i] == p[j])
                    {
                        i++;
                        j++;
                    }
                    else if (j + 1 < p.Length && p[j+1] == '*')
                    {
                        j++;
                    }
                    else
                        return false;
                }
            if (i == s.Length && j == p.Length)
                return true;
            else if (j == p.Length && p[j - 1] == '*')
            {
                while (i < s.Length)
                    if (s[i] == s[i - 1])
                        i++;
                    else
                        return false;
                return true;
            }
            else if (i == s.Length && p[j] == '*' && j == p.Length - 1)
                return true;
            else if(i==s.Length && p[j] == '*')
            {
                if (p.Substring(j + 1).Length == 1)
                    return s[s.Length - 1] == p.Substring(j + 1).ToCharArray()[0];

                throw new Exception("Still working on this...");

            }
            return false;
        }
        */
    }
}
