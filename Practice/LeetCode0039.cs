/*
 * Author: Tyler Richey
 * LeetCode: 39
 * Title: Combination Sum
 * Description: Returns all combinations of an int array that can be added to equal a target int.  Numbers may be used more than once to hit the target int.
 * Difficulty: Medium
 * Status: Solved
 * Time Complexity: O(2^n)
 * Date: 12/7/2021
 * Notes: 
 */

using System;
using System.Collections.Generic;

/*
39. Combination Sum
Medium

Given an array of distinct integers candidates and a target integer target, return a list of all unique combinations of
candidates where the chosen numbers sum to target. You may return the combinations in any order.

The same number may be chosen from candidates an unlimited number of times. Two combinations are unique if the frequency of
at least one of the chosen numbers is different.

It is guaranteed that the number of unique combinations that sum up to target is less than 150 combinations for the given input.

Example 1:

Input: candidates = [2,3,6,7], target = 7
Output: [[2,2,3],[7]]
Explanation:
2 and 3 are candidates, and 2 + 2 + 3 = 7. Note that 2 can be used multiple times.
7 is a candidate, and 7 = 7.
These are the only two combinations.

Example 2:

Input: candidates = [2,3,5], target = 8
Output: [[2,2,2,2],[2,3,3],[3,5]]

Example 3:

Input: candidates = [2], target = 1
Output: []

Example 4:

Input: candidates = [1], target = 1
Output: [[1]]

Example 5:

Input: candidates = [1], target = 2
Output: [[1,1]]

Constraints:

    1 <= candidates.length <= 30
    1 <= candidates[i] <= 200
    All elements of candidates are distinct.
    1 <= target <= 500
*/

namespace Practice
{
    class LeetCode0039
    {
        // Test Case
        public LeetCode0039()
        {
            try
            {
                int[] candidates = new int[] { 2, 3, 4, 5, 6 };
                int target = 12;

                IList<IList<int>> lists = CombinationSum(candidates, target);

                Console.Write("Input: {");
                for (int i = 0; i < candidates.Length; i++)
                {
                    if (i > 0)
                        Console.Write(", ");
                    Console.Write(candidates[i]);
                }

                Console.WriteLine("}\nTarget: " + target + "\nOutput:");
                for (int i = 0; i < lists.Count; i++)
                {
                    Console.Write("{");
                    for (int j = 0; j < lists[i].Count; j++)
                    {
                        if (j > 0)
                            Console.Write(", ");
                        Console.Write(lists[i][j]);
                    }
                    Console.WriteLine("}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        private IList<IList<int>> result = new List<IList<int>>();
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            Sort(candidates);
            for(int i = 0; i < candidates.Length; i++)
            {
                IList<int> current = new List<int>();
                current.Add(candidates[i]);
                if (candidates[i] == target)
                {
                    AddIfNotAlreadyPresent(current);
                    current = CopyList(current);
                }
                else if(candidates[i] < target)
                    RecursiveCall(candidates, target, current, 150); // Max depth of 150 for recursive calls
            }
            return result;
        }
        private void RecursiveCall(int[] candidates, int target, IList<int> current, int limit)
        {
            if (limit <= 0)
                return;

            limit--;

            IList<int> currentCopy = CopyList(current);
            for (int i = 0; i < candidates.Length; i++)
            {
                current = CopyList(currentCopy);
                int currentSum = 0;
                foreach (int j in current)
                    currentSum += j;
                currentSum += candidates[i];
                if (currentSum == target)
                {
                    current.Add(candidates[i]);
                    AddIfNotAlreadyPresent(current);
                    current = CopyList(current);
                }
                else if (currentSum < target)
                {
                    current.Add(candidates[i]);
                    RecursiveCall(candidates, target, current, limit); // Max depth of 150 for recursive calls
                }
                else
                    return;
            }
        }
        private void Sort(int[] nums) // From LeetCode0033.cs
        {
            for (int i = 0; i < nums.Length - 1; i++)
                for (int j = 0; j < nums.Length - 1 - i; j++)
                    if (nums[j] > nums[j + 1])
                        Swap(nums, j, j + 1);
        }
        private void Sort(IList<int> nums)
        {
            for (int i = 0; i < nums.Count - 1; i++)
                for (int j = 0; j < nums.Count - 1 - i; j++)
                    if (nums[j] > nums[j + 1])
                        Swap(nums, j, j + 1);
        }
        private void Swap(int[] nums, int i, int j) // From LeetCode0033.cs
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
        private void Swap(IList<int> nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
        private IList<int> CopyList(IList<int> x) // Reusing the same list over and over was giving me troubles.  Made this to easily copy it into a new object so it's not edited later on
        {
            IList<int> y = new List<int>();
            foreach (int i in x)
                y.Add(i);

            return y;
        }
        private void AddIfNotAlreadyPresent(IList<int> toAdd)
        {
            Sort(toAdd);

            bool alreadyAdded = false;
            foreach (IList<int> toCheck in result)
                if (AreEqual(toCheck, toAdd))
                    alreadyAdded = true;

            if (!alreadyAdded)
                result.Add(toAdd);
        }
        private bool AreEqual(IList<int> x, IList<int> y)
        {
            if(x.Count == y.Count)
            {
                bool equal = true;
                for (int i = 0; i < x.Count; i++)
                    if (x[i] != y[i])
                        equal = false;

                return equal;
            }

            return false;
        }
    }
}
