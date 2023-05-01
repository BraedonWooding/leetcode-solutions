/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */
struct ListNode* middleNode(struct ListNode *head){
    // find length
    int len = 0;
    struct ListNode *p = head;
    while (p) {
        len++;
        p = p->next;
    }

    int midpoint = len / 2;
    while (midpoint > 0) {
        head = head->next;
        midpoint--;
    }

    return head;
}