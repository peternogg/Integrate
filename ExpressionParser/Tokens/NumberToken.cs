using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser.Tokens {
    public class NumberToken : Token {
        public double Value { get; private set; }

        public NumberToken(string Text) : base(Text) {
            if (!double.TryParse(Text, out double result))
                throw new ArgumentException("Invalid number " + Text);
            else {
                this.Value = result;
            }
        }
    }
}
