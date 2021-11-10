﻿/*
 * Tyler Richey
 * Programming Practice - LeetCode
 * Started on 6/23/2021
 */

using System;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                try
                {
                    Console.Write("Enter a number to run that LeetCode solution: ");
                    int i = int.Parse(Console.ReadLine());
                    try
                    {
                        switch (i)
                        {
                            case -1: new SDVProb1(); break; //This is a separate practice problem, unrelated to LeetCode
                            case 1: new LeetCode0001(); break; //All solutions are mine unless noted otherwise
                            case 2: new LeetCode0002(); break;
                            case 3: new LeetCode0003(); break;
                            case 4: new LeetCode0004(); break;
                            case 5: new LeetCode0005(); break;
                            case 6: new LeetCode0006(); break;
                            case 7: new LeetCode0007(); break;
                            case 8: new LeetCode0008(); break;
                            case 9: new LeetCode0009(); break;
                            case 10: new LeetCode0010(); break; //Did not solve this one myself
                            case 11: new LeetCode0011(); break;
                            case 12: new LeetCode0012(); break;
                            case 13: new LeetCode0013(); break;
                            case 14: new LeetCode0014(); break;
                            case 15: new LeetCode0015(); break;
                            case 16: new LeetCode0016(); break;
                            case 17: new LeetCode0017(); break;
                            case 18: new LeetCode0018(); break;
                            case 19: new LeetCode0019(); break;
                            case 20: new LeetCode0020(); break;
                            case 21: new LeetCode0021(); break;
                            case 22: new LeetCode0022(); break;
                            case 23: new LeetCode0023(); break;
                            case 24: new LeetCode0024(); break;
                            case 25: new LeetCode0025(); break;
                            case 26: new LeetCode0026(); break;
                            case 27: new LeetCode0027(); break;
                            case 28: new LeetCode0028(); break;
                            case 29: new LeetCode0029(); break; //Not finished yet.  Works, but runs too slow for the LeetCode tests
                            case 31: new LeetCode0031(); break;
                            case 33: new LeetCode0033(); break;
                            case 34: new LeetCode0034(); break;
                            case 35: new LeetCode0035(); break;
                            case 36: new LeetCode0036(); break;
                            case 37: new LeetCode0037(); break;
                            case 38: new LeetCode0038(); break; //Most recently worked on
                            default: Console.WriteLine("That number is not currently supported.  Please try again."); break;
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("Error: Input must be an integer.");
                }
                Console.WriteLine("");
            }
        }
    }
}
