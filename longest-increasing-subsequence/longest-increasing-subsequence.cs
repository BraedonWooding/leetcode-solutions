public class Solution {
    public int LengthOfLIS(int[] nums) {
        if (nums.Length == 0) return 0;

        var dp = new int[nums.Length];
        Array.Fill(dp, 1);
        int max = 1;
        for (int i = 0; i < nums.Length; i++) {
            for (int j = 0; j < i; j++) {
                if (nums[i] > nums[j]) {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                    max = Math.Max(max, dp[i]);
                }
            }
        }

        return max;
    }
}