using System.Collections.Generic;
using NUnit.Framework;

namespace katas.unique
{
    public static class Kata
    {
        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
        {
            var previous = default(T);
            var comparer = Comparer<T>.Default;

            foreach (var item in iterable)
            {
                if (previous == null || previous.Equals(default))
                {
                    previous = item;
                    yield return item;
                }

                if (comparer.Compare(item, previous) == 0)
                {
                    previous = item;
                    continue;
                }

                previous = item;
                yield return item;
            }
        }
    }

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void EmptyTest()
        {
            Assert.AreEqual("", Kata.UniqueInOrder(""));
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual("ABCDAB", Kata.UniqueInOrder("AAAABBBCCDAABBB"));
        }
    }
}