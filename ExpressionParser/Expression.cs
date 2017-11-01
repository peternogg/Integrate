using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser {
    using Tokens;

    public class Expression {
        private readonly Stack<Token> _tokenStack;

        public Expression(Stack<Token> tokenStack) {
            _tokenStack = tokenStack;
        }

        /// <summary>
        /// Evaluate the stack
        /// </summary>
        /// <returns></returns>
        public double Evaluate() {
            throw new NotImplementedException("Expression#Evaluate");
        }

        public override string ToString() {
            StringBuilder builder = new StringBuilder();

            foreach (var token in _tokenStack)
                builder.Append(token.Text).Append(' ');

            return builder.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator==(Expression left, Expression right) {
            // The expressions are not equal if they are of different lengths
            if (left._tokenStack.Count != right._tokenStack.Count)
                return false;

            // Look at each element in the stacks and compare them. If they are the same, in the same order,
            // then the expressions are the same.
            IEnumerator<Token> leftStack = left._tokenStack.GetEnumerator(), rightStack = right._tokenStack.GetEnumerator();
            bool same = true;

            while (same && leftStack.MoveNext() && rightStack.MoveNext())
                same &= leftStack.Current == rightStack.Current;

            return same;
        }

        public static bool operator!=(Expression left, Expression right) {
            return !(left == right);
        }
    }
}
