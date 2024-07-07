public class Solution {
    public IList<IList<int>> Combine(int n, int k) {
        var results = new List<IList<int>>();

        void CombineBT(HashSet<int> items, int start, int n, int k) {
            if (k == 0) {
                // we can choose no more items
                results.Add(items.ToList());
                return;
            }

            for (int i = start; i <= n; i++) {
                if (!items.Contains(i)) {
                    items.Add(i);
                    CombineBT(items, i + 1, n, k - 1);
                    items.Remove(i);
                }
            }
        }

        CombineBT(new(), 1, n, k);

        return results;
    }
}