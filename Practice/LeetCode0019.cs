/*
 * Author: Tyler Richey
 * LeetCode: 19
 * Title: Remove Nth Node From End of List
 * Description: Remove the Nth node from the end of a linked list.
 * Difficulty: Medium
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 8/6/2021
 * Notes: 
 */

using System;

/*
19. Remove Nth Node From End of List
Medium

Given the head of a linked list, remove the nth node from the end of the list and return its head.

Example 1:

Input: head = [1,2,3,4,5], n = 2
Output: [1,2,3,5]

Example 2:

Input: head = [1], n = 1
Output: []

Example 3:

Input: head = [1,2], n = 1
Output: [1]

Constraints:

    The number of nodes in the list is sz.
    1 <= sz <= 30
    0 <= Node.val <= 100
    1 <= n <= sz

Follow up: Could you do this in one pass?
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

// Note: ListNode was defined in LeetCode0002.cs

namespace Practice
{
    class LeetCode0019
    {
        // Test Cases
        public LeetCode0019()
        {
            try
            {
                Random r = new Random();

                for (int i = 0; i < 10; i++)
                {
                    int nodes = r.Next(30) + 1;
                    int toRemove = r.Next(nodes) + 1;
                    ListNode head = new ListNode(r.Next(101), null);
                    ListNode current = head;
                    Console.Write("Input: [" + head.val);
                    for (int j = 1; j < nodes; j++)
                    {
                        current.next = new ListNode(r.Next(101), null);
                        current = current.next;
                        Console.Write(", " + current.val);
                    }

                    Console.Write("]\nRemove: " + toRemove + "\nResult: [");
                    ListNode result = RemoveNthFromEnd(head, toRemove);
                    for (int j = 0; j < nodes - 1; j++)
                    {
                        if (result == null)
                            throw new Exception("Error: There were fewer values than expected.  Check code!");
                        if (j > 0)
                            Console.Write(", ");
                        Console.Write(result.val);
                        result = result.next;
                    }

                    if (result != null)
                        throw new Exception("Error: There were more values than expected.  Check code!");

                    Console.WriteLine("]\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode temp = head;
            int size = 0;
            while (temp != null) // I don't know how long it is, so this is necessary.  Doing this in one pass is not possible
            {
                temp = temp.next;
                size++;
            }

            if (size == 1)
                return null;

            if (size == n)
                return head.next;

            temp = head; // Reset and now I'll go to the n'th from the end, minus 1, and change it's next value to skip the n'th node
            for(int i = 0; i < size - n - 1; i++)
                temp = temp.next;
            temp.next = temp.next.next;

            return head;
        }
    }
}
