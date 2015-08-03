namespace Compost.Generics
{
    /// <summary>
    ///     A collection of methods for applying operators on generics.
    /// </summary>
    public interface IOperators
    {
        /// <summary>
        ///     Applies the + operator and returns the result.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Add<T>(T a, T b);

        /// <summary>
        ///     Applies the + operator and returns the result.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        object Add(object a, object b);

        /// <summary>
        ///     Applies the - operator and returns the result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        T Subtract<T>(T a, T b);

        /// <summary>
        ///     Applies the - operator and returns the result.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        object Subtract(object a, object b);

        /// <summary>
        ///     Applies the * operator and returns the result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        T Multiply<T>(T a, T b);

        /// <summary>
        ///     Applies the * operator and returns the result.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        object Multiply(object a, object b);

        /// <summary>
        ///     Applies the / operator and returns the result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        T Divide<T>(T a, T b);

        /// <summary>
        ///     Applies the / operator and returns the result.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        object Divide(object a, object b);

        /// <summary>
        ///     Applies the % operator and returns the result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        T Modulus<T>(T a, T b);

        /// <summary>
        ///     Applies the % operator and returns the result.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        object Modulus(object a, object b);
    }
}