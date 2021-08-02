/*
 * Tyler Richey
 * LeetCode 16
 * 8/2/2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*

16. 3Sum Closest
Medium

Given an array nums of n integers and an integer target, find three integers in nums such that the sum is closest to target.
Return the sum of the three integers. You may assume that each input would have exactly one solution.

Example 1:

Input: nums = [-1,2,1,-4], target = 1
Output: 2
Explanation: The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).

Constraints:

    3 <= nums.length <= 10^3
    -10^3 <= nums[i] <= 10^3
    -10^4 <= target <= 10^4
*/

namespace Practice
{
    class LeetCode0016
    {
        public LeetCode0016()
        {
            const int lenMin = 3; //3
            const int lenMax = 20; //1000
            const int numMin = -1000; //-1000
            const int numMax = 1000; //1000
            const int tarMin = -10000; //-10000
            const int tarMax = 10000; //10000

            Random r = new Random();

            for(int i = 1; i <= 5; i++)
            {
                int[] nums = new int[r.Next(lenMax - lenMin + 1) + lenMin];
                for (int j = 0; j < nums.Length; j++)
                    nums[j] = r.Next(numMax - numMin + 1) + numMin;
                int target = r.Next(tarMax - tarMin + 1) + tarMin;

                Console.WriteLine("Test " + i + ": ");
                Console.Write("  Nums: [" + nums[0]);
                for (int j = 1; j < nums.Length; j++)
                    Console.Write(", " + nums[j]);
                Console.WriteLine("]\n  Target: " + target + "\n  Result: " + ThreeSumClosest(nums, target));
            }
        }
        public int ThreeSumClosest(int[] nums, int target)
        {
            //A classic bubble sort
            for (int i = 0; i < nums.Length; i++)
                for (int j = 0; j < nums.Length - i - 1; j++)
                    if (nums[j] > nums[j + 1])
                    {
                        int t = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = t;
                    }

            int minDiff = 30000;
            int bestSum = 0;
            for(int i = 0; i < nums.Length - 2; i++)
            {
                int j = i + 1;
                int k = nums.Length - 1;
                while(j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    int diff = target - sum;
                    if (Math.Abs(diff) < minDiff)
                    {
                        minDiff = Math.Abs(diff);
                        bestSum = sum;
                    }
                    if (diff > 0)
                    {
                        j++;
                        while (j < k && nums[j] == nums[j - 1])
                            j++;
                    }
                    else if (diff < 0)
                    {
                        k--;
                        while (j < k && nums[k] == nums[k + 1])
                            k--;
                    }
                    else
                        return target;
                }
            }
            return bestSum;
        }
    }
}
