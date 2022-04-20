/*
 * Tyler Richey
 * LeetCode 45
 * 4/20/2022
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
45. Jump Game II
Medium

Given an array of non-negative integers nums, you are initially positioned at the first index of the array.
Each element in the array represents your maximum jump length at that position.
Your goal is to reach the last index in the minimum number of jumps.
You can assume that you can always reach the last index.

Example 1:
Input: nums = [2,3,1,1,4]
Output: 2
Explanation: The minimum number of jumps to reach the last index is 2. Jump 1 step from index 0 to 1, then 3 steps to the last index.

Example 2:
Input: nums = [2,3,0,1,4]
Output: 2

Constraints:

    1 <= nums.length <= 10^4
    0 <= nums[i] <= 1000
*/

namespace Practice
{
    class LeetCode0045
    {
        private const int minInputs = 1;
        private const int maxInputs = 10; //10000
        private const int minJumps = 0;
        private const int maxJumps = 10; //1000
        private const int maxPrintPrefix = 7;
        private const int maxPrintSuffix = 3;
        private const int numberOfTests = 8;
        public LeetCode0045()
        {
            Random r = new Random();
            r.Next(); r.Next(); r.Next();

            for(int i = 1; i <= numberOfTests; i++)
            {
                int[] inputs = new int[r.Next(maxInputs - minInputs + 1) + minInputs];
                for (int j = 0; j < inputs.Length; j++)
                    inputs[j] = r.Next(maxJumps - minJumps + 1) + minJumps;
                Console.WriteLine("Test " + i + ":\n\tInput: " + PrintArray(inputs) + "\n\tOutput: " + Jump(inputs));
            }
        }
        private String PrintArray(int[] array)
        {
            String output = "[";
            for(int i = 0; i < array.Length; i++)
                if(array.Length <= maxPrintPrefix + maxPrintSuffix)
                {
                    if (i > 0)
                        output += ", ";
                    output += array[i];
                }
                else
                {
                    if (i < maxPrintPrefix || i >= array.Length - maxPrintSuffix)
                    {
                        if (i > 0)
                            output += ", ";
                        output += array[i];
                    }
                    else if (i == maxPrintPrefix)
                        output += ", ...";
                }
            output += "]";
            if (array.Length > maxPrintPrefix + maxPrintSuffix)
                output += " (Length: " + array.Length + ")";
            return output;
        }
        public int Jump(int[] nums)
        {
            int jumps = -1;
            int max = -1;
            int current = -1;

            for(int i = 0; i < nums.Length; i++)
            {
                //If I made it to the end with that last index, increment jump and break
                //current is the current max reach
                //max is the overall temporary max.  current becomes this when i == current, and increment jump

                if(max >= nums.Length - 1)
                {
                    jumps++;
                    break;
                }
                if(i == current)
                {
                    current = max;
                    jumps++;
                }









            }

            return jumps;
        }
    }
}
