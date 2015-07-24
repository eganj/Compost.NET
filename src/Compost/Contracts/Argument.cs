using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Compost.Contracts
{
    /// <summary>
    ///     An easliy testable class for ensuring that arguments are valid.
    /// </summary>
    public static class Argument
    {
        /// <summary>
        ///     Ensures that the argument is not null. If the argument is null, an <seealso cref="ArgumentNullException" /> is
        ///     thrown.
        /// </summary>
        /// <param name="arg"></param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void CannotBeNull<T>(T arg) where T : class
        {
            if (arg == null)
                throw new ArgumentNullException();
        }

        /// <summary>
        ///     Ensures that the argument is not null. If the argument is null, an <seealso cref="ArgumentNullException" /> is
        ///     thrown.
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="argumentName"></param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void CannotBeNull<T>(T arg, string argumentName) where T : class
        {
            if (arg == null)
                throw new ArgumentNullException(argumentName);
        }

        /// <summary>
        ///     Ensures that the argument is not null or empty. If the argument is null, an
        ///     <seealso cref="ArgumentNullException" /> is thrown. If the argument is empty, an
        ///     <seealso cref="ArgumentException" /> is thrown.
        /// </summary>
        /// <param name="arg"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void CannotBeNullOrEmpty(string arg)
        {
            CannotBeNull(arg);
            if (arg == string.Empty)
                throw new ArgumentException("Argument cannot be empty!");
        }

        /// <summary>
        ///     Ensures that the argument is not null or empty. If the argument is null, an
        ///     <seealso cref="ArgumentNullException" /> is thrown. If the argument is empty, an
        ///     <seealso cref="ArgumentException" /> is thrown.
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="argumentName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void CannotBeNullOrEmpty(string arg, string argumentName)
        {
            CannotBeNull(arg, argumentName);
            if (arg == string.Empty)
                throw new ArgumentException("Argument cannot be empty!", argumentName);
        }

        /// <summary>
        ///     Ensures that the argument is not null or white space. If the argument is null, an
        ///     <seealso cref="ArgumentNullException" /> is thrown. If the argument is white space, an
        ///     <seealso cref="ArgumentException" /> is thrown.
        /// </summary>
        /// <param name="arg"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void CannotBeNullOrWhiteSpace(string arg)
        {
            CannotBeNull(arg);
            if (string.IsNullOrWhiteSpace(arg))
                throw new ArgumentException("Argument cannot be empty or white space!");
        }

        /// <summary>
        ///     Ensures that the argument is not null or white space. If the argument is null, an
        ///     <seealso cref="ArgumentNullException" /> is thrown. If the argument is white space, an
        ///     <seealso cref="ArgumentException" /> is thrown.
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="argumentName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void CannotBeNullOrWhiteSpace(string arg, string argumentName)
        {
            CannotBeNull(arg, argumentName);
            if (string.IsNullOrWhiteSpace(arg))
                throw new ArgumentException("Argument cannot be empty or white space!", argumentName);
        }

        /// <summary>
        ///     Ensures that the argument is not null or empty. If the argument is null, an
        ///     <seealso cref="ArgumentNullException" /> is thrown. If the argument is empty, an
        ///     <seealso cref="ArgumentException" /> is thrown.
        /// </summary>
        /// <param name="arg"></param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void CannotBeNullOrEmpty<T>(ICollection<T> arg)
        {
            CannotBeNull(arg);
            if (arg.Count == 0)
                throw new ArgumentException("Argument cannot be empty!");
        }

        /// <summary>
        ///     Ensures that the argument is not null or empty. If the argument is null, an
        ///     <seealso cref="ArgumentNullException" /> is thrown. If the argument is empty, an
        ///     <seealso cref="ArgumentException" /> is thrown.
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="argumentName"></param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void CannotBeNullOrEmpty<T>(ICollection<T> arg, string argumentName)
        {
            CannotBeNull(arg, argumentName);
            if (arg.Count == 0)
                throw new ArgumentException("Argument cannot be empty!", argumentName);
        }

        /// <summary>
        ///     Ensures that the argument meets the specified criteria. If the argument does not meet the criteria, an
        ///     <seealso cref="ArgumentException" /> is thrown.
        /// </summary>
        /// <param name="argExpression"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void MeetsCriteria(Expression<Func<bool>> argExpression)
        {
            var f = argExpression.Compile();
            if (!f())
                throw new ArgumentException("Argument did not meet criteria: " + argExpression);
        }

        /// <summary>
        ///     Ensures that the argument meets the specified criteria. If the argument does not meet the criteria, an
        ///     <seealso cref="ArgumentException" /> is thrown.
        /// </summary>
        /// <param name="argExpression"></param>
        /// <param name="argumentName"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void MeetsCriteria(Expression<Func<bool>> argExpression, string argumentName)
        {
            var f = argExpression.Compile();
            if (!f())
                throw new ArgumentException("Argument did not meet criteria: " + argExpression, argumentName);
        }

        /// <summary>
        ///     Ensures that the argument meets the specified criteria. If the argument does not meet the criteria, an
        ///     <seealso cref="ArgumentException" /> is thrown.
        /// </summary>
        /// <param name="criteria"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void MeetsCriteria(bool criteria)
        {
            if (!criteria)
                throw new ArgumentException("Argument did not meet criteria.");
        }

        /// <summary>
        ///     Ensures that the argument meets the specified criteria. If the argument does not meet the criteria, an
        ///     <seealso cref="ArgumentException" /> is thrown.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="argumentName"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void MeetsCriteria(bool criteria, string argumentName)
        {
            if (!criteria)
                throw new ArgumentException("Argument did not meet criteria.", argumentName);
        }
    }
}