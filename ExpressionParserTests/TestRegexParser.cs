using System;
using System.IO;
using System.Collections.Generic;

using NUnit.Framework;

using ExpressionParser;
using ExpressionParser.Tokens;

namespace ExpressionParserTests {
    public class TestRegexParser {
        public static IEnumerable<TestCaseData> EquationTestCasesFromFile {
            get {
                var path = Common.TestCaseLocation + @"\ParserTestEquations.txt";
                IList<TestCaseData> testCases = new List<TestCaseData>();

                // Transform lines into a test case
                foreach (var line in Common.LoadTestCasesFrom(path)) {
                    string input = line.Item1; // Input
                    Stack<Token> output = new Stack<Token>();

                    foreach (var token in line.Item2)
                        output.Push(Common.CreateTokenOf(token));

                    testCases.Add(new TestCaseData(input, new Expression(output)));
                }

                foreach (var testCase in testCases)
                    yield return testCase;
            }
        }

        [Test]
        public void TestParserParsesOnePlusOneCorrectly() {
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

        [Test]
        [TestCaseSource("EquationTestCasesFromFile")]
        public void TestParserParsesEquationCorrectly(string equation, Expression Expected) {
            var parser = new InfixParser();
            Expression Actual;

            Actual = parser.ParseExpression(equation);

            Assert.IsTrue(Actual == Expected);
        }
    }
}
