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
            private static readonly string TestDir = Path.Combine(TEST_DIRECTORY, "testDirectory");
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

            [Test]
            public void create_directory()
            {
                ioWrapper.CreateDirectory(TestDir);

                Assert.IsTrue(Directory.Exists(TestDir));
            }

            [Test]
            public void delete_directory_should_delete_an_emepty_directory()
            {
                Directory.CreateDirectory(TestDir);
                Assert.IsTrue(Directory.Exists(TestDir));

                ioWrapper.DeleteDirectory(TestDir);

                Assert.IsFalse(Directory.Exists(TestDir));
            }

            [Test]
            public void delete_directory_should_delete_subfolders_and_files()
            {
                Directory.CreateDirectory(TestDir);
                File.WriteAllText(Path.Combine(TestDir, "asdf.txt"), "asdf");
                Directory.CreateDirectory(Path.Combine(TestDir, "dir2", "dir3"));

                ioWrapper.DeleteDirectory(TestDir);

                Assert.IsFalse(Directory.Exists(TestDir));
            }

            [Test]
            public void delete_directory_should_throw_if_recursive_is_false_and_dir_is_not_empty()
            {
                Directory.CreateDirectory(TestDir);
                File.WriteAllText(Path.Combine(TestDir, "asdf.txt"), "asdf");

                AssertThat.ExceptionIsThrown<IOException>(() => ioWrapper.DeleteDirectory(TestDir, false));
            }

            [Test]
            public void delete_directory_should_not_throw_if_the_directory_does_not_exist()
            {
                ioWrapper.DeleteDirectory(TestDir);

                Assert.Pass("No exception was thrown.");
            }

            [Test]
            public void exists()
            {
                Assert.IsFalse(ioWrapper.DirectoryExists(TestDir));

                Directory.CreateDirectory(TestDir);

                Assert.IsTrue(ioWrapper.DirectoryExists(TestDir));
            }

            [Test]
            public void get_current_directory()
            {
                Assert.AreEqual(Directory.GetCurrentDirectory(), ioWrapper.GetCurrentDirectory());
            }

            [Test]
            public void get_directories()
            {
                var a = Path.Combine(TestDir, "a");
                var b = Path.Combine(TestDir, "a\\b");
                var c = Path.Combine(TestDir, "a\\c");
                var d = Path.Combine(TestDir, "d");

                foreach (var s in new[] {a, b, c, d})
                    Directory.CreateDirectory(s);

                Assert.AreEqual(new[] {a, d}, ioWrapper.GetDirectories(TestDir));
                Assert.AreEqual(new[] {a}, ioWrapper.GetDirectories(TestDir, "*a*"));
                Assert.AreEqual(new[] {a, d, b, c}, ioWrapper.GetDirectories(TestDir, "*", SearchOption.AllDirectories));
                Assert.AreEqual(new[] {c}, ioWrapper.GetDirectories(TestDir, "*c*", SearchOption.AllDirectories));
            }

            [Test]
            public void get_files()
            {
                var p1 = Path.Combine(TestDir, "a\\b");
                var p2 = Path.Combine(TestDir, "a\\c");

                Directory.CreateDirectory(p1);
                Directory.CreateDirectory(p2);

                var a = Path.Combine(TestDir, "a.txt");
                var b = Path.Combine(p1, "b.txt");
                var c = Path.Combine(p2, "c.txt");
                var d = Path.Combine(TestDir, "d.txt");

                foreach (var s in new[] {a, b, c, d})
                    File.WriteAllText(s, "testing");

                Assert.AreEqual(new[] {a, d}, ioWrapper.GetFiles(TestDir));
                Assert.AreEqual(new[] {a}, ioWrapper.GetFiles(TestDir, "*a*"));
                Assert.AreEqual(new[] {a, d, b, c}, ioWrapper.GetFiles(TestDir, "*", SearchOption.AllDirectories));
                Assert.AreEqual(new[] {c}, ioWrapper.GetFiles(TestDir, "*c*", SearchOption.AllDirectories));
            }

            [Test]
            public void move_should_move_an_empty_directory()
            {
                Directory.CreateDirectory(TestDir);
                var destPath = Path.Combine(TEST_DIRECTORY, "new_folder");

                ioWrapper.MoveDirectory(TestDir, destPath);

                Assert.IsTrue(Directory.Exists(destPath));
                Assert.IsFalse(Directory.Exists(TestDir));
            }

            [Test]
            public void move_should_move_a_directory_with_files_and_subfolders()
            {
                Directory.CreateDirectory(TestDir);
                Directory.CreateDirectory(Path.Combine(TestDir, "asdf"));
                File.WriteAllText(Path.Combine(TestDir, "a.txt"), ";asldkfj");
                var destPath = Path.Combine(TEST_DIRECTORY, "new_folder");

                ioWrapper.MoveDirectory(TestDir, destPath);

                Assert.IsTrue(Directory.Exists(destPath));
                Assert.IsFalse(Directory.Exists(TestDir));
            }

            [Test]
            public void move_should_throw_if_overwrite_is_false_and_directory_exists()
            {
                var destPath = Path.Combine(TEST_DIRECTORY, "new_folder");
                Directory.CreateDirectory(TestDir);
                Directory.CreateDirectory(destPath);

                AssertThat.ExceptionIsThrown<IOException>(() => ioWrapper.MoveDirectory(TestDir, destPath));
            }

            [Test]
            public void move_should_be_able_to_overwrite()
            {
                Directory.CreateDirectory(TestDir);
                Directory.CreateDirectory(Path.Combine(TestDir, "asdf"));
                File.WriteAllText(Path.Combine(TestDir, "a.txt"), ";asldkfj");
                var destPath = Path.Combine(TEST_DIRECTORY, "new_folder");

                Directory.CreateDirectory(destPath);
                ioWrapper.MoveDirectory(TestDir, destPath, true);

                Assert.IsTrue(Directory.Exists(destPath));
                Assert.IsFalse(Directory.Exists(TestDir));
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
                    ioWrapper.DeleteFile(TestFile);

                    Assert.IsFalse(File.Exists(TestFile));
                }

                [Test]
                public void delete_should_not_throw_if_file_does_not_exist()
                {
                    File.Delete(TestFile);
                    Assert.IsFalse(File.Exists(TestFile));

                    ioWrapper.DeleteFile(TestFile);
                }

                [Test]
                public void exists()
                {
                    Assert.IsTrue(ioWrapper.FileExists(TestFile));

                    File.Delete(TestFile);

                    Assert.IsFalse(ioWrapper.FileExists(TestFile));
                }

                [Test]
                public void move_file()
                {
                    ioWrapper.MoveFile(TestFile, DestFile);

                    Assert.IsTrue(File.Exists(DestFile));
                    Assert.IsFalse(File.Exists(TestFile));
                }

                [Test]
                public void move_file_should_throw_if_file_exists_and_overwrite_is_false()
                {
                    File.WriteAllText(DestFile, "asdf");

                    AssertThat.ExceptionIsThrown<IOException>(() => ioWrapper.MoveFile(TestFile, DestFile));
                }

                [Test]
                public void move_file_should_replace_if_overwrite_is_true()
                {
                    var writeTime = File.GetLastWriteTime(TestFile);
                    File.WriteAllText(DestFile, "asdf");

                    ioWrapper.MoveFile(TestFile, DestFile, true);

                    Assert.IsTrue(File.Exists(DestFile));
                    Assert.IsFalse(File.Exists(TestFile));
                    Assert.That(File.GetLastWriteTime(DestFile), Is.EqualTo(writeTime));
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