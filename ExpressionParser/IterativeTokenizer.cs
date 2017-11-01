using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser
{
    public class IterativeTokenizer : ITokenizer
    {
        public Token CurrentToken { get; protected set; }

        public string Expression { get; protected set; }

        public bool HasTokens { get; protected set; }

        public IterativeTokenizer(string expression)
        {
            Expression = expression;
        }

        public Token ConsumeToken()
        {
            throw new NotImplementedException();
        }

        public void MoveNext()
        {
            throw new NotImplementedException();
        }
    }
}
