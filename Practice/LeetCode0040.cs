/*
 * Author: Tyler Richey
 * LeetCode: 40
 * Title: Combination Sum II
 * Description: Combination Sum II.
 * Difficulty: Medium
 * Status: Solved
 * Time Complexity: O(2^n)
 * Date: 3/1/2022
 * Notes: 
 */

using System;
using System.Collections.Generic;

/*
40. Combination Sum II
Medium

Given a collection of candidate numbers (candidates) and a target number (target),
find all unique combinations in candidates where the candidate numbers sum to target.

Each number in candidates may only be used once in the combination.

Note: The solution set must not contain duplicate combinations.

Example 1:

Input: candidates = [10,1,2,7,6,1,5], target = 8
Output: 
[
[1,1,6],
[1,2,5],
[1,7],
[2,6]
]

Example 2:

Input: candidates = [2,5,2,1,2], target = 5
Output: 
[
[1,2,2],
[5]
]

Constraints:

    1 <= candidates.length <= 100
    1 <= candidates[i] <= 50
    1 <= target <= 30
*/

namespace Practice
{
    class LeetCode0040
    {
        // Test Cases
        private const int targetMin = 1;
        private const int targetMax = 30;
        private const int candidateMin = 1;
        private const int candidateMax = 50;
        private const int candidateLengthMin = 1;
        private const int candidateLengthMax = 100;
        private const int testCount = 5;
        public LeetCode0040()
        {
            try
            {
                Random r = new Random();
                r.Next(); r.Next(); r.Next(); // The Random classes first value (at least) follows very clear patterns tied to system time etc.  I do this to break that pattern and get more random results

                for (int i = 1; i <= testCount; i++)
                {
                    Console.Write("Test " + i + ":\n\tCandidates: [");

                    int[] candidates;
                    int target;
                    if (i == testCount) // Last test I want to manually set
                    {
                        candidates = new int[] { 1, 2 };
                        for (int j = 0; j < candidates.Length; j++)
                        {
                            if (j > 0)
                                Console.Write(", ");
                            Console.Write(candidates[j]);
                        }

                        target = 1;
                    }
                    else
                    {
                        candidates = new int[r.Next(candidateLengthMax - candidateLengthMin + 1) + candidateLengthMin];
                        for (int j = 0; j < candidates.Length; j++)
                        {
                            if (j > 0)
                                Console.Write(", ");
                            candidates[j] = r.Next(candidateMax - candidateMin + 1) + candidateMin;
                            Console.Write(candidates[j]);
                        }

                        target = r.Next(targetMax - targetMin + 1) + targetMin;
                    }

                    Console.Write("]\n\tTarget: " + target + "\n\tOutput: [");
                    IList<IList<int>> result = CombinationSum2(candidates, target);
                    for (int j = 0; j < result.Count; j++)
                    {
                        if (j > 0)
                            Console.Write(", ");
                        Console.Write("[");
                        for (int k = 0; k < result[j].Count; k++)
                        {
                            if (k > 0)
                                Console.Write(", ");
                            Console.Write(result[j][k]);
                        }
                        Console.Write("]");
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
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();

            Sort(candidates);
            Trim(candidates, target);

            IList<int> temp = new List<int>();

            if(GetSum(candidates) == target)
            {
                result.Add(Copy(candidates));
                for(int i = 0; i < result[0].Count; i++)
                    if (result[0][i] == 0)
                    {
                        result[0].RemoveAt(i);
                        i--;
                    }

                return result;
            }

            if(AllSame(candidates))
            {
                if (GetSum(candidates) > target)
                {
                    while (GetSum(temp) < target)
                        temp.Add(candidates[0]);
                    if (GetSum(temp) == target)
                        result.Add(temp);
                }

                return result;
            }

            AddAnotherRecursive(temp, candidates, target, result, 0);

            return result;
        }
        private void AddAnotherRecursive(IList<int> temp, int[] candidates, int target, IList<IList<int>> result, int start)
        {
            for(int i = start; i < candidates.Length && candidates[i] > 0; i++)
            {
                IList<int> current = Copy(temp);

                current.Add(candidates[i]);

                int sum = GetSum(current);
                if (sum > target)
                    return;

                if(sum == target)
                    AddIfNotPresent(result, current);
                else
                    AddAnotherRecursive(current, candidates, target, result, i + 1);
            }
        }
        private IList<int> Copy(IList<int> temp)
        {
            IList<int> result = new List<int>();
            foreach (int i in temp)
                result.Add(i);
            return result;
        }
        private void Sort(int[] n) // From LeetCode 4
        {
            for (int i = 0; i < n.Length; i++)
            {
                int lowest = i;
                for (int j = i; j < n.Length; j++)
                    if (n[j] < n[lowest])
                        lowest = j;
                Swap(n, i, lowest);
            }
        }
        private void Swap(int[] n, int x, int y) // From LeetCode 4
        {
            int temp = n[x];
            n[x] = n[y];
            n[y] = temp;
        }
        private void Trim(int[] n, int target)
        {
            for(int i = 0; i < n.Length; i++)
                if (n[i] > target)
                    n[i] = 0; // 0 is not possible, so I'll know to skip it in the main method
        }
        private int GetSum(IList<int> nums)
        {
            int sum = 0;
            foreach (int i in nums)
                sum += i;

            return sum;
        }
        private void AddIfNotPresent(IList<IList<int>> result, IList<int> b)
        {
            foreach(IList<int> a in result)
                if(AreEqual(a, b))
                    return;

            result.Add(b);
        }
        private bool AreEqual(IList<int> a, IList<int> b)
        {
            if (a.Count != b.Count)
                return false;

            for(int i = 0; i < a.Count; i++)
                if (a[i] != b[i])
                    return false;

            return true;
        }
        private bool AllSame(int[] nums)
        {
            int num = nums[0];
            for (int i = 1; i < nums.Length; i++)
                if (nums[i] != num)
                    return false;

            return true;
        }
    }
}
