using System.IO;
using Compost.InputOutput;
using NUnit.Framework;

namespace Compost.Tests.InputOutput
{
    [TestFixture]
    public class FileWrapperTests : WithFileSystemOperations
    {
        private const string TEXT = "asdfdkjdkdfj";

        private static readonly string TestFile = Path.Combine(ROOT_TEST_DIRECTORY, "testing.txt");
        private static readonly string[] Lines = {"asdf asdf", ";lkj ;lkj", "qwerpoiu"};

        private FileWrapper fileWrapper;

        [SetUp]
        public void Setup()
        {
            fileWrapper = new FileWrapper();
        }

        [Test]
        public void append_all_lines()
        {
            fileWrapper.AppendAllLines(TestFile, Lines);

            Assert.AreEqual(Lines, File.ReadAllLines(TestFile));
        }

        [Test]
        public void append_all_text()
        {
            fileWrapper.AppendAllText(TestFile, TEXT);

            Assert.AreEqual(TEXT, File.ReadAllText(TestFile));
        }

        [Test]
        public void write_all_bytes()
        {
            var bytes = new byte[] {1, 2, 3, 4, 5, 6};
            fileWrapper.WriteAllBytes(TestFile, bytes);

            Assert.AreEqual(bytes, File.ReadAllBytes(TestFile));
        }

        [Test]
        public void write_all_lines()
        {
            fileWrapper.WriteAllLines(TestFile, Lines);

            Assert.AreEqual(Lines, File.ReadAllLines(TestFile));
        }

        [Test]
        public void write_all_text()
        {
            fileWrapper.WriteAllText(TestFile, TEXT);

            Assert.AreEqual(TEXT, File.ReadAllText(TestFile));
        }
    }

    [TestFixture]
    public class FileWrapperTestsOnAnExistingFile : WithFileSystemOperations
    {
        private const string TEXT = "asdfdkjdkdfj";

        private static readonly string TestFile = Path.Combine(ROOT_TEST_DIRECTORY, "testing.txt");
        private static readonly string DestFile = Path.Combine(ROOT_TEST_DIRECTORY, "newFile.txt");

        private FileWrapper ioWrapper;

        [SetUp]
        public void Setup()
        {
            File.AppendAllText(TestFile, TEXT);

            ioWrapper = new FileWrapper();
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
        public void move_file()
        {
            ioWrapper.Move(TestFile, DestFile);

            Assert.IsTrue(File.Exists(DestFile));
            Assert.IsFalse(File.Exists(TestFile));
        }

        [Test]
        public void move_file_should_throw_if_file_exists_and_overwrite_is_false()
        {
            File.WriteAllText(DestFile, "asdf");

            AssertThat.ExceptionIsThrown<IOException>(() => ioWrapper.Move(TestFile, DestFile));
        }

        [Test]
        public void move_file_should_replace_if_overwrite_is_true()
        {
            var writeTime = File.GetLastWriteTime(TestFile);
            File.WriteAllText(DestFile, "asdf");

            ioWrapper.Move(TestFile, DestFile, true);

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