using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace katas.vowels
{
    public static class Kata
    {
        public static string Disemvowel(string str)
        {
            var vowels = new[] {'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};
            var list = new List<char>();

            foreach (var c in str)
            {
                if (vowels.Any(x => x == c))
                {
                    continue;
                }

                list.Add(c);
            }

            var voweless = string.Join("", list);
            return voweless;
        }
    }

    [TestFixture]
    public class DisemvowelTest
    {
        [Test]
        public void ShouldRemoveAllVowels()
        {
            Assert.AreEqual("Ths wbst s fr lsrs LL!", Kata.Disemvowel("This website is for losers LOL!"));
        }

        [Test]
        public void MultilineString()
        {
            Assert.AreEqual("N ffns bt,\nYr wrtng s mng th wrst 'v vr rd", Kata.Disemvowel("No offense but,\nYour writing is among the worst I've ever read"));
        }

        [Test]
        public void OneMoreForGoodMeasure()
        {
            Assert.AreEqual("Wht r y,  cmmnst?", Kata.Disemvowel("What are you, a communist?"));
        }
    }
}