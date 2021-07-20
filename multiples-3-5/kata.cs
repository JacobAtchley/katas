using System.Linq;
using NUnit.Framework;

namespace katas.multiples_3_5
{
    /// <summary>
    /// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    ///Finish the solution so that it returns the sum of all the multiples of 3 or 5 below the number passed in.
    /// </summary>
    public static class Kata
    {
        public static int Solution(int value)
        {
            if (value <= 0)
            {
                return 0;
            }

            return Enumerable
                .Range(1, value -1)
                .Where(x => x % 3 == 0 || x % 5 == 0)
                .Sum();
        }
    }

    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual(23, Kata.Solution(10));
        }
    }
}