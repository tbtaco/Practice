/*
 * Author: Tyler Richey
 * LeetCode: 160
 * Title: Intersection of Two Linked Lists
 * Description: Given the heads of two singly linked-lists headA and headB, return the node at which the two lists intersect.
 * Difficulty: Easy
 * Status: Solved
 * Time Complexity: O(n)
 * Date: 8/8/2023
 * Notes: 
 */

using System;

/*
160. Intersection of Two Linked Lists
Easy
Given the heads of two singly linked-lists headA and headB, return the node at which the two lists intersect.
If the two linked lists have no intersection at all, return null.

For example, the following two linked lists begin to intersect at node c1:
The test cases are generated such that there are no cycles anywhere in the entire linked structure.
Note that the linked lists must retain their original structure after the function returns.

Custom Judge:
The inputs to the judge are given as follows (your program is not given these inputs):
    intersectVal - The value of the node where the intersection occurs. This is 0 if there is no intersected node.
    listA - The first linked list.
    listB - The second linked list.
    skipA - The number of nodes to skip ahead in listA (starting from the head) to get to the intersected node.
    skipB - The number of nodes to skip ahead in listB (starting from the head) to get to the intersected node.

The judge will then create the linked structure based on these inputs and pass the two heads, headA and headB to your program.
If you correctly return the intersected node, then your solution will be accepted.

Example 1:
Input: intersectVal = 8, listA = [4,1,8,4,5], listB = [5,6,1,8,4,5], skipA = 2, skipB = 3
Output: Intersected at '8'
Explanation: The intersected node's value is 8 (note that this must not be 0 if the two lists intersect).
From the head of A, it reads as [4,1,8,4,5]. From the head of B, it reads as [5,6,1,8,4,5]. There are 2 nodes before the intersected node in A; There are 3 nodes before the intersected node in B.
- Note that the intersected node's value is not 1 because the nodes with value 1 in A and B (2nd node in A and 3rd node in B) are different node references. In other words, they point to two different locations in memory, while the nodes with value 8 in A and B (3rd node in A and 4th node in B) point to the same location in memory.

Example 2:
Input: intersectVal = 2, listA = [1,9,1,2,4], listB = [3,2,4], skipA = 3, skipB = 1
Output: Intersected at '2'
Explanation: The intersected node's value is 2 (note that this must not be 0 if the two lists intersect).
From the head of A, it reads as [1,9,1,2,4]. From the head of B, it reads as [3,2,4]. There are 3 nodes before the intersected node in A; There are 1 node before the intersected node in B.

Example 3:
Input: intersectVal = 0, listA = [2,6,4], listB = [1,5], skipA = 3, skipB = 2
Output: No intersection
Explanation: From the head of A, it reads as [2,6,4]. From the head of B, it reads as [1,5]. Since the two lists do not intersect, intersectVal must be 0, while skipA and skipB can be arbitrary values.
Explanation: The two lists do not intersect, so return null.

Constraints:
    The number of nodes of listA is in the m.
    The number of nodes of listB is in the n.
    1 <= m, n <= 3 * 10^4
    1 <= Node.val <= 10^5
    0 <= skipA < m
    0 <= skipB < n
    intersectVal is 0 if listA and listB do not intersect.
    intersectVal == listA[skipA] == listB[skipB] if listA and listB intersect.

Follow up: Could you write a solution that runs in O(m + n) time and use only O(1) memory?
*/

namespace Practice
{
    class LeetCode0160
    {
        // Test Cases
        public LeetCode0160()
        {
            try
            {
                Random r = new Random();
                r.Next(); r.Next(); r.Next();

                for (int test = 1; test <= 5; test++)
                {
                    ListNode head1 = null, head2 = null, shared = null, current = null;

                    for (int i = 0; i < r.Next(5); i++)
                    {
                        if(i == 0)
                        {
                            current = new ListNode(r.Next(1000), null);
                            shared = current;
                        }
                        else
                        {
                            current.next = new ListNode(r.Next(1000), null);
                            current = current.next;
                        }
                    }

                    current = null;
                    for(int i = r.Next(10); i >= 0; i--)
                    {
                        if(i == 0)
                        {
                            if (current == null)
                                head1 = shared;
                            else
                                current.next = new ListNode(r.Next(1000), shared);
                        }
                        else if(head1 == null)
                        {
                            current = new ListNode(r.Next(1000), null);
                            head1 = current;
                        }
                        else
                        {
                            current.next = new ListNode(r.Next(1000), null);
                            current = current.next;
                        }
                    }

                    current = null;
                    for (int i = r.Next(10); i >= 0; i--)
                    {
                        if (i == 0)
                        {
                            if (current == null)
                                head2 = shared;
                            else
                                current.next = new ListNode(r.Next(1000), shared);
                        }
                        else if (head2 == null)
                        {
                            current = new ListNode(r.Next(1000), null);
                            head2 = current;
                        }
                        else
                        {
                            current.next = new ListNode(r.Next(1000), null);
                            current = current.next;
                        }
                    }

                    Console.Write("Test " + test + ":\n  Input 1: ");
                    PrintList(head1);
                    Console.Write("\n  Input 2: ");
                    PrintList(head2);
                    Console.Write("\n  Output: ");
                    PrintList(GetIntersectionNode(head1, head2));
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something seemed to break with that last test.  See below:\n" + e);
            }
        }
        private void PrintList(ListNode head)
        {
            if (head == null)
                return;
            Console.Write(head.val);
            ListNode current = head.next;
            while(current != null)
            {
                Console.Write(", " + current.val);
                current = current.next;
            }
        }
        // Solution
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode a = headA;
            ListNode b = headB;

            // The main thing I need to accomplish here is getting both to be the same length from the end.
            // Going through both equally and starting each over at the start of the opposite head does this.
            // Worst case it goes through both lists twice before returning null since both would then be null.

            while(a != b)
            {
                if (a == null)
                    a = headB;
                else
                    a = a.next;

                if (b == null)
                    b = headA;
                else
                    b = b.next;
            }

            return a;
        }
    }
}
