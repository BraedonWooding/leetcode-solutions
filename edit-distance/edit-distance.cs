public class Solution {
    public int MinDistance(string word1, string word2) {
        // create a 2d array that stores the cost of operations to get to a point
        // we can then use DP to calculate the cost, with the result being the bottom right corner (max row/col)
        var dp = new int[word1.Length + 1, word2.Length + 1];
        for (int i = 0; i <= word1.Length; i++) {
            for (int j = 0; j <= word2.Length; j++) {
                if (j == 0) dp[i, j] = i;
                else if (i == 0) dp[i, j] = j;
                else dp[i, j] = Math.Min(
                    Math.Min(
                        dp[i - 1, j] + 1, // Deletion
                        dp[i, j - 1] + 1  // Insertion
                    ),
                    dp[i - 1, j - 1] + (word1[i - 1] == word2[j - 1] ? 0 : 1) // Substition
                );
            }
        }

        for (int i = 0; i <= word1.Length; i++) {
            for (int j = 0; j <= word2.Length; j++) {
                Console.Write(dp[i, j]);
            }
            Console.WriteLine();
        }

        return dp[word1.Length, word2.Length];
    }
}