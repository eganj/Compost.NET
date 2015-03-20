using System;
using System.Linq.Expressions;

namespace Compost.Contracts
{
    /// <summary>
    ///     An easliy testable class for ensuring that states are correct.
    /// </summary>
    public static class Ensure
    {
        /// <summary>
        ///     Ensures that the condition is true. Throws an <seealso cref="EnsureException" /> if the condition is false.
        /// </summary>
        /// <param name="condition"></param>
        /// <exception cref="EnsureException"></exception>
        public static void That(bool condition)
        {
            if (!condition)
                throw new EnsureException();
        }

        /// <summary>
        ///     Ensures that the condition is true. Throws an <seealso cref="EnsureException" /> if the condition is false.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        public static void That(bool condition, string message)
        {
            if (!condition)
                throw new EnsureException(message);
        }

        /// <summary>
        ///     Ensures that the condition is true. Throws an <seealso cref="EnsureException" /> if the condition is false.
        /// </summary>
        /// <param name="condition"></param>
        /// <exception cref="EnsureException"></exception>
        public static void That(Expression<Func<bool>> condition)
        {
            if (!condition.Compile()())
                throw new EnsureException(condition.ToString());
        }

        /// <summary>
        ///     Ensures that the condition is true. Throws an <seealso cref="EnsureException" /> if the condition is false.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        public static void That(Expression<Func<bool>> condition, string message)
        {
            if (!condition.Compile()())
                throw new EnsureException(message + " " + condition);
        }
    }
}