public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        // we can loop backwards through the arrays using the fact nums1
        // has enough space to store m + n
        int i = m - 1, j = n - 1;
        var endBuf = m + n - 1; 
        while (j >= 0) {
            if (i >= 0 && nums1[i] > nums2[j]) {
                nums1[endBuf--] = nums1[i--];
            } else {
                nums1[endBuf--] = nums2[j--];
            }
        }
        // then we don't have to handle the rest since nums1 is already in order
    }
}