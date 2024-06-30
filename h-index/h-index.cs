public class Solution {
    public int HIndex(int[] citations) {
        // h-index = max(h) such that citations.take(h) > h
        Array.Sort(citations);

        for (int i = 0; i < citations.Length; i++) {
            if (citations[i] >= citations.Length - i) return citations.Length - i;
        }
        return 0;
    }
}