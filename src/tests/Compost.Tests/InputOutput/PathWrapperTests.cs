using System;
using System.IO;
using Compost.InputOutput;
using NUnit.Framework;

namespace Compost.Tests.InputOutput
{
    [TestFixture]
    public class PathWrapperTests
    {
        private const string TEST_FILE_PATH = @"C:\file\path\test.txt";

        private PathWrapper pathWrapper;

        [SetUp]
        public void Setup()
        {
            pathWrapper = new PathWrapper();
        }

        [Test]
        public void combine()
        {
            Assert.AreEqual(@"a\b\c\d", Path.Combine("a", "b", "c", "d"));
            Assert.AreEqual(@"a\b\c\d", pathWrapper.Combine("a", "b", "c", "d"));
        }

        [Test]
        public void get_directory_name()
        {
            Assert.AreEqual(@"C:\file\path", Path.GetDirectoryName(TEST_FILE_PATH));
            Assert.AreEqual(@"C:\file\path", pathWrapper.GetDirectoryName(TEST_FILE_PATH));
        }

        [Test]
        public void get_extension()
        {
            Assert.AreEqual(@".txt", Path.GetExtension(TEST_FILE_PATH));
            Assert.AreEqual(@".txt", pathWrapper.GetExtension(TEST_FILE_PATH));
        }

        [Test]
        public void get_file_name()
        {
            Assert.AreEqual(@"test.txt", Path.GetFileName(TEST_FILE_PATH));
            Assert.AreEqual(@"test.txt", pathWrapper.GetFileName(TEST_FILE_PATH));
        }

        [Test]
        public void get_file_name_without_ext()
        {
            Assert.AreEqual("test", Path.GetFileNameWithoutExtension(TEST_FILE_PATH));
            Assert.AreEqual("test", pathWrapper.GetFileNameWithoutExtension(TEST_FILE_PATH));
        }

        [Test]
        public void get_full_path()
        {
            var expected = Path.Combine(Environment.CurrentDirectory, @"test\file.txt");

            Assert.AreEqual(expected, Path.GetFullPath(@"test\file.txt"));
            Assert.AreEqual(expected, pathWrapper.GetFullPath(@"test\file.txt"));
        }
    }
}