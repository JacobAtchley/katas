using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace katas.roman_numerals
{
    public class RomanConvert
    {
        public static string Solution(int n)
        {
            var mappings = new List<(char, int)>
            {
                ('M', 1_000),
                ('D', 500),
                ('C', 100),
                ('L', 50),
                ('X', 10),
                ('V', 5),
                ('I', 1)
            };

            var sb = new StringBuilder();
            var numberStr = n.ToString();
            var index = 0;

            while (index < numberStr.Length)
            {
                string ns;

                if (index == numberStr.Length)
                {
                    ns = numberStr;
                }
                else
                {
                    ns = numberStr.Substring(index, 1).PadRight(numberStr.Length - index, '0');
                }

                var number = int.Parse(ns);

                if (number != 0)
                {
                    var numeral = FindClosestNumeral(mappings, number);

                    if (numeral.number == number)
                    {
                        sb.Append(numeral.romanNumber);
                    }
                    else if (numeral.index >= 1)
                    {
                        var previous = mappings[numeral.index - 1];

                        var nextIndex = numeral.index + 1;

                        if (nextIndex >= mappings.Count)
                        {
                            nextIndex = mappings.Count - 1;
                        }

                        var next = mappings[nextIndex];

                        if (previous.Item2 - next.Item2 == number)
                        {
                            sb.Append(next.Item1);
                            sb.Append(previous.Item1);
                        }
                        else if (previous.Item2 - numeral.number == number)
                        {
                            sb.Append(numeral.romanNumber);
                            sb.Append(previous.Item1);
                        }
                        else
                        {
                            var sum = 0;
                            while (sum < number)
                            {
                                if (numeral.number <= number)
                                {
                                    sum += numeral.number;
                                    sb.Append(numeral.romanNumber);
                                }

                                numeral = FindClosestNumeral(mappings, number - sum);
                            }
                        }
                    }
                    else
                    {
                        var sum = 0;
                        while (sum < number)
                        {
                            if (numeral.number <= number)
                            {
                                sum += numeral.number;
                                sb.Append(numeral.romanNumber);
                            }

                            numeral = FindClosestNumeral(mappings, number - sum);
                        }
                    }
                }

                index++;
            }

            return sb.ToString();
        }

        private static (char romanNumber, int number, int index) FindClosestNumeral(List<(char romanNumber, int number)> mappings, int number)
        {
            var numeral = mappings
                .Select((tuple, index) => (tuple.romanNumber, tuple.number, index))
                .FirstOrDefault(x => x.number <= number);
            return numeral;
        }
    }

    [TestFixture]
    public class RomanConvertTests
    {
        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(4, "IV")]
        [TestCase(500, "D")]
        [TestCase(1000, "M")]
        [TestCase(1954, "MCMLIV")]
        [TestCase(1990, "MCMXC")]
        [TestCase(2008, "MMVIII")]
        [TestCase(2014, "MMXIV")]
        [TestCase(2345, "MMCCCXLV")]
        public void Test(int value, string expected)
        {
            Assert.AreEqual(expected, RomanConvert.Solution(value));
        }
    }
}