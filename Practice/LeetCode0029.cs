/*
 * Tyler Richey
 * LeetCode 29
 * 1/3/2022
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
range: [−2^31, 2^31 − 1]. For this problem, assume that your function returns 2^31 − 1 when the division result overflows.

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
            Console.WriteLine("Extra. Max (+) / 1 = " + Divide(int.MaxValue, 1));
            Console.WriteLine("Extra. Min (-) / -1 = " + Divide(int.MinValue, -1));
            Console.WriteLine("Extra. Min (-) / 1 = " + Divide(int.MinValue, 1));
            Console.WriteLine("Extra. Max (+) / 2 = " + Divide(int.MaxValue, 2) + " (Should end with a 3)");
            Console.WriteLine("Extra. Min (-) / 2 = " + Divide(int.MinValue, 2) + " (Should end with a 4)");
            Console.WriteLine("Extra. Max (+) / 3 = " + Divide(int.MaxValue, 3) + " (Tests failed at this due to taking too long)");
        }
        public int Divide(int dividend, int divisor)
        {
            if (divisor == 0) //Take care of simple 0, 1, and -1 cases
                return int.MaxValue;
            if (divisor == 1)
                return dividend;
            if(divisor == -1)
            {
                if (dividend == int.MinValue)
                    return int.MaxValue;
                return 0 - dividend;
            }

            //int.MinValue is 1 more than int.MaxValue, so to avoid issues of losing that 1,
            //I'll work in negatives, then fix the sign later
            bool negative = (dividend < 0 && divisor > 0) || (dividend > 0 && divisor < 0);

            if (dividend > 0)
                dividend = 0 - dividend;
            if (divisor > 0)
                divisor = 0 - divisor;

            //Another couple simple cases
            if (divisor < dividend)
                return 0;
            if (divisor == dividend)
            {
                if (negative)
                    return -1;
                return 1;
            }



            /*
            int tempDiv = divisor;
            int tempMult = 1;
            int result = 0;
            while(dividend < tempDiv + tempDiv)
            {
                tempDiv += tempDiv;
                tempMult += tempMult;
            }
            if (tempMult != 1) //If the above While loop helped, save this and move forward.
                               //Do things the long way below if the While loop didn't help,
                               //or if it did, do the below with the remainder
            {
                dividend -= tempDiv;
                result += tempMult;
            }

            while (dividend <= 0) //Now back to my original idea since the numbers are small enough to work with
            {
                dividend -= divisor;
                result++;
            }
            result--; //Went 1 too far, so it's fixed here (With some exceptions?  Will test...)
            if (negative)
                result = 0 - result;
            */



            int result = 0;

            //I'll work on more LeetCode soon.  Getting a new device setup with Visual Studio etc

            throw new Exception("TODO");














            return result;
        }
    }
}
