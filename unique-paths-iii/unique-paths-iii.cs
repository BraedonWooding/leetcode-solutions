public class Solution {
    public int UniquePathsIII(int[][] grid) {
        var dp = new int[grid.Length, grid[0].Length];

        var start = (x: 0, y: 0);
        var end = (x: 0, y: 0);
        var emptyCounts = 0;
        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[i].Length; j++) {
                if (grid[i][j] == 1) start = (i, j);
                else if (grid[i][j] == 2) end = (i, j);
                else if (grid[i][j] == 0) emptyCounts++;
            }
        }

        var bitArray = new BitArray(grid.Length * grid[0].Length);

        int BackTracking(int x, int y, int count) {
            if (x < 0 || y < 0 || x >= grid.Length || y >= grid[0].Length) return 0;
            if (x == end.x && y == end.y) {
                return count > emptyCounts ? 1 : 0;
            }
            if (grid[x][y] == -1) return 0;
            if (bitArray.Get(x * grid[0].Length + y)) {
                // we've visited this square, we can't visit it again
                return 0;
            }
            
            // visit cell
            bitArray.Set(x * grid[0].Length + y, true);

            var result = BackTracking(x - 1, y, count + 1)
                + BackTracking(x + 1, y, count + 1)
                + BackTracking(x, y - 1, count + 1)
                + BackTracking(x, y + 1, count + 1);

            bitArray.Set(x * grid[0].Length + y, false);

            return result;
        }

        return BackTracking(start.x, start.y, 0);
    }
}