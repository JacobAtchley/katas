using NUnit.Framework;

namespace katas
{
    /// <summary>
    ///     #Find the missing letter
    ///     Write a method that takes an array of consecutive (increasing) letters as input and that returns the missing letter in the array.
    ///     You will always get an valid array. And it will be always exactly one letter be missing. The length of the array will always be at least 2.
    ///     The array will always contain letters in only one case.
    ///     Example:
    ///     ['a','b','c','d','f'] -> 'e' ['O','Q','R','S'] -> 'P'
    ///     ["a","b","c","d","f"] -> "e"
    ///     ["O","Q","R","S"] -> "P"
    /// </summary>
    public class Kata
    {
        public static char FindMissingLetter(char[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                var current = array[i];

                if (i < array.Length)
                {
                    var next = array[i + 1];

                    if (next - current > 1)
                    {
                        return (char) (current + 1);
                    }

                    if (i > 0)
                    {
                        var previous = array[i - 1];

                        if (current - previous > 1)
                        {
                            return (char) (previous + 1);
                        }
                    }
                }
            }

            return char.MinValue;
        }
    }

    public class KataTests
    {
        [Test]
        public void ExampleTests()
        {
            Assert.AreEqual('e', Kata.FindMissingLetter(new[] {'a', 'b', 'c', 'd', 'f'}));
            Assert.AreEqual('P', Kata.FindMissingLetter(new[] {'O', 'Q', 'R', 'S'}));
        }
    }
}