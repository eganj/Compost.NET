using System;
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
            Assert.AreEqual(@".txt", ioWrapper.GetExtension(TEST_FILE_PATH));
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

        [Test]
        public void get_full_path()
        {
            var expected = Path.Combine(Environment.CurrentDirectory, @"test\file.txt");

            Assert.AreEqual(expected, Path.GetFullPath(@"test\file.txt"));
            Assert.AreEqual(expected, ioWrapper.GetFullPath(@"test\file.txt"));
        }

        [TestFixture]
        public class With_io_operations
        {
            private const string TEST_DIRECTORY = @"C:\UnitTestDirectory";
            private static readonly string TestFile = Path.Combine(TEST_DIRECTORY, "testing.txt");
            private static readonly string[] Lines = {"asdf asdf", ";lkj ;lkj", "qwerpoiu"};
            private const string TEXT = "asdfdkjdkdfj";

            private IOWrapper ioWrapper;

            [SetUp]
            public void Setup()
            {
                if (Directory.Exists(TEST_DIRECTORY))
                    Directory.Delete(TEST_DIRECTORY, true);

                Directory.CreateDirectory(TEST_DIRECTORY);

                ioWrapper = new IOWrapper();
            }

            [TearDown]
            public void TearDown()
            {
                if (Directory.Exists(TEST_DIRECTORY))
                    Directory.Delete(TEST_DIRECTORY, true);
            }

            [Test]
            public void append_all_lines()
            {
                ioWrapper.AppendAllLines(TestFile, Lines);

                Assert.AreEqual(Lines, File.ReadAllLines(TestFile));
            }

            [Test]
            public void append_all_test()
            {
                ioWrapper.AppendAllText(TestFile, TEXT);

                Assert.AreEqual(TEXT, File.ReadAllText(TestFile));
            }

            [Test]
            public void copy()
            {
                var dest = Path.Combine(TEST_DIRECTORY, "newFile.txt");

                ioWrapper.AppendAllLines(TestFile, Lines);
                ioWrapper.Copy(TestFile, dest);

                Assert.IsTrue(File.Exists(dest));
            }
        }
    }
}