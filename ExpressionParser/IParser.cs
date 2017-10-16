using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser
{
    public interface IParser
    {
        Expression ParseExpression(string expression);
    }
}
