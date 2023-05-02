impl Solution {
    pub fn find_the_winner(n: i32, k: i32) -> i32 {
        /*
            At the end when we kill the final person we end up with a 0th index
            f(1, k) = 0

            Thus we can build bottom up to determine the previous position and so on
            this enables us to find the initial position of the final person

            i.e.
            f(2, k) = (f(1, k) + k) % 2
                    = (0 + k) % 2
            
            If we follow example 1
            f(1, 2) = 0
            f(2, 2) = (0 + 2) % 2 = 0
            f(3, 2) = (0 + 2) % 3 = 2
            f(4, 2) = (2 + 2) % 4 = 0
            f(5, 2) = (0 + 2) % 4 = 2
            Thus counting from the 0th position we have the 3rd friend living

            If we look at the graph we can see this!
            Friend 3:
            - Starts at index 2
            - When friend 2 dies they move to index 0 since they are the next one
            - When friend 4 dies they are the last one in the circle giving them index 2
            - When friend 1 dies they are the next one in the circle giving them index 0
            - When friend 5 dies they are again the next one giving them index 0
            - and when they are alone they'll also be index 0
        */

        // We could define above using a recursive function, but we can easily do it iteratively
        // we can skip the first iteration f(1, k) since that's always 0 so we just set initial value to 0
        // we add 1 at the end to convert it from index -> position in circle
        (2..=n).fold(0, |acc, n| (acc + k) % n) + 1
    }
}