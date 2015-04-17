using System;

namespace Compost.RandomUtils
{
    /// <summary>
    ///     A collection of methods for generating random numbers.
    /// </summary>
    public class RandomNumber : IRandomNumber
    {
        private readonly Random random;

        /// <summary>
        ///     Initializes a new instance of the <seealso cref="RandomNumber" /> class using a time dependent default seed value.
        /// </summary>
        public RandomNumber()
        {
            random = new Random();
        }

        /// <summary>
        ///     Initializes a new instance of the <seealso cref="RandomNumber" /> class using the specified
        ///     <paramref name="seed" /> value.
        /// </summary>
        /// <param name="seed"></param>
        public RandomNumber(int seed)
        {
            random = new Random(seed);
        }

        /// <summary>
        ///     Returns a random integer that is greater than or equal to zero.
        /// </summary>
        /// <returns></returns>
        public int Int()
        {
            return random.Next();
        }

        /// <summary>
        ///     Returns a random integer in the range of [0, <paramref name="exclusiveMax" />).
        ///     <paramref name="exclusiveMax" />.
        /// </summary>
        /// <param name="exclusiveMax">
        ///     The exclusive upper bound for the randomly generated integer. Must be greater than or equal
        ///     to zero.
        /// </param>
        /// <returns></returns>
        public int Int(int exclusiveMax)
        {
            if (exclusiveMax < 0)
                throw new ArgumentOutOfRangeException("exclusiveMax", "The exclusive maximum must be greater than or equal to zero.");

            return random.Next(exclusiveMax);
        }

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
        public int Int(int inclusiveMin, int exclusiveMax)
        {
            if (exclusiveMax < inclusiveMin)
                throw new ArgumentOutOfRangeException("exclusiveMax",
                    "The exclusive maximum must be greater than or equal to the inclusive minimum.");

            return random.Next(inclusiveMin, exclusiveMax);
        }

        /// <summary>
        ///     Returns a random double in the range of [0.0, 1.0).
        /// </summary>
        /// <returns></returns>
        public double Double()
        {
            return random.NextDouble();
        }

        /// <summary>
        ///     Returns a random double in the range of [0, <paramref name="exclusiveMax" />).
        ///     <paramref name="exclusiveMax" />.
        /// </summary>
        /// <param name="exclusiveMax">
        ///     The exclusive upper bound for the randomly generated double. Must be greater than or equal
        ///     to zero.
        /// </param>
        /// <returns></returns>
        public double Double(double exclusiveMax)
        {
            if (exclusiveMax < 0)
                throw new ArgumentOutOfRangeException("exclusiveMax", "The exclusive maximum must be greater than or equal to zero.");

            return Double(0, exclusiveMax);
        }

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
        public double Double(double inclusiveMin, double exclusiveMax)
        {
            if (exclusiveMax < inclusiveMin)
                throw new ArgumentOutOfRangeException("exclusiveMax",
                    "The exclusive maximum must be greater than or equal to the inclusive minimum.");

            return random.NextDouble()*(exclusiveMax - inclusiveMin) + inclusiveMin;
        }
    }
}