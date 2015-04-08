using System;
using Compost.InputOutput;
using NUnit.Framework;

namespace Compost.Tests.InputOutput
{
    [TestFixture]
    public class IOTests
    {
        [Test]
        public void exception_is_thrown_if_path_is_null()
        {
            AssertThat.ExceptionIsThrown<NullReferenceException>(() => { var v = IO.Path; });
        }

        [Test]
        public void exception_is_thrown_if_file_is_null()
        {
            AssertThat.ExceptionIsThrown<NullReferenceException>(() => { var v = IO.File; });
        }

        [Test]
        public void exception_is_thrown_if_directory_is_null()
        {
            AssertThat.ExceptionIsThrown<NullReferenceException>(() => { var v = IO.Directory; });
        }

        [Test]
        public void no_exception_is_thrown_if_assigned()
        {
            IO.Directory = new DirectoryWrapper();
            IO.File = new FileWrapper();
            IO.Path = new PathWrapper();

            Assert.IsNotNull(IO.Directory);
            Assert.IsNotNull(IO.File);
            Assert.IsNotNull(IO.Path);
        }
    }
}