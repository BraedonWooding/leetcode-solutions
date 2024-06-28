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
    public bool HasPathSum(TreeNode root, int targetSum) {
        // base case: empty tree has path sum if = 0
        if (root == null) return false;
        // leaf node
        if (root.left == null && root.right == null) return targetSum == root.val;
        
        // target sum can be negative so we shouldn't do a sort of "optimization" to skip iteration if < 0

        // else we subtract our current node from the target sum then check either paths
        if (HasPathSum(root.left, targetSum - root.val)) return true;
        return HasPathSum(root.right, targetSum - root.val);
    }
}