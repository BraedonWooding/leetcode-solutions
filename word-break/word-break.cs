public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) {
        var dp = new bool[s.Length + 1];
        dp[0] = true;
        for (int i = 1; i <= s.Length; i++) {
            foreach (var word in wordDict) {
                if (s[0..i].EndsWith(word) && dp[i - word.Length]) {
                    dp[i] = true;
                    break;
                }
            }
        }

        return dp[s.Length];
    }
}