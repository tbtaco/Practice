/*
 * Tyler Richey
 * LeetCode 23
 * 8/20/2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
23. Merge k Sorted Lists
Hard

You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.
Merge all the linked-lists into one sorted linked-list and return it.

Example 1:

Input: lists = [[1,4,5],[1,3,4],[2,6]]
Output: [1,1,2,3,4,4,5,6]
Explanation: The linked-lists are:
[
  1->4->5,
  1->3->4,
  2->6
]
merging them into one sorted list:
1->1->2->3->4->4->5->6

Example 2:

Input: lists = []
Output: []

Example 3:

Input: lists = [[]]
Output: []

Constraints:

    k == lists.length
    0 <= k <= 10^4
    0 <= lists[i].length <= 500
    -10^4 <= lists[i][j] <= 10^4
    lists[i] is sorted in ascending order.
    The sum of lists[i].length won't exceed 10^4.
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
    class LeetCode0023
    {
        public LeetCode0023()
        {
            //The following was copied from LeetCode0021.cs and as such will only test for 2 lists, but this is enough for my tests
            const int maxNodes = 50;
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
                ListNode output = MergeKLists(new ListNode[] { head1, head2 }); //Modified
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
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0)
                return null;
            if (lists.Length == 1)
                return lists[0];
            if (AllAreNull(lists))
                return null;

            int lowest = 0;
            while(lists[lowest] == null && lowest < lists.Length)
                lowest++;
            if (lowest == lists.Length)
                return null;
            for(int i = lowest + 1; i < lists.Length; i++)
                if (lists[i] != null && lists[lowest].val > lists[i].val)
                    lowest = i;
            ListNode result = new ListNode(lists[lowest].val, null);
            lists[lowest] = lists[lowest].next;

            ListNode current = result;
            while(!AllAreNull(lists))
            {
                lowest = 0;
                while (lists[lowest] == null)
                    lowest++;
                for (int i = lowest + 1; i < lists.Length; i++)
                    if (lists[i] != null && lists[lowest].val > lists[i].val)
                        lowest = i;
                current.next = new ListNode(lists[lowest].val, null);
                current = current.next;
                lists[lowest] = lists[lowest].next;
            }

            return result;
        }
        private Boolean AllAreNull(ListNode[] lists)
        {
            foreach (ListNode list in lists)
                if (list != null)
                    return false;
            return true;
        }
    }
}
