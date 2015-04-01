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
            Assert.AreEqual(@"a\b\c\d", Path.Combine("a", "b", "c", "d"));
            Assert.AreEqual(@"a\b\c\d", ioWrapper.Combine("a", "b", "c", "d"));
        }

        [Test]
        public void get_directory_name()
        {
            Assert.AreEqual(@"C:\file\path", Path.GetDirectoryName(TEST_FILE_PATH));
            Assert.AreEqual(@"C:\file\path", ioWrapper.GetDirectoryName(TEST_FILE_PATH));
        }

        [Test]
        public void get_extension()
        {
            Assert.AreEqual(@".txt", Path.GetExtension(TEST_FILE_PATH));
            Assert.AreEqual(@".txt", ioWrapper.GetFileExtension(TEST_FILE_PATH));
        }

        [Test]
        public void get_file_name()
        {
            Assert.AreEqual(@"test.txt", Path.GetFileName(TEST_FILE_PATH));
            Assert.AreEqual(@"test.txt", ioWrapper.GetFileName(TEST_FILE_PATH));
        }

        [Test]
        public void get_file_name_without_ext()
        {
            Assert.AreEqual("test", Path.GetFileNameWithoutExtension(TEST_FILE_PATH));
            Assert.AreEqual("test", ioWrapper.GetFileNameWithoutExtension(TEST_FILE_PATH));
        }
    }
}