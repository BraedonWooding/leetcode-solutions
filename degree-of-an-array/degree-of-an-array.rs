use std::collections::{HashMap};

#[derive(Debug)]
struct Num {
    count: u32,
    first_index: usize,
    last_index: usize,
}

impl Solution {
    pub fn find_shortest_sub_array(nums: Vec<i32>) -> i32 {
        if (nums.len() == 0) { return 0; }

        let mut max = 1;

        let degrees = nums
            .iter()
            .enumerate()
            .fold(HashMap::<i32, Num>::new(), |mut map, (i, val)|{
                map.entry(*val)
                    .and_modify(|f| {
                        f.count += 1;
                        f.last_index = i;
                        if f.count > max { max = f.count; }
                    })
                    .or_insert(Num{ count: 1, first_index: i, last_index: i });
                map
            });

        // let max = degrees.values().max_by_key(|num| num.count).unwrap().count;
        let minSubArray = degrees.values()
            .filter(|num| num.count == max)
            .min_by_key(|num| num.last_index - num.first_index)
            .unwrap();
        
        (minSubArray.last_index - minSubArray.first_index + 1) as i32
    }
}