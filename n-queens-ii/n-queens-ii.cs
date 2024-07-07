public class Solution {
    public int STotalNQueens(int n) {
        // n <= 9
        // 9 * 2 + (17 * 2) (or 36) bits of storage
        // 64bit machine so we can efficiently store in 64 bit memory
        // board is structured like this;
        var board = 0UL;

        int Solve(ulong y) {
            if ((int)y == n) {
                // we've got a queen in every position
                return 1;
            }

            int count = 0;

            for (ulong x = 0; x < (ulong)n; x++) {
                // 0, 3 = 0
                // 0, 2 = 1
                // 0, 1 = 2
                // 0, 0 = 3
                //
                // 3, 3 = 3
                // 3, 2 = 4
                // 3, 1 = 5
                // 3, 0 = 6
                ulong diagDownCol = (1ul << (int)((x) + (3 - y)));
                // 3, 3 = 0
                // 3, 2 = 1
                // 3, 1 = 2
                // 3, 0 = 3
                //
                // 0, 0 = 6
                ulong diagUpCol = (1ul << (int)((3 - y) + (3 - x)));

                ulong col = (1ul << (int)(y));
                ulong row = (1ul << (int)(x));

                var newBoardState = (
                    row |
                    (col << 10) |
                    (diagUpCol << 24) |
                    (diagDownCol << 44)
                );

                if (
                    ((board & row) == 0) &&
                    (((board >> 10) & col) == 0) &&
                    (((board >> 24) & diagUpCol) == 0) &&
                    (((board >> 44) & diagDownCol) == 0)
                ) {
                    if ((board & newBoardState) != 0) {
                        Console.WriteLine("HUH");
                    }

                    board |= newBoardState;
                    count += Solve(y + 1);
                    board &= ~newBoardState;
                }
            }

            return count;
        }

        return Solve(0);
    }

    public int TotalNQueens(int n) {
        // up to 9 bits of storage so we can just store in 16 bits easily
        // keeping as 32 bits since more efficient on system
        var rows = 0u;
        var cols = 0u;
        var diagUp = 0u;
        var diagDown = 0u;

        int Solve(uint y) {
            if (y == n) {
                // we've got a queen in every position
                return 1;
            }

            int count = 0;

            for (uint x = 0; x < n; x++) {
                // 0, 3 = 0
                // 0, 2 = 1
                // 0, 1 = 2
                // 0, 0 = 3
                //
                // 3, 3 = 3
                // 3, 2 = 4
                // 3, 1 = 5
                // 3, 0 = 6
                var diagDownCol = (x) + ((n - 1) - y);
                // 3, 3 = 0
                // 3, 2 = 1
                // 3, 1 = 2
                // 3, 0 = 3
                //
                // 0, 0 = 6
                var diagUpCol = ((n - 1) - y) + ((n - 1) - x);

                if (
                    // 1. Row check
                    ((rows & (1u << (int)x)) == 0) &&
                    // 2. Col check
                    ((cols & (1u << (int)y)) == 0) &&       
                    // 3. DiagDown Check
                    ((diagDown & (1u << (int)diagDownCol)) == 0) &&
                    // 4. DiagUp Check
                    ((diagUp & (1u << (int)diagUpCol)) == 0)
                ) {
                    // no one is occupying our square!
                    rows |= 1u << (int)x;
                    cols |= 1u << (int)y;
                    diagDown |= (1u << (int)diagDownCol);
                    diagUp |= (1u << (int)diagUpCol);

                    count += Solve(y + 1u);
                    
                    rows &= ~(1u << (int)x);
                    cols &= ~(1u << (int)y);
                    diagDown &= ~(1u << (int)diagDownCol);
                    diagUp &= ~(1u << (int)diagUpCol);
                }
            }

            return count;
        }

        return Solve(0);
    }
}