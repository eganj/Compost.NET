using System;
using Compost.RandomUtils;
using NUnit.Framework;

namespace Compost.Tests.RandomUtils
{
    [TestFixture]
    public class RandomNumberTests
    {
        private RandomNumber randomNumber;

        [SetUp]
        public void Setup()
        {
            randomNumber = new RandomNumber();
        }

        [Test]
        public void int_returns_integer()
        {
            Repeat(() => Assert.That(randomNumber.Int(), Is.GreaterThanOrEqualTo(0)));
        }

        [Test]
        public void int_returns_less_than_max()
        {
            Repeat(() => Assert.That(randomNumber.Int(5), Is.InRange(0, 4)));
            Repeat(() => Assert.That(randomNumber.Int(0), Is.EqualTo(0)));
        }

        [Test]
        public void int_throws_if_max_is_negative()
        {
            AssertThat.ExceptionIsThrown<ArgumentOutOfRangeException>(() => randomNumber.Int(-1));
        }

        [Test]
        public void int_returns_within_range()
        {
            Repeat(() => Assert.That(randomNumber.Int(1, 3), Is.InRange(1, 2)));
            Repeat(() => Assert.That(randomNumber.Int(-10, 3), Is.InRange(-10, 2)));
            Repeat(() => Assert.That(randomNumber.Int(0, 0), Is.EqualTo(0)));
        }

        [Test]
        public void int_throws_if_max_is_greater_than_min()
        {
            AssertThat.ExceptionIsThrown<ArgumentOutOfRangeException>(() => randomNumber.Int(1234, 8));
        }

        [Test]
        public void double_returns_double()
        {
            Repeat(() => Assert.That(randomNumber.Double(), Is.InRange(0.0, 1.0)));
        }

        [Test]
        public void double_returns_less_than_max()
        {
            Repeat(() => Assert.That(randomNumber.Double(15), Is.InRange(0, 15)));
        }

        [Test]
        public void double_throws_if_max_is_negative()
        {
            AssertThat.ExceptionIsThrown<ArgumentOutOfRangeException>(() => randomNumber.Double(-1));
        }

        [Test]
        public void double_returns_within_range()
        {
            Repeat(() => Assert.That(randomNumber.Double(1, 3), Is.InRange(1, 3)));
            Repeat(() => Assert.That(randomNumber.Double(-10, 3), Is.InRange(-10, 3)));
            Repeat(() => Assert.That(randomNumber.Double(0, 0), Is.EqualTo(0)));
        }

        [Test]
        public void double_throws_if_max_is_greater_than_min()
        {
            AssertThat.ExceptionIsThrown<ArgumentOutOfRangeException>(() => randomNumber.Double(1234, 8));
        }

        [Test]
        public void same_random_numbers_can_be_generated_using_the_same_seed()
        {
            var r1 = new RandomNumber(1234);
            var r2 = new RandomNumber(1234);

            Repeat(() => Assert.That(r1.Int(), Is.EqualTo(r2.Int())));
        }

        private void Repeat(Action action, int repetitions = 100)
        {
            var c = 0;
            while (c++ < repetitions)
                action();
        }
    }
}