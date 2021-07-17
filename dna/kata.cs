using System.Collections.Generic;
using NUnit.Framework;

namespace katas.dna
{
    /// <summary>
    ///     Deoxyribonucleic acid (DNA) is a chemical found in the nucleus of cells and carries the "instructions" for the development and functioning of living
    ///     organisms.
    ///     If you want to know more: http://en.wikipedia.org/wiki/DNA
    ///     In DNA strings, symbols "A" and "T" are complements of each other, as "C" and "G". You have function with one side of the DNA (string, except for Haskell);
    ///     you need to get the other complementary side. DNA strand is never empty or there is no DNA at all (again, except for Haskell).
    ///     More similar exercise are found here: http://rosalind.info/problems/list-view/ (source)
    ///     Example: (input: output)
    ///     MakeComplement("ATTGC") => "TAACG"
    ///     MakeComplement("GTAT") => "CATA"
    /// </summary>
    public class DnaStrand
    {
        private static readonly Dictionary<char, char> DnaComplements = new Dictionary<char, char>
        {
            {'A', 'T'},
            {'T', 'A'},
            {'C', 'G'},
            {'G', 'C'}
        };

        public static string MakeComplement(string dna)
        {
            if (string.IsNullOrWhiteSpace(dna))
            {
                return null;
            }

            var chars = new List<char>();

            foreach (var c in dna)
            {
                if (DnaComplements.TryGetValue(c, out var complement))
                {
                    chars.Add(complement);
                    continue;
                }

                chars.Add(c);
            }

            return string.Join(string.Empty, chars);
        }
    }

    [TestFixture]
    public class DnaStrandTest
    {
        [TestCase("AAAA", "TTTT")]
        [TestCase("ATTGC", "TAACG")]
        [TestCase("GTAT", "CATA")]
        [TestCase("AAGG", "TTCC")]
        [TestCase("CGCG", "GCGC")]
        [TestCase("ATTGC", "TAACG")]
        [TestCase("GTATCGATCGATCGATCGATTATATTTTCGACGAGATTTAAATATATATATATACGAGAGAATACAGATAGACAGATTA",
            "CATAGCTAGCTAGCTAGCTAATATAAAAGCTGCTCTAAATTTATATATATATATGCTCTCTTATGTCTATCTGTCTAAT")]
        public void SampleTests(string dna, string expected)
        {
            Assert.AreEqual(expected, DnaStrand.MakeComplement(dna));
        }
    }
}