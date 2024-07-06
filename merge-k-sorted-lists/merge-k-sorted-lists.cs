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
        int len = lists.Length;
        while (len > 0) {
            ListNode lowestNode = lists[0];
            int lowest = (lists[0]?.val ?? int.MaxValue);
            int index = 0;
            for (int i = 1; i < len;) {
                if (lists[i] == null) {
                    lists[i] = lists[len - 1];
                    len--;
                }
                else if (lowest > lists[i].val) {
                    lowestNode = lists[i];
                    lowest = lowestNode.val;
                    index = i;
                    if (lowest == cur?.val) break;
                    i++;
                } else i++;
            }

            // no more items
            if (lowestNode == null) break;
            else {
                lists[index] = lowestNode.next;
                lowestNode.next = null;
                if (lists[index] == null && len > 0) {
                    len--;
                    lists[index] = lists[len];
                }

                if (head == null) head = cur = lowestNode;
                else cur = cur.next = lowestNode;
            }
        }

        return head;
    }
}