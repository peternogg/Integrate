using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser.Tokens {
    public class InvalidToken : Token {
        public InvalidToken() : base(String.Empty) {

        }
    }
}
