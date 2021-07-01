/*
 * Tyler Richey
 * LeetCode 10
 * 7/1/2021
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
            String[][] tests = {
                new String[] { "aa", "a" }, //False
                new String[] { "aa", "a*" }, //True
                new String[] { "ab", ".*" }, //True
                new String[] { "aab", "c*a*b" }, //True
                new String[] { "mississippi", "mis*is*p*." }, //False
                new String[] { "testing testing one two three", "....... ....... ... ... ....." }, //True
                new String[] { "this is a test string aaaaaaaaaaaaaaaaaaaaaaaabc", "this is a test string a*bc" }, //True
                new String[] { "aaaaaabbbbbbbbbbbbbbccccccccccccdddddddddddddddeeefg", "a*b*c*d*e*f*g*" }, //True
                new String[] { "this one should always be true for anything", ".*" }, //True
                new String[] { "programming is fun", "prog..m*ing....fun." }}; //False
            foreach(String[] test in tests)
                Console.WriteLine("S: \"" + test[0] + "\", P: \"" + test[1] + "\", Result: " + IsMatch(test[0], test[1]));
        }
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
                        return true; //Incorrect assumption.  ".*c" for example
                    if (i - 1 >= 0 && s[i] == s[i - 1])
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
            return false;
        }
    }
}
