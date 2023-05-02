use std::collections::{HashMap};

#[derive(Debug, Clone)]
struct Num {
    count: u32,
    first_index: usize,
    last_index: usize,
}

impl Solution {
    pub fn find_shortest_sub_array(nums: Vec<i32>) -> i32 {
        if (nums.len() == 0) { return 0; }

        let mut max = 1;
        let mut validArrays = Vec::<Num>::new();

        let degrees = nums
            .iter()
            .enumerate()
            .fold(HashMap::<i32, Num>::new(), |mut map, (i, val)|{
                map.entry(*val)
                    .and_modify(|f| {
                        f.count += 1;
                        f.last_index = i;
                        if f.count > max { max = f.count; validArrays.clear(); validArrays.push(f.clone()); }
                        else if f.count == max { validArrays.push(f.clone()); }
                    })
                    .or_insert(Num{ count: 1, first_index: i, last_index: i });
                map
            });

        if max == 1 { return 1; }

        // let max = degrees.values().max_by_key(|num| num.count).unwrap().count;
        // let minSubArray = degrees.values()
        //     .filter(|num| num.count == max)
        //     .min_by_key(|num| num.last_index - num.first_index)
        //     .unwrap();
        let minSubArray = validArrays
            .iter()
            .min_by_key(|num| num.last_index - num.first_index)
            .unwrap();
        
        (minSubArray.last_index - minSubArray.first_index + 1) as i32
    }
}