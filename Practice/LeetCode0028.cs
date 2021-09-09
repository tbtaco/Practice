/*
 * Tyler Richey
 * LeetCode 28
 * 9/9/2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
28. Implement strStr()
Easy

Implement strStr().

Return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.

Clarification:

What should we return when needle is an empty string? This is a great question to ask during an interview.

For the purpose of this problem, we will return 0 when needle is an empty string.
This is consistent to C's strstr() and Java's indexOf().

Example 1:

Input: haystack = "hello", needle = "ll"
Output: 2

Example 2:

Input: haystack = "aaaaa", needle = "bba"
Output: -1

Example 3:

Input: haystack = "", needle = ""
Output: 0

Constraints:

    0 <= haystack.length, needle.length <= 5 * 104
    haystack and needle consist of only lower-case English characters.
*/

namespace Practice
{
    class LeetCode0028
    {
        public LeetCode0028()
        {
            const String haystack = "Example String for Needle in a Haystack.";
            const String needle = "Need";
            Console.WriteLine("Haystack: \"" + haystack + "\", Needle: \"" + needle + "\", Result: " + StrStr(haystack, needle));
        }
        public int StrStr(string haystack, string needle)
        {
            if (needle == null || needle.Length == 0)
                return 0;
            for(int i = 0; i <= haystack.Length - needle.Length; i++)
                if (haystack.Substring(i, needle.Length).Equals(needle))
                    return i;
            return -1;
        }
    }
}
