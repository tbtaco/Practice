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
            /*Ideas
            The main issue here is I'm going through 3 tiers of for loops
            I've cut that down to about 2.5 or so, but it's still too much
            How can I cut this down to a single for loop with a while inside?

            i = 0
            j = length - 1
            k will be searched for?
            Sorting is definitely the key
            ex i = -50 and j = 75, I'm looking for -25.  that's easy enough.  Then what?
            If I increment through all i and j, then search for k it's no better than what I've done so far...

            i will go through 0 to length - 3
            j and k will start at either end of what remains
            if sum is greater than 0, I need to decrement k
            else (less than 0) I need to increment j
            Doing this will let me find numbers that work and if j == k I end and increment i, go through again
            Also if incrementing or decrementing, the numbers stay the same I'll do the same action without re-checking






            */

            IList<IList<int>> list = new List<IList<int>>();
            if (nums.Length < 3)
                return list;

            //A classic bubble sort
            for(int i = 0; i < nums.Length; i++)
                for(int j = 0; j < nums.Length - i - 1; j++)
                    if(nums[j] > nums[j + 1])
                    {
                        int t = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = t;
                    }

            //If all the numbers are on the same side of 0, my improvements won't help so just run my first attempt
            if ((nums[0] >= 0 && nums[nums.Length - 1] >= 0) || (nums[0] <= 0 && nums[nums.Length - 1] <= 0))
                return FirstAttempt(nums, list);

            //Else run the improved version
            return SecondAttempt(nums, list);
        }
        private IList<IList<int>> FirstAttempt(int[] nums, IList<IList<int>> list)
        {
            for (int i = 0; i < nums.Length - 2; i++)
                for (int j = i + 1; j < nums.Length - 1; j++)
                    for (int k = j + 1; k < nums.Length; k++)
                        if (nums[i] + nums[j] + nums[k] == 0 && i != j && i != k && j != k)
                        {
                            List<int> l = new List<int> { nums[i], nums[j], nums[k] };
                            l.Sort();
                            Boolean alreadyAdded = false;
                            for (int x = 0; x < list.Count; x++)
                                if (ListsEqual(list[x], l))
                                    alreadyAdded = true;
                            if (!alreadyAdded)
                                list.Add(l);
                        }
            return list;
        }
        private IList<IList<int>> SecondAttempt(int[] nums, IList<IList<int>> list)
        {
            int center = 0;
            for(int i = 0; i < nums.Length; i++)
                if (nums[i] < 0)
                    center++;
                else
                    i = nums.Length;

            for (int i = 0; i < nums.Length - 2; i++)
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    int start = j + 1;
                    int end = nums.Length;
                    if (i < center && j < center)
                        start = center;
                    if (i > center && j > center)
                        end = center + 1;

                    for (int k = start; k < end; k++)
                        if (nums[i] + nums[j] + nums[k] == 0 && i != j && i != k && j != k)
                        {
                            List<int> l = new List<int> { nums[i], nums[j], nums[k] };
                            l.Sort();
                            Boolean alreadyAdded = false;
                            for (int x = 0; x < list.Count; x++)
                                if (ListsEqual(list[x], l))
                                    alreadyAdded = true;
                            if (!alreadyAdded)
                                list.Add(l);
                        }
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
