impl Solution {
    pub fn average(mut salary: Vec<i32>) -> f64 {
        // use the fact that a sorted list of integers will have max/min at extremes
        salary.sort();
        let len = salary.len() - 2;
        return (salary[1..=len].iter().sum::<i32>() as f64) / (len as f64);
    }
}