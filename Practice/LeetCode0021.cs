/*
 * Author: Tyler Richey
 * LeetCode: 21
 * Title: Merge Two Sorted Lists
 * Description: Merge two sorted lists.
 * Difficulty: Easy
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 8/11/2021
 * Notes: 
 */

using System;

/*
21. Merge Two Sorted Lists
Easy

Merge two sorted linked lists and return it as a sorted list.
The list should be made by splicing together the nodes of the first two lists.

Example 1:

Input: l1 = [1,2,4], l2 = [1,3,4]
Output: [1,1,2,3,4,4]

Example 2:

Input: l1 = [], l2 = []
Output: []

Example 3:

Input: l1 = [], l2 = [0]
Output: [0]

Constraints:

    The number of nodes in both lists is in the range [0, 50].
    -100 <= Node.val <= 100
    Both l1 and l2 are sorted in non-decreasing order.
*/

/**
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

// Note: ListNode is defined in LeetCode0002.cs

namespace Practice
{
    class LeetCode0021
    {
        // Test Cases
        public LeetCode0021()
        {
            try
            {
                const int maxNodes = 50; // Does not test for node count of 0, but that was easy enough to write
                const int minVal = -100;
                const int maxVal = 100;

                Random r = new Random();
                for (int i = 0; i < 5; i++)
                {
                    ListNode head1 = new ListNode(r.Next(maxVal - minVal + 1) + minVal, null);
                    ListNode current = head1;
                    int count = 1;
                    while (count <= maxNodes && current.val != maxVal)
                    {
                        int nextVal = r.Next(maxVal - current.val + 1) + current.val;
                        current.next = new ListNode(nextVal, null);
                        current = current.next;
                        count++;
                    }

                    ListNode head2 = new ListNode(r.Next(maxVal - minVal + 1) + minVal, null);
                    current = head2;
                    count = 1;
                    while (count <= maxNodes && current.val != maxVal)
                    {
                        int nextVal = r.Next(maxVal - current.val + 1) + current.val;
                        current.next = new ListNode(nextVal, null);
                        current = current.next;
                        count++;
                    }

                    Console.Write("Input 1: [" + head1.val);
                    current = head1.next;
                    while (current != null)
                    {
                        Console.Write(", " + current.val);
                        current = current.next;
                    }

                    Console.Write("]\nInput 2: [" + head2.val);
                    current = head2.next;
                    while (current != null)
                    {
                        Console.Write(", " + current.val);
                        current = current.next;
                    }

                    ListNode output = MergeTwoLists(head1, head2);
                    Console.Write("]\nOutput: [" + output.val);
                    current = output.next;
                    while (current != null)
                    {
                        Console.Write(", " + current.val);
                        current = current.next;
                    }

                    Console.WriteLine("]");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;

            if (l2 == null)
                return l1;

            ListNode result = new ListNode(l1.val, null);

            if (l1.val > l2.val)
            {
                result = new ListNode(l2.val, null);
                l2 = l2.next;
            }
            else
                l1 = l1.next;

            ListNode current = result;

            while(l1 != null || l2 != null)
            {
                if(l1 == null)
                {
                    current.next = new ListNode(l2.val, null);
                    l2 = l2.next;
                    current = current.next;
                }

                else if(l2 == null)
                {
                    current.next = new ListNode(l1.val, null);
                    l1 = l1.next;
                    current = current.next;
                }

                else
                {
                    if(l1.val > l2.val)
                    {
                        current.next = new ListNode(l2.val, null);
                        l2 = l2.next;
                        current = current.next;
                    }

                    else
                    {
                        current.next = new ListNode(l1.val, null);
                        l1 = l1.next;
                        current = current.next;
                    }
                }
            }

            return result;
        }
    }
}
