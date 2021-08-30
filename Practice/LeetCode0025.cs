/*
 * Tyler Richey
 * LeetCode 25
 * 8/30/2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
25. Reverse Nodes in k-Group
Hard

Given a linked list, reverse the nodes of a linked list k at a time and return its modified list.

k is a positive integer and is less than or equal to the length of the linked list.
If the number of nodes is not a multiple of k then left-out nodes, in the end, should remain as it is.

You may not alter the values in the list's nodes, only nodes themselves may be changed.

Example 1:

Input: head = [1,2,3,4,5], k = 2
Output: [2,1,4,3,5]

Example 2:

Input: head = [1,2,3,4,5], k = 3
Output: [3,2,1,4,5]

Example 3:

Input: head = [1,2,3,4,5], k = 1
Output: [1,2,3,4,5]

Example 4:

Input: head = [1], k = 1
Output: [1]

Constraints:

    The number of nodes in the list is in the range sz.
    1 <= sz <= 5000
    0 <= Node.val <= 1000
    1 <= k <= sz

Follow-up: Can you solve the problem in O(1) extra memory space?
*/

//Note: ListNode is defined in LeetCode0002.cs

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
    class LeetCode0025
    {
        public LeetCode0025() //Copied and modified from LeetCode0024.cs
        {
            const int minCount = 1;
            const int maxCount = 25; //5000
            const int minVal = 0;
            const int maxVal = 1000;
            Random r = new Random();

            for(int i = 0; i < 5; i++)
            {
                int count = r.Next(maxCount - minCount + 1) + minCount;
                int totalCount = count;
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
                while (current != null)
                {
                    Console.Write(", " + current.val);
                    current = current.next;
                }
                int k = r.Next(totalCount - 1) + 1;
                Console.Write("]\nK: " + k + "\nOutput: [");
                ListNode result = ReverseKGroup(head, k);

                int tempCount = 0;
                current = result;
                while(current != null)
                {
                    tempCount++;
                    current = current.next;
                }
                if (tempCount != totalCount)
                    throw new Exception("Original length: " + totalCount + ", New length: " + tempCount + ", Lengths must match!");

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
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (k == 1)
                return head;
            int count = 0;
            ListNode current = head;
            while(current != null)
            {
                count++;
                current = current.next;
            }
            if (count < k)
                return head;

            current = head;
            for (int i = k - 1; i > 0; i--)
                current = current.next;
            ListNode next = ReverseKGroup(current.next, k);

            ListNode newHead = head;
            current = newHead;
            for(int i = 1; i < k; i++)
            {
                ListNode temp = head;
                for(int j = k - i - 1; j > 0; j--)
                {
                    if(temp != null) //Should never be null...
                        temp = temp.next;
                }
                current.next = temp;
                current = current.next;
            }

            current = newHead;
            for (int i = k - 1; i > 0; i--)
                current = current.next;
            current.next = next;

            return newHead;
        }
    }
}
