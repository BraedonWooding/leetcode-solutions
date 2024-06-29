public class Solution {
    public int MaximalSquare(char[][] matrix) {
        // re-use the matrix for this for a cheeky O(1)
        int m = matrix[0].Length;
        int max = 0;
        int val;
        for (int i = matrix.Length - 1; i >= 0; i--) {
            for (int j = 0; j < m; j++) {
                if (matrix[i][j] == '1') {
                    // no point updating cells that aren't 1
                    val = Math.Min(
                        j > 0 ? (matrix[i][j - 1] - '0') : 0,
                        Math.Min(
                            i < matrix.Length - 1 ? (matrix[i + 1][j] - '0') : 0,
                            i < matrix.Length - 1 && j > 0 ? (matrix[i + 1][j - 1] - '0') : 0
                        )
                    ) + 1;
                    matrix[i][j] = (char)('0' + val);
                    if (val > max) max = val;
                }
                Console.Write(matrix[i][j] + " ");
            }
            Console.WriteLine();
        }

        return max * max;
    }
}