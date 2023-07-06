/*
 * Author: Tyler Richey
 * LeetCode: 58
 * Title: Length of Last Word
 * Description: Given a string s consisting of words and spaces, return the length of the last word in the string.
 * Difficulty: Easy
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 7/5/2023
 * Notes: 
 */

using System;

/*
58. Length of Last Word
Easy
Given a string s consisting of words and spaces, return the length of the last word in the string.

A word is a maximal
substring
consisting of non-space characters only.

Example 1:
Input: s = "Hello World"
Output: 5
Explanation: The last word is "World" with length 5.

Example 2:
Input: s = "   fly me   to   the moon  "
Output: 4
Explanation: The last word is "moon" with length 4.

Example 3:
Input: s = "luffy is still joyboy"
Output: 6
Explanation: The last word is "joyboy" with length 6.

Constraints:
    1 <= s.length <= 104
    s consists of only English letters and spaces ' '.
    There will be at least one word in s.
*/

namespace Practice
{
    class LeetCode0058
    {
        // Test Cases
        public LeetCode0058()
        {
            try
            {
                String[] tests = new string[] { "Test One", "Test Two", "Test Three", "   A test   with odd spaces     " };

                foreach(String test in tests)
                    Console.WriteLine("\"" + test + "\" = " + LengthOfLastWord(test));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public int LengthOfLastWord(string s)
        {
            int numberOfTrailingSpaces = 0;
            while (numberOfTrailingSpaces < s.Length && s[s.Length - numberOfTrailingSpaces - 1] == ' ')
                numberOfTrailingSpaces++;
            int lastWordLength = 0;
            while (lastWordLength + numberOfTrailingSpaces < s.Length && s[s.Length - lastWordLength - numberOfTrailingSpaces - 1] != ' ')
                lastWordLength++;
            return lastWordLength;
        }
    }
}
