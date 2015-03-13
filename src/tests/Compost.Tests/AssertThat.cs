using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Compost.Tests
{
    public static class AssertThat
    {
        public static void ExceptionIsThrown<T>(TestDelegate code) where T : Exception
        {
            var e = Assert.Throws<T>(code);
            Console.WriteLine("Exception was thrown as expected. Exception message: " + e.Message);
        }
    }
}
