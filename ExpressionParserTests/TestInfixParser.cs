using System;
using System.IO;
using System.Collections.Generic;

using NUnit.Framework;

using ExpressionParser;
using ExpressionParser.Tokens;

namespace ExpressionParserTests {
    class TestInfixParser {

        public static IEnumerable<TestCaseData> TestEquationsFromFile {
            get {
                IList<TestCaseData> testCases = new List<TestCaseData>();
                IList<(string, string[])> lines = Common.LoadTestCasesFrom("ParserTestEquations.txt");

                // Transform lines into a test case
                foreach (var line in lines) {
                    string input = line.Item1; // Input
                    Stack<Token> output = new Stack<Token>();

                    foreach (var token in line.Item2)
                        output.Push(Common.CreateTokenOf(token));
                }

                foreach (var testCase in testCases)
                    yield return testCase;
            }
        }

        [Test]
        public void TestOnePlusOneParsedCorrectly() {
            string OnePlusOne = "1 + 1";
            InfixParser parser = new InfixParser();

            Stack<Token> ExpectedStack = new Stack<Token>();
            ExpectedStack.Push(new NumberToken("1"));
            ExpectedStack.Push(new NumberToken("1"));
            ExpectedStack.Push(new OperatorToken("+"));

            Expression Expected = new Expression(ExpectedStack);
            Expression Actual = parser.ParseExpression(OnePlusOne);

            Assert.IsTrue(Actual == Expected);
        }

        [Test, TestCaseSource("TestEquationsFromFile")]
        public void TestEquationsParsedCorrectly(string equation, Expression expected) {

        }
    }
}
