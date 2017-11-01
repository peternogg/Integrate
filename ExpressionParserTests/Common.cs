using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using NUnit.Framework;

using ExpressionParser;
using ExpressionParser.Tokens;

namespace ExpressionParserTests {
    public static class Common {

        // String -> Token Type
        public static readonly Dictionary<string, Type> TokenTypes = new Dictionary<string, Type>() {
            { "Number", typeof(NumberToken) },
            { "Operator", typeof(OperatorToken) },
            { "Function", typeof(FunctionToken) },
            { "LeftParenthesis", typeof(LeftParenthesisToken) },
            { "RightParenthesis", typeof(RightParenthesisToken) },
            { "EndOfExpression", typeof(EndOfExpressionToken) }
        };

        public static readonly string TestCaseLocation 
            = TestContext.CurrentContext.TestDirectory + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "Test Cases";

        /// <summary>
        /// Load a test case file with cases on separate lines, formatted as input, token 1, token 2, token 3...
        /// </summary>
        /// <param name="filename">The name of the file to load. Doesn't need to contain the path</param>
        /// <returns>A list of lines split into parts on commas. The parts are not trimmed.</returns>
        public static IList<Tuple<string, string[]>> LoadTestCasesFrom(string filename) {
            var processedLines = new List<Tuple<string, string[]>>();

            using (StreamReader caseFile = new StreamReader(filename)) {
                string currentLine;

                while (!caseFile.EndOfStream) {
                    currentLine = caseFile.ReadLine().Trim();

                    // Ignore comments
                    if (!currentLine.StartsWith("#") && !string.IsNullOrWhiteSpace(currentLine)) {
                        string[] splitLine = currentLine.Split(',');

                        // Get the parts of splitLine
                        // Get the input part (the first item)
                        string inputPart = splitLine[0];
                        // Get the tokens
                        string[] tokens = new string[splitLine.Length - 1];

                        // Copy token strings from splitLine
                        for (int i = 1; i < splitLine.Length; i++)
                            tokens[i - 1] = splitLine[i];

                        processedLines.Add(new Tuple<string, string[]>(inputPart, tokens));
                    }
                }
            }

            return processedLines;
        }

        public static Token CreateTokenOf(string token) {
            string[] parts = token.Trim().Split(' ');
            Type construct = TokenTypes[parts[0].Trim()];
            Token finalToken;

            // If there is an argument, pass it on
            if (parts.Length > 1)
                finalToken = Activator.CreateInstance(construct, parts[1]) as Token;
            else
                finalToken = Activator.CreateInstance(construct) as Token;

            return finalToken;
        }
    }
}
