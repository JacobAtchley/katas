using System;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace katas.duplicate_detector
{
    /// <summary>
    ///     The goal of this exercise is to convert a string to a new string where each character in the new string is "("
    ///     if that character appears only once in the original string, or ")"
    ///     if that character appears more than once in the original string.
    ///     Ignore capitalization when determining if a character is a duplicate.
    ///     Examples
    ///     "din"      =>  "((("
    ///     "recede"   =>  "()()()"
    ///     "Success"  =>  ")())())"
    ///     "(( @"     =>  "))(("
    /// </summary>
    public class Kata
    {
        public static string DuplicateEncode(string word)
        {
            var builder = new StringBuilder();

            foreach (var c in word)
            {
                var count = word.Count(x => x.ToString().Equals(c.ToString(), StringComparison.InvariantCultureIgnoreCase));
                builder.Append(count > 1 ? ')' : '(');
            }

            return builder.ToString();
        }
    }

    [TestFixture]
    public class KataTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual("(((", Kata.DuplicateEncode("din"));
            Assert.AreEqual("()()()", Kata.DuplicateEncode("recede"));
            Assert.AreEqual(")())())", Kata.DuplicateEncode("Success"), "should ignore case");
            Assert.AreEqual("))((", Kata.DuplicateEncode("(( @"));
        }
    }
}