/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    int nodesVisited = 0;

    public int KthSmallest(TreeNode root, int k) {
        if (root.left != null) {
            var left = KthSmallest(root.left, k);
            if (nodesVisited == k) return left;
        }

        nodesVisited++;
        if (nodesVisited == k) return root.val;

        if (root.right != null) {
            var right = KthSmallest(root.right, k);
            if (nodesVisited == k) return right;
        }

        return root.val;
    }
}