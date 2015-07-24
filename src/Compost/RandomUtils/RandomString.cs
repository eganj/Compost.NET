using System;
using System.Collections.Generic;
using System.Linq;
using Compost.Contracts;

namespace Compost.RandomUtils
{
    /// <summary>
    ///     A collection of methods for generating random strings.
    /// </summary>
    public class RandomString : IRandomString
    {
        private static readonly char[] AlphaUpperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private static readonly char[] AlphaLowerChars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        private static readonly char[] NumericChars = "0123456789".ToCharArray();

        private static readonly char[] AlphaChars = AlphaUpperChars.Concat(AlphaLowerChars).ToArray();
        private static readonly char[] AlphaNumericChars = NumericChars.Concat(AlphaChars).ToArray();

        private static readonly char[] AsciiChars = Enumerable.Range(33, 94).Select(i => (char) i).ToArray();

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
        ///     Returns a random numeric string.
        /// </summary>
        /// <returns></returns>
        public string Numeric()
        {
            return FromChars(NumericChars);
        }

        /// <summary>
        ///     Returns a random numeric string of the specified <paramref name="length" />.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public string Numeric(int length)
        {
            return FromChars(NumericChars, length);
        }

        /// <summary>
        ///     Returns a random lowercase alpha string.
        /// </summary>
        /// <returns></returns>
        public string LowercaseAlpha()
        {
            return FromChars(AlphaLowerChars);
        }

        /// <summary>
        ///     Returns a random lowercase alpha string of the specified <paramref name="length" />.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public string LowercaseAlpha(int length)
        {
            return FromChars(AlphaLowerChars, length);
        }

        /// <summary>
        ///     Returns a random uppercase alpha string.
        /// </summary>
        /// <returns></returns>
        public string UppercaseAlpha()
        {
            return FromChars(AlphaUpperChars);
        }

        /// <summary>
        ///     Returns a random uppercase alpha string of the specified <paramref name="length" />.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public string UppercaseAlpha(int length)
        {
            return FromChars(AlphaUpperChars, length);
        }

        /// <summary>
        ///     Returns a random alpha string.
        /// </summary>
        /// <returns></returns>
        public string Alpha()
        {
            return FromChars(AlphaChars);
        }

        /// <summary>
        ///     Returns a random alpha string of the specified <paramref name="length" />.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public string Alpha(int length)
        {
            return FromChars(AlphaChars, length);
        }

        /// <summary>
        ///     Returns a random alphanumeric string.
        /// </summary>
        /// <returns></returns>
        public string AlphaNumeric()
        {
            return FromChars(AlphaNumericChars);
        }

        /// <summary>
        ///     Returns a random alphanumeric string of the specified <paramref name="length" />.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public string AlphaNumeric(int length)
        {
            return FromChars(AlphaNumericChars, length);
        }

        /// <summary>
        ///     Returns a random string of visible ascii characters (33 - 126).
        /// </summary>
        /// <returns></returns>
        public string Ascii()
        {
            return FromChars(AsciiChars);
        }

        /// <summary>
        ///     Returns a random string of visible ascii characters (33 - 126) of the specified <paramref name="length" />.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public string Ascii(int length)
        {
            return FromChars(AsciiChars, length);
        }

        /// <summary>
        ///     Returns a random string created by randomly selecting from the given <paramref name="characters" />.
        /// </summary>
        /// <returns></returns>
        public string FromChars(IList<char> characters)
        {
            return FromChars(characters, random.Next(32, 65));
        }

        /// <summary>
        ///     Returns a random string created by randomly selecting from the given <paramref name="characters" /> of the
        ///     specified <paramref name="length" />.
        /// </summary>
        /// <param name="characters"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public string FromChars(IList<char> characters, int length)
        {
            Argument.CannotBeNullOrEmpty(characters, "characters");

            var chars = new char[length];
            for (var i = 0; i < length; i++)
                chars[i] = characters[random.Next(characters.Count)];

            return new string(chars);
        }
    }
}