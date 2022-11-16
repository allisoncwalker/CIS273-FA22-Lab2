using System.Data.SqlTypes;

namespace Lab2;
public class Program
{
    public static void Main(string[] args)
    {
        IsBalanced("{ ( < > ) }");  // true
        IsBalanced("<> {(})");      // false
    }

    public static bool IsBalanced(string s)
    {
        Stack<char> stack = new Stack<char>();

        // iterate over all chars in string
        foreach (var c in s)
        {
            // if char is an open thing, push it
            if (c == '<' || c == '(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }

            // if char is a close thing,
            // compare it to top of stack;
            else if (c == '>' || c == ')' || c == '}' || c == ']')
            {
                char top;
                bool result = stack.TryPeek(out top);
                // handle result == false

                // if they match, pop()
                if (Matches(c, top))
                {
                    //looking for top in an empty stack will cause an error
                    //make a conditional pertaining to this issue
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    stack.Pop();
                }

                //There was a missing condition, so condition for Matches being false is made

                if (Matches(c, top) == false)
                {
                    return false;
                }
                // else, return false
                else
                {
                    return false;
                }
            }

        }

        // if stack is empty, return true
        if (stack.Count == 0)
        {
            return true;
        }

        return false;

    }

    private static bool Matches(char closing, char opening)
    {
        if (closing == '}')
        {
            opening = '{';
            return true;
        }

        else if (closing == ')')
        {
            opening = '(';
            return true;
        }

        else if (closing == '>')
        {
            opening = '<';
            return true;
        }

        else if (closing == ']')
        {
            closing = '[';
            return true;
        }

        return false;
    }


    public static double? Evaluate(string s)
    {
        Stack<string> stack = new Stack<string>();

        // parse string into tokens
        string[] tokens = s.Split();

        // foreach token
        foreach (var t in tokens)
        {
            // if it's a number, push to stack
            double n;
            if (double.TryParse(t, out n) == true)
            {
                stack.Push(t);
            }

            // if it's a math operator, pop twice;
            else if (t == "-" || t == "+" || t == "*" || t == "/")
            {
                string firstNumber = stack.Pop();
                string secondNumber = stack.Pop();

                // compute result
                if (t == "-")
                {
                    double result = double.Parse(secondNumber) - double.Parse(firstNumber);
                    string stringResult = result.ToString();

                    // push result onto stack
                    stack.Push(stringResult);
                }

                if (t == "+")
                {
                    double result = double.Parse(secondNumber) + double.Parse(firstNumber);
                    string stringResult = result.ToString();

                    // push result onto stack
                    stack.Push(stringResult);
                }

                if (t == "*")
                {
                    double result = double.Parse(secondNumber) * double.Parse(firstNumber);
                    string stringResult = result.ToString();

                    // push result onto stack
                    stack.Push(stringResult);
                }

                if (t == "/")
                {
                    double result = double.Parse(secondNumber) / double.Parse(firstNumber);
                    string stringResult = result.ToString();

                    // push result onto stack
                    stack.Push(stringResult);
                }
            }
        }

        // return top of stack (if the stack has 1 element)
        if (stack.Count == 1)
        {
            string answer = stack.Peek();
            double intAnswer = double.Parse(answer);
            return intAnswer;
        }

        return null;
    }

}
