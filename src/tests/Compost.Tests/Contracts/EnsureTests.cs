using Compost.Contracts;
using NUnit.Framework;

namespace Compost.Tests.Contracts
{
    [TestFixture]
    public class EnsureTests
    {
        [Test]
        public void that_throws_if_input_is_false()
        {
            AssertThat.ExceptionIsThrown<EnsureException>(() => Ensure.That(false));
        }

        [Test]
        public void that_does_not_throw_if_condition_is_true()
        {
            Ensure.That(true);

            Assert.Pass("No exception was thrown.");
        }

        [Test]
        public void that_throws_if_input_is_false_with_message()
        {
            AssertThat.ExceptionIsThrown<EnsureException>(() => Ensure.That(false, "message"));
        }

        [Test]
        public void that_does_not_throw_if_condition_is_true_with_message()
        {
            Ensure.That(true, "message");

            Assert.Pass("No exception was thrown.");
        }

        [Test]
        public void that_throws_if_lambda_input_is_false()
        {
            AssertThat.ExceptionIsThrown<EnsureException>(() => Ensure.That(() => false));
        }

        [Test]
        public void that_does_not_throw_if_lambda_condition_is_true()
        {
            Ensure.That(() => true);

            Assert.Pass("No exception was thrown.");
        }

        [Test]
        public void that_throws_if_lambda_input_is_false_with_message()
        {
            AssertThat.ExceptionIsThrown<EnsureException>(() => Ensure.That(() => false, "message"));
        }

        [Test]
        public void that_does_not_throw_if_lambda_condition_is_true_with_message()
        {
            Ensure.That(() => true, "message");

            Assert.Pass("No exception was thrown.");
        }
    }
}