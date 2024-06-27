public class Solution {
    public class CustomSort : IComparer<int>
    {
        public int Value { get; }
        public CustomSort(int val)
        {
            Value = val;
        }

        int IComparer<int>.Compare(int x, int y)
        {
            if (x == y) return 0;
            if (x == Value) return 1;
            if (y == Value) return -1;
            return x - y;
        }
    }

    public int RemoveElement(int[] nums, int val) {
        if (nums.Length == 0) return 0;
        Array.Sort(nums, new CustomSort(val));

        var end = nums.Length;
        while (end > 0 && nums[end - 1] == val) end--;
        return end;
    }
}