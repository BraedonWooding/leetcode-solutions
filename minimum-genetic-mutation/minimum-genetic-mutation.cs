public class Solution {
    public int MinMutation(string startGene, string endGene, string[] bank) {
        var set = bank.ToHashSet();

        // no point looping if we can't even get the last word
        if (set.Contains(endGene) == false) return -1;
        if (startGene == endGene) return 1;

        // precompute all the variations of each word (i.e. remove each character once)
        // we have to replace each char removed with an _
        var lookupNextWords = new Dictionary<string, List<string>>();
        var variations = new Dictionary<string, List<string>>();
        var endWordVariations = new HashSet<string>();
        foreach (var word in bank.Append(startGene)) {
            var wordOptions = new List<string>();
            for (int i = 0; i < word.Length; i++) {
                var lookupWord = word[0..i] + "_" + word[(i + 1)..];
                wordOptions.Add(lookupWord);
                if (!lookupNextWords.TryGetValue(lookupWord, out var words))
                    words = lookupNextWords[lookupWord] = new();
                words.Add(word);
            }
            variations[word] = wordOptions;
            if (word == endGene) {
                endWordVariations = wordOptions.ToHashSet();
            }
        }

        var queue = new Queue<(string word, int len)>();
        queue.Enqueue((startGene, 0));

        while (queue.Count > 0) {
            var (word, len) = queue.Dequeue();
            foreach (var variation in variations[word]) {
                if (endWordVariations.Contains(variation)) return len + 1;
                if (lookupNextWords.TryGetValue(variation, out var words)) {
                    foreach (var newWord in words) {
                        if (!set.Contains(newWord)) continue;
                        queue.Enqueue((newWord, len + 1));
                        set.Remove(newWord);
                    }
                }
            }
        }

        return -1;
    }
}