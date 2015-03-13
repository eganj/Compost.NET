using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Compost.FileSystem;
using Rhino.Mocks;

namespace Compost.Tests.FileSystem
{
    [TestFixture]
    public class IOTests
    {
        private IIOWrapper ioWrapper;

        [SetUp]
        public void Setup()
        {
            ioWrapper = MockRepository.GenerateStub<IIOWrapper>();

            IO.Wrapper = ioWrapper;
        }
    }
}
