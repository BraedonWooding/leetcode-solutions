public class Solution {
    public string LongestPalindrome(string s) {
        return Recursive(s, 0, 0);
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