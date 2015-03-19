using Compost.FileSystem;
using NUnit.Framework;
using Rhino.Mocks;

namespace Compost.Tests.FileSystem
{
    [TestFixture]
    public class IOTests
    {
        private IIOWrapper ioWrapper;

        [SetUp]
        public void Setup()
        {
            ioWrapper = MockRepository.GenerateStub<IIOWrapper>();

            IO.Wrapper = ioWrapper;
        }

        [Test]
        public void combine()
        {
            IO.Combine("a", "b", "c");

            ioWrapper.AssertWasCalled(i => i.Combine("a", "b", "c"));
        }
    }
}