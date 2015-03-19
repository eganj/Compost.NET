using System.IO;
using Compost.FileSystem;
using NUnit.Framework;

namespace Compost.Tests.FileSystem
{
    [TestFixture]
    public class IOWrapperTests
    {
        private IOWrapper ioWrapper;

        [SetUp]
        public void Setup()
        {
            ioWrapper = new IOWrapper();
        }

        [Test]
        public void combine()
        {
            Assert.AreEqual(Path.Combine("a", "b", "c", "d"), ioWrapper.Combine("a", "b", "c", "d"));
        }
    }
}