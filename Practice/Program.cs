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
                            case 1: new LeetCode0001(); break;
                            case 2: new LeetCode0002(); break;
                            case 3: new LeetCode0003(); break;
                            case 4: new LeetCode0004(); break;
                            case 5: new LeetCode0005(); break;
                            case 6: new LeetCode0006(); break;
                            case 7: new LeetCode0007(); break;
                            case 8: new LeetCode0008(); break;
                            case 9: new LeetCode0009(); break;
                            case 10: new LeetCode0010(); break;
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
