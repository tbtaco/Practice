/*
 * Author: Tyler Richey
 * LeetCode: 10
 * Title: Regular Expression Matching
 * Description: Regular expression matching. I had troubles with this one and ended up seeking help to complete it. See comments for further explanation.
 * Difficulty: Hard
 * Status: Solved (With Help)
 * Time Complexity: O(n^2)
 * Date: 7/4/2021
 * Notes: I was stuck on this one for a good while and ended up asking others for some ideas on a direction to go to solve this.
 * Credit for this solution should go to https://redquark.org/leetcode/0010-regular-expression-matching/
 * My original way of solving this was needlessly complex and would still run into issues if multiple * or .* were inserted with normal chars at the end.
 * My last attempt was going to use recursive calls to tackle it little by little, but that became a mess very quickly.
 */

using System;

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
        // Test Cases
        public LeetCode0010()
        {
            try
            {
                Console.WriteLine("\n    Note: I can't take credit for this solution.  See my comments in LeetCode0010.cs for more info\n");

                String[][] tests = { // S, P, Expected
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

                foreach (String[] test in tests)
                    Console.WriteLine("S: \"" + test[0] + "\", P: \"" + test[1] + "\", Result: " + IsMatch(test[0], test[1]) +
                        ", Expected: " + test[2]);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public bool IsMatch(string s, string p)
        {
            if (s.Length == 0 && p.Length == 0) // Both strings are empty
                return true;

            if (p.Length == 0) // p is empty, but s is not
                return false;

            bool[][] testTable = new bool[s.Length + 1][]; // A 2D array will be used to keep track of tests.
            for (int i = 0; i < testTable.Length; i++) // 0 and 0 will represent an empty char "" and everything else is a char of s or p
                testTable[i] = new bool[p.Length + 1];
            for (int i = 0; i < testTable.Length; i++) // Initialize (good habit at least, even if all cells are false by default)
                for (int j = 0; j < testTable[i].Length; j++)
                    testTable[i][j] = false;

            testTable[0][0] = true; // Matching "" to ""

            for (int i = 2; i < p.Length + 1; i++) // Matching "" to "*"
                if (p[i - 1] == '*')
                    testTable[0][i] = testTable[0][i - 2];

            for(int i = 1; i < s.Length + 1; i++)
                for(int j = 1; j < p.Length + 1; j++)
                    if (s[i - 1] == p[j - 1] || p[j - 1] == '.') // Check the site included on line 7 above for credit for this if/else if section
                        testTable[i][j] = testTable[i - 1][j - 1]; // They include a full explanation that is worth a reading
                    else if (j > 1 && p[j - 1] == '*')
                    {
                        testTable[i][j] = testTable[i][j - 2];
                        if (p[j - 2] == '.' || p[j - 2] == s[i - 1])
                            testTable[i][j] = testTable[i][j] || testTable[i - 1][j];
                    }

            return testTable[s.Length][p.Length];
        }
    }
}
