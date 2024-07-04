public class Solution {
    public string LongestPalindrome(string s) {
        // 2 variables are your indexes
        var dp = new int[s.Length, s.Length];
        int maxLength = 1;
        int start = 0;
        // we know that the diagonal are all palindromes (of one)
        for (int i = 0; i < s.Length; i++) {
            dp[i, i] = 1;
        }
        for (int i = 0; i < s.Length -1; i++) {
            if (s[i] == s[i + 1]) {
                dp[i, i + 1] = 2;
                start = i;
                maxLength = 2;
            }
        }

        for (int len = 2; len < s.Length; len++) {
            for (int i = 0; i < s.Length - len; i++) {
                int end = i + len;
                if (s[i] == s[end] && dp[i + 1, end - 1] > 0) {
                    dp[i, end] = dp[i + 1, end - 1] + 1;
                    if (len + 1 > maxLength) {
                        start = i;
                        maxLength = len + 1;
                    }
                }
            }
        }

        return s[start..(start + maxLength)];
    }

    public string Recursive(string s, int start, int end) {
        if (start < 0 || end >= s.Length) return ""; 
        var candidate = "";
        var maxLength = 0;
        if (start == end) {
            candidate = Recursive(s, start + 1, start + 1);
            maxLength = candidate.Length;
        }
        if (s[start] == s[end]) {
            var possible = s[start..(end + 1)];
            if (possible.Length > maxLength) {
                candidate = possible;                
                maxLength = possible.Length;
            }

            // odd or even palindrome

            if (start > 0 && end < s.Length - 1) {
                possible = Recursive(s, start - 1, end + 1);
                if (possible.Length > maxLength) {
                    candidate = possible;                
                    maxLength = possible.Length;
                }
            }

            if (start == end && end < s.Length - 1) {
                possible = Recursive(s, start, end + 1);
                if (possible.Length > maxLength) {
                    candidate = possible;                
                    maxLength = possible.Length;
                }
            }
        }

        return candidate;
    }
}