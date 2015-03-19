using System;
using Compost.Contracts;
using Compost.Reflection;
using NUnit.Framework;

namespace Compost.Tests.Contracts
{
    [TestFixture]
    public class ArgumentTests
    {
        // ReSharper disable ConvertToConstant.Local
        private static readonly string NullString = null;
        private static readonly string ValidString = "asdf";
        private static readonly string WhitespaceString = " ";
        private static readonly string EmptyString = "";
        // ReSharper restore ConvertToConstant.Local

        [Test]
        public void cannot_be_null_does_not_throw_if_arg_is_not_null()
        {
            Argument.CannotBeNull(ValidString);

            Assert.Pass("Exception was not thrown.");
        }

        [Test]
        public void cannot_be_null_does_not_throw_if_arg_is_not_null_2()
        {
            Argument.CannotBeNull(ValidString, Reflector.MemberName(() => ValidString));

            Assert.Pass("Exception was not thrown.");
        }

        [Test]
        public void cannot_be_null_throws_if_argument_is_null()
        {
            AssertThat.ExceptionIsThrown<ArgumentNullException>(() => Argument.CannotBeNull(NullString));
        }

        [Test]
        public void cannot_be_null_throws_if_argument_is_null_2()
        {
            AssertThat.ExceptionIsThrown<ArgumentNullException>(
                () => Argument.CannotBeNull(NullString, Reflector.MemberName(() => NullString)));

        }

        [Test]
        public void cannot_be_null_or_empty_does_not_throw_if_string_is_not_null_or_empty()
        {
            Argument.CannotBeNullOrEmpty(ValidString);
            Argument.CannotBeNullOrEmpty(WhitespaceString);

            Assert.Pass("Exception was not thrown.");
        }

        [Test]
        public void cannot_be_null_or_empty_throws_if_argument_is_null_or_empty()
        {
            AssertThat.ExceptionIsThrown<ArgumentNullException>(() => Argument.CannotBeNullOrEmpty(null));
            AssertThat.ExceptionIsThrown<ArgumentException>(() => Argument.CannotBeNullOrEmpty(""));
        }

        [Test]
        public void cannot_be_null_or_empty_does_not_throw_if_string_is_not_null_or_empty_2()
        {
            Argument.CannotBeNullOrEmpty(ValidString, Reflector.MemberName(() => ValidString));
            Argument.CannotBeNullOrEmpty(WhitespaceString, Reflector.MemberName(() => WhitespaceString));

            Assert.Pass("Exception was not thrown.");
        }

        [Test]
        public void cannot_be_null_or_empty_throws_if_argument_is_null_or_empty_2()
        {
            AssertThat.ExceptionIsThrown<ArgumentNullException>(() => Argument.CannotBeNullOrEmpty(NullString, Reflector.MemberName(() => NullString)));
            AssertThat.ExceptionIsThrown<ArgumentException>(() => Argument.CannotBeNullOrEmpty(EmptyString, Reflector.MemberName(() => EmptyString)));
        }

    }
}