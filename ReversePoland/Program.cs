using ReversePoland;
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
            //Console.WriteLine("Enter an expression:");
            //string expression = Console.ReadLine();
            string expression = "12+34*(56+78)+11";
            // Calculate the result using Reverse Polish Notation
            // Display the result
            Console.WriteLine("Result: " + RPN_Solver.Solve(expression));
        }

    }
}
