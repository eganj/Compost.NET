using Compost.Reflection;
using NUnit.Framework;

namespace Compost.Tests.Reflection
{
    public class ReflectorTests
    {
        [TestFixture]
        public class WithInstance
        {
            private const string FOO = "asdf";

            private static readonly TestClassAlpha TestClass = new TestClassAlpha();

            [Test]
            public void member_info_returns_info_for_fields_and_properties()
            {
                Assert.That(Reflector.MemberInfo(() => TestClass.SomeField).Name, Is.EqualTo("SomeField"));
                Assert.That(Reflector.MemberInfo(() => TestClass.SomeProperty).Name, Is.EqualTo("SomeProperty"));
            }

            [Test]
            public void member_info_throws_if_not_a_member()
            {
                AssertThat.ExceptionIsThrown<NotAMemberException>(
                    () => Reflector.MemberInfo(() => TestClass.ReturnSomething()));
            }

            [Test]
            public void member_info_throws_if_given_a_constant()
            {
                AssertThat.ExceptionIsThrown<NotAMemberException>(
                    () => Reflector.MemberInfo(() => FOO));
            }

            [Test]
            public void member_info_returns_info_for_unary_expressions()
            {
                int d = 0;

                Assert.That(Reflector.MemberInfo(() => -d).Name, Is.EqualTo("d"));
            }

            [Test]
            public void member_name_returns_name()
            {
                Assert.That(Reflector.MemberName(() => TestClass.SomeField), Is.EqualTo("SomeField"));
                Assert.That(Reflector.MemberName(() => TestClass.SomeProperty), Is.EqualTo("SomeProperty"));
            }

            [Test]
            public void method_info_returns_info_for_method()
            {
                Assert.That(Reflector.MethodInfo(() => TestClass.ReturnSomething()).Name, Is.EqualTo("ReturnSomething"));
                Assert.That(Reflector.MethodInfo(() => TestClass.DoSomething()).Name, Is.EqualTo("DoSomething"));
            }

            [Test]
            public void method_info_throws_if_not_a_method()
            {
                AssertThat.ExceptionIsThrown<NotAMethodException>(() => Reflector.MethodInfo(() => TestClass.SomeField));
            }

            [Test]
            public void method_name_returns_name()
            {
                Assert.That(Reflector.MethodName(() => TestClass.ReturnSomething()), Is.EqualTo("ReturnSomething"));
                Assert.That(Reflector.MethodName(() => TestClass.DoSomething()), Is.EqualTo("DoSomething"));
            }
        }

        [TestFixture]
        public class WithoutInstance
        {
            [Test]
            public void member_info_returns_info_for_fields_and_properties()
            {
                Assert.That(Reflector.MemberInfo((TestClassAlpha testClass) => testClass.SomeField).Name,
                    Is.EqualTo("SomeField"));
                Assert.That(Reflector.MemberInfo((TestClassAlpha testClass) => testClass.SomeProperty).Name,
                    Is.EqualTo("SomeProperty"));
            }

            [Test]
            public void member_info_throws_if_not_a_member()
            {
                AssertThat.ExceptionIsThrown<NotAMemberException>(
                    () => Reflector.MemberInfo((TestClassAlpha testClass) => testClass.ReturnSomething()));
            }

            [Test]
            public void member_name_returns_name()
            {
                Assert.That(Reflector.MemberName((TestClassAlpha testClass) => testClass.SomeField),
                    Is.EqualTo("SomeField"));
                Assert.That(Reflector.MemberName((TestClassAlpha testClass) => testClass.SomeProperty),
                    Is.EqualTo("SomeProperty"));
            }

            [Test]
            public void method_info_returns_info_for_method()
            {
                Assert.That(Reflector.MethodInfo((TestClassAlpha testClass) => testClass.ReturnSomething()).Name,
                    Is.EqualTo("ReturnSomething"));
                Assert.That(Reflector.MethodInfo((TestClassAlpha testClass) => testClass.DoSomething()).Name,
                    Is.EqualTo("DoSomething"));
            }

            [Test]
            public void method_info_throws_if_not_a_method()
            {
                AssertThat.ExceptionIsThrown<NotAMethodException>(
                    () => Reflector.MethodInfo((TestClassAlpha testClass) => testClass.SomeField));
            }

            [Test]
            public void method_name_returns_name()
            {
                Assert.That(Reflector.MethodName((TestClassAlpha testClass) => testClass.ReturnSomething()),
                    Is.EqualTo("ReturnSomething"));
                Assert.That(Reflector.MethodName((TestClassAlpha testClass) => testClass.DoSomething()),
                    Is.EqualTo("DoSomething"));
            }
        }

        private class TestClassAlpha
        {
            public int SomeField;
            public string SomeProperty { get; set; }
            public void DoSomething() {}

            public double ReturnSomething()
            {
                return -1;
            }
        }
    }
}