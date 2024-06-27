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
public class Solution {
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        // base case, we don't need to do anything
        if (k == 1) return head;

        return Tmp(head, null, head, k, 0);
    }

    public ListNode Tmp(ListNode headOfSegment, ListNode parent, ListNode current, int k, int offset)
    {
        if (headOfSegment == null || current == null) return null;

        if (offset == k - 1)
        {
            headOfSegment.next = Tmp(current.next, null, current.next, k, 0);
            current.next = parent;
            return current;
        }
        else
        {
            if (current.next == null)
            {
                // we have no more items to process
                return headOfSegment;
            }

            var result = Tmp(headOfSegment, current, current.next, k, offset + 1);
            if (parent != null && result != headOfSegment) current.next = parent;
            return result;
        }
    }
}