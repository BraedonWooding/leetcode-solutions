public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        // we can loop backwards through the arrays using the fact nums1
        // has enough space to store m + n
        int i = m - 1, j = n - 1;
        var endBuf = m + n - 1; 
        while (i >= 0) {
            if (j >= 0 && nums2[j] > nums1[i]) {
                nums1[endBuf--] = nums2[j--];
            } else {
                nums1[endBuf--] = nums1[i--];
            }
        }
        // handle the last of j
        while (j >= 0) nums1[endBuf--] = nums2[j--];
    }
}