using System;
using Compost.RandomUtils;
using NUnit.Framework;

namespace Compost.Tests.RandomUtils
{
    [TestFixture]
    public class RandomStringTests
    {
        private RandomString randomString;

        [SetUp]
        public void Setup()
        {
            randomString = new RandomString();
        }

        [Test]
        public void numeric_should_return_random_string_containing_only_numeric_characters()
        {
            var s = randomString.Numeric();

            Assert.That(s, Is.StringMatching(@"^[0-9]+$"));
        }

        [Test]
        public void numeric_should_return_random_string_containing_only_numeric_characters_of_specified_length()
        {
            var s = randomString.Numeric(12345);

            Assert.That(s, Is.StringMatching(@"^[0-9]+$"));
            Assert.That(s.Length, Is.EqualTo(12345));
        }

        [Test]
        public void lowercase_alpha_should_return_random_string_containing_only_lowercase_alpha_characters()
        {
            var s = randomString.LowercaseAlpha();

            Assert.That(s, Is.StringMatching(@"^[a-z]+$"));
        }

        [Test]
        public void lowercase_alpha_should_return_random_string_containing_only_lowercase_alpha_characters_of_specified_length()
        {
            var s = randomString.LowercaseAlpha(12345);

            Assert.That(s, Is.StringMatching(@"^[a-z]+$"));
            Assert.That(s.Length, Is.EqualTo(12345));
        }

        [Test]
        public void uppercase_alpha_should_return_random_string_containing_only_uppercase_alpha_characters()
        {
            var s = randomString.UppercaseAlpha();

            Assert.That(s, Is.StringMatching(@"^[A-Z]+$"));
        }

        [Test]
        public void uppercase_alpha_should_return_random_string_containing_only_uppercase_alpha_characters_of_specified_length()
        {
            var s = randomString.UppercaseAlpha(12345);

            Assert.That(s, Is.StringMatching(@"^[A-Z]+$"));
            Assert.That(s.Length, Is.EqualTo(12345));
        }

        [Test]
        public void alpha_should_return_random_string_containing_only_alpha_characters()
        {
            var s = randomString.Alpha();

            Assert.That(s, Is.StringMatching(@"^[a-zA-Z]+$"));
        }

        [Test]
        public void alpha_should_return_random_string_containing_only_alpha_characters_of_specified_length()
        {
            var s = randomString.Alpha(12345);

            Assert.That(s, Is.StringMatching(@"^[a-zA-Z]+$"));
            Assert.That(s.Length, Is.EqualTo(12345));
        }

        [Test]
        public void alpha_numeric_should_return_random_string_containing_only_alpha_numeric_characters()
        {
            var s = randomString.AlphaNumeric();

            Assert.That(s, Is.StringMatching(@"^[a-zA-Z0-9]+$"));
        }

        [Test]
        public void alpha_numeric_should_return_random_string_containing_only_alpha_numeric_characters_of_specified_length()
        {
            var s = randomString.AlphaNumeric(12345);

            Assert.That(s, Is.StringMatching(@"^[a-zA-Z0-9]+$"));
            Assert.That(s.Length, Is.EqualTo(12345));
        }

        [Test]
        public void ascii_should_return_random_string_containing_only_ascii_characters()
        {
            var s = randomString.Ascii();

            foreach (var c in s.ToCharArray())
                Assert.That((int) c, Is.GreaterThanOrEqualTo(33).And.LessThanOrEqualTo(126));
        }

        [Test]
        public void ascii_should_return_random_string_containing_only_ascii_characters_of_specified_length()
        {
            var s = randomString.Ascii(12345);

            Assert.That(s, Contains.Substring("!"));
            Assert.That(s, Contains.Substring("~"));
            foreach (var c in s.ToCharArray())
                Assert.That((int) c, Is.GreaterThanOrEqualTo(33).And.LessThanOrEqualTo(126));
            Assert.That(s.Length, Is.EqualTo(12345));
        }

        [Test]
        public void from_chars_should_return_random_string_containing_only_given_characters()
        {
            var s = randomString.FromChars("asdf0987".ToCharArray());

            Assert.That(s, Is.StringMatching(@"^[asdf0987]+$"));
        }

        [Test]
        public void from_chars_should_return_random_string_containing_only_given_characters_of_specified_length()
        {
            var s = randomString.FromChars("asdf0987".ToCharArray(), 12345);

            Assert.That(s, Is.StringMatching(@"^[asdf0987]+$"));
            Assert.That(s.Length, Is.EqualTo(12345));
        }

        [Test]
        public void from_chars_should_throw_if_chars_array_is_null_or_empty()
        {
            AssertThat.ExceptionIsThrown<ArgumentNullException>(() => randomString.FromChars(null));
            AssertThat.ExceptionIsThrown<ArgumentException>(() => randomString.FromChars(new char[0]));
        }

        [Test]
        public void from_chars_with_length_should_throw_if_chars_array_is_null_or_empty()
        {
            AssertThat.ExceptionIsThrown<ArgumentNullException>(() => randomString.FromChars(null, 1234));
            AssertThat.ExceptionIsThrown<ArgumentException>(() => randomString.FromChars(new char[0], 1234));
        }

        [Test]
        public void using_seed_returns_same_values_repeatedly()
        {
            var r1 = new RandomString(1234);
            var r2 = new RandomString(1234);

            Assert.AreEqual(r1.AlphaNumeric(123), r2.AlphaNumeric(123));
        }
    }
}