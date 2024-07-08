public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        var dp = new int[obstacleGrid.Length,obstacleGrid[0].Length];
        dp[0, 0] = obstacleGrid[0][0] == 1 ? 0 : 1;
        for (int i = 1; i < obstacleGrid.Length; i++) {
            dp[i, 0] = obstacleGrid[i][0] == 1 ? 0 : dp[i - 1, 0];
        }
        for (int i = 1; i < obstacleGrid[0].Length; i++) {
            dp[0, i] = obstacleGrid[0][i] == 1 ? 0 : dp[0, i - 1];
        }

        for (int i = 1; i < obstacleGrid.Length; i++) {
            for (int j = 1; j < obstacleGrid[i].Length; j++) {
                if (obstacleGrid[i][j] == 1) dp[i, j] = 0;
                else dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
            }
        }
        return dp[obstacleGrid.Length - 1, obstacleGrid[0].Length - 1];
    }
}