/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     TreeNode *left;
 *     TreeNode *right;
 *     TreeNode() : val(0), left(nullptr), right(nullptr) {}
 *     TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
 *     TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
 * };
 */
class Solution {
public:
    int largestValueProcessed = INT_MAX;

    int getMinimumDifference(TreeNode* root) {
        if (root == nullptr) return INT_MAX;

        int diff = getMinimumDifference(root->left);
        // no need for abs, this node will become our largest value so it's > largestValueProcessed
        if (largestValueProcessed != INT_MAX) diff = min(diff, root->val - largestValueProcessed);
        // now we can update our largest value since it would be "this node"
        largestValueProcessed = root->val;

        return min(getMinimumDifference(root->right), diff);
    }
};