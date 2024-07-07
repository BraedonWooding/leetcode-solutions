public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        var middleIsh = Array.BinarySearch(nums, target);
        if (middleIsh < 0) return new int[]{ -1, -1 };

        int startingPosition = middleIsh;
        while (startingPosition > 0 && nums[startingPosition - 1] == target) {
            startingPosition--;
        }

        int endingPosition = middleIsh;
        while (endingPosition < nums.Length - 1 && nums[endingPosition + 1] == target) {
            endingPosition++;
        }

        return new int[]{ startingPosition, endingPosition };
    }
}