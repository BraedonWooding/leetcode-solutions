public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        var set = wordList.ToHashSet();

        // no point looping if we can't even get the last word
        if (set.Contains(endWord) == false) return 0;
        if (beginWord == endWord) return 1;

        // precompute all the variations of each word (i.e. remove each character once)
        // we have to replace each char removed with an _
        var lookupNextWords = new Dictionary<string, List<string>>();
        var variations = new Dictionary<string, List<string>>();
        var endWordVariations = new HashSet<string>();
        foreach (var word in wordList.Append(beginWord)) {
            var wordOptions = new List<string>();
            for (int i = 0; i < word.Length; i++) {
                var lookupWord = word[0..i] + "_" + word[(i + 1)..];
                wordOptions.Add(lookupWord);
                if (!lookupNextWords.TryGetValue(lookupWord, out var words))
                    words = lookupNextWords[lookupWord] = new();
                words.Add(word);
            }
            variations[word] = wordOptions;
            if (word == endWord) {
                endWordVariations = wordOptions.ToHashSet();
            }
        }

        var queue = new Queue<(string word, int len)>();
        queue.Enqueue((beginWord, 1));

        while (queue.Count > 0) {
            var (word, len) = queue.Dequeue();
            foreach (var variation in variations[word]) {
                if (endWordVariations.Contains(variation)) return len + 1;
                if (lookupNextWords.TryGetValue(variation, out var words)) {
                    foreach (var newWord in words) {
                        if (newWord == endWord) return len + 1;
                        if (newWord == word || !set.Contains(newWord)) continue;
                        queue.Enqueue((newWord, len + 1));
                        set.Remove(newWord);
                    }
                }
            }
        }

        return 0;
    }
}