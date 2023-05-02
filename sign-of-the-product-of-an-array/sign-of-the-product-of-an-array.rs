impl Solution {
    pub fn array_sign(nums: Vec<i32>) -> i32 {
        nums.iter().map(|x| x.signum()).product::<i32>().signum()
    }
}