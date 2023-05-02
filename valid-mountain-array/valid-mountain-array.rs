impl Solution {
    pub fn valid_mountain_array(arr: Vec<i32>) -> bool {
        if arr.len() < 3 { return false; }

        let mut increasing = true;
        for i in 1..arr.len() {
            if !increasing && arr[i] >= arr[i - 1] {
                // if we are meant to be decreasing but we are increasing then no mountain
                return false;
            } else if arr[i] < arr[i - 1] {
                if (i <= 1) { return false; }

                // if we are increasing and we suddenly decrease it's okay
                // we are always fine to decrease (given i > 1) since it
                // should at bareminimum go 1 2 1 rather than 2 1 0
                increasing = false;
            } else if arr[i] == arr[i - 1] {
                return false;
            }
            // otherwise loop again
        }
        
        // at the end we should be decreasing
        !increasing
    }
}