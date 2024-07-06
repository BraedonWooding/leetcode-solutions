public class Solution {
    // this has extremely low memory usage (top 99%)
    // because it reuses the passed in array to output the intervals
    // it does this while being semi-efficient O(n) by using a 2-ptr approach
    // where
    // it further optimizes this 2-ptr approach 
    public int[][] Merge(int[][] intervals) {
        Array.Sort(intervals, static (a,b) => a[0] - b[0]);

        int[] prev = intervals[0];
        int realLen = 1;
        for (int curPointer = 1; curPointer < intervals.Length; curPointer++) {
            if (prev[1] >= intervals[curPointer][0]) {
                // update the array bounds
                // note that the array might be something like [1, 4] and [2, 3] so we have to take the max
                prev[1] = Math.Max(prev[1], intervals[curPointer][1]);
                // we no longer need these bounds so let's null them out and we'll compress at the end
                intervals[curPointer] = null;
            }
            else {
                prev = intervals[curPointer];
                realLen++;
            }
        }

        Array.Sort(intervals, static (a,b) => {
            return (a == null ? 1 : 0) - (b == null ? 1 : 0);
        });

        // resize result
        Array.Resize(ref intervals, realLen);
        return intervals;
    }
}