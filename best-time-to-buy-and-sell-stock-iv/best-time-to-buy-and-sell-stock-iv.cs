public class Solution {
    public int MaxProfit(int k, int[] prices) {
        // 3 parameters;
        // index
        // # of transactions
        // buy or sell
        var dp = new int[prices.Length + 1, 2, k + 1];
        
        for (int i = prices.Length - 1; i >= 0; i--) {
            for (int buy = 0; buy <= 1; buy++) {
                for (int transactions = 1; transactions <= k; transactions++) {
                    if (buy == 1) {
                        dp[i, buy, transactions] = Math.Max(-prices[i] + dp[i + 1, 0, transactions], dp[i + 1, 1, transactions]);
                    } else {
                        dp[i, buy, transactions] = Math.Max(prices[i] + dp[i + 1, 1, transactions - 1], dp[i + 1, 0, transactions]);
                    }
                }
            }
        }

        return dp[0, 1, k];
    }
}