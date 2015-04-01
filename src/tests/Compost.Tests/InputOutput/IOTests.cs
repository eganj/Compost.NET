using System;
using Compost.InputOutput;
using Moq;
using NUnit.Framework;

namespace Compost.Tests.InputOutput
{
    [TestFixture]
    public class IOTests
    {
        private const string TestFile = "a";
        private static readonly string[] Lines = {TestFile, "b", "asdf"};

        private Mock<IIOWrapper> ioWrapper;

        [SetUp]
        public void Setup()
        {
            ioWrapper = new Mock<IIOWrapper>();

            IO.Wrapper = ioWrapper.Object;
        }

        [Test]
        public void exception_is_thrown_if_wrapper_is_null()
        {
            IO.Wrapper = null;

            AssertThat.ExceptionIsThrown<NullReferenceException>(() => IO.Combine(TestFile, "b"));
        }

        [Test]
        public void combine()
        {
            IO.Combine(TestFile, "b", "c");

            ioWrapper.Verify(i => i.Combine(TestFile, "b", "c"));
        }

        [Test]
        public void get_directory_name()
        {
            IO.GetDirectoryName(TestFile);

            ioWrapper.Verify(i => i.GetDirectoryName(TestFile));
        }

        [Test]
        public void get_extension()
        {
            IO.GetExtension(TestFile);

            ioWrapper.Verify(i => i.GetExtension(TestFile));
        }

        [Test]
        public void get_file_name()
        {
            IO.GetFileName(TestFile);

            ioWrapper.Verify(i => i.GetFileName(TestFile));
        }

        [Test]
        public void get_file_name_without_ext()
        {
            IO.GetFileNameWithoutExtension(TestFile);

            ioWrapper.Verify(i => i.GetFileNameWithoutExtension(TestFile));
        }

        [Test]
        public void get_full_path()
        {
            IO.GetFullPath(TestFile);

            ioWrapper.Verify(i => i.GetFullPath(TestFile));
        }

        [Test]
        public void append_all_lines()
        {
            IO.AppendAllLines(TestFile, Lines);

            ioWrapper.Verify(i => i.AppendAllLines(TestFile, Lines));
        }

        [Test]
        public void append_all_text()
        {
            IO.AppendAllText(TestFile, "b");

            ioWrapper.Verify(i => i.AppendAllText(TestFile, "b"));
        }

        [Test]
        public void write_all_bytes()
        {
            var bytes = new byte[] {1, 2, 3, 4, 5, 6};
            IO.WriteAllBytes(TestFile, bytes);

            ioWrapper.Verify(i => i.WriteAllBytes(TestFile, bytes));
        }

        [Test]
        public void write_all_lines()
        {
            IO.WriteAllLines(TestFile, Lines);

            ioWrapper.Verify(i => i.WriteAllLines(TestFile, Lines));
        }

        [Test]
        public void write_all_text()
        {
            IO.WriteAllText(TestFile, "b");

            ioWrapper.Verify(i => i.WriteAllText(TestFile, "b"));
        }

        [Test]
        public void copy()
        {
            IO.Copy(TestFile, "b");

            ioWrapper.Verify(i => i.Copy(TestFile, "b", true));
        }

        [Test]
        public void delete()
        {
            IO.Delete(TestFile);

            ioWrapper.Verify(i => i.Delete(TestFile));
        }

        [Test]
        public void exists()
        {
            IO.Exists(TestFile);

            ioWrapper.Verify(i => i.Exists(TestFile));
        }

        [Test]
        public void move()
        {
            IO.Move(TestFile, "b");

            ioWrapper.Verify(i => i.Move(TestFile, "b", true));
        }

        [Test]
        public void read_all_bytes()
        {
            IO.ReadAllBytes(TestFile);

            ioWrapper.Verify(i => i.ReadAllBytes(TestFile));
        }

        [Test]
        public void read_all_lines()
        {
            IO.ReadAllLines(TestFile);

            ioWrapper.Verify(i => i.ReadAllLines(TestFile));
        }

        [Test]
        public void read_all_text()
        {
            IO.ReadAllText(TestFile);

            ioWrapper.Verify(i => i.ReadAllText(TestFile));
        }
    }
}