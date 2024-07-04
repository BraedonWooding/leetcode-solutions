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
    public TreeNode SortedArrayToBST(int[] nums) {
        return Helper(nums, 0, nums.Length);
    }

    public TreeNode Helper(int[] nums, int start, int length) {
        if (length <= 0) return null;
        int middle = start + length / 2;
        return new TreeNode(nums[middle], Helper(nums, start, middle - start), Helper(nums, middle + 1, (start + length) - middle - 1));
    }
}