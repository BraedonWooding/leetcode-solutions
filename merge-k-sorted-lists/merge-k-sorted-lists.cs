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
    public ListNode MergeKLists(ListNode[] lists) {
        ListNode head = null;
        ListNode cur = null;
        while (true) {
            ListNode lowestNode = null;
            int index = -1;
            for (int i = 0; i < lists.Length; i++) {
                if (lists[i] != null && (lowestNode == null || lowestNode.val > lists[i].val)) {
                    lowestNode = lists[i];
                    index = i;
                    if (cur != null && (lowestNode.val <= cur.val)) break;
                }
            }

            // no more items
            if (lowestNode == null) break;
            else {
                lists[index] = lowestNode.next;
                lowestNode.next = null;
                if (head == null) head = cur = lowestNode;
                else cur = cur.next = lowestNode;
            }
        }

        return head;
    }
}