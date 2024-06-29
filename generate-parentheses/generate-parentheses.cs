public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        var list = new List<string>();
        Generate(list, "", 0, n);
        return list;
    }

    public void Generate(List<string> set, string prefix, int open, int n) {
        if (n == 0) return;
        // we can't open any more
        // this is a slight optimization since technically we could just add
        // if (open < n) to the else generate
        if (open == n) {
            set.Add(prefix + new String(')', open));
        }
        // else open one!
        else {
            Generate(set, prefix + '(', open + 1, n);
            if (open > 0) {
                // we can also close one earlier, though have to reflect that in n
                Generate(set, prefix + ')', open - 1, n - 1);
            }
        }
    }
}