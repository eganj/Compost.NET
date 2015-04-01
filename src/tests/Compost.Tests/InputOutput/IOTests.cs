using System;
using Compost.InputOutput;
using Moq;
using NUnit.Framework;

namespace Compost.Tests.InputOutput
{
    [TestFixture]
    public class IOTests
    {
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

            AssertThat.ExceptionIsThrown<NullReferenceException>(() => IO.Combine("a", "b"));
        }

        [Test]
        public void combine()
        {
            IO.Combine("a", "b", "c");

            ioWrapper.Verify(i => i.Combine("a", "b", "c"));
        }

        [Test]
        public void get_directory_name()
        {
            IO.GetDirectoryName("a");

            ioWrapper.Verify(i => i.GetDirectoryName("a"));
        }

        [Test]
        public void get_extension()
        {
            IO.GetExtension("a");

            ioWrapper.Verify(i => i.GetExtension("a"));
        }

        [Test]
        public void get_file_name()
        {
            IO.GetFileName("a");

            ioWrapper.Verify(i => i.GetFileName("a"));
        }

        [Test]
        public void get_file_name_without_ext()
        {
            IO.GetFileNameWithoutExtension("a");

            ioWrapper.Verify(i => i.GetFileNameWithoutExtension("a"));
        }

        [Test]
        public void get_full_path()
        {
            IO.GetFullPath("a");

            ioWrapper.Verify(i => i.GetFullPath("a"));
        }
    }
}