/*
 * Tyler Richey
 * LeetCode 15
 * 7/12/2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
15. 3Sum
Medium

Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]]
such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
Notice that the solution set must not contain duplicate triplets.

Example 1:

Input: nums = [-1,0,1,2,-1,-4]
Output: [[-1,-1,2],[-1,0,1]]

Example 2:

Input: nums = []
Output: []

Example 3:

Input: nums = [0]
Output: []

Constraints:

    0 <= nums.length <= 3000
    -10^5 <= nums[i] <= 10^5
*/

namespace Practice
{
    class LeetCode0015
    {
        public LeetCode0015()
        {
            int maxLength = 30; //3000; //Must be Positive
            int min = -40; //-10000; //Must be Negative
            int max = 40; //10000; //Must be Positive
            int testCount = 21; //4; //First will be length 0.  Rest will be random

            Random r = new Random();
            int nextLength = 0; //First test will be length of 0
            for(int i = 0; i < testCount; i++)
            {
                int[] nums = new int[nextLength];
                for(int j = 0; j < nums.Length; j++)
                    nums[j] = r.Next(max - min + 1) + min;

                Console.Write("Input: [");
                for(int j = 0; j < nums.Length; j++)
                {
                    if (j > 0)
                        Console.Write(", ");
                    Console.Write(nums[j]);
                }
                Console.Write("] Output: [");
                IList<IList<int>> result = ThreeSum(nums);
                for(int j = 0; j < result.Count; j++)
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
                Console.WriteLine("]\n");
                nextLength = r.Next(maxLength + 1);
            }
        }
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> list = new List<IList<int>>();
            if (nums.Length < 3)
                return list;

            /*
            //If I sort the array of nums first, I could rule out any all positive or all negative cases, for a start
            for (int i = 0; i < nums.Length - 2; i++)
                for (int j = i + 1; j < nums.Length - 1; j++)
                    for (int k = j + 1; k < nums.Length; k++)
                        if(i != j && i != k && j != k && nums[i] + nums[j] + nums[k] == 0)
                        {
                            List<int> l = new List<int> { nums[i], nums[j], nums[k] };
                            l.Sort();
                            Boolean alreadyAdded = false;
                            for(int x = 0; x < list.Count; x++)
                                if (ListsEqual(list[x], l))
                                    alreadyAdded = true;
                            if (!alreadyAdded)
                                list.Add(l);
                        }
            */

            for(int i = 0; i < nums.Length; i++)
            {

            }









            return list;
        }
        private Boolean ListsEqual(IList<int> l, IList<int> m)
        {
            if (l.Count != m.Count)
                return false;
            for (int i = 0; i < l.Count; i++)
                if (l[i] != m[i])
                    return false;
            return true;
        }
    }
}
