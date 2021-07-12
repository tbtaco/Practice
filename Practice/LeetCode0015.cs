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
            Random r = new Random();
            int nextLength = 0;
            for(int i = 0; i < 5; i++)
            {
                throw new Exception("TODO");


                nextLength = r.Next(3001);
            }
        }
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            List<List<int>> list = new List<List<int>>();
            if (nums.Length < 3)
                return (IList<IList<int>>)list;
            for(int i = 0; i < nums.Length; i++)
                for(int j = i + 1; j < nums.Length; j++)
                    for(int k = j + 1; k < nums.Length; k++)
                        if (nums[i] != nums[j] && nums[i] != nums[k] && nums[j] != nums[k] && nums[i] + nums[j] + nums[k] == 0)
                            list.Add(new List<int> { nums[i], nums[j], nums[k] });
            return (IList<IList<int>>)list;
        }
    }
}
