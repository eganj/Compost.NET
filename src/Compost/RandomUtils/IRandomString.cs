using System.Collections.Generic;

namespace Compost.RandomUtils
{
    /// <summary>
    ///     A collection of methods for generating random strings.
    /// </summary>
    public interface IRandomString
    {
        /// <summary>
        ///     Returns a random numeric string.
        /// </summary>
        /// <returns></returns>
        string Numeric();

        /// <summary>
        ///     Returns a random numeric string of the specified <paramref name="length" />.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        string Numeric(int length);

        /// <summary>
        ///     Returns a random lowercase alpha string.
        /// </summary>
        /// <returns></returns>
        string LowercaseAlpha();

        /// <summary>
        ///     Returns a random lowercase alpha string of the specified <paramref name="length" />.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        string LowercaseAlpha(int length);

        /// <summary>
        ///     Returns a random uppercase alpha string.
        /// </summary>
        /// <returns></returns>
        string UppercaseAlpha();

        /// <summary>
        ///     Returns a random uppercase alpha string of the specified <paramref name="length" />.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        string UppercaseAlpha(int length);

        /// <summary>
        ///     Returns a random alpha string.
        /// </summary>
        /// <returns></returns>
        string Alpha();

        /// <summary>
        ///     Returns a random alpha string of the specified <paramref name="length" />.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        string Alpha(int length);

        /// <summary>
        ///     Returns a random alphanumeric string.
        /// </summary>
        /// <returns></returns>
        string AlphaNumeric();

        /// <summary>
        ///     Returns a random alphanumeric string of the specified <paramref name="length" />.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        string AlphaNumeric(int length);

        /// <summary>
        ///     Returns a random string of visible ascii characters (33 - 126).
        /// </summary>
        /// <returns></returns>
        string Ascii();

        /// <summary>
        ///     Returns a random string of visible ascii characters (33 - 126) of the specified <paramref name="length" />.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        string Ascii(int length);

        /// <summary>
        ///     Returns a random string created by randomly selecting from the given <paramref name="characters" />.
        /// </summary>
        /// <returns></returns>
        string FromChars(IList<char> characters);

        /// <summary>
        ///     Returns a random string created by randomly selecting from the given <paramref name="characters" /> of the
        ///     specified <paramref name="length" />.
        /// </summary>
        /// <param name="characters"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        string FromChars(IList<char> characters, int length);
    }
}