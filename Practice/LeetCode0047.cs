/*
 * Tyler Richey
 * LeetCode 47
 * 6/22/2022
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
47. Permutations II
Medium

Given a collection of numbers, nums, that might contain duplicates, return all possible unique permutations in any order.

Example 1:

Input: nums = [1,1,2]
Output:
[[1,1,2],[1,2,1],[2,1,1]]

Example 2:

Input: nums = [1,2,3]
Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]

Constraints:

    1 <= nums.length <= 8
    -10 <= nums[i] <= 10
*/

namespace Practice
{
    class LeetCode0047
    {
        public LeetCode0047()
        {
            int[][] tests = new int[][]
            {
                new int[]{ 0, 0, 0, 0, 1 },
                new int[]{ 0, 1, 2, 3, 4 },
                new int[]{ 0, 0, 0, 1, 1, 1, 1 },
                new int[]{ }
            };
            foreach (int[] test in tests)
            {
                Console.Write("Input: [");
                for(int i = 0; i < test.Length; i++)
                {
                    if (i > 0)
                        Console.Write(", ");
                    Console.Write(test[i]);
                }
                Console.Write("]\nOutput: [");
                IList<IList<int>> result = PermuteUnique(test);
                for(int i = 0; i < result.Count; i++)
                {
                    if (i > 0)
                        Console.Write(", ");
                    Console.Write("[");
                    for(int j = 0; j < result[i].Count; j++)
                    {
                        if (j > 0)
                            Console.Write(", ");
                        Console.Write(result[i][j]);
                    }
                    Console.Write("]");
                }
                Console.WriteLine("]");
            }
        }
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Sort(nums);
            PermuteUniqueRecursive(nums, result, new List<int>(), new bool[nums.Length]);
            return result;
        }
        private void PermuteUniqueRecursive(int[] nums, IList<IList<int>> result, IList<int> temp, bool[] visited)
        {
            if (temp.Count >= nums.Length)
                result.Add(new List<int>(temp));
            else
                for(int i = 0; i < visited.Length; i++)
                    if (!visited[i] && (i == 0 || nums[i] != nums[i - 1] || visited[i - 1]))
                    {
                        visited[i] = true;
                        temp.Add(nums[i]);

                        PermuteUniqueRecursive(nums, result, temp, visited);

                        temp.RemoveAt(temp.Count - 1);
                        visited[i] = false;
                    }
        }
        //Bubble Sort
        private void Sort(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
                for (int j = 0; j < nums.Length - i - 1; j++)
                    if (nums[j] > nums[j + 1])
                        Swap(nums, j, j + 1);
        }
        private void Swap(int[] nums, int x, int y)
        {
            int temp = nums[x];
            nums[x] = nums[y];
            nums[y] = temp;
        }
    }
}
