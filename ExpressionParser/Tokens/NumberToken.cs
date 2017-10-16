using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser.Tokens {
    public class NumberToken : IToken {
        public string Text { get; private set; }
        public double Value { get; private set; }

        public NumberToken(string Text) {
            if (!double.TryParse(Text, out double result))
                throw new ArgumentException("Invalid number " + Text);
            else {
                this.Text = Text;
                this.Value = result;
            }
        }
    }
}
