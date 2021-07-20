using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace katas.split_strings
{
    /// <summary>
    ///     Complete the solution so that it splits the string into pairs of two characters. If the string contains an odd number of characters then it should replace
    ///     the missing second character of the final pair with an underscore ('_').
    ///     Examples:
    ///     SplitString.Solution("abc"); // should return ["ab", "c_"]
    ///     SplitString.Solution("abcdef"); // should return ["ab", "cd", "ef"]
    /// </summary>
    public class SplitString
    {
        public static string[] Solution(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return Array.Empty<string>();
            }

            var buffer = new StringBuilder();
            var list = new List<string>();

            for (var i = 0; i < str.Length; i++)
            {
                if (i > 0 && i % 2 == 0)
                {
                    list.Add(buffer.ToString());
                    buffer.Clear();
                }

                buffer.Append(str[i]);
            }

            if (buffer.Length > 0)
            {
                if (buffer.Length == 1)
                {
                    buffer.Append('_');
                }

                list.Add(buffer.ToString());
                buffer.Clear();
            }

            return list.ToArray();
        }
    }

    [TestFixture]
    public class SplitStringTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(new[] {"ab", "c_"}, SplitString.Solution("abc"));
            Assert.AreEqual(new[] {"ab", "cd", "ef"}, SplitString.Solution("abcdef"));
        }
    }
}