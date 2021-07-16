using System.Linq;
using NUnit.Framework;

namespace katas.find_odd_int
{

    /// <summary>
    /// Given an array of integers, find the one that appears an odd number of times.
    // There will always be only one integer that appears an odd number of times.
    /// </summary>
    class Kata
    {
        public static int find_it(int[] seq)
        {
            return seq
                .GroupBy(x => x)
                .FirstOrDefault(x => x.Count() % 2 != 0)
                .Key;
        }

    }
    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void Tests()
        {
            Assert.AreEqual(5 , Kata.find_it ( new[] { 20,1,-1,2,-2,3,3,5,5,1,2,4,20,4,-1,-2,5 }));
        }
    }
}