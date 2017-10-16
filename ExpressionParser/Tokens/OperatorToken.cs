using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser.Tokens {
    public struct OperatorToken : IToken {
        public string Text { get; private set; }
        public int Precedence { get; private set; }
        public bool LeftAssociative => Text != "^"; // Exponent is the only right associative operator

        private static readonly Dictionary<string, int> PrecedenceFor = new Dictionary<string, int> {
            { "+", 1 },
            { "-", 1 },
            { "/", 2 },
            { "*", 2 },
            { "^", 3 }
        };

        public OperatorToken(string TokenString) {
            this.Text = TokenString.Trim();
            this.Precedence = PrecedenceFor[Text];
        }
    }
}
