using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace katas.top_words
{
    [TestFixture]
    public class TopWords
    {
        private const char APOSTROPHE_CHAR = (char)39;
        private const char SPACE = ' ';

        public static List<string> Top3(string s)
        {
            var counts = new Dictionary<string, int>();
            var builder = new StringBuilder();
            var previousLetter = char.MinValue;

            foreach (var character in s)
            {
                var letter = char.ToLower(character);
                var isLetter = letter >= 97 && letter <= 122;

                if (previousLetter == APOSTROPHE_CHAR && isLetter)
                {
                    builder.Append(APOSTROPHE_CHAR);
                }

                if (isLetter)
                {
                    builder.Append(letter);
                }

                if (character == SPACE)
                {
                    if (previousLetter == APOSTROPHE_CHAR && builder.Length > 0)
                    {
                        builder.Append(APOSTROPHE_CHAR);
                    }

                    AddWord(builder, counts);
                }

                previousLetter = letter;
            }

            if (builder.Length > 0)
            {
                AddWord(builder, counts);
            }

            var top = counts
                .OrderByDescending(x => x.Value)
                .Take(3)
                .Select(x => x.Key)
                .ToList();

            return top;
        }

        private static void AddWord(StringBuilder builder, IDictionary<string, int> counts)
        {
            var word = builder.ToString();

            if (string.IsNullOrWhiteSpace(word))
            {
                return;
            }

            if (counts.ContainsKey(word))
            {
                counts[word]++;
            }
            else
            {
                counts.Add(word, 1);
            }

            builder.Clear();
        }

        [Test]
        public void SampleTests()
        {
            Assert.AreEqual(new List<string> { "e", "d", "a" }, Top3("a a a  b  c c  d d d d  e e e e e"));
            Assert.AreEqual(new List<string> { "e", "ddd", "aa" }, Top3("e e e e DDD ddd DdD: ddd ddd aa aA Aa, bb cc cC e e e"));
            Assert.AreEqual(new List<string> { "won't", "wont" }, Top3("  //wont won't won't "));
            Assert.AreEqual(new List<string> { "e" }, Top3("  , e   .. "));
            Assert.AreEqual(new List<string>(), Top3("  ...  "));
            Assert.AreEqual(new List<string>(), Top3("  '  "));
            Assert.AreEqual(new List<string>(), Top3("  '''  "));
            Assert.AreEqual(new List<string> { "a", "of", "on" }, Top3(
                string.Join("\n", "In a village of La Mancha, the name of which I have no desire to call to",
                    "mind, there lived not long since one of those gentlemen that keep a lance",
                    "in the lance-rack, an old buckler, a lean hack, and a greyhound for", "coursing. An olla of rather more beef than mutton, a salad on most",
                    "nights, scraps on Saturdays, lentils on Fridays, and a pigeon or so extra", "on Sundays, made away with three-quarters of his income.")));
        }
    }
}