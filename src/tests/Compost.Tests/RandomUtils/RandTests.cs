using System;
using Compost.RandomUtils;
using NUnit.Framework;

namespace Compost.Tests.RandomUtils
{
    [TestFixture]
    public class RandTests
    {
        [Test]
        public void exception_is_thrown_if_string_is_null()
        {
            AssertThat.ExceptionIsThrown<NullReferenceException>(() => { var v = Rand.String; });
        }

        [Test]
        public void exception_is_thrown_if_file_is_null()
        {
            AssertThat.ExceptionIsThrown<NullReferenceException>(() => { var v = Rand.Number; });
        }

        [Test]
        public void no_exception_is_thrown_if_assigned()
        {
            Rand.String = new RandomString();
            Rand.Number = new RandomNumber();

            Assert.IsNotNull(Rand.String);
            Assert.IsNotNull(Rand.Number);
        }
    }
}