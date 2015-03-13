using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Compost.FileSystem;
using System.IO;

namespace Compost.Tests.FileSystem
{
    [TestFixture]
    public class IOWrapperTests
    {
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
    }
}
