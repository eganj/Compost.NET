using System.IO;
using NUnit.Framework;

namespace Compost.Tests
{
    public class WithFileSystemOperations
    {
        protected const string ROOT_TEST_DIRECTORY = @"C:\UnitTestDirectory";

        [SetUp]
        public void CreateCleanTestDirectory()
        {
            DeleteTestDirectory();
            Directory.CreateDirectory(ROOT_TEST_DIRECTORY);
        }

        [TearDown]
        public void DeleteTestDirectory()
        {
            if (Directory.Exists(ROOT_TEST_DIRECTORY))
                Directory.Delete(ROOT_TEST_DIRECTORY, true);
        }
    }
}