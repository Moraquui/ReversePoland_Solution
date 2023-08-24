# ReversePoland
Reverse Polish Notation (RPN) Calculator
This program is a simple calculator that uses Reverse Polish Notation (RPN) to evaluate arithmetic expressions. RPN is a mathematical notation where operators are placed after their operands instead of between them.

Addition {+}
Subtraction {-}
Multiplication {*}
Division {/}
parenthesis{(,)}
The calculator also supports parentheses for grouping expressions.


Here's an example usage of the program:

Enter an expression:
5 3 2 * + 4 -
Result: 5
In this example, the entered expression 5 3 2 * + 4 - is converted to RPN and evaluated to produce the result 5.

Implementation Details
The program consists of two main functions:

ToRPN: This function converts the entered expression to Reverse Polish Notation (RPN) using the Shunting Yard algorithm and returns the RPN expression as a string.
CalculateRPN: This function takes the RPN expression and evaluates it by using a stack to perform the required mathematical operations.
