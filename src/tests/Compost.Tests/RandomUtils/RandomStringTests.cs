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
        public void alpha_numeric_should_return_random_string_containing_only_alpha_numeric_characters()
        {
            var s = randomString.AlphaNumeric(12345);

            Assert.That(s, Is.StringMatching(@"^[a-zA-Z0-9]{12345}$"));
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