/*
 * Author: Tyler Richey
 * LeetCode: 8
 * Title: String to Integer (atoi)
 * Description: Given a string, return the integer portion that the string starts with (if possible). Creates a sort of atoi() function.
 * Difficulty: Medium
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 7/1/2021
 * Notes: 
 */

using System;

/*
8. String to Integer (atoi)
Medium

Implement the myAtoi(string s) function, which converts a string to a 32-bit signed integer (similar to C/C++'s atoi function).
The algorithm for myAtoi(string s) is as follows:

Read in and ignore any leading whitespace.
Check if the next character (if not already at the end of the string) is '-' or '+'. Read this character in if it is either.
This determines if the final result is negative or positive respectively. Assume the result is positive if neither is present.
Read in next the characters until the next non-digit charcter or the end of the input is reached. The rest of the string is ignored.
Convert these digits into an integer (i.e. "123" -> 123, "0032" -> 32). If no digits were read, then the integer is 0.
Change the sign as necessary (from step 2).
If the integer is out of the 32-bit signed integer range [-2^31, 2^31 - 1], then clamp the integer so that it remains in the range.
Specifically, integers less than -2^31 should be clamped to -2^31, and integers greater than 2^31 - 1 should be clamped to 2^31 - 1.
Return the integer as the final result.

Note:

Only the space character ' ' is considered a whitespace character.
Do not ignore any characters other than the leading whitespace or the rest of the string after the digits.

Example 1:

Input: s = "42"
Output: 42

Explanation: The underlined characters are what is read in, the caret is the current reader position.
Step 1: "42" (no characters read because there is no leading whitespace)
         ^
Step 2: "42" (no characters read because there is neither a '-' nor '+')
         ^
Step 3: "42" ("42" is read in)
           ^
The parsed integer is 42.
Since 42 is in the range [-231, 231 - 1], the final result is 42.

Example 2:

Input: s = "   -42"
Output: -42

Explanation:
Step 1: "   -42" (leading whitespace is read and ignored)
            ^
Step 2: "   -42" ('-' is read, so the result should be negative)
             ^
Step 3: "   -42" ("42" is read in)
               ^
The parsed integer is -42.
Since -42 is in the range [-231, 231 - 1], the final result is -42.

Example 3:

Input: s = "4193 with words"
Output: 4193

Explanation:
Step 1: "4193 with words" (no characters read because there is no leading whitespace)
         ^
Step 2: "4193 with words" (no characters read because there is neither a '-' nor '+')
         ^
Step 3: "4193 with words" ("4193" is read in; reading stops because the next character is a non-digit)
             ^
The parsed integer is 4193.
Since 4193 is in the range [-231, 231 - 1], the final result is 4193.

Example 4:

Input: s = "words and 987"
Output: 0

Explanation:
Step 1: "words and 987" (no characters read because there is no leading whitespace)
         ^
Step 2: "words and 987" (no characters read because there is neither a '-' nor '+')
         ^
Step 3: "words and 987" (reading stops immediately because there is a non-digit 'w')
         ^
The parsed integer is 0 because no digits were read.
Since 0 is in the range [-231, 231 - 1], the final result is 0.

Example 5:

Input: s = "-91283472332"
Output: -2147483648

Explanation:
Step 1: "-91283472332" (no characters read because there is no leading whitespace)
         ^
Step 2: "-91283472332" ('-' is read, so the result should be negative)
          ^
Step 3: "-91283472332" ("91283472332" is read in)
                     ^
The parsed integer is -91283472332.
Since -91283472332 is less than the lower bound of the range [-231, 231 - 1], the final result is clamped to -231 = -2147483648.

Constraints:

0 <= s.length <= 200
s consists of English letters (lower-case and upper-case), digits (0-9), ' ', '+', '-', and '.'.
*/

namespace Practice
{
    class LeetCode0008
    {
        // Test Cases
        public LeetCode0008()
        {
            try
            {
                String[] tests = {"1", "0213", "Testing", "8372819283745884", "-28384758588372771", "+8475838271773848327", "+12", "-48",
                "18Test", "The lucky number of the day is: 7", "         7 is awesome!", "       321        ", "2 3 4 5",
                "2147483646"};

                foreach (String test in tests)
                {
                    Console.Write("Test: \"" + test + "\", ");
                    Console.WriteLine("Result: " + MyAtoi(test));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public int MyAtoi(string s)
        {
            String number = "";

            for(int i = 0; i < s.Length; i++)
                if (s[i] != ' ')
                {
                    Boolean readingNumbers = false;
                    while (i < s.Length && ((!readingNumbers && (s[i] == '+' || s[i] == '-')) || (s[i] >= 48 && s[i] <= 57))) // ASCII Values 0-9
                    {
                        number += s[i];
                        if (!readingNumbers)
                            readingNumbers = true;
                        i++;
                    }
                    i = s.Length;
                }

            if (number == "" || number == "+" || number == "-" || number == "0") // Get some easy cases out of the way
                return 0;

            if (number[0] != '+' && number[0] != '-')
                number = '+' + number;

            while (number.Length >= 3 && number[1] == '0') // Gets rid of unnecessary zeros
                number = number[0] + number.Substring(2);

            if (number.Length > 10) // 2,147,483,647 upper limit, -2,147,483,648 lower limit.  Anything above 10 chars then, with sign
            {
                if(number.Length > 11 || number[1] - 48 > 2)
                {
                    if (number[0] == '+')
                        return Int32.MaxValue;
                    return Int32.MinValue;
                }

                if(number[1] - 48 == 2)
                {
                    int temp = 0;
                    int mul = 1;
                    for(int i = number.Length - 1; i >= 2; i--)
                    {
                        temp += (number[i] - 48) * mul;
                        mul *= 10;
                    }

                    if (number[0] == '+' && temp > Int32.MaxValue - 2000000000)
                        return Int32.MaxValue;

                    else if (number[0] == '-' && -1 * temp < Int32.MinValue + 2000000000)
                        return Int32.MinValue;
                }
            }

            int result = 0;
            int mult = 1;
            for(int i = number.Length - 1; i >= 1; i--)
            {
                result += (number[i] - 48) * mult;
                mult *= 10;
            }

            if (number[0] == '-')
                result *= -1;

            return result;
        }
    }
}
