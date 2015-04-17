using System;
using System.Linq.Expressions;
using Compost.Reflection;

namespace Compost.RandomUtils
{
    /// <summary>
    ///     A collection of statically available implementations of classes that generate random values.
    /// </summary>
    public static class Rand
    {
        private static IRandomString stringField;
        private static IRandomNumber number;

        /// <summary>
        ///     A statically available implementation of <seealso cref="IRandomString" />.
        /// </summary>
        public static IRandomString String
        {
            get { return stringField ?? Throw(() => String); }
            set { stringField = value; }
        }

        /// <summary>
        ///     A statically available implementation of <seealso cref="IRandomNumber" />.
        /// </summary>
        public static IRandomNumber Number
        {
            get { return number ?? Throw(() => Number); }
            set { number = value; }
        }

        private static T Throw<T>(Expression<Func<T>> expression)
        {
            var propertyInfo = Reflector.PropertyInfo(expression);
            throw new NullReferenceException("You must assign an implementation of " + propertyInfo.PropertyType.FullName + " to " +
                                             typeof (Rand).FullName + "." + propertyInfo.Name);
        }
    }
}