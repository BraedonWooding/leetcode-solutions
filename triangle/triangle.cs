public class Solution {
    public int MinimumTotal(IList<IList<int>> triangle) {
        var dp = new int[triangle.Count()][];
        // base case, first array is always length 0
        dp[0] = new int[] { triangle[0][0] };
        for (int i = 1; i < triangle.Count(); i++) {
            dp[i] = new int[triangle[i].Count()];
            for (int j = 0; j < triangle[i].Count(); j++) {
                dp[i][j] = Math.Min(
                    j < triangle[i - 1].Count() ? dp[i - 1][j] : int.MaxValue,
                    j > 0 ? dp[i - 1][j - 1] : int.MaxValue
                ) + triangle[i][j];
            }
        }

        return dp[triangle.Count() - 1].Min();
    }
}