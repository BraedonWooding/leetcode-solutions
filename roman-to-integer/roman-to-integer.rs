use std::collections::{ HashMap };

impl Solution {
    pub fn roman_to_int(s: String) -> i32 {
        let mut result: i32 = 0;

        // we can iterate 2 characters at a time to handle the IV/IX/... case
        let mut iter = s.chars().peekable();

        while let Some(firstChar) = iter.next() {
            result += match firstChar {
                // before V & X
                'I' => match iter.peek() {
                    Some('V') => {
                        iter.next();
                        5 - 1
                    },
                    Some('X') => {
                        iter.next();
                        10 - 1
                    },
                    _ => 1,
                },
                // 5/50/... can't be before other characters
                'V' => 5,
                // before L & C
                'X' => match iter.peek() {
                    Some('L') => {
                        iter.next();
                        50 - 10
                    },
                    Some('C') => {
                        iter.next();
                        100 - 10
                    },
                    _ => 10,
                },
                // 5/50/... can't be before other characters
                'L' => 50,
                // can be before D or M
                'C' => match iter.peek() {
                    Some('D') => {
                        iter.next();
                        500 - 100
                    },
                    Some('M') => {
                        iter.next();
                        1000 - 100
                    },
                    _ => 100,
                },
                // 5/50/... can't be before other characters
                'D' => 500,
                // no larger value so we can just always output this
                'M' => 1000,
                _ => 0,
            }
        }

        result
    }
}