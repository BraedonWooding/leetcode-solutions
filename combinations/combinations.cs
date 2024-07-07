public class Solution {
    public IList<IList<int>> Combine(int n, int k) {
        var results = new List<IList<int>>();

        void CombineBT(Stack<int> items, int start, int n, int k) {
            if (k == 0) {
                // we can choose no more items
                results.Add(new List<int>(items));
                return;
            }

            for (int i = start; i <= n; i++) {
                items.Push(i);
                CombineBT(items, i + 1, n, k - 1);
                items.Pop();
            }
        }

        CombineBT(new(), 1, n, k);

        return results;
    }
}