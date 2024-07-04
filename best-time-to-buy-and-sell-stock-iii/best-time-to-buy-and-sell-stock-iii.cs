public class Solution {
    public int MaxProfit(int[] prices) {
        // 3 parameters;
        // index
        // # of transactions
        // buy or sell
        var dp = new int[prices.Length + 1, 2, 3];
        
        for (int i = prices.Length - 1; i >= 0; i--) {
            for (int buy = 0; buy <= 1; buy++) {
                for (int transactions = 1; transactions <= 2; transactions++) {
                    if (buy == 1) {
                        dp[i, buy, transactions] = Math.Max(-prices[i] + dp[i + 1, 0, transactions], dp[i + 1, 1, transactions]);
                    } else {
                        dp[i, buy, transactions] = Math.Max(prices[i] + dp[i + 1, 1, transactions - 1], dp[i + 1, 0, transactions]);
                    }
                }
            }
        }

        return dp[0, 1, 2];
        // return MaxProfitRecursive(prices, 0, true, 0);
    }

    public int MaxProfitRecursive(int[] prices, int index, bool buy, int transactions) {
        // no more buys
        if (transactions == 2) return 0;
        if (index < prices.Length) {
            if (buy) {
                return Math.Max(-prices[index] + MaxProfitRecursive(prices, index + 1, false, transactions), MaxProfitRecursive(prices, index + 1, true, transactions));
            } else {
                return Math.Max(prices[index] + MaxProfitRecursive(prices, index + 1, true, transactions + 1), MaxProfitRecursive(prices, index + 1, false, transactions));
            }
        } else {
            return 0;
        }
    }
}