using System;

namespace Compost.Contracts
{
    /// <summary>
    ///     Thrown if an ensure statement fails.
    /// </summary>
    public class EnsureException : Exception
    {
#pragma warning disable 1591
        public EnsureException() {}
        public EnsureException(string message) : base(message) {}
        public EnsureException(string message, Exception innerException) : base(message, innerException) {}
#pragma warning restore 1591
    }
}