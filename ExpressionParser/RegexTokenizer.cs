using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ExpressionParser {
    using Tokens;

    public class RegexTokenizer : ITokenizer
    {
        private int _index;
        private Token _currentToken = null;
        private Token _previousToken = null;

        public string Expression { get; private set; }

        public Token CurrentToken
        {
            get
            {
                return _currentToken;
            }
            private set
            {
                _previousToken = _currentToken;
                _currentToken = value;
            }
        }

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
        public RegexTokenizer(string infixExpression) {
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
            // Continue only if we think there might still be tokens
            if (!HasTokens)
                return;
            
            string target = Expression.Substring(Math.Min(_index, Expression.Length)).Trim();
            var nextToken = FindNextToken(target);

            if (nextToken == null)
            {
                CurrentToken = new EndOfExpressionToken();
                HasTokens = false;
            }
            else
            {
                CurrentToken = nextToken;
            }
        }

        private Token FindNextToken(string target)
        {
            Match match;
            
            // If the match string is empty, then we're at the end of the string
            // And thus the expression
            if (string.IsNullOrEmpty(target))
            {
                return new EndOfExpressionToken();
            }
            
            if ((match = Regex.Match(target, _leftParenthesisPattern)).Value != string.Empty) {
                // Found a left paren
                _index += match.Value.Length;
                return new LeftParenthesisToken();
            }
            
            if ((match = Regex.Match(target, _rightParenthesisPattern)).Value != string.Empty) {
                // Found a right paren
                _index += match.Value.Length;
                return new RightParenthesisToken();
            }
            
            if ((match = Regex.Match(target, _numberPattern)).Value != string.Empty) {
                // The tokenizer sometimes grabs minus operators as part of a number when it's wrong
                // There's ambiguity when the expression contains number MINUS number. If the previous
                // token WASN'T a number, and this match starts with a negative, then it's a number.
                // Otherwise, we'll let it be an operator
                if (!(match.Value.StartsWith("-") && _previousToken is NumberToken))
                {
                    // Found a number
                    _index += match.Value.Length;
                    return new NumberToken(match.Value);
                }
                // If we don't enter the above if block, then the next thing that it should match is the operator
            }
            
            if ((match = Regex.Match(target, _operatorsPattern)).Value != string.Empty) {
                // Found an operator
                _index += match.Value.Length;
                return new OperatorToken(match.Value);
            }
            
            if ((match = Regex.Match(target, _functionPattern)).Value != string.Empty) {
                // Found a function
                _index += match.Value.Length;
                return new FunctionToken(match.Value);
            }
            
            // We probably shouldn't be down here
            return new InvalidToken();
        }
    }
}
