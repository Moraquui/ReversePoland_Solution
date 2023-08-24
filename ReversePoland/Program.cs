using System;
using System.Collections.Generic;
using System.Text;

namespace ReversePolishNotation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter an expression
            Console.WriteLine("Enter an expression:");
            string expression = Console.ReadLine();

            // Calculate the result using Reverse Polish Notation
            double result = CalculateRPN(ToRPN(expression));

            // Display the result
            Console.WriteLine("Result: " + result);
        }

        static double CalculateRPN(string expression)
        {
            // Split the expression into tokens
            string[] tokens = expression.Split(' ');

            // Create a stack to store numbers and intermediate results
            Stack<double> stack = new Stack<double>();

            foreach (string token in tokens)
            {
                if (double.TryParse(token, out double number))
                {
                    // If the token is a number, push it to the stack
                    stack.Push(number);
                }
                else
                {
                    // If the token is an operator, pop the top two numbers from the stack,
                    // perform the operation, and push the intermediate result back to the stack
                    double operand2 = stack.Pop();
                    double operand1 = stack.Pop();
                    double intermediateResult;

                    switch (token)
                    {
                        case "+":
                            intermediateResult = operand1 + operand2;
                            break;
                        case "-":
                            intermediateResult = operand1 - operand2;
                            break;
                        case "*":
                            intermediateResult = operand1 * operand2;
                            break;
                        case "/":
                            intermediateResult = operand1 / operand2;
                            break;
                        default:
                            throw new ArgumentException("Invalid operator: " + token);
                    }

                    stack.Push(intermediateResult);
                }
            }

            return stack.Pop(); // The final result is the only number left in the stack
        }

        static string ToRPN(string expression)
        {
            // Create a StringBuilder to store the Reverse Polish Notation expression
            StringBuilder rpnExpression = new StringBuilder();

            // Create a stack to store operators
            Stack<char> stack = new Stack<char>();

            foreach (char c in expression)
            {
                if (char.IsDigit(c))
                {
                    // If the character is a digit, append it to the RPN expression
                    rpnExpression.Append(c);
                    rpnExpression.Append(' ');
                }
                else if (IsOperator(c))
                {
                    // If the character is an operator, pop operators from the stack
                    // and append them to the RPN expression until a lower precedence operator
                    // or a left parenthesis is encountered, then push the character to the stack
                    while (stack.Count > 0 && IsOperator(stack.Peek()) && GetPrecedence(c) <= GetPrecedence(stack.Peek()))
                    {
                        rpnExpression.Append(stack.Pop());
                        rpnExpression.Append(' ');
                    }

                    stack.Push(c);
                }
                else if (c == '(')
                {
                    // If the character is a left parenthesis, push it to the stack
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    // If the character is a right parenthesis, pop operators from the stack
                    // and append them to the RPN expression until a left parenthesis is encountered,
                    // then discard the left parenthesis
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        rpnExpression.Append(stack.Pop());
                        rpnExpression.Append(' ');
                    }

                    stack.Pop(); // Discard the opening parentheses
                }
            }

            // Append any remaining operators in the stack to the RPN expression
            while (stack.Count > 0)
            {
                rpnExpression.Append(stack.Pop());
                rpnExpression.Append(' ');
            }

            return rpnExpression.ToString().Trim(); // Return the RPN expression as a string
        }

        static bool IsOperator(char c)
        {
            // Check if the character is one of the supported operators
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        static int GetPrecedence(char c)
        {
            // Assign precedence values to the operators
            switch (c)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                default:
                    return 0;
            }
        }
    }
}
