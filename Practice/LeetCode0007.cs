/*
 * Tyler Richey
 * LeetCode 7
 * 6/28/2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
7. Reverse Integer
Easy

Given a signed 32-bit integer x, return x with its digits reversed.
If reversing x causes the value to go outside the signed 32-bit integer range [-2^31, 2^31 - 1], then return 0.
Assume the environment does not allow you to store 64-bit integers (signed or unsigned).

Example 1:

Input: x = 123
Output: 321

Example 2:

Input: x = -123
Output: -321

Example 3:

Input: x = 120
Output: 21

Example 4:

Input: x = 0
Output: 0

Constraints:

-2^31 <= x <= 2^31 - 1
*/

namespace Practice
{
    class LeetCode0007
    {
        public LeetCode0007()
        {
            Random r = new Random(); //Work In Progress
            int multiplier = 1;
            int input = 0;
            int len = r.Next(9) + 1;
            for (int i = 0; i < len; i++) //At most 9 digits should stay under 2^31
                input += r.Next(10) * multiplier++;
            if (r.Next(2) == 1)
                input *= -1;

            int result = Reverse(input);

            Console.WriteLine("Input: " + input);
            Console.WriteLine("Output: " + result);
        }
        public int Reverse(int x)
        {
            if (x < 0)
                x *= -1;
            int digit3 = x / 100; //Assumed 3 digits.  This is no longer the case!
            int digit2 = (x % 100) / 10;
            int digit1 = x % 10;
            int result = (digit1 * 100) + (digit2 * 10) + digit3; //What about something like 5?  Would it be 5 or 500?
            if (x < 0)
                result *= -1;
            if (result > 230 || result < -231)
                return 0;
            return result;
        }
    }
}
