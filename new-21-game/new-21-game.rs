impl Solution {
    pub fn new21_game(n: i32, k: i32, max_pts: i32) -> f64 {
        // Soln: P(n) + P(n - 1) + P(n - 2) + ... + P(k)
        let mut memoization = vec![0.0; n as usize + 1];
        memoization[0] = 1.0;

        // Base Case
        // If we can't draw any more points then we win! (100%)
        // If the max draw (max_pts) + our stopping point are equal (or less than) n
        //    then we can never overdraw resulting in again 100%
        if (k == 0 || n >= k + max_pts) {
            return 1.0;
        }
        
        // General Case
        // P(n) = P(k - 1) * P(n - (k - 1)) + P(k - 2) * P(n - (k - 2))
        //      + ... + P(n - max_pts) * P(n - (n - max_pts))
        // with that last one simplifying to just P(n - max_pts) * P(max_pts)
        // with P(1) = 1/max_pts, P(2) = 1/max_pts and so on.
        let mut window = 1.0;

        // i is our P(n) bottom up
        for i in 1..=n {
            // optimisation of window function
            memoization[i as usize] = window / max_pts as f64;
            if i < k {
                // front of window so add right side
                window += memoization[i as usize];
            }
            if (i - max_pts >= 0) {
                // end of window so remove left side
                window -= memoization[(i - max_pts) as usize];
            }

            // slower method, (where we don't need window)
            // just maps to the function evaluation above
            // j is our k - 1, k - 2, ... n - max_pts
            // for j in 1..=max_pts {
            //     if (i - j >= 0 && i - j < k) {
            //         memoization[i as usize] += memoization[i as usize - j as usize] * (1.0/max_pts as f64);
            //     }
            // }
        }

        println!("{:?}", memoization);

        memoization[(k as usize)..=(n as usize)].iter().sum()
    }
}