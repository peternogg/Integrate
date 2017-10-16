using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser {
    using Tokens;

    public class Expression {
        private readonly Stack<Token> _tokenStack;

        internal Expression(Stack<Token> tokenStack) {
            _tokenStack = tokenStack;
        }

        public double Evaluate() {
            throw new System.NotImplementedException("Expression#Evaluate");
        }
    }
}
