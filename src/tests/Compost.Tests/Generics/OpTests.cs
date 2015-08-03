using System;
using System.Reflection;
using Compost.Generics;
using Compost.Reflection;
using NUnit.Framework;

namespace Compost.Tests.Generics
{
    [TestFixture]
    public class OpTests
    {
        private static readonly Type[] NumericTypes =
        {
            typeof (byte), typeof (sbyte), typeof (short), typeof (ushort),
            typeof (int), typeof (uint), typeof (long), typeof (ulong),
            typeof (float), typeof (double), typeof (decimal)
        };

        private Operators _operators;

        [SetUp]
        public void Setup()
        {
            _operators = new Operators();
        }

        [Test]
        public void add_suite()
        {
            RunTestSuite(Reflector.MethodInfo(() => _operators.Add(null, null)), 2, 7, 9);
        }

        [TestCase(2, 7, 9)]
        [TestCase(2.0, 7.5, 9.5)]
        public void add_works_with_generics<T>(T a, T b, T expected)
        {
            Assert.That(_operators.Add(a, b), Is.EqualTo(expected));
        }

        [Test]
        public void add_supports_any_type_with_operator()
        {
            var a = new TestClass(1, 7);
            var b = new TestClass(17, 3);

            Assert.That(_operators.Add(a, b), Is.EqualTo(new TestClass(18, 10)));
            Assert.That(_operators.Add("Hello ", "World"), Is.EqualTo("Hello World"));
        }

        [Test]
        public void subtract_suite()
        {
            RunTestSuite(Reflector.MethodInfo(() => _operators.Subtract(null, null)), 9, 7, 2);
        }

        [TestCase(9, 7, 2)]
        [TestCase(9.0, 7.5, 1.5)]
        public void subtract_works_with_generics<T>(T a, T b, T expected)
        {
            Assert.That(_operators.Subtract(a, b), Is.EqualTo(expected));
        }

        [Test]
        public void subtract_supports_any_type_with_operator()
        {
            var a = new TestClass(31, 7);
            var b = new TestClass(17, 3);

            Assert.That(_operators.Subtract(a, b), Is.EqualTo(new TestClass(14, 4)));
        }

        [Test]
        public void multiply_suite()
        {
            RunTestSuite(Reflector.MethodInfo(() => _operators.Multiply(null, null)), 2, 7, 14);
        }

        [TestCase(3, 7, 21)]
        [TestCase(3.0, 6.0, 18.0)]
        public void multiply_works_with_generics<T>(T a, T b, T expected)
        {
            Assert.That(_operators.Multiply(a, b), Is.EqualTo(expected));
        }

        [Test]
        public void multiply_supports_any_type_with_operator()
        {
            var a = new TestClass(3, 7);
            var b = new TestClass(7, 5);

            Assert.That(_operators.Multiply(a, b), Is.EqualTo(new TestClass(21, 35)));
        }

        [Test]
        public void divide_suite()
        {
            RunTestSuite(Reflector.MethodInfo(() => _operators.Divide(null, null)), 14, 7, 2);
        }

        [TestCase(21, 7, 3)]
        [TestCase(18.0, 6.0, 3.0)]
        public void divide_works_with_generics<T>(T a, T b, T expected)
        {
            Assert.That(_operators.Divide(a, b), Is.EqualTo(expected));
        }

        [Test]
        public void divide_supports_any_type_with_operator()
        {
            var a = new TestClass(21, 25);
            var b = new TestClass(7, 5);

            Assert.That(_operators.Divide(a, b), Is.EqualTo(new TestClass(3, 5)));
        }

        [Test]
        public void modulus_suite()
        {
            RunTestSuite(Reflector.MethodInfo(() => _operators.Modulus(null, null)), 17, 10, 7);
        }

        [TestCase(21, 9, 3)]
        [TestCase(18.0, 7.0, 4.0)]
        public void modulus_works_with_generics<T>(T a, T b, T expected)
        {
            Assert.That(_operators.Modulus(a, b), Is.EqualTo(expected));
        }

        [Test]
        public void modulus_supports_any_type_with_operator()
        {
            var a = new TestClass(21, 25);
            var b = new TestClass(4, 9);

            Assert.That(_operators.Modulus(a, b), Is.EqualTo(new TestClass(1, 7)));
        }

        private void RunTestSuite(MethodInfo method, int a, int b, int expectedResult)
        {
            AssertThatExceptionIsThrownWhenGivenUnsupportedType(method);
            AssertThatAllSupportedTypesWorkAsExpected(method, a, b, expectedResult);
        }

        private void AssertThatExceptionIsThrownWhenGivenUnsupportedType(MethodInfo method)
        {
            var e = Assert.Throws<TargetInvocationException>(
                () => method.Invoke(_operators, new object[] {new Random(), new Random()}));
            Assert.That(e.InnerException, Is.TypeOf<NotSupportedException>());
            Console.WriteLine("Exception was thrown as expected. Exception message: " + e.InnerException.Message);
            Console.WriteLine(" ");
        }

        private void AssertThatAllSupportedTypesWorkAsExpected(MethodInfo method, int a, int b, int expectedResult)
        {
            foreach (var numericType in NumericTypes)
            {
                var actualResult = method.Invoke(_operators,
                    new[] {Convert.ChangeType(a, numericType), Convert.ChangeType(b, numericType)});

                Assert.That(actualResult, Is.EqualTo(Convert.ChangeType(expectedResult, numericType)),
                    "The method " + method.Name + " did not return the correct result for type " + numericType.FullName);
            }
        }

        private class TestClass : IEquatable<TestClass>
        {
            private readonly int _a;
            private readonly int _b;

            public TestClass(int a, int b)
            {
                _a = a;
                _b = b;
            }

            public bool Equals(TestClass other)
            {
                return _a.Equals(other._a) && _b.Equals(other._b);
            }

            public static TestClass operator +(TestClass a, TestClass b)
            {
                return new TestClass(a._a + b._a, a._b + b._b);
            }

            public static TestClass operator -(TestClass a, TestClass b)
            {
                return new TestClass(a._a - b._a, a._b - b._b);
            }

            public static TestClass operator *(TestClass a, TestClass b)
            {
                return new TestClass(a._a*b._a, a._b*b._b);
            }

            public static TestClass operator /(TestClass a, TestClass b)
            {
                return new TestClass(a._a/b._a, a._b/b._b);
            }

            public static TestClass operator %(TestClass a, TestClass b)
            {
                return new TestClass(a._a%b._a, a._b%b._b);
            }
        }
    }
}