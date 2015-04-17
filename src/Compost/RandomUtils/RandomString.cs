using System;
using System.Linq;

namespace Compost.RandomUtils
{
    /// <summary>
    ///     A collection of methods for generating random strings.
    /// </summary>
    public class RandomString : IRandomString
    {
        private static readonly char[] AlphaUpperChars = Enumerable.Range(65, 26).Select(i => (char) i).ToArray();
        private static readonly char[] AlphaLowerChars = Enumerable.Range(97, 26).Select(i => (char) i).ToArray();
        private static readonly char[] NumericChars = Enumerable.Range(48, 10).Select(i => (char) i).ToArray();

        private static readonly char[] AlphaChars = AlphaUpperChars.Concat(AlphaLowerChars).ToArray();
        private static readonly char[] AlphaNumericChars = NumericChars.Concat(AlphaChars).ToArray();

        private readonly Random random;

        /// <summary>
        ///     Initializes a new instance of the <seealso cref="RandomString" /> class using a time dependent default seed value.
        /// </summary>
        public RandomString()
        {
            random = new Random();
        }

        /// <summary>
        ///     Initializes a new instance of the <seealso cref="RandomString" /> class using the specified
        ///     <paramref name="seed" /> value.
        /// </summary>
        /// <param name="seed"></param>
        public RandomString(int seed)
        {
            random = new Random(seed);
        }

        /// <summary>
        ///     Returns a random alphanumeric string of the specified <paramref name="length" />.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public string AlphaNumeric(int length)
        {
            return CreateRandomString(AlphaNumericChars, length);
        }

        private string CreateRandomString(char[] availableChars, int length)
        {
            var chars = new char[length];
            for (var i = 0; i < length; i++)
                chars[i] = availableChars[random.Next(availableChars.Length)];

            return new string(chars);
        }
    }
}