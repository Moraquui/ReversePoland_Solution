using System;
using System.Collections.Generic;
using System.Text;

namespace ReversePolishNotation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an expression:");
            string expression = Console.ReadLine();

            double result = CalculateRPN(ToRPN(expression));

            Console.WriteLine("Result: " + result);
        }

        static double CalculateRPN(string expression)
        {
            string[] tokens = expression.Split(' ');
            Stack<double> stack = new Stack<double>();

            foreach (string token in tokens)
            {
                if (double.TryParse(token, out double number))
                {
                    stack.Push(number);
                }
                else
                {
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

            return stack.Pop();
        }
        static string ToRPN(string expression)
        {
            StringBuilder rpnExpression = new StringBuilder();
            Stack<char> stack = new Stack<char>();

            foreach (char c in expression)
            {
                if (char.IsDigit(c))
                {
                    rpnExpression.Append(c);
                    rpnExpression.Append(' ');
                }
                else if (IsOperator(c))
                {
                    while (stack.Count > 0 && IsOperator(stack.Peek()) && GetPrecedence(c) <= GetPrecedence(stack.Peek()))
                    {
                        rpnExpression.Append(stack.Pop());
                        rpnExpression.Append(' ');
                    }

                    stack.Push(c);
                }
                else if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        rpnExpression.Append(stack.Pop());
                        rpnExpression.Append(' ');
                    }

                    stack.Pop(); // Discard the opening parentheses
                }
            }

            while (stack.Count > 0)
            {
                rpnExpression.Append(stack.Pop());
                rpnExpression.Append(' ');
            }

            return rpnExpression.ToString().Trim();
        }

        static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        static int GetPrecedence(char c)
        {
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