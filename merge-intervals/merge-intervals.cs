public class Solution {
    public int[][] Merge(int[][] intervals) {
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
}