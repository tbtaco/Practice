/*
 * Tyler Richey
 * LeetCode 46
 * 4/29/2022
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
46. Permutations
Medium

Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.

Example 1:

Input: nums = [1,2,3]
Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]

Example 2:

Input: nums = [0,1]
Output: [[0,1],[1,0]]

Example 3:

Input: nums = [1]
Output: [[1]]

Constraints:

    1 <= nums.length <= 6
    -10 <= nums[i] <= 10
    All the integers of nums are unique.
*/

namespace Practice
{
    class LeetCode0046
    {
        public LeetCode0046()
        {
            int[] input = new int[] { 1, 2, 3, 4 };
            Console.Write("Input: [");
            for(int i = 0; i < input.Length; i++)
            {
                if (i > 0)
                    Console.Write(", ");
                Console.Write(input[i]);
            }
            Console.Write("]\nOutput: [");
            IList<IList<int>> output = Permute(input);
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
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> output = new List<IList<int>>();

            int[] order = new int[nums.Length];
            for (int i = 0; i < order.Length; i++)
                order[i] = i;

            bool keepGoing = true;
            while(keepGoing)
            {
                IList<int> tempResult = new List<int>();
                for (int i = 0; i < order.Length; i++)
                    tempResult.Add(nums[order[i]]);
                output.Add(tempResult);

                if (IsDescendingOrder(order))
                    keepGoing = false;
                if(keepGoing)
                    NextPermutation(order);
            }

            return output;
        }
        private bool IsDescendingOrder(int[] nums)
        {
            bool result = true;
            for (int i = 0; i < nums.Length - 1; i++)
                if (nums[i] < nums[i + 1])
                    result = false;
            return result;
        }
        private void NextPermutation(int[] nums) //From LeetCode 31
        {
            if (nums.Length <= 1)
                return;

            bool alreadyOrdered = true;
            for (int k = 0; k < nums.Length - 1; k++)
                if (nums[k] < nums[k + 1])
                    alreadyOrdered = false;
            if (alreadyOrdered)
            {
                Reverse(nums, 0);
                return;
            }

            int i = nums.Length - 2;
            while (i > 0 && nums[i] >= nums[i + 1])
                i--;
            //var i is now the index of the num that is lower than the one on it's right
            //next I need the first index from the right that's higher than this num, as I can't assume it's right next to it
            int j = nums.Length - 1;
            while (nums[i] >= nums[j])
                j--;
            //var j is now the index of the num that is higher than var i
            //swap these two numbers, then reverse everything to the right of i
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
            Reverse(nums, i + 1);
        }
        private void Reverse(int[] nums, int start) //Also From LeetCode 31
        {
            int i = start;
            int j = nums.Length - 1;
            while (i < j)
            {
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
                i++;
                j--;
            }
        }
    }
}
