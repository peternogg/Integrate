﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser.Tokens {
    public class RightParenthesisToken : IToken {
        public string Text => ")";
    }
}
