/*
 * Author: Tyler Richey
 * LeetCode: 66
 * Title: Plus One
 * Description: You are given a large integer represented as an integer array digits, where each digits[i] is the ith digit of the integer. The digits are ordered from most significant to least significant in left-to-right order.
 * Difficulty: Easy
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 8/20/2023
 * Notes: 
 */

using System;

/*
66. Plus One
Easy
You are given a large integer represented as an integer array digits, where each digits[i] is the ith digit of the integer. The digits are ordered from most significant to least significant in left-to-right order. The large integer does not contain any leading 0's.

Increment the large integer by one and return the resulting array of digits.

Example 1:
Input: digits = [1,2,3]
Output: [1,2,4]
Explanation: The array represents the integer 123.
Incrementing by one gives 123 + 1 = 124.
Thus, the result should be [1,2,4].

Example 2:
Input: digits = [4,3,2,1]
Output: [4,3,2,2]
Explanation: The array represents the integer 4321.
Incrementing by one gives 4321 + 1 = 4322.
Thus, the result should be [4,3,2,2].

Example 3:
Input: digits = [9]
Output: [1,0]
Explanation: The array represents the integer 9.
Incrementing by one gives 9 + 1 = 10.
Thus, the result should be [1,0].

Constraints:
    1 <= digits.length <= 100
    0 <= digits[i] <= 9
    digits does not contain any leading 0's.
*/

namespace Practice
{
    class LeetCode0066
    {
        // Test Cases
        public LeetCode0066()
        {
            try
            {
                int[][] tests = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 3, 2, 1 }, new int[] { 9 } };

                foreach (int[] test in tests)
                {
                    Console.Write("Input: [");
                    for(int i = 0; i < test.Length; i++)
                    {
                        if (i > 0)
                            Console.Write(", ");
                        Console.Write(test[i]);
                    }
                    Console.Write("], Output: [");
                    int[] output = PlusOne(test);
                    for (int i = 0; i < output.Length; i++)
                    {
                        if (i > 0)
                            Console.Write(", ");
                        Console.Write(output[i]);
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
        public int[] PlusOne(int[] digits)
        {
            bool carry = true;
            int index = digits.Length - 1;

            while(index >= 0 && carry)
            {
                digits[index]++;
                if (digits[index] == 10)
                    digits[index] = 0;
                else
                    carry = false;
                index--;
            }

            if(carry)
            {
                digits = new int[digits.Length + 1];
                digits[0] = 1;
                for (int i = 1; i < digits.Length; i++)
                    digits[i] = 0;
            }

            return digits;
        }
    }
}
