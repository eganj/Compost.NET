using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Compost.FileSystem;

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
    }
}
