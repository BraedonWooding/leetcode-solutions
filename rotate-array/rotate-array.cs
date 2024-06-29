public class Solution {
    public void Rotate(int[] nums, int k) {
        int n = nums.Length;
        // first of all `k` can be simplified since k could be > nums.Length
        // as a simple example if k = n then k = 0 (since moving everything n spaces moves it back to the start)
        // you can extend this to k = 2n ... meaning that you can just take the remainder after division of n
        // i.e. k = k % n
        k %= n;
        // we also don't have to do anything if no numbers are going to move
        if (k == 0 || n == 1 || n == 0) return;

        // this is challenging primarily due to the limited space of nums
        // we could so a calculation where nums[i] = nums[i - k] (with wrapping ofcourse)
        // but with wrapping we got to make sure we don't override any value that we want to reference later
        // let's look at a simple example to derive a possible approach
        // [ A, B, C ], k = 2 => [ B, C, A ]
        // we can store a single value (or technically any number of constant values) this lets us make sure
        // we don't lose any value we set, but we have to be careful
        // i.e. [ A, B, C ] => [ A, B, A ] storing C, then we have to figure out where C goes,
        // since we know it's index we can calculate it's position and insert
        // [ A, C, A ] storing B, then we continue!
        // How do we know when to stop?
        // Well we can use the fact that technically since we are conceptually lengthening the array there is no
        // way for us to get to a duplicate till we get through all the records
        // So we know we can stop once we get back to "0" or the starting index
        int currentIndex = 0;
        int currentValue = nums[0];
        int startingIndex = 0;
        for (int i = 0; i < n; i++)
        {
            currentIndex = (currentIndex + k) % n;
            var tmp = nums[currentIndex];
            nums[currentIndex] = currentValue;
            currentValue = tmp;
            if (currentIndex == startingIndex) {
                startingIndex = currentIndex = (currentIndex + 1) % n;
                currentValue = nums[startingIndex];
            }
        }
    }
}