/*
// Definition for a QuadTree node.
public class Node {
    public bool val;
    public bool isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;

    public Node() {
        val = false;
        isLeaf = false;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val, bool _isLeaf) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val,bool _isLeaf,Node _topLeft,Node _topRight,Node _bottomLeft,Node _bottomRight) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = _topLeft;
        topRight = _topRight;
        bottomLeft = _bottomLeft;
        bottomRight = _bottomRight;
    }
}
*/

public class Solution {
    public Node Construct(int[][] grid) {
        return ConstructRec((0, 0), grid.Length);

        Node ConstructRec((int x, int y) offset, int len) {
            if (len == 1) {
                // base case
                return new Node(grid[offset.y][offset.x] == 1, true);
            }
            
            var newLen = len / 2;
            // sub nodes
            var topLeft = ConstructRec(offset, newLen);
            var topRight = ConstructRec((offset.x + newLen, offset.y), newLen);
            var bottomLeft = ConstructRec((offset.x, offset.y + newLen), newLen);
            var bottomRight = ConstructRec((offset.x + newLen, offset.y + newLen), newLen);
            if (topLeft.isLeaf && topRight.isLeaf && bottomLeft.isLeaf && bottomRight.isLeaf &&
                topLeft.val == topRight.val && topLeft.val == bottomLeft.val && topLeft.val == bottomRight.val) {
                return new Node(topLeft.val, true);
            }
            else {
                return new Node(true, false, topLeft, topRight, bottomLeft, bottomRight);
            }
        }
    }
}