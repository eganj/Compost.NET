using System.IO;
using Compost.InputOutput;
using NUnit.Framework;

namespace Compost.Tests.InputOutput
{
    [TestFixture]
    public class IOWrapperTests
    {
        private const string TEST_FILE_PATH = @"C:\file\path\test.txt";

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

        [Test]
        public void extension()
        {
            Assert.AreEqual(Path.GetExtension(TEST_FILE_PATH),
                ioWrapper.GetFileExtension(TEST_FILE_PATH));
        }

        [Test]
        public void ext()
        {
            Assert.AreEqual(Path.GetFileName(TEST_FILE_PATH),
                ioWrapper.GetFileName(TEST_FILE_PATH));
        }
    }
}