public class Solution {
    public int EvalRPN(string[] tokens) {
        var stack = new Stack<int>();
        foreach (var token in tokens) {
            switch (token) {
                case "+": {
                    stack.Push(stack.Pop() + stack.Pop());
                    break;
                }
                case "/": {
                    var rhs = stack.Pop();
                    stack.Push(stack.Pop() / rhs);
                    break;
                }
                case "-": {
                    var rhs = stack.Pop();
                    stack.Push(stack.Pop() - rhs);
                    break;
                }
                case "*": {
                    var rhs = stack.Pop();
                    stack.Push(stack.Pop() * rhs);
                    break;
                }
                default: {
                    stack.Push(int.Parse(token));
                    break;
                }
            }
        }
        return stack.Pop();
    }
}