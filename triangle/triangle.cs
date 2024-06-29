public class Solution {
    // we can optimize this using prev/current rows
    // given that it's a 1D translatable problem
    public int MinimumTotal(IList<IList<int>> triangle) {
        var prevRow = new int[triangle.Last().Count()];
        var currentRow = new int[triangle.Last().Count()];
        prevRow[0] = triangle[0][0];
        
        for (int i = 1; i < triangle.Count(); i++) {
            for (int j = 0; j < triangle[i].Count(); j++) {
                currentRow[j] = Math.Min(
                    j < triangle[i - 1].Count() ? prevRow[j] : int.MaxValue,
                    j > 0 ? prevRow[j - 1] : int.MaxValue
                ) + triangle[i][j];
            }
            (prevRow, currentRow) = (currentRow, prevRow);
        }

        return prevRow.Min();
    }

    public int MinimumTotal2D(IList<IList<int>> triangle) {
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