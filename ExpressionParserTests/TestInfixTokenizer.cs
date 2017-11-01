using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using NUnit.Framework;

using ExpressionParser;
using ExpressionParser.Tokens;

namespace ExpressionParserTests
{
    public class TestInfixTokenizer
    {
        public static IEnumerable<TestCaseData> EquationTestCasesFromFile {
            get {
                var path = Common.TestCaseLocation + Path.DirectorySeparatorChar + "TokenizerTestEquations.txt";
                List<TestCaseData> testCases = new List<TestCaseData>();

                foreach (var line in Common.LoadTestCasesFrom(path)) {
                    List<Token> outputTokens = new List<Token>();
                    foreach(string token in line.Item2) {
                        // Split the token into two parts: its Type, and its arguments (optional)
                        outputTokens.Add(Common.CreateTokenOf(token));
                    }
                    
                    testCases.Add(new TestCaseData(line.Item1, outputTokens));
                }

                // Yield each case in turn
                foreach (var testCase in testCases)
                    yield return testCase;
            }
        }

        [Test]
        public void TestTokenizerTokenizesOnePlusOneCorrectly() {
            var OnePlusOne = "1 + 1";
            var tokenizer = new RegexTokenizer(OnePlusOne);

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
        public void TestTokenizerRecognizesNumbers() {
            var Numbers = "1 1.1 -1 1 2 3 -2 -3 1.000101 432515335151";
            var tokenizer = new RegexTokenizer(Numbers);

            List<Token> Actual = new List<Token>();
            List<Token> Expected = Numbers.Split(' ').Select(number => new NumberToken(number)).ToList<Token>();

            while (tokenizer.HasTokens)
                Actual.Add(tokenizer.ConsumeToken());

            Assert.That(Actual, Is.EquivalentTo(Expected));
        }

        [Test]
        public void TestTokenizerFailsOnExplicitPositives() {
            // Tokenizer uses regexes so it can't see explicit positives
            // Maybe a different approach would be better but... eh
            var TestExpression = "1 +1 -1 +1.0 -1.0";
            var tokenizer = new RegexTokenizer(TestExpression);

            List<Token> Actual = new List<Token>();
            List<Token> Expected = new List<Token>() {
                new NumberToken("1"), 
                new OperatorToken("+"),
                new NumberToken("1"),
                new NumberToken("-1"),
                new OperatorToken("+"),
                new NumberToken("1.0"),
                new NumberToken("-1.0")
            };

            while (tokenizer.HasTokens)
                Actual.Add(tokenizer.ConsumeToken());

            Assert.That(Actual, Is.EquivalentTo(Expected));
        }

        [Test]
        public void TestTokenizerIgnoresWhitespace() {
            // +2 might introduce problems
            var Equation = " \t  1   +2 -   +     5 3 / 4  - 5 \t";
            var tokenizer = new RegexTokenizer(Equation);

            List<Token> Actual = new List<Token>();
            List<Token> Expected = new List<Token>() {
                new NumberToken("1"),
                new OperatorToken("+"),
                new NumberToken("2"),
                new OperatorToken("-"),
                new OperatorToken("+"),
                new NumberToken("5"),
                new NumberToken("3"),
                new OperatorToken("/"),
                new NumberToken("4"),
                new OperatorToken("-"),
                new NumberToken("5")
            };

            while (tokenizer.HasTokens)
                Actual.Add(tokenizer.ConsumeToken());

            Assert.That(Actual, Is.EquivalentTo(Expected));
        }

        [Test]
        public void TestTokenizerTokenizesOnePlusOnePlusOneIsCorrectly() {
            var OnePlusOnePlusOne = "1 + 1 + 1";
            var tokenizer = new RegexTokenizer(OnePlusOnePlusOne);

            List<Token> Actual = new List<Token>();
            List<Token> Expected = new List<Token> {
                new NumberToken("1"),
                new OperatorToken("+"),
                new NumberToken("1"),
                new OperatorToken("+"),
                new NumberToken("1")
            };

            while (tokenizer.HasTokens)
                Actual.Add(tokenizer.ConsumeToken());

            Assert.That(Actual, Is.EquivalentTo(Expected));
        }

        [Test]
        public void TestTokenizerRecognizesAllOperators() {
            var Operators = "+-/*^";
            var tokenizer = new RegexTokenizer(Operators);

            List<Token> Actual = new List<Token>();
            List<Token> Expected = new List<Token>() {
                new OperatorToken("+"),
                new OperatorToken("-"),
                new OperatorToken("/"),
                new OperatorToken("*"),
                new OperatorToken("^")
            };

            while (tokenizer.HasTokens)
                Actual.Add(tokenizer.ConsumeToken());

            Assert.That(Actual, Is.EquivalentTo(Expected));
        }

        [Test]
        public void TestTokenizerFindsParenthesis() {
            var ParenthesisTestString = "() )   ( (( ))";
            var tokenizer = new RegexTokenizer(ParenthesisTestString);

            var Actual = new List<Token>();
            var Expected = new List<Token>() {
                new LeftParenthesisToken(),
                new RightParenthesisToken(),
                new RightParenthesisToken(),
                new LeftParenthesisToken(),
                new LeftParenthesisToken(),
                new LeftParenthesisToken(),
                new RightParenthesisToken(),
                new RightParenthesisToken()
            };

            while (tokenizer.HasTokens)
                Actual.Add(tokenizer.ConsumeToken());

            Assert.That(Actual, Is.EquivalentTo(Expected));
        }

        [Test, TestCaseSource(nameof(EquationTestCasesFromFile))]
        public void TestTokenizerCorrectlyTokenizesRegularEquations(string Input, List<Token> Expected) {
            var Actual = new List<Token>();
            var tokenizer = new RegexTokenizer(Input);

            while (tokenizer.HasTokens)
                Actual.Add(tokenizer.ConsumeToken());

            Assert.That(Actual, Is.EquivalentTo(Expected));
        }
    } 
}
