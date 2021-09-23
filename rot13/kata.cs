using System.Text;
using NUnit.Framework;

namespace katas.rot13
{
    public class Kata
    {
        /// <summary>
        ///     reverses a rot13 string
        /// </summary>
        /// <param name="input">the rot13 encoded string</param>
        /// <returns>
        ///     the deciphered text
        /// </returns>
        public static string Rot13(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            var sb = new StringBuilder();

            for (var i = 0; i < input.Length; i++)
            {
                if (!char.IsLetter(input[i]))
                {
                    sb.Append(input[i]);
                    continue;
                }

                if (input[i] >= 65 && input[i]<= 90)
                {
                    sb.Append(ClampChar(65, 90, input[i] - 13));
                }
                else if (input[i] >= 97 && input[i] <= 122)
                {
                    sb.Append(ClampChar(97, 122, input[i] - 13));
                }
            }

            var newStr = sb.ToString();
            return newStr;
        }

        private static char ClampChar(int minBound, int maxBound, int input)
        {
            if (input < minBound)
            {
                return (char)(maxBound - (minBound - input) + 1);
            }

            if (input > maxBound)
            {
                return (char)(minBound + (input - maxBound));
            }

            return (char)input;
        }

        [TestFixture]
        public class SystemTests
        {
            [Test]
            public void Test1()
            {
                Assert.AreEqual("ROT13 example.", Rot13("EBG13 rknzcyr."));
            }
        }
    }
}