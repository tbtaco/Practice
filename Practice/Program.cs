/*
 * Tyler Richey
 * Programming Practice - LeetCode
 * Started on 6/23/2021
 * Main Program.cs Redo On 10/31/2022
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Practice
{
    class Program
    {
        private const int TotalProblemsAvailable = 2449; // Last checked on 10/31/2022
        static void Main(string[] args)
        {
            List<Solution> solutions = new List<Solution>();
            String path = "";
            try
            {
                String[] pathParts = Path.GetFullPath(Process.GetCurrentProcess().MainModule.ModuleName).Split("\\");
                path = pathParts[0] + "\\";
                bool found = false;
                for (int i = 1; i < pathParts.Length; i++)
                {
                    if (pathParts[i] == "Practice" && i + 1 < pathParts.Length && pathParts[i + 1] == "Practice")
                    {
                        path += "Practice\\Practice\\"; // I'm after this folder
                        i = pathParts.Length;
                        found = true;
                    }
                    else
                        path += pathParts[i] + "\\";
                }

                if(!found)
                    throw new Exception("Error/TODO: Could not locate source code at ...\\Practice\\Practice\\ and can't proceed");

                String[] files = Directory.GetFiles(path);
                foreach (String file in files)
                    solutions.Add(new Solution(file));
            }
            catch(Exception e)
            {
                path = "";
                Console.WriteLine("Error: Something seemed to break with initialization.  See below:\n" + e);
            }

            while (true)
            {
                Console.Write("Enter a number to run that LeetCode solution (or \"?\" for help): ");
                String input = Console.ReadLine().ToLower();
                if(input == "?" || input == "h" || input == "help" || input == "s" || input == "status" || input == "l" || input == "list")
                {
                    Console.WriteLine("\nEnter a number to run that LeetCode solution.  Status of current LeetCode solutions are shown below:");
                    Console.Write("  Solved: ");
                    bool comma = false;
                    String notMarkedAsSolved = "  Not marked as \"Solved\":\n";
                    String otherWithoutStatus = "  Added, but missing a status: ";
                    int initialLength = otherWithoutStatus.Length;
                    List<int> nums = new List<int>();
                    foreach(Solution s in solutions)
                    {
                        if(s.IsSolved())
                        {
                            if (comma)
                                Console.Write(", ");
                            comma = true;
                            Console.Write(s.GetNumber());
                        }
                        else
                        {
                            String t = s.GetStatus();
                            if(t != null)
                                notMarkedAsSolved += "    " + s.GetNumber() + ": " + t + "\n";
                            else
                            {
                                int num = s.GetNumber();
                                if(num > 0)
                                {
                                    if (otherWithoutStatus.Length > initialLength)
                                        otherWithoutStatus += ", ";
                                    otherWithoutStatus += num;
                                }
                            }
                        }
                        nums.Add(s.GetNumber());
                    }
                    Console.Write("\n" + notMarkedAsSolved);
                    Console.WriteLine(otherWithoutStatus);

                    BubbleSort(nums);
                    RemoveNegativesAndZerosFromSortedList(nums);
                    RemoveDuplicates(nums); // Shouldn't ever happen
                    Console.WriteLine("  Numbers not added yet: " + GetMissingNumbersFormatted(nums, TotalProblemsAvailable));

                    Console.WriteLine("To exit the program run one of the following: q, quit, e, exit");
                    Console.WriteLine("To update the README.md run one of the following: o, output, r, readme");
                    Console.WriteLine("To list this again run one of the following: ?, h, help, s, status, l, list");
                }
                else if(input == "o" || input == "output" || input == "r" || input == "readme")
                {
                    if (path == "" || path.Length < "Practice\\Practice\\".Length)
                        Console.WriteLine("No path found in initialization.  Make sure the program has .../Practice/Practice somewhere in it's path.");
                    else
                        OutputREADME(solutions, path.Substring(0, path.Length - "Practice\\".Length) + "README.temp"); // .md
                }
                else if(input == "q" || input == "quit" || input == "e" || input == "exit")
                    return;
                else
                {
                    try
                    {
                        int num = int.Parse(input);
                        if (num <= 0)
                            Console.WriteLine("Error: Input must be greater than 0");
                        else
                        {
                            Solution s = GetSolution(solutions, num);
                            if (s != null)
                                s.Run();
                            else
                                Solution.Run(num);
                        }
                    }
                    catch(Exception)
                    {
                        Console.WriteLine("Error: Input must be an integer.");
                    }
                }
                Console.WriteLine("");
            }
        }
        private static Solution GetSolution(List<Solution> solutions, int i)
        {
            foreach (Solution s in solutions)
                if (s.GetNumber() == i)
                    return s;
            return null;
        }
        private static void BubbleSort(List<int> nums)
        {
            for (int i = 0; i < nums.Count; i++)
                for (int j = 0; j < nums.Count - i - 1; j++)
                    if (nums[j] > nums[j + 1])
                    {
                        int t = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = t;
                    }
        }
        private static void RemoveNegativesAndZerosFromSortedList(List<int> nums)
        {
            while (nums.Count > 0 && nums[0] <= 0)
                nums.RemoveAt(0);
        }
        private static void RemoveDuplicates(List<int> nums)
        {
            int i = 0;
            while(i < nums.Count - 1)
            {
                if (nums[i] == nums[i + 1])
                    nums.RemoveAt(i);
                else
                    i++;
            }
        }
        private static String GetMissingNumbersFormatted(List<int> nums, int highestPossibleValue)
        {
            String result = "";
            String toAdd = "";
            int low = 1;
            int high = 1;

            while (nums.Count > 0)
            {
                if (nums[0] == high)
                {
                    toAdd = "";
                    switch(high - low)
                    {
                        case 0:
                            break;
                        case 1:
                            toAdd += low;
                            break;
                        case 2:
                            toAdd += low + ", " + (high - 1);
                            break;
                        default:
                            toAdd += low + "-" + (high - 1);
                            break;
                    }
                    if (result.Length > 0 && toAdd.Length > 0)
                        toAdd = ", " + toAdd;
                    result += toAdd;
                    low = high + 1;
                    nums.RemoveAt(0);
                }
                high++;
            }

            high = highestPossibleValue + 1;
            toAdd = "";
            switch (high - low)
            {
                case 0:
                    break;
                case 1:
                    toAdd += low;
                    break;
                case 2:
                    toAdd += low + ", " + (high - 1);
                    break;
                default:
                    toAdd += low + "-" + (high - 1);
                    break;
            }
            if (result.Length > 0 && toAdd.Length > 0)
                toAdd = ", " + toAdd;
            result += toAdd;

            return result;
        }
        private static void OutputREADME(List<Solution> solutions, String path)
        {
            try
            {
                throw new Exception("TODO");
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with outputting to README.  See below:\n" + e);
            }
        }
    }
    class Solution
    {
        private String path = "";
        private String author = "";
        private int number = 0;
        private String title = "";
        private String description = "";
        private String difficulty = "";
        private String status = "";
        private String complexity = "";
        private String date = "";
        private String notes = "";
        private bool valid = false;
        public Solution(String path)
        {
            this.path = path;
            try
            {
                StreamReader sr = new StreamReader(path);
                while(!sr.EndOfStream)
                {
                    String line = sr.ReadLine();
                    if (line.Length >= 3 && line.Substring(0, 3) == " * ")
                    {
                        String[] parts = line.Substring(3).Split(": ");
                        if(parts.Length == 2)
                            switch(parts[0])
                            {
                                case "Author": author = parts[1]; break;
                                case "LeetCode": number = int.Parse(parts[1]); break;
                                case "Title": title = parts[1]; break;
                                case "Description": description = parts[1]; break;
                                case "Difficulty": difficulty = parts[1]; break;
                                case "Status": status = parts[1]; break;
                                case "Time Complexity": complexity = parts[1]; break;
                                case "Date": date = parts[1]; break;
                                case "Notes": notes = parts[1]; break;
                                default: break;
                            }
                        else
                        {
                            for (int i = 0; i < parts.Length; i++)
                            {
                                notes += " " + parts[i];
                                if (i + 1 < parts.Length)
                                    notes += " * ";
                            }
                        }
                    }
                    else if (line == " */")
                        break;
                }
                sr.Close();

                if(number == 0)
                {
                    String[] parts = path.Split("\\");
                    String s = parts[parts.Length - 1];
                    if(s.Substring(0, 8) == "LeetCode")
                        number = int.Parse(s.Substring(8, 4));
                }
            }
            catch (Exception) { }
        }
        private bool IsValid()
        {
            if (valid)
                return valid;
            if (number > 0 && title.Length > 0 && description.Length > 0 && difficulty.Length > 0 && status.Length > 0)
                valid = true;
            return valid;
        }
        public int GetNumber()
        {
            return number;
        }
        private String GetFileName()
        {
            if(IsValid())
                return "LeetCode" + GetNumberAsString() + ".cs";
            throw new Exception("File Did Not Pass Validity Checks");
        }
        private String GetLink()
        {
            return "https://github.com/tbtaco/Practice/blob/master/Practice/" + GetFileName();
        }
        private String GetNumberAsString()
        {
            return GetNumberAsString(GetNumber());
        }
        private static String GetNumberAsString(int i)
        {
            String s = "" + i;
            while (s.Length < 4)
                s = "0" + s;
            return s;
        }
        public bool IsSolved()
        {
            if (IsValid())
                return status == "Solved";
            return false;
        }
        public String GetStatus()
        {
            if (IsValid())
                return status;
            return null;
        }
        public void Run()
        {
            Run(GetNumber());
        }
        public static void Run(int i)
        {
            String name = "Practice.LeetCode" + GetNumberAsString(i);
            Type t = Type.GetType(name);
            if (t == null)
                foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
                {
                    t = asm.GetType(name);
                    if (t != null)
                        break;
                }
            if (t != null)
                Activator.CreateInstance(t);
            else
                Console.WriteLine("Error: Could not find " + name);
        }
    }
}
