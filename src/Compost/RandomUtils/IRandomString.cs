namespace Compost.RandomUtils
{
    /// <summary>
    ///     A collection of methods for generating random strings.
    /// </summary>
    public interface IRandomString
    {
        /// <summary>
        ///     Returns a random alphanumeric string of the specified <paramref name="length" />.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        string AlphaNumeric(int length);
    }
}