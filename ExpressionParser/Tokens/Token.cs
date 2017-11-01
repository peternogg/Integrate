using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser {
    public abstract class Token {
        public string Text { get; protected set; }

        public Token(string Text) {
            this.Text = Text.Trim();
        }

        public override string ToString() {
            return String.Format("{0} -> {1}", GetType().Name, Text);
        }

        public override bool Equals(object obj) {
            return this.Text == (obj as Token).Text;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Two tokens are equal when the text they represent are equal
        /// </summary>
        /// <param name="left">Left side of comparison</param>
        /// <param name="right">Right side of comparison</param>
        /// <returns></returns>
        public static bool operator==(Token left, Token right) {
            return left.Text == right.Text;
        }

        public static bool operator!=(Token left, Token right) {
            return !(left == right);
        }
    }

}
