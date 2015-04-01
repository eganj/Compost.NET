using Compost.InputOutput;
using Moq;
using NUnit.Framework;

namespace Compost.Tests.InputOutput
{
    [TestFixture]
    public class IOTests
    {
        private Mock<IIOWrapper> ioWrapper;

        [SetUp]
        public void Setup()
        {
            ioWrapper = new Mock<IIOWrapper>();

            IO.Wrapper = ioWrapper.Object;
        }

        [Test]
        public void combine()
        {
            IO.Combine("a", "b", "c");

            ioWrapper.Verify(i => i.Combine("a", "b", "c"));
        }
    }
}