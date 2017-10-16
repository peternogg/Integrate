using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser.Tokens {
    class EndOfExpressionToken : IToken {
        public string Text => string.Empty;
    }
}
