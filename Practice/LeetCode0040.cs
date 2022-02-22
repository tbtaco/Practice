/*
 * Tyler Richey
 * LeetCode 40
 * 2/22/2022
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private const int targetMin = 1;
        private const int targetMax = 30;
        private const int candidateMin = 1;
        private const int candidateMax = 50;
        private const int candidateLengthMin = 1;
        private const int candidateLengthMax = 100;
        public LeetCode0040()
        {
            Random r = new Random();
            r.Next(); r.Next(); r.Next();
            for (int i = 1; i <= 5; i++)
            {
                Console.Write("Test " + i + ": Candidates: [");
                int[] candidates = new int[r.Next(candidateLengthMax - candidateLengthMin + 1) + candidateLengthMin];
                for (int j = 0; j < candidates.Length; j++)
                {
                    if (j > 0)
                        Console.Write(", ");
                    candidates[j] = r.Next(candidateMax - candidateMin + 1) + candidateMin;
                    Console.Write(candidates[j]);
                }
                int target = r.Next(targetMax - targetMin + 1) + targetMin;
                Console.Write("] Target: " + target + " Output: [");
                IList<IList<int>> result = CombinationSum2(candidates, target);
                for(int j = 0; j < result.Count; j++)
                {
                    if (j > 0)
                        Console.Write(", ");
                    Console.Write("[");
                    for(int k = 0; k < result[j].Count; k++)
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
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            throw new Exception("TODO");
        }
    }
}
