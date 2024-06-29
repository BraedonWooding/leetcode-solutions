public class Solution {
    public double MyPow(double x, int n) {
        // we can flip it to make it (1/x)^|n| (given negative n)
        if (n < 0) {
            x = 1 / x;
            n = -n;
        }
        if (n == int.MinValue) return (Math.Abs(x) == 1) ? 1 : 0;
        double result = 1;
        double product = x;
        // given that its disible by 2 we can just keep building up our product
        // i.e. x^5 = x^2 * x^2 * x
        while (n > 0) {
            if (n % 2 == 1) {
                result *= product;
            }
            product *= product;
            n /= 2;
        }
        return result;
    }
}