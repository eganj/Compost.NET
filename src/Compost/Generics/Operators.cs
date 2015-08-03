using System;
using System.Collections.Generic;
using System.Reflection;

namespace Compost.Generics
{
    /// <summary>
    ///     A collection of methods for applying operators on generics.
    /// </summary>
    public class Operators : IOperators
    {
        private static readonly Dictionary<Type, Func<object, object, object>> AddMethods =
            new Dictionary<Type, Func<object, object, object>>
            {
                {typeof (byte), (a, b) => (byte) a + (byte) b},
                {typeof (sbyte), (a, b) => (sbyte) a + (sbyte) b},
                {typeof (short), (a, b) => (short) a + (short) b},
                {typeof (ushort), (a, b) => (ushort) a + (ushort) b},
                {typeof (int), (a, b) => (int) a + (int) b},
                {typeof (uint), (a, b) => (uint) a + (uint) b},
                {typeof (long), (a, b) => (long) a + (long) b},
                {typeof (ulong), (a, b) => (ulong) a + (ulong) b},
                {typeof (float), (a, b) => (float) a + (float) b},
                {typeof (double), (a, b) => (double) a + (double) b},
                {typeof (decimal), (a, b) => (decimal) a + (decimal) b},
                {typeof (string), (a, b) => (string) a + (string) b}
            };

        private static readonly Dictionary<Type, Func<object, object, object>> SubtractMethods =
            new Dictionary<Type, Func<object, object, object>>
            {
                {typeof (byte), (a, b) => (byte) a - (byte) b},
                {typeof (sbyte), (a, b) => (sbyte) a - (sbyte) b},
                {typeof (short), (a, b) => (short) a - (short) b},
                {typeof (ushort), (a, b) => (ushort) a - (ushort) b},
                {typeof (int), (a, b) => (int) a - (int) b},
                {typeof (uint), (a, b) => (uint) a - (uint) b},
                {typeof (long), (a, b) => (long) a - (long) b},
                {typeof (ulong), (a, b) => (ulong) a - (ulong) b},
                {typeof (float), (a, b) => (float) a - (float) b},
                {typeof (double), (a, b) => (double) a - (double) b},
                {typeof (decimal), (a, b) => (decimal) a - (decimal) b}
            };

        private static readonly Dictionary<Type, Func<object, object, object>> MultiplyMethods =
            new Dictionary<Type, Func<object, object, object>>
            {
                {typeof (byte), (a, b) => (byte) a*(byte) b},
                {typeof (sbyte), (a, b) => (sbyte) a*(sbyte) b},
                {typeof (short), (a, b) => (short) a*(short) b},
                {typeof (ushort), (a, b) => (ushort) a*(ushort) b},
                {typeof (int), (a, b) => (int) a*(int) b},
                {typeof (uint), (a, b) => (uint) a*(uint) b},
                {typeof (long), (a, b) => (long) a*(long) b},
                {typeof (ulong), (a, b) => (ulong) a*(ulong) b},
                {typeof (float), (a, b) => (float) a*(float) b},
                {typeof (double), (a, b) => (double) a*(double) b},
                {typeof (decimal), (a, b) => (decimal) a*(decimal) b}
            };

        private static readonly Dictionary<Type, Func<object, object, object>> DivideMethods =
            new Dictionary<Type, Func<object, object, object>>
            {
                {typeof (byte), (a, b) => (byte) a/(byte) b},
                {typeof (sbyte), (a, b) => (sbyte) a/(sbyte) b},
                {typeof (short), (a, b) => (short) a/(short) b},
                {typeof (ushort), (a, b) => (ushort) a/(ushort) b},
                {typeof (int), (a, b) => (int) a/(int) b},
                {typeof (uint), (a, b) => (uint) a/(uint) b},
                {typeof (long), (a, b) => (long) a/(long) b},
                {typeof (ulong), (a, b) => (ulong) a/(ulong) b},
                {typeof (float), (a, b) => (float) a/(float) b},
                {typeof (double), (a, b) => (double) a/(double) b},
                {typeof (decimal), (a, b) => (decimal) a/(decimal) b}
            };

        private static readonly Dictionary<Type, Func<object, object, object>> ModulusMethods =
            new Dictionary<Type, Func<object, object, object>>
            {
                {typeof (byte), (a, b) => (byte) a%(byte) b},
                {typeof (sbyte), (a, b) => (sbyte) a%(sbyte) b},
                {typeof (short), (a, b) => (short) a%(short) b},
                {typeof (ushort), (a, b) => (ushort) a%(ushort) b},
                {typeof (int), (a, b) => (int) a%(int) b},
                {typeof (uint), (a, b) => (uint) a%(uint) b},
                {typeof (long), (a, b) => (long) a%(long) b},
                {typeof (ulong), (a, b) => (ulong) a%(ulong) b},
                {typeof (float), (a, b) => (float) a%(float) b},
                {typeof (double), (a, b) => (double) a%(double) b},
                {typeof (decimal), (a, b) => (decimal) a%(decimal) b}
            };

        /// <summary>
        ///     Applies the + operator and returns the result.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Add<T>(T a, T b)
        {
            return (T) Add((object) a, b);
        }

        /// <summary>
        ///     Applies the + operator and returns the result.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public object Add(object a, object b)
        {
            return PerformComputation(a, b, AddMethods, "op_Addition");
        }

        /// <summary>
        ///     Applies the - operator and returns the result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public T Subtract<T>(T a, T b)
        {
            return (T) Subtract((object) a, b);
        }

        /// <summary>
        ///     Applies the - operator and returns the result.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public object Subtract(object a, object b)
        {
            return PerformComputation(a, b, SubtractMethods, "op_Subtraction");
        }

        /// <summary>
        ///     Applies the * operator and returns the result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public T Multiply<T>(T a, T b)
        {
            return (T) Multiply((object) a, b);
        }

        /// <summary>
        ///     Applies the * operator and returns the result.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public object Multiply(object a, object b)
        {
            return PerformComputation(a, b, MultiplyMethods, "op_Multiply");
        }

        /// <summary>
        ///     Applies the / operator and returns the result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public T Divide<T>(T a, T b)
        {
            return (T) Divide((object) a, b);
        }

        /// <summary>
        ///     Applies the / operator and returns the result.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public object Divide(object a, object b)
        {
            return PerformComputation(a, b, DivideMethods, "op_Division");
        }

        /// <summary>
        ///     Applies the % operator and returns the result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public T Modulus<T>(T a, T b)
        {
            return (T) Modulus((object) a, b);
        }

        /// <summary>
        ///     Applies the % operator and returns the result.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public object Modulus(object a, object b)
        {
            return PerformComputation(a, b, ModulusMethods, "op_Modulus");
        }

        private static object PerformComputation(object a, object b,
            IReadOnlyDictionary<Type, Func<object, object, object>> methodsDictionary, string operatorMethodName = "")
        {
            var type = a.GetType();
            if (methodsDictionary.ContainsKey(type))
                return Convert.ChangeType(methodsDictionary[type](a, b), type);

            var operatorMethod = type.GetMethod(operatorMethodName, BindingFlags.Public | BindingFlags.Static);
            if (operatorMethod != null)
                return operatorMethod.Invoke(null, new[] {a, b});

            throw new NotSupportedException("The given type is not supported: " + type.FullName);
        }
    }
}