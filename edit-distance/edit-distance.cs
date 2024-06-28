public class Solution {
    // this uses the fact that we don't need more than i - 1, j - 1 so we can just store the prev row
    public int MinDistance(string word1, string word2) {
        // create a 2d array that stores the cost of operations to get to a point
        // we can then use DP to calculate the cost, with the result being the bottom right corner (max row/col)
        var prevRow = new int[word2.Length + 1];
        var curRow = new int[word2.Length + 1];

        Console.Write("   ");
        for (int i = 0; i < word2.Length; i++) {
            Console.Write(word2[i]);
        }
        Console.WriteLine();
        Console.Write("  ");
        for (int i = 0; i <= word2.Length; i++) {
            prevRow[i] = i;
            Console.Write(prevRow[i]);
        }
        Console.WriteLine();

        for (int i = 1; i <= word1.Length; i++) {
            Console.Write(word1[i - 1] + " ");
            curRow[0] = i;
            Console.Write(curRow[0]);
            for (int j = 1; j <= word2.Length; j++) {
                curRow[j] = Math.Min(
                    Math.Min(
                        prevRow[j] + 1,     // Deletion
                        curRow[j - 1] + 1   // Insertion
                    ),
                    prevRow[j - 1] + (word1[i - 1] == word2[j - 1] ? 0 : 1) // Substition
                );
                Console.Write(curRow[j]);
            }
            Console.WriteLine();
            (prevRow, curRow) = (curRow, prevRow);
        }

        return prevRow[word2.Length];
    }

    public int MinDistanceBase(string word1, string word2) {
        // create a 2d array that stores the cost of operations to get to a point
        // we can then use DP to calculate the cost, with the result being the bottom right corner (max row/col)
        var dp = new int[word1.Length + 1, word2.Length + 1];
        for (int i = 0; i <= word1.Length; i++) dp[i, 0] = i;
        for (int i = 0; i <= word2.Length; i++) dp[0, i] = i;

        for (int i = 1; i <= word1.Length; i++) {
            for (int j = 1; j <= word2.Length; j++) {
                dp[i, j] = Math.Min(
                    Math.Min(
                        dp[i - 1, j] + 1, // Deletion
                        dp[i, j - 1] + 1  // Insertion
                    ),
                    dp[i - 1, j - 1] + (word1[i - 1] == word2[j - 1] ? 0 : 1) // Substition
                );
            }
        }

        return dp[word1.Length, word2.Length];
    }
}