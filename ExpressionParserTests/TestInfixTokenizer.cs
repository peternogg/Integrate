using System.Linq;
using System.Collections.Generic;

using NUnit.Framework;

using ExpressionParser;
using ExpressionParser.Tokens;

namespace ExpressionParserTests
{
    public class TestInfixTokenizer
    {
        [Test]
        public void TestOnePlusOneIsParsedCorrectly() {
            string OnePlusOne = "1 + 1";
            InfixTokenizer tokenizer = new InfixTokenizer(OnePlusOne);

            List<Token> Actual = new List<Token>();
            List<Token> Expected = new List<Token>() {
                new NumberToken("1"),
                new OperatorToken("+"),
                new NumberToken("1"),
                //new EndOfExpressionToken()
            };

            while (tokenizer.HasTokens)
                Actual.Add(tokenizer.ConsumeToken());

            Assert.That(Actual, Is.EquivalentTo(Expected));
        }

        [Test]
        public void TestParserRecognizersNumbers() {
            string Numbers = "1 1.1 -1 +1 +2 +3 -2 -3 1.000101 432515335151";
            InfixTokenizer tokenizer = new InfixTokenizer(Numbers);

            List<Token> Actual = new List<Token>();
            List<Token> Expected = Numbers.Split(' ').Select(number => new NumberToken(number)).ToList<Token>();

            while (tokenizer.HasTokens)
                Actual.Add(tokenizer.ConsumeToken());

            Assert.That(Actual, Is.EquivalentTo(Expected));
        }

        [Test]
        public void TestOnePlusOnePlusOneIsParsedCorrectly() {
            string OnePlusOnePlusOne = "1 + 1 + 1";
            InfixTokenizer tokenizer = new InfixTokenizer(OnePlusOnePlusOne);

            List<Token> Actual = new List<Token>();
            List<Token> Expected = new List<Token> {
                new NumberToken("1"),
                new OperatorToken("+"),
                new NumberToken("1"),
                new OperatorToken("+"),
                new NumberToken("1"),
                //new EndOfExpressionToken() // Do we really want this in the output stream
            };

            while (tokenizer.HasTokens)
                Actual.Add(tokenizer.ConsumeToken());

            Assert.That(Actual, Is.EquivalentTo(Expected));
        }

        [Test]
        public void TestTokenizerRecognizesAllOperators() {
            var Operators = "+-/*^";
            var tokenizer = new InfixTokenizer(Operators);

            List<Token> Actual = new List<Token>();
            List<Token> Expected = new List<Token>() {
                new OperatorToken("+"),
                new OperatorToken("-"),
                new OperatorToken("/"),
                new OperatorToken("*"),
                new OperatorToken("^"),
                //new EndOfExpressionToken()
            };

            while (tokenizer.HasTokens)
                Actual.Add(tokenizer.ConsumeToken());

            Assert.That(Actual, Is.EquivalentTo(Expected));
        }
    } 
}
