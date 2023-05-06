use std::iter;

impl Solution {
    pub fn num_subseq(mut nums: Vec<i32>, target: i32) -> i32 {
        let max = i32::pow(10, 9) + 7;
        let mut result: u64 = 0;
        nums.sort();
        
        // we can efficiently find the high point by ensuring that the max we go to is <= target
        let highPoint = nums.partition_point(|&x| x <= target);
        if highPoint == 0 { return 0; }

        // we have to precompute the powers to avoid modulus errors
        // (this makes this question just "annoying"... why)
        let powers: Vec<_> = iter::successors(Some(1), |prev| Some((prev * 2) % max))
            .take(highPoint + 1)
            .collect();

        nums[..highPoint].iter()
            .enumerate()
            .scan(highPoint, |i_end, (i, &value)| {
                while *i_end > i && nums[*i_end - 1] + value > target {
                    *i_end -= 1;
                }

                (*i_end > i).then(|| powers[*i_end - i - 1])
            })
            .fold(0, |acc, s| (s + acc) % max)
    }
}