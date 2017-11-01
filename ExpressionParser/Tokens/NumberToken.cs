using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser.Tokens {
    public class NumberToken : Token {
        public double Value { get; private set; }

        public NumberToken(string Text) : base(Text)
        {
            double result;
            if (!double.TryParse(Text, out result))
                throw new ArgumentException("Invalid number " + Text);
            else {
                this.Value = result;
            }
        }
    }
}
