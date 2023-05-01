use std::collections::{ HashMap };

impl Solution {
    pub fn roman_to_int(s: String) -> i32 {
        let mut result: i32 = 0;

        let mut valueMap = HashMap::<char, i32>::new();
        valueMap.insert('I', 1);
        valueMap.insert('V', 5);
        valueMap.insert('L', 50);
        valueMap.insert('X', 10);
        valueMap.insert('C', 100);
        valueMap.insert('D', 500);
        valueMap.insert('M', 1000);

        // we can iterate 2 characters at a time to handle the IV/IX/... case
        let mut iter = s.chars().peekable();

        while let Some(firstChar) = iter.next() {
            let firstValue = valueMap[&firstChar];
            if let Some(secondChar) = iter.peek() {
                let secondValue = valueMap[&secondChar];
                if firstValue == secondValue {
                    // since it's ordered in descending order
                    // we can never have a value larger than firstValue
                    // since we already have seen it twice
                    result += firstValue + secondValue;
                    iter.next();
                } else if firstValue < secondValue {
                    // IV case
                    result += secondValue - firstValue;
                    iter.next();
                } else {
                    // VI case, we can't just add firstValue & secondValue
                    // since it could be something like XIV
                    // we don't do iter.next() since we want to keep the next value in the iterator
                    // so we'll process it next time we can just fallback to if it's a single value
                    result += firstValue;
                }
            } else {
                // just a single value
                result += firstValue;
            }
        }

        result
    }
}