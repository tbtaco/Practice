/*
 * Author: Tyler Richey
 * LeetCode: 100
 * Title: Same Tree
 * Description: Given the roots of two binary trees p and q, write a function to check if they are the same or not.
 * Difficulty: Easy
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 8/13/2023
 * Notes: 
 */

using System;

/*
100. Same Tree
Easy
Given the roots of two binary trees p and q, write a function to check if they are the same or not.

Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.

Example 1:
Input: p = [1,2,3], q = [1,2,3]
Output: true

Example 2:
Input: p = [1,2], q = [1,null,2]
Output: false

Example 3:
Input: p = [1,2,1], q = [1,1,2]
Output: false

Constraints:
    The number of nodes in both trees is in the range [0, 100].
    -10^4 <= Node.val <= 10^4
*/

namespace Practice
{
    class LeetCode0100
    {
        // Test Cases
        public LeetCode0100()
        {
            try
            {
                Console.WriteLine("Input: [1, [2, 3]] and [1, [2, 3]], Output: " +
                    IsSameTree(new TreeNode(1, new TreeNode(2), new TreeNode(3)), new TreeNode(1, new TreeNode(2), new TreeNode(3))));
                Console.WriteLine("Input: [1, [2, 3]] and [1, [2, 4]], Output: " +
                    IsSameTree(new TreeNode(1, new TreeNode(2), new TreeNode(3)), new TreeNode(1, new TreeNode(2), new TreeNode(4))));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;

            if (p == null || q == null)
                return false;

            if (p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right))
                return true;

            return false;
        }
    }
}
