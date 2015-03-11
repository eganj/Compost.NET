using Compost.Reflection;
using NUnit.Framework;

namespace Compost.Tests.Reflection
{
    [TestFixture]
    public class ReflectorTests
    {
        [Test]
        public void class_name_returns_name_of_class()
        {
            Assert.AreEqual("TestClassAlpha", Reflector.ClassName<TestClassAlpha>());
        }

        private class TestClassAlpha {}
    }
}