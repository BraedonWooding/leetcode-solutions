public class Solution {
    public IList<string> SummaryRanges(int[] nums) {
        if (nums.Length == 0) return new List<string>();

        var results = new List<string>(nums.Length);
        int rangeStart = 0;
        int rangeEnd = 0;
        int? lastValue = null;
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] - 1 == lastValue) {
                // we can just continue the current range
                // do nothing
            } else if (lastValue == null) {
                // this is the first value
                rangeStart = i;
            } else {
                // we have broken the range
                if (rangeStart == rangeEnd) results.Add(nums[rangeStart].ToString());
                else results.Add($"{nums[rangeStart]}->{nums[rangeEnd]}");
                
                rangeStart = i;
            }
            rangeEnd = i;
            lastValue = nums[i];
        }

        // the last range
        if (lastValue != null) {
            if (rangeStart == rangeEnd) results.Add(nums[rangeStart].ToString());
            else results.Add($"{nums[rangeStart]}->{nums[rangeEnd]}");
        }

        return results;
    }
}