using System;
using System.IO;
using Compost.InputOutput;
using NUnit.Framework;

namespace Compost.Tests.InputOutput
{
    [TestFixture]
    public class IOWrapperTests
    {
        // ReSharper disable InconsistentNaming
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
            private const string TEXT = "asdfdkjdkdfj";
            private static readonly string TestFile = Path.Combine(TEST_DIRECTORY, "testing.txt");
            private static readonly string DestFile = Path.Combine(TEST_DIRECTORY, "newFile.txt");
            private static readonly string[] Lines = {"asdf asdf", ";lkj ;lkj", "qwerpoiu"};

            private IOWrapper ioWrapper;

            [SetUp]
            public void Setup()
            {
                CreateCleanTestDirectory();

                ioWrapper = new IOWrapper();
            }

            [TearDown]
            public void TearDown()
            {
                DeleteTestDirectory();
            }

            [Test]
            public void append_all_lines()
            {
                ioWrapper.AppendAllLines(TestFile, Lines);

                Assert.AreEqual(Lines, File.ReadAllLines(TestFile));
            }

            [Test]
            public void append_all_text()
            {
                ioWrapper.AppendAllText(TestFile, TEXT);

                Assert.AreEqual(TEXT, File.ReadAllText(TestFile));
            }

            [Test]
            public void write_all_bytes()
            {
                var bytes = new byte[] {1, 2, 3, 4, 5, 6};
                ioWrapper.WriteAllBytes(TestFile, bytes);

                Assert.AreEqual(bytes, File.ReadAllBytes(TestFile));
            }

            [Test]
            public void write_all_lines()
            {
                ioWrapper.WriteAllLines(TestFile, Lines);

                Assert.AreEqual(Lines, File.ReadAllLines(TestFile));
            }

            [Test]
            public void write_all_text()
            {
                ioWrapper.WriteAllText(TestFile, TEXT);

                Assert.AreEqual(TEXT, File.ReadAllText(TestFile));
            }

            private static void CreateCleanTestDirectory()
            {
                DeleteTestDirectory();

                Directory.CreateDirectory(TEST_DIRECTORY);
            }

            private static void DeleteTestDirectory()
            {
                if (Directory.Exists(TEST_DIRECTORY))
                    Directory.Delete(TEST_DIRECTORY, true);
            }

            [TestFixture]
            public class When_the_file_exists
            {
                private IOWrapper ioWrapper;

                [SetUp]
                public void Setup()
                {
                    CreateCleanTestDirectory();

                    File.AppendAllText(TestFile, TEXT);

                    ioWrapper = new IOWrapper();
                }

                [TearDown]
                public void TearDown()
                {
                    DeleteTestDirectory();
                }

                [Test]
                public void copy()
                {
                    ioWrapper.Copy(TestFile, DestFile);

                    Assert.IsTrue(File.Exists(DestFile));
                }

                [Test]
                public void delete()
                {
                    ioWrapper.Delete(TestFile);

                    Assert.IsFalse(File.Exists(TestFile));
                }

                [Test]
                public void delete_should_not_throw_if_file_does_not_exist()
                {
                    File.Delete(TestFile);
                    Assert.IsFalse(File.Exists(TestFile));

                    ioWrapper.Delete(TestFile);
                }

                [Test]
                public void exists()
                {
                    Assert.IsTrue(ioWrapper.Exists(TestFile));

                    File.Delete(TestFile);

                    Assert.IsFalse(ioWrapper.Exists(TestFile));
                }

                [Test]
                public void move()
                {
                    ioWrapper.Move(TestFile, DestFile);

                    Assert.IsTrue(File.Exists(DestFile));
                    Assert.IsFalse(File.Exists(TestFile));
                }

                [Test]
                public void read_all_bytes()
                {
                    Assert.AreEqual(File.ReadAllBytes(TestFile), ioWrapper.ReadAllBytes(TestFile));
                }

                [Test]
                public void read_all_lines()
                {
                    Assert.AreEqual(File.ReadAllLines(TestFile), ioWrapper.ReadAllLines(TestFile));
                }

                [Test]
                public void read_all_text()
                {
                    Assert.AreEqual(TEXT, ioWrapper.ReadAllText(TestFile));
                }
            }
        }
    }
}