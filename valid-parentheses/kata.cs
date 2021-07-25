using System.Collections.Generic;
using NUnit.Framework;

namespace katas.valid_parentheses
{
    /// <summary>
    ///     Write a function that takes a string of parentheses, and determines if the order of the parentheses is valid. The function should return true if the string
    ///     is valid, and false if it's invalid.
    ///     Examples
    ///     "()"              =>  true
    ///     ")(()))"          =>  false
    ///     "("               =>  false
    ///     "(())((()())())"  =>  true
    ///     Constraints
    ///     0 <= input.length <= 100
    ///     Along with opening (() and closing ()) parenthesis, input may contain any valid ASCII characters.
    ///     Furthermore, the input string may be empty and/or not contain any parentheses at all
    ///     Do not treat other forms of brackets as parentheses (e.g. [], {}, <>).
    /// </summary>
    public class Parentheses
    {
        public static bool ValidParentheses(string input)
        {
            const char open = '(';
            const char close = ')';

            if (input.StartsWith(close))
            {
                return false;
            }

            if (input.EndsWith(open))
            {
                return false;
            }

            var opens = new List<int>();

            for (var i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];

                switch (currentChar)
                {
                    case open:
                        opens.Add(i);
                        break;
                    case close:
                        if (opens.Count >= 1)
                        {
                            opens.RemoveAt(opens.Count - 1);
                        }
                        else
                        {
                            return false;
                        }
                        break;
                }
            }

            return opens.Count == 0;
        }
    }

    [TestFixture]
    public class SolutionTest
    {
        [TestCase("()", true)]
        [TestCase("(())((()())())", true)]
        [TestCase(")((((", false)]
        [TestCase("())))))", false)]
        public void SampleTest1(string paren, bool should)
        {
            Assert.AreEqual(should, Parentheses.ValidParentheses(paren));
        }
    }
}