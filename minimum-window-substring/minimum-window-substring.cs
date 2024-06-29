public class Solution {
    public string MinWindow(string s, string t) {
        // to hit O(m + n) complexity we have to be careful with our searches
        // we could make this more compressed (it's just alphabet size)
        // but this is still O(1) so :shrug:
        var expectedCounts = new int[256];
        var windowCounts = new int[256];
        var totalCount = 0;
        var minimumRange = 0..int.MaxValue;
        var minimumLength = int.MaxValue;
        foreach (var c in t) expectedCounts[c]++;

        int i = 0, j = 0;
        while (true) {
            // we've found a possible window
            if (totalCount == t.Length) {
                if (minimumLength > j - i) {
                    minimumRange = i..j;
                    minimumLength = j - i;
                }
                // if the current count goes below the expected count
                // we've lost one of the chars and needs another
                if (expectedCounts[s[i]] >= windowCounts[s[i]]--) {
                    totalCount--;
                }
                // move the window head forward
                i++;
            } else if (j == s.Length) {
                return minimumLength != int.MaxValue ? s[minimumRange] : "";
            } else {
                // we've found a wanted char if we are under the expected char
                if (expectedCounts[s[j]] > windowCounts[s[j]]++) {
                    totalCount++;
                }
                // move the window tail forward
                j++;
            }
        }
    }
}