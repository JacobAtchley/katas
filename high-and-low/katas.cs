using System.Linq;
using NUnit.Framework;

namespace katas.high_and_low
{
    public static class Kata
    {
        public static string HighAndLow(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return null;
            }

            var numbs = numbers
                .Split(' ')
                .Select(x =>
                {
                    if (int.TryParse(x, out var integer))
                    {
                        return (int?) integer;
                    }

                    return null;
                })
                .Where(x => x.HasValue)
                .Select(x => x.Value)
                .ToArray();

            var max = numbs.Max();
            var min = numbs.Min();

            return $"{max} {min}";
        }
    }

    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual("42 -9", Kata.HighAndLow("8 3 -5 42 -1 0 0 -9 4 7 4 -4"));
        }
    }
}