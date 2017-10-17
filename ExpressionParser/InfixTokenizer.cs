using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ExpressionParser {
    using Tokens;

    public class InfixTokenizer {
        private int _index;
        private Token _currentToken;

        public string Expression { get; private set; }
        public Token CurrentToken { get { return _currentToken; } }
        public bool HasTokens { get; private set; }


        private readonly string _numberPattern = @"^-?\d+(\.\d+)?\s*"; // Numbers cannot be explicitly positive
        private readonly string _functionPattern = @"(^sin|cos|tan|abs|sqrt)";
        private readonly string _operatorsPattern = @"(^\+|^\-|^\/|^\*|^\^)\s*";
        private readonly string _rightParenthesisPattern = @"^\)\s*";
        private readonly string _leftParenthesisPattern = @"^\(\s*";

        /// <summary>
        /// Create a new tokenizer object
        /// </summary>
        /// <param name="infixExpression">A string containing an expression in infix notation</param>
        public InfixTokenizer(string infixExpression) {
            Expression = infixExpression.Trim(); // Tidy up the expression a bit
            HasTokens = true;
        }

        /// <summary>
        /// Get the current token the parser is at, and move to the next one
        /// </summary>
        /// <returns>The token the parser has just found</returns>
        public Token ConsumeToken() {
            MoveNext();

            return _currentToken;
        }

        /// <summary>
        /// Move the tokenizer to the next token in the stream
        /// </summary>
        public void MoveNext() {
            Match match;
            // Try not to take a substring past the end of the string
            String matchAgainst = Expression.Substring(Math.Min(_index, Expression.Length)).Trim();

            // If the match string is empty, then we're at the end of the string
            // And thus the expression
            if (String.IsNullOrEmpty(matchAgainst)) {
                HasTokens = false;
                _currentToken = new EndOfExpressionToken();
            }

            // If there's no tokens left, don't move
            if (!HasTokens)
                return;

            if ((match = Regex.Match(matchAgainst, _leftParenthesisPattern)).Value != string.Empty) {
                // Found a left paren
                _currentToken = new LeftParenthesisToken();
                _index += match.Value.Length;

            } else if ((match = Regex.Match(matchAgainst, _rightParenthesisPattern)).Value != string.Empty) {
                // Found a right paren
                _currentToken = new RightParenthesisToken();
                _index += match.Value.Length;

            } else if ((match = Regex.Match(matchAgainst, _numberPattern)).Value != string.Empty) {
                // Found a number
                _currentToken = new NumberToken(match.Value);
                _index += match.Value.Length;

            } else if ((match = Regex.Match(matchAgainst, _operatorsPattern)).Value != string.Empty) {
                // Found an operator
                _currentToken = new OperatorToken(match.Value);
                _index += match.Value.Length;

            } else if ((match = Regex.Match(matchAgainst, _functionPattern)).Value != string.Empty) {
                // Found a function
                _currentToken = new FunctionToken(match.Value);
                _index += match.Value.Length;

            } else {
                // Found something we don't know about
                // Just quit
                HasTokens = false;
                _currentToken = new InvalidToken();
            }

            // Check if we've consumed all the tokens available in the expression
            if (_index == Expression.Length) {
                HasTokens = false;
                // On the next pass, _currentToken will be set to EndOfExpressionToken
            }
        }
    }
}
