using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser.Tokens {
    public struct FunctionToken : IToken {
        public string Text { get; private set; }

        public FunctionToken(string Text) {
            this.Text = Text;
        }
    }
}
