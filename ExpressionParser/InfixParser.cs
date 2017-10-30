using System;
using System.Collections.Generic;

namespace ExpressionParser {
    using Tokens;

    public class InfixParser : IParser {
        public Expression ParseExpression(string infixExpression) {
            // First: Tokenize the entire string
            var output = new Queue<Token>();
            var operators = new Stack<Token>();
            RegexTokenizer tokenizer = new RegexTokenizer(infixExpression);
            Token currentToken;

            while (tokenizer.HasTokens) {
                currentToken = tokenizer.ConsumeToken();

                if (currentToken is NumberToken)
                    output.Enqueue(currentToken);
                else if (currentToken is LeftParenthesisToken)
                    operators.Push(currentToken);
                else if (currentToken is OperatorToken)
                    HandleOperator((OperatorToken)currentToken, output: output, operators: operators);
                else if (currentToken is RightParenthesisToken)
                    HandleRightParen(output: output, operators: operators);

            }

            while (operators.Count > 0)
                output.Enqueue(operators.Pop());

            return new Expression(new Stack<Token>(output));
        }

        private void HandleRightParen(Queue<Token> output, Stack<Token> operators) {
            while (!(operators.Peek() is LeftParenthesisToken))
                output.Enqueue(operators.Pop());

            // Top of operators is a left parenthesis token
            if (operators.Count > 0)
                operators.Pop(); // Throw it away
            else
                throw new Exception("Mismatched parenthesis");
        }

        private void HandleOperator(OperatorToken currentToken, Queue<Token> output, Stack<Token> operators) {
            if (operators.Count > 0) {
                OperatorToken operatorsTop = (OperatorToken)operators.Peek();

                while (operators.Count > 0 && operatorsTop.LeftAssociative && operatorsTop.Precedence >= currentToken.Precedence) {
                    output.Enqueue(operators.Pop());
                }
            }

            operators.Push(currentToken);
        }
    }
}
