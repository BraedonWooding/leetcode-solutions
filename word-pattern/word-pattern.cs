public class Solution {
    public bool WordPattern(string pattern, string s) {
        Dictionary<char, string> lookup = new();
        HashSet<string> currentWords = new();
        var index = 0;
        foreach (var word in s.Split(" "))
        {
            if (index >= pattern.Length) return false;

            if (lookup.TryGetValue(pattern[index], out var key))
            {
                if (key != word)
                {
                    return false;
                }
            }
            else if (!currentWords.Add(word))
            {
                // if we already have seen this word then we can't bind a different pattern key to it
                return false;
            }
            else
            {
                lookup[pattern[index]] = word;
            }
            index++;
        }

        return index == pattern.Length;
    }
}