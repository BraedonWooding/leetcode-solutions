impl Solution {
    pub fn longest_common_prefix(strs: Vec<String>) -> String {
        if (strs.len() == 1) { return strs[0].to_string(); }

        let mut iters : Vec<std::str::Chars> = strs.iter().skip(1).map(|s| s.chars()).collect();
        let mut prefix = String::new();

        if iters.len() > 0 {
            let mut firstIter = strs[0].chars();
            while let Some(value) = firstIter.next() {
                if iters.iter_mut().all(|iter| iter.next() == Some(value)) {
                    prefix.push(value);
                } else {
                    break;
                }
            }
        }

        return prefix;
    }
}