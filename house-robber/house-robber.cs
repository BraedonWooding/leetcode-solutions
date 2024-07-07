public class Solution {
    public int Rob(int[] nums) {
        var dp = new int[nums.Length + 1];
        dp[0] = 0;
        dp[1] = nums[0];
        for (int i = 1; i < nums.Length; i++) {
            // either you don't rob or you rob this one
            dp[i + 1] = Math.Max(dp[i], dp[i - 1] + nums[i]);
        }
        
        return dp[nums.Length];
    }
}