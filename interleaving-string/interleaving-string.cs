public class Solution {
    public bool IsInterleave(string s1, string s2, string s3) {
        if (s1.Length + s2.Length != s3.Length) return false;

        var dp = new bool[s1.Length + 1, s2.Length + 1];
        // base case empty strings work
        dp[0, 0] = true;
        for (int i = 1; i <= s1.Length && s3[i - 1] == s1[i - 1]; i++) {
            dp[i, 0] = true;
        }
        for (int i = 1; i <= s2.Length && s3[i - 1] == s2[i - 1]; i++) {
            dp[0, i] = true;
        }

        for (int i = 1; i <= s1.Length; i++) {
            for (int j = 1; j <= s2.Length; j++) {
                if (s3[i + j - 1] == s1[i - 1]) {
                    dp[i, j] = dp[i - 1, j];
                }
                if (s3[i + j - 1] == s2[j - 1]) {
                    dp[i, j] |= dp[i, j - 1];
                }
            }
        }

        for (int i = 0; i <= s1.Length; i++) {
            for (int j = 0; j <= s2.Length; j++) {
                Console.Write((dp[i, j] ? 1 : 0) + " ");
            }
            Console.WriteLine();
        }

        return dp[s1.Length, s2.Length];
    }
}