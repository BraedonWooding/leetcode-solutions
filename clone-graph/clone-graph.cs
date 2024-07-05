/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Dictionary<int, Node> lookup = new();

    public Node CloneGraph(Node node) {
        if (node == null) return null;
        if (lookup.TryGetValue(node.val, out var cloned)) return cloned;
        cloned = lookup[node.val] = new Node(node.val);
        ((List<Node>)cloned.neighbors).AddRange(node.neighbors.Select(CloneGraph).ToList());
        return cloned;
    }
}