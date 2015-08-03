using System;
using NUnit.Framework;

namespace Compost.Tests
{
    public static class AssertThat
    {
        public static T ExceptionIsThrown<T>(TestDelegate code) where T : Exception
        {
            var e = Assert.Throws<T>(code);
            Console.WriteLine("Exception was thrown as expected. Exception message: " + e.Message);
            Console.WriteLine(" ");
            return e;
        }
    }
}