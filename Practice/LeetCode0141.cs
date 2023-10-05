/*
 * Author: Tyler Richey
 * LeetCode: 141
 * Title: Linked List Cycle
 * Description: Given head, the head of a linked list, determine if the linked list has a cycle in it.
 * Difficulty: Easy
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 10/5/2023
 * Notes: By using 2 pointers where one is faster than the other, if a loop is present they will collide in at most 2 loops.
 */

using System;

/*
141. Linked List Cycle
Easy
Given head, the head of a linked list, determine if the linked list has a cycle in it.

There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer.
Internally, pos is used to denote the index of the node that tail's next pointer is connected to. Note that pos is not passed as a parameter.
Return true if there is a cycle in the linked list. Otherwise, return false.

Example 1:
Input: head = [3,2,0,-4], pos = 1
Output: true
Explanation: There is a cycle in the linked list, where the tail connects to the 1st node (0-indexed).

Example 2:
Input: head = [1,2], pos = 0
Output: true
Explanation: There is a cycle in the linked list, where the tail connects to the 0th node.

Example 3:
Input: head = [1], pos = -1
Output: false
Explanation: There is no cycle in the linked list.

Constraints:
    The number of the nodes in the list is in the range [0, 10^4].
    -10^5 <= Node.val <= 10^5
    pos is -1 or a valid index in the linked-list.

Follow up: Can you solve it using O(1) (i.e. constant) memory?
*/

namespace Practice
{
    class LeetCode0141
    {
        // Test Cases
        public LeetCode0141()
        {
            try
            {
                ListNode a = new ListNode(1), b = new ListNode(2), c = new ListNode(3), d = new ListNode(4);
                a.next = b;
                b.next = c;
                c.next = d;
                d.next = b;

                ListNode e = new ListNode(5), f = new ListNode(6), g = new ListNode(7);
                e.next = f;
                f.next = g;

                ListNode h = new ListNode(8);

                Console.WriteLine("For a->b->c->d->b... is there a cycle?  " + HasCycle(a));
                Console.WriteLine("For e->f->g is there a cycle?  " + HasCycle(e));
                Console.WriteLine("For h is there a cycle?  " + HasCycle(h));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        // Solution
        public bool HasCycle(ListNode head)
        {
            if (head == null)
                return false;

            ListNode p1 = head, p2 = head.next;

            while (p1 != null && p2 != null)
            {
                if (p1 == p2)
                    return true;

                p1 = p1.next;
                if (p2.next == null)
                    return false;
                p2 = p2.next.next;
            }

            return false;
        }
    }
}
