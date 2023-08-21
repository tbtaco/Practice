/*
 * Author: Tyler Richey
 * LeetCode: 108
 * Title: Convert Sorted Array to Binary Search Tree
 * Description: Given an integer array nums where the elements are sorted in ascending order, convert it to a height-balanced binary search tree.
 * Difficulty: Easy
 * Status: Work In Progress
 * Time Complexity: TBD
 * Date: 8/20/2023
 * Notes: 
 */

using System;
using System.Collections.Generic;
using System.Linq;

/*
108. Convert Sorted Array to Binary Search Tree
Easy
Given an integer array nums where the elements are sorted in ascending order, convert it to a height-balanced binary search tree.

Example 1:
Input: nums = [-10,-3,0,5,9]
Output: [0,-3,9,-10,null,5]
Explanation: [0,-10,5,null,-3,null,9] is also accepted:

Example 2:
Input: nums = [1,3]
Output: [3,1]
Explanation: [1,null,3] and [3,1] are both height-balanced BSTs.

Constraints:
    1 <= nums.length <= 10^4
    -10^4 <= nums[i] <= 10^4
    nums is sorted in a strictly increasing order.
*/

namespace Practice
{
    class LeetCode0108
    {
        // Test Cases
        public LeetCode0108()
        {
            try
            {
                int[][] tests = new int[][] { new int[] { -10, -3, 0, 5, 9 }, new int[] { 1, 3 } };

                foreach (int[] test in tests)
                {
                    Console.Write("Input: [");
                    for(int i = 0; i < test.Length; i++)
                    {
                        if (i > 0)
                            Console.Write(", ");
                        Console.Write(test[i]);
                    }
                    Console.WriteLine("], Output: [" + PrintTreeNode(SortedArrayToBST(test)) + "]");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        private String PrintTreeNode(TreeNode head)
        {
            if (head == null)
                return "null";

            if (head.left == null && head.right == null)
                return "" + head.val;

            return PrintTreeNode(head.left) + ", " + head.val + ", " + PrintTreeNode(head.right);
        }
        // Solution
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return SortedArrayToBST(nums.ToList());
        }
        private TreeNode SortedArrayToBST(List<int> nums)
        {
            throw new Exception("TODO");

            // Not entirely sure I understand what I'm trying to do with this one.  I'll look at it again at a later date.

            /*
            if (nums == null || nums.Count == 0)
                return null;

            if (nums.Count == 1)
                return new TreeNode(nums[0]);

            if (nums.Count == 2)
                return new TreeNode(nums[0], new TreeNode(nums[1]));

            if (nums.Count == 3)
                return new TreeNode(nums[1], new TreeNode(nums[0]), new TreeNode(nums[2]));

            int start1 = 0;
            int end1 = nums.Count / 2 - 1;
            int middle = end1 + 1;
            int start2 = middle + 1;
            int end2 = nums.Count - 1;
            return new TreeNode(nums[middle], SortedArrayToBST(nums.GetRange(start1, end1 - start1 + 1)), SortedArrayToBST(nums.GetRange(start2, end2 - start2 + 1)));
            */
        }
    }
}
