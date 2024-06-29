public class Solution {
    // we can use the fact that we never access more than i - 1, j - 1
    // and just store prev/current row
    public bool IsInterleave(string s1, string s2, string s3) {
        if (s1.Length + s2.Length != s3.Length) return false;

        var currentRow = new bool[s2.Length + 1];
        var prevRow = new bool[s2.Length + 1];
        
        // base case empty strings work
        prevRow[0] = false;
        currentRow[0] = true;

        for (int i = 0; i <= s1.Length; i++) {
            for (int j = 0; j <= s2.Length; j++) {
                if (i != 0 && j != 0) currentRow[j] = false;
                if (i > 0 && s3[i + j - 1] == s1[i - 1]) {
                    currentRow[j] = prevRow[j];
                }
                if (j > 0 && s3[i + j - 1] == s2[j - 1]) {
                    currentRow[j] |= currentRow[j - 1];
                }
            }
            (prevRow, currentRow) = (currentRow, prevRow);
        }

        return prevRow[s2.Length];
    }

    public bool IsInterleaveInitial(string s1, string s2, string s3) {
        if (s1.Length + s2.Length != s3.Length) return false;

        var dp = new bool[s1.Length + 1, s2.Length + 1];
        // base case empty strings work
        dp[0, 0] = true;

        for (int i = 0; i <= s1.Length; i++) {
            for (int j = 0; j <= s2.Length; j++) {
                if (i > 0 && s3[i + j - 1] == s1[i - 1]) {
                    dp[i, j] = dp[i - 1, j];
                }
                if (j > 0 && s3[i + j - 1] == s2[j - 1]) {
                    dp[i, j] |= dp[i, j - 1];
                }
            }
        }

        return dp[s1.Length, s2.Length];
    }
}