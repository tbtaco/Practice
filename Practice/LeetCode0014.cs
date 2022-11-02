/*
 * Author: Tyler Richey
 * LeetCode: 14
 * Title: Longest Common Prefix
 * Description: Return the longest prefix shared by an array of strings.
 * Difficulty: Easy
 * Status: Solved
 * Time Complexity: O(n^2)
 * Date: 7/12/2021
 * Notes: 
 */

using System;

/*
14. Longest Common Prefix
Easy

Write a function to find the longest common prefix string amongst an array of strings.
If there is no common prefix, return an empty string "".

Example 1:

Input: strs = ["flower","flow","flight"]
Output: "fl"

Example 2:

Input: strs = ["dog","racecar","car"]
Output: ""
Explanation: There is no common prefix among the input strings.

Constraints:

    1 <= strs.length <= 200
    0 <= strs[i].length <= 200
    strs[i] consists of only lower-case English letters.
*/

namespace Practice
{
    class LeetCode0014
    {
        // Test Cases
        public LeetCode0014()
        {
            try
            {
                String[][] tests = {
                new String[] { "flower", "flow", "flight" },
                new String[] { "dog", "racecar", "car" } };
                foreach (String[] test in tests)
                {
                    Console.Write("Input: \"" + test[0] + "\"");
                    for (int i = 1; i < test.Length; i++)
                        Console.Write(", \"" + test[i] + "\"");
                    Console.WriteLine("\nOutput: " + LongestCommonPrefix(test) + "\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public string LongestCommonPrefix(string[] strs)
        {
            foreach (String s in strs)
                if (s.Length == 0)
                    return "";

            int index = 0;
            while (LettersMatch(strs, index))
                index++;
            return strs[0].Substring(0, index);
        }
        private bool LettersMatch(String[] strs, int i)
        {
            char c;
            if (strs[0].Length > i)
                c = strs[0][i];
            else
                return false;

            for (int j = 1; j < strs.Length; j++)
                if (strs[j].Length > i)
                {
                    if (strs[j][i] != c)
                        return false;
                }
                else
                    return false;

            return true;
        }
    }
}
