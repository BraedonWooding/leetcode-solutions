impl Solution {
    pub fn average(mut salary: Vec<i32>) -> f64 {
        // use the fact that a sorted list of integers will have max/min at extremes
        salary.sort();
        return (salary.iter().skip(1).take(salary.len() - 2).sum::<i32>() as f64) / (salary.len() as f64 - 2.0);
    }
}