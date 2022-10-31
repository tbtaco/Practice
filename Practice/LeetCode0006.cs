/*
 * Author: Tyler Richey
 * LeetCode: 6
 * Title: ZigZag Conversion
 * Description: Take a string and convert it to a zig-zag version. Easier to explain by showing an example.
 * Difficulty: Medium
 * Status: Solved
 * Time Complexity: O(n^2)
 * Date: 6/28/2021
 * Notes: 
 */

using System;
using System.Collections.Generic;

/*
6. ZigZag Conversion
Medium

The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

P   A   H   N
A P L S I I G
Y   I   R

And then read line by line: "PAHNAPLSIIGYIR"

Write the code that will take a string and make this conversion given a number of rows:

string convert(string s, int numRows);

Example 1:

Input: s = "PAYPALISHIRING", numRows = 3
Output: "PAHNAPLSIIGYIR"

Example 2:

Input: s = "PAYPALISHIRING", numRows = 4
Output: "PINALSIGYAHRPI"

Explanation:
P     I    N
A   L S  I G
Y A   H R
P     I

Example 3:

Input: s = "A", numRows = 1
Output: "A"

Constraints:

1 <= s.length <= 1000
s consists of English letters (lower-case and upper-case), ',' and '.'.
1 <= numRows <= 1000
*/

namespace Practice
{
    class LeetCode0006
    {
        // Test Case
        public LeetCode0006()
        {
            try
            {
                String s = "ThisIsJustALongExampleStringToTestLeetCode6.ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz.";
                Random r = new Random();
                int numRows = r.Next(30) + 1; // Constraints are higher, but to test I lowered this to 1-30

                String result = Convert(s, numRows);

                Console.WriteLine("Input: " + s);
                Console.WriteLine("Number of Rows: " + numRows);
                Console.WriteLine("Output: " + result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public string Convert(string s, int numRows)
        {
            if (numRows == 1)
                return s;

            List<String> zigzag = new List<String>();
            for (int i = 0; i < numRows; i++)
                zigzag.Add("");

            for(int i = 0; i < s.Length; i++)
            {
                int j = i % (2 * numRows - 2);
                if (j < numRows)
                    zigzag[j] += s[i];
                else
                {
                    int charRow = numRows - j % numRows - 2;
                    for (int k = 0; k < numRows; k++)
                        if (k == charRow)
                            zigzag[k] += s[i];
                        else
                            zigzag[k] += " ";
                }
            }

            String result = "";
            foreach(String str in zigzag)
                foreach(char c in str)
                    if (c != ' ')
                        result += c;

            return result;
        }
    }
}
