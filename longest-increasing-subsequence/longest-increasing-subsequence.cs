public class Solution {
    public int LengthOfLIS(int[] nums) {
        var dp = new int[nums.Length + 1];
        dp[0] = 0;
        for (int i = 0; i < nums.Length; i++) {
            dp[i + 1] = Enumerable.Range(0, i)
                .Where(x => nums[x] < nums[i])
                .Select(x => dp[x + 1] + 1)
                .Concat(new int[]{1})
                .Max();
        }

        return dp.Max();
    }
}