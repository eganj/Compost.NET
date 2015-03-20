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

        private static readonly int[] ValidCollection = {0, 1, 2, 3};
        private static readonly int[] NullCollection = null;
        private static readonly int[] EmptyCollection = {};
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
            AssertThat.ExceptionIsThrown<ArgumentNullException>(
                () => Argument.CannotBeNullOrEmpty(NullString, Reflector.MemberName(() => NullString)));
            AssertThat.ExceptionIsThrown<ArgumentException>(
                () => Argument.CannotBeNullOrEmpty(EmptyString, Reflector.MemberName(() => EmptyString)));
        }

        [Test]
        public void cannot_be_null_or_whitespace_does_not_throw_if_input_is_valid()
        {
            Argument.CannotBeNullOrWhiteSpace(ValidString);

            Assert.Pass("Exception was not thrown.");
        }

        [Test]
        public void cannot_be_null_or_whitespace_throws_if_argument_is_null_or_whitespace()
        {
            AssertThat.ExceptionIsThrown<ArgumentNullException>(() => Argument.CannotBeNullOrWhiteSpace(NullString));
            AssertThat.ExceptionIsThrown<ArgumentException>(() => Argument.CannotBeNullOrWhiteSpace(EmptyString));
            AssertThat.ExceptionIsThrown<ArgumentException>(() => Argument.CannotBeNullOrWhiteSpace(WhitespaceString));
        }

        [Test]
        public void cannot_be_null_or_whitespace_does_not_throw_if_input_is_valid_2()
        {
            Argument.CannotBeNullOrWhiteSpace(ValidString, Reflector.MemberName(() => ValidString));

            Assert.Pass("Exception was not thrown.");
        }

        [Test]
        public void cannot_be_null_or_whitespace_throws_if_argument_is_null_or_whitespace_2()
        {
            AssertThat.ExceptionIsThrown<ArgumentNullException>(
                () => Argument.CannotBeNullOrWhiteSpace(NullString, Reflector.MemberName(() => NullString)));
            AssertThat.ExceptionIsThrown<ArgumentException>(
                () => Argument.CannotBeNullOrWhiteSpace(EmptyString, Reflector.MemberName(() => EmptyString)));
            AssertThat.ExceptionIsThrown<ArgumentException>(
                () => Argument.CannotBeNullOrWhiteSpace(WhitespaceString, Reflector.MemberName(() => WhitespaceString)));
        }

        [Test]
        public void cannot_be_null_or_empty_does_not_throw_for_valid_collections()
        {
            Argument.CannotBeNullOrEmpty(ValidCollection);

            Assert.Pass("Exception was not thrown.");
        }

        [Test]
        public void cannot_be_null_or_empty_throws_for_null_or_empty_collections()
        {
            AssertThat.ExceptionIsThrown<ArgumentNullException>(() => Argument.CannotBeNullOrEmpty(NullCollection));
            AssertThat.ExceptionIsThrown<ArgumentException>(() => Argument.CannotBeNullOrEmpty(EmptyCollection));
        }

        [Test]
        public void cannot_be_null_or_empty_does_not_throw_for_valid_collections_2()
        {
            Argument.CannotBeNullOrEmpty(ValidCollection, Reflector.MemberName(() => ValidCollection));

            Assert.Pass("Exception was not thrown.");
        }

        [Test]
        public void cannot_be_null_or_empty_throws_for_null_or_empty_collections_2()
        {
            AssertThat.ExceptionIsThrown<ArgumentNullException>(
                () => Argument.CannotBeNullOrEmpty(NullCollection, Reflector.MemberName(() => NullCollection)));
            AssertThat.ExceptionIsThrown<ArgumentException>(
                () => Argument.CannotBeNullOrEmpty(EmptyCollection, Reflector.MemberName(() => EmptyCollection)));
        }

        [Test]
        public void meets_criteria_does_not_throw_if_expression_returns_true()
        {
            Argument.MeetsCriteria(() => true);
            Argument.MeetsCriteria(() => 8 > 2);

            Assert.Pass("Exception was not thrown.");
        }

        [Test]
        public void meets_criteria_throws_if_expression_returns_false()
        {
            AssertThat.ExceptionIsThrown<ArgumentException>(() => Argument.MeetsCriteria(() => false));
            AssertThat.ExceptionIsThrown<ArgumentException>(() => Argument.MeetsCriteria(() => 2 > 9));
            AssertThat.ExceptionIsThrown<ArgumentException>(() => Argument.MeetsCriteria(() => NullCollection != null));
        }

        [Test]
        public void meets_criteria_does_not_throw_if_expression_returns_true_2()
        {
            Argument.MeetsCriteria(() => ValidCollection.Length > 0, Reflector.MemberName(() => ValidCollection));

            Assert.Pass("Exception was not thrown.");
        }

        [Test]
        public void meets_criteria_throws_if_expression_returns_false_2()
        {
            AssertThat.ExceptionIsThrown<ArgumentException>(
                () => Argument.MeetsCriteria(() => NullCollection != null, Reflector.MemberName(() => NullCollection)));
        }

        [Test]
        public void meets_criteria_does_not_throw_if_expression_returns_true_3()
        {
            Argument.MeetsCriteria(ValidCollection.Length > 0, Reflector.MemberName(() => ValidCollection));

            Assert.Pass("Exception was not thrown.");
        }

        [Test]
        public void meets_criteria_throws_if_expression_returns_false_3()
        {
            AssertThat.ExceptionIsThrown<ArgumentException>(
                () => Argument.MeetsCriteria(NullCollection != null, Reflector.MemberName(() => NullCollection)));
        }

        [Test]
        public void meets_criteria_does_not_throw_if_expression_returns_true_4()
        {
            Argument.MeetsCriteria(ValidCollection.Length > 0);

            Assert.Pass("Exception was not thrown.");
        }

        [Test]
        public void meets_criteria_throws_if_expression_returns_false_4()
        {
            AssertThat.ExceptionIsThrown<ArgumentException>(() => Argument.MeetsCriteria(NullCollection != null));
        }
    }
}