public class Solution {
    public int LengthOfLastWord(string s) {
        return s.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Last().Length;
    }
}