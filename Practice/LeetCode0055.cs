/*
 * Author: Tyler Richey
 * LeetCode: 55
 * Title: Jump Game
 * Description: Integers in an integer array represent how far you can jump.  Starting at [0], return true if it's possible to reach the last index.  See LeetCode0045.cs for Jump Game II.
 * Difficulty: Medium
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 11/3/2022
 * Notes: 
 */

using System;

/*
55. Jump Game
Medium

You are given an integer array nums. You are initially positioned at the array's first index, and each element in the array
represents your maximum jump length at that position.

Return true if you can reach the last index, or false otherwise.

Example 1:

Input: nums = [2,3,1,1,4]
Output: true
Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.

Example 2:

Input: nums = [3,2,1,0,4]
Output: false
Explanation: You will always arrive at index 3 no matter what. Its maximum jump length is 0, which makes it impossible to reach the last index.

Constraints:

    1 <= nums.length <= 10^4
    0 <= nums[i] <= 10^5
*/

namespace Practice
{
    class LeetCode0055
    {
        // Test Cases
        private const int minInputs = 1;
        private const int maxInputs = 20;
        private const int minJumps = 0;
        private const int maxJumps = 7;
        private const int maxPrintPrefix = 7;
        private const int maxPrintSuffix = 3;
        private const int numberOfTests = 8;
        public LeetCode0055() // Copied from LeetCode0045.cs
        {
            try
            {
                Random r = new Random();
                r.Next(); r.Next(); r.Next();

                for (int i = 1; i <= numberOfTests; i++)
                {
                    int[] inputs = new int[r.Next(maxInputs - minInputs + 1) + minInputs];
                    for (int j = 0; j < inputs.Length; j++)
                        inputs[j] = r.Next(maxJumps - minJumps + 1) + minJumps;
                    Console.WriteLine("Test " + i + ":\n\tInput: " + PrintArray(inputs) + "\n\tOutput: " + CanJump(inputs));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        private String PrintArray(int[] array) // Copied from LeetCode0045.cs
        {
            String output = "[";
            for (int i = 0; i < array.Length; i++)
                if (array.Length <= maxPrintPrefix + maxPrintSuffix)
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
        // Solution
        public bool CanJump(int[] nums) // Modified solution to LeetCode0045.cs
        {
            if (nums.Length <= 1)
                return true;

            int temporaryNewMaxReach = 0;
            int currentMaxReach = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (temporaryNewMaxReach < i + nums[i])
                    temporaryNewMaxReach = i + nums[i];
                if (temporaryNewMaxReach >= nums.Length - 1)
                    break;
                if (i == currentMaxReach)
                {
                    if (currentMaxReach == temporaryNewMaxReach && nums[i] == 0)
                        return false;

                    currentMaxReach = temporaryNewMaxReach;
                }
            }

            return true;
        }
    }
}
