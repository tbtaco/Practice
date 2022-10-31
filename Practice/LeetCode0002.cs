/*
 * Author: Tyler Richey
 * LeetCode: 2
 * Title: Add Two Numbers
 * Description: Add two numbers stored as linked lists, and return as a linked list.
 * Difficulty: Medium
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 6/24/2021
 * Notes: 
 */

using System;

/*
2. Add Two Numbers
Medium

You are given two non-empty linked lists representing two non-negative integers.
The digits are stored in reverse order, and each of their nodes contains a single digit.
Add the two numbers and return the sum as a linked list.
You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Example 1:

Input: l1 = [2,4,3], l2 = [5,6,4]
Output: [7,0,8]
Explanation: 342 + 465 = 807.

Example 2:

Input: l1 = [0], l2 = [0]
Output: [0]

Example 3:

Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
Output: [8,9,9,9,0,0,0,1]

Constraints:

The number of nodes in each linked list is in the range [1, 100].
0 <= Node.val <= 9
It is guaranteed that the list represents a number that does not have leading zeros.
*/

namespace Practice
{
    /*
     * Definition for singly-linked list.
     * public class ListNode {
     *     public int val;
     *     public ListNode next;
     *     public ListNode(int val=0, ListNode next=null) {
     *         this.val = val;
     *         this.next = next;
     *     }
     * }
     */
    class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null)
        {
            this.val = val;
            this.next = next;
        }
    }
    class LeetCode0002
    {
        // Test Cases
        public LeetCode0002()
        {
            try
            {
                Random r = new Random();

                int size1 = r.Next(100) + 1;
                ListNode node1 = null;
                for (int i = 0; i < size1; i++)
                    node1 = new ListNode(r.Next(10), node1);

                int size2 = r.Next(100) + 1;
                ListNode node2 = null;
                for (int i = 0; i < size2; i++)
                    node2 = new ListNode(r.Next(10), node2);

                ListNode node3 = AddTwoNumbers(node1, node2);

                Console.Write("ListNode 1: [" + node1.val);
                while (node1.next != null)
                {
                    node1 = node1.next;
                    Console.Write(", " + node1.val);
                }
                Console.WriteLine("]");
                Console.Write("ListNode 2: [" + node2.val);
                while (node2.next != null)
                {
                    node2 = node2.next;
                    Console.Write(", " + node2.val);
                }
                Console.WriteLine("]");
                Console.Write("ListNode Result: [" + node3.val);
                while (node3.next != null)
                {
                    node3 = node3.next;
                    Console.Write(", " + node3.val);
                }
                Console.WriteLine("]");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int sum = l1.val + l2.val;
            int carry = 0;
            if(sum >= 10)
            {
                sum -= 10;
                carry = 1;
            }
            ListNode current = new ListNode(sum, null);
            ListNode l3 = current;
            l1 = l1.next;
            l2 = l2.next;
            while(l1 != null || l2 != null || carry == 1)
            {
                sum = carry;
                carry = 0;
                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }
                if (sum >= 10)
                {
                    sum -= 10;
                    carry = 1;
                }
                current.next = new ListNode(sum, null);
                current = current.next;
            }
            return l3;
        }
    }
}
