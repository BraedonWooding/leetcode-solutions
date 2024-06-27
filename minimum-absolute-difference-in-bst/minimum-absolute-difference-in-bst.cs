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
    int? largestValueProcessed = null;
    
    // Since this is sorted we can rely on the fact that the tree will be increasing
    // and in decreasing order so we can just compare the difference between our node
    // and our children (recursively) and know that it will be the absolute minimum distance
    // because left < parent < right
    public int GetMinimumDifference(TreeNode root) {
        if (root == null) return int.MaxValue;

        // no need for abs, this node will become our largest value so it's > largestValueProcessed
        int diff = GetMinimumDifference(root.left);
        if (largestValueProcessed.HasValue) diff = Math.Min(diff, root.val - largestValueProcessed.Value);
        // now we can update our largest value since it would be "this node"
        largestValueProcessed = root.val;

        return Math.Min(GetMinimumDifference(root.right), diff);
    }
}