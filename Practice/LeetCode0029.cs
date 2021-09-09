/*
 * Tyler Richey
 * LeetCode 29
 * 9/9/2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
29. Divide Two Integers
Medium

Given two integers dividend and divisor, divide two integers without using multiplication, division, and mod operator.

Return the quotient after dividing dividend by divisor.

The integer division should truncate toward zero, which means losing its fractional part. For example, truncate(8.345) = 8
and truncate(-2.7335) = -2.

Note: Assume we are dealing with an environment that could only store integers within the 32-bit signed integer
range: [−2^31, 2^31 − 1]. For this problem, assume that your function returns 231 − 1 when the division result overflows.

Example 1:

Input: dividend = 10, divisor = 3
Output: 3
Explanation: 10/3 = truncate(3.33333..) = 3.

Example 2:

Input: dividend = 7, divisor = -3
Output: -2
Explanation: 7/-3 = truncate(-2.33333..) = -2.

Example 3:

Input: dividend = 0, divisor = 1
Output: 0

Example 4:

Input: dividend = 1, divisor = 1
Output: 1

Constraints:

    -2^31 <= dividend, divisor <= 2^31 - 1
    divisor != 0
*/

namespace Practice
{
    class LeetCode0029
    {
        public LeetCode0029()
        {
            const int max = 1000;
            const int min = -1000;
            Random r = new Random();
            for(int i = 1; i <= 20; i++)
            {
                int dividend = r.Next(max - min + 1) + min;
                int divisor = r.Next(max - min + 1) + min;
                Console.Write(i + ". " + dividend + " / " + divisor + " = ");
                int result = Divide(dividend, divisor);
                Console.WriteLine(result);
            }
            Console.WriteLine("Extra. int.MaxValue / 1 = " + Divide(int.MaxValue, 1));
            Console.WriteLine("Extra. int.MinValue / -1 = " + Divide(int.MinValue, -1));
            Console.WriteLine("Extra. int.MinValue / 1 = " + Divide(int.MinValue, 1));
        }
        public int Divide(int dividend, int divisor)
        {










            /* I could definitely simplify this some, and it works, but it's slow enough to not pass the LeetCode tests
            if (divisor == 0)
                return 0;
            if (divisor == 1)
                return dividend;
            int result = 0;
            bool negative = (dividend < 0 && divisor > 0) || (dividend > 0 && divisor < 0);
            if (dividend == int.MinValue)
                dividend = int.MaxValue;
            if (divisor == int.MinValue)
                divisor = int.MaxValue;
            if (dividend < 0)
                dividend = 0 - dividend;
            if (divisor < 0)
                divisor = 0 - divisor;
            while(dividend >= 0)
            {
                dividend -= divisor;
                result++;
            }
            result--;
            if (negative)
                return 0 - result;
            return result;
            */
        }
    }
}
