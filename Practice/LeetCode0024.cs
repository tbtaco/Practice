/*
 * Tyler Richey
 * LeetCode 24
 * 8/30/2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
24. Swap Nodes in Pairs
Medium

Given a linked list, swap every two adjacent nodes and return its head.
You must solve the problem without modifying the values in the list's nodes
(i.e., only nodes themselves may be changed.)

Example 1:

Input: head = [1,2,3,4]
Output: [2,1,4,3]

Example 2:

Input: head = []
Output: []

Example 3:

Input: head = [1]
Output: [1]

Constraints:

    The number of nodes in the list is in the range [0, 100].
    0 <= Node.val <= 100
*/

//Note: ListNode defined in LeetCode0002.cs

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

namespace Practice
{
    class LeetCode0024
    {
        public LeetCode0024()
        {
            const int minCount = 0;
            const int maxCount = 100;
            const int minVal = 0;
            const int maxVal = 100;
            Random r = new Random();

            for(int i = 0; i < 10; i++)
            {
                int count = r.Next(maxCount - minCount + 1) + minCount;
                ListNode head;
                ListNode current;
                if (count == 0)
                    head = null;
                else
                {
                    head = new ListNode(r.Next(maxVal - minVal + 1) + minCount, null);
                    current = head;
                    count--;
                    while (count > 0)
                    {
                        current.next = new ListNode(r.Next(maxVal - minVal + 1) + minCount, null);
                        current = current.next;
                        count--;
                    }
                }
                Console.Write("Input: [");
                current = null;
                if (head != null)
                {
                    Console.Write(head.val);
                    current = head.next;
                }
                while(current != null)
                {
                    Console.Write(", " + current.val);
                    current = current.next;
                }
                Console.Write("]\nOutput: [");
                ListNode result = SwapPairs(head);
                current = null;
                if (result != null)
                {
                    Console.Write(result.val);
                    current = result.next;
                }
                while (current != null)
                {
                    Console.Write(", " + current.val);
                    current = current.next;
                }
                Console.WriteLine("]\n");
            }
        }
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null)
                return null;
            if (head.next == null)
                return head;
            ListNode temp = head;
            head = head.next;
            temp.next = head.next;
            head.next = temp;
            head.next.next = SwapPairs(head.next.next);
            return head;
        }
    }
}
