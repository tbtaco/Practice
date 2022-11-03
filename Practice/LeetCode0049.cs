/*
 * Author: Tyler Richey
 * LeetCode: 49
 * Title: Group Anagrams
 * Description: Given an array of strings, group the anagrams together.
 * Difficulty: Medium
 * Status: Solved
 * Time Complexity: O(n^2)
 * Date: 11/3/2022
 * Notes: 
 */

using System;
using System.Collections.Generic;

/*
49. Group Anagrams
Medium

Given an array of strings strs, group the anagrams together. You can return the answer in any order.
An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

Example 1:

Input: strs = ["eat","tea","tan","ate","nat","bat"]
Output: [["bat"],["nat","tan"],["ate","eat","tea"]]

Example 2:

Input: strs = [""]
Output: [[""]]

Example 3:

Input: strs = ["a"]
Output: [["a"]]

Constraints:

    1 <= strs.length <= 10^4
    0 <= strs[i].length <= 100
    strs[i] consists of lowercase English letters.
*/

namespace Practice
{
    class LeetCode0049
    {
        // Test Case
        public LeetCode0049()
        {
            try
            {
                String[] input = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };

                Console.Write("Input: [");
                for(int i = 0; i < input.Length; i++)
                {
                    if (i > 0)
                        Console.Write(", ");
                    Console.Write(input[i]);
                }

                Console.Write("]\nOutput: [");

                IList<IList<String>> output = GroupAnagrams(input);

                for(int i = 0; i < output.Count; i++)
                {
                    if (i > 0)
                        Console.Write(", ");
                    Console.Write("[");
                    for(int j = 0; j < output[i].Count; j++)
                    {
                        if (j > 0)
                            Console.Write(", ");
                        Console.Write(output[i][j]);
                    }
                    Console.Write("]");
                }
                Console.WriteLine("]");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<String>> result = new List<IList<String>>();

            if (strs.Length == 1)
                result.Add(new List<String> { strs[0] });
            else
            {
                bool[] used = new bool[strs.Length];

                for(int i = 0; i < strs.Length; i++)
                    if(!used[i])
                    {
                        List<String> current = new List<String> { strs[i] };

                        for (int j = i + 1; j < strs.Length; j++)
                            if (!used[j] && IsAnagram(strs[i], strs[j]))
                            {
                                current.Add(strs[j]);
                                used[j] = true;
                            }

                        result.Add(current);

                        used[i] = true;
                    }
            }

            return result;
        }
        private bool IsAnagram(String a, String b)
        {
            if (a.Length != b.Length)
                return false;

            for(int i = 0; i < a.Length; i++)
                for(int j = 0; j < b.Length; j++)
                    if (b[j] == a[i])
                    {
                        b = b.Remove(j, 1);
                        j = b.Length;
                    }

            return b.Length == 0;
        }
    }
}
