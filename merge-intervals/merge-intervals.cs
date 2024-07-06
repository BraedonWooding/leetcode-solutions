public class Solution {
    public int[][] Merge2(int[][] intervals) {
        // to reduce memory first detect how many intervals we have
        int intervalCount = 0;
        // first lets sort our intervals
        Array.Sort(intervals, (a,b) => a[0] - b[0]);
        int curInterval = 0;
        int skipped = 0;
        int curPointer = 0;
        while (curPointer < intervals.Length - skipped) {
            if (curInterval == curPointer) {
                intervalCount++;
                curPointer++;
            }
            else if (intervals[curInterval][1] >= intervals[curPointer][0]) {
                // update the array
                intervals[curInterval][1] = Math.Max(intervals[curInterval][1], intervals[curPointer][1]);
 
                // increment skipped so we know how far through we are
                skipped++;

                for (int i = curPointer; i < intervals.Length - skipped; i++) {
                    intervals[i] = intervals[i + 1];
                }
            }
            else {
                // doesn't overlap so reset count
                intervalCount++;
                curInterval = curPointer++;
            }
        }

        // resize result
        Array.Resize(ref intervals, intervalCount);
        return intervals;
    }

    // this has extremely low memory usage (top 99%)
    // because it reuses the passed in array to output the intervals
    // it does this while being semi-efficient O(n) by using a 2-ptr approach
    // where
    // it further optimizes this 2-ptr approach 
    public int[][] Merge(int[][] intervals) {
        Array.Sort(intervals, (a,b) => a[0] - b[0]);

        int[] prev = intervals[0];
        // cache
        int prevUpper = prev[1];
        int realLen = 1;
        for (int curPointer = 1; curPointer < intervals.Length; curPointer++) {
            if (prevUpper >= intervals[curPointer][0]) {
                // update the array bounds
                // note that the array might be something like [1, 4] and [2, 3] so we have to take the max
                prevUpper = prev[1] = Math.Max(prevUpper, intervals[curPointer][1]);
                // we no longer need these bounds so let's null them out and we'll compress at the end
                intervals[curPointer] = null;
            }
            else {
                prev = intervals[curPointer];
                prevUpper = prev[1];
                realLen++;
            }
        }

        Array.Sort(intervals, (a,b) => {
            return (a == null ? 1 : 0) - (b == null ? 1 : 0);
        });

        // resize result
        Array.Resize(ref intervals, realLen);
        return intervals;
    }
}