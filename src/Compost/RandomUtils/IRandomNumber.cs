namespace Compost.RandomUtils
{
    /// <summary>
    ///     A collection of methods for generating random numbers.
    /// </summary>
    public interface IRandomNumber
    {
        /// <summary>
        ///     Returns a random integer that is greater than or equal to zero.
        /// </summary>
        /// <returns></returns>
        int Int();

        /// <summary>
        ///     Returns a random integer in the range of [0, <paramref name="exclusiveMax" />).
        ///     <paramref name="exclusiveMax" />.
        /// </summary>
        /// <param name="exclusiveMax">
        ///     The exclusive upper bound for the randomly generated integer. Must be greater than or equal
        ///     to zero.
        /// </param>
        /// <returns></returns>
        int Int(int exclusiveMax);

        /// <summary>
        ///     Returns a random integer in the range of [<paramref name="inclusiveMin" />, <paramref name="exclusiveMax" />).
        /// </summary>
        /// <param name="inclusiveMin">
        ///     The inclusive lower bound for the randomly generated integer. Must be less than or equal to
        ///     the <paramref name="exclusiveMax" />.
        /// </param>
        /// <param name="exclusiveMax">
        ///     The exclusive upper bound for the randomly generated integer. Must be greater than or equal
        ///     to the <paramref name="inclusiveMin" />.
        /// </param>
        /// <returns></returns>
        int Int(int inclusiveMin, int exclusiveMax);

        /// <summary>
        ///     Returns a random double in the range of [0.0, 1.0).
        /// </summary>
        /// <returns></returns>
        double Double();

        /// <summary>
        ///     Returns a random double in the range of [0, <paramref name="exclusiveMax" />).
        ///     <paramref name="exclusiveMax" />.
        /// </summary>
        /// <param name="exclusiveMax">
        ///     The exclusive upper bound for the randomly generated double. Must be greater than or equal
        ///     to zero.
        /// </param>
        /// <returns></returns>
        double Double(double exclusiveMax);

        /// <summary>
        ///     Returns a random double in the range of [<paramref name="inclusiveMin" />, <paramref name="exclusiveMax" />).
        /// </summary>
        /// <param name="inclusiveMin">
        ///     The inclusive lower bound for the randomly generated double. Must be less than or equal to
        ///     the <paramref name="exclusiveMax" />.
        /// </param>
        /// <param name="exclusiveMax">
        ///     The exclusive upper bound for the randomly generated double. Must be greater than or equal
        ///     to the <paramref name="inclusiveMin" />.
        /// </param>
        /// <returns></returns>
        double Double(double inclusiveMin, double exclusiveMax);
    }
}