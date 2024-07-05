public class Solution {
    public bool IsIsomorphic(string s, string t) {
        if (s.Length != t.Length) return false;
        var mapping = new Dictionary<char, char>();
        var values = new HashSet<char>();

        for (int i = 0; i < s.Length; i++) {
            if (mapping.TryGetValue(s[i], out var mappedChar)) {
                if (t[i] != mappedChar) return false;
            }
            else {
                mapping[s[i]] = t[i];
                if (!values.Add(t[i])) return false;
            }
        }

        return true;
    }
}