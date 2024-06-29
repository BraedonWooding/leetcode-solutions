public class Solution {
    public int HammingWeight(int n) {
        return (int)System.Runtime.Intrinsics.X86.Popcnt.PopCount((uint)n);
    }
}