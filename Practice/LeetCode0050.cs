/*
 * Tyler Richey
 * LeetCode 50
 * 6/14/2022
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
50. Pow(x, n)
Medium

Implement pow(x, n), which calculates x raised to the power n (i.e., x^n).

Example 1:

Input: x = 2.00000, n = 10
Output: 1024.00000

Example 2:

Input: x = 2.10000, n = 3
Output: 9.26100

Example 3:

Input: x = 2.00000, n = -2
Output: 0.25000
Explanation: 2^-2 = 1/2^2 = 1/4 = 0.25

Constraints:

    -100.0 < x < 100.0
    -2^31 <= n <= 2^31-1
    -10^4 <= x^n <= 10^4
*/

namespace Practice
{
    class LeetCode0050
    {
        public LeetCode0050()
        {
            int[][] tests = new int[][]
            {
                new int[]{ 0, 1 },
                new int[]{ 1, 0 },
                new int[]{ 1, -1 },
                new int[]{ -1, 1 },
                new int[]{ 20, 2 },
                new int[]{ 9, 9 },
                new int[]{ -4, -4 },
                new int[]{ 2, -8 },
                new int[]{ 2, -7 },
                new int[]{ 2, -6 },
                new int[]{ 2, -5 },
                new int[]{ 2, -4 },
                new int[]{ 2, -3 },
                new int[]{ 2, -2 },
                new int[]{ 2, -1 },
                new int[]{ 2, 0 },
                new int[]{ 2, 1 },
                new int[]{ 2, 2 },
                new int[]{ 2, 3 },
                new int[]{ 2, 4 },
                new int[]{ 2, 5 },
                new int[]{ 2, 6 },
                new int[]{ 2, 7 },
                new int[]{ 2, 8 },
                new int[]{ 2, -500000 }
            };
            foreach (int[] test in tests)
                Console.WriteLine(test[0] + " ^ " + test[1] + " = " + MyPow(test[0], test[1]));
        }
        public double MyPow(double x, int n)
        {
            if (x == 0)
                return 0;
            if (n == 0)
                return 1;
            if (x == 1 || n == 1)
                return x;

            if (n > 10000 || n < -10000)
            {
                if (n > 0)
                {
                    if (n % 2 == 1)
                    {
                        n--;
                        return x * MyPow(MyPow(x, n / 2), 2);
                    }
                }
                else
                {
                    if (n % 2 == 1)
                    {
                        n++;
                        return MyPow(MyPow(x, n / 2), 2) / x;
                    }
                }
                return MyPow(MyPow(x, n / 2), 2);
            }

            double result = x;
            if (n > 0)
            {
                while (n > 1)
                {
                    n--;
                    result *= x;
                }
            }
            else
            {
                result = 1 / x;
                while (n < -1)
                {
                    n++;
                    result /= x;
                }
            }
            return result;
        }
    }
}
