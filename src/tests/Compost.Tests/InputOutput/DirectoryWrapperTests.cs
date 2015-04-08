using System.IO;
using Compost.InputOutput;
using NUnit.Framework;

namespace Compost.Tests.InputOutput
{
    [TestFixture]
    public class DirectoryWrapperTests : WithFileSystemOperations
    {
        private static readonly string TestDir = Path.Combine(ROOT_TEST_DIRECTORY, "testDirectory");
        private static readonly string TestFile = Path.Combine(TestDir, "asdf.txt");

        private DirectoryWrapper directoryWrapper;

        [SetUp]
        public void Setup()
        {
            directoryWrapper = new DirectoryWrapper();
        }

        [Test]
        public void create_directory()
        {
            directoryWrapper.Create(TestDir);

            Assert.IsTrue(Directory.Exists(TestDir));
        }

        [Test]
        public void delete_directory_should_delete_an_emepty_directory()
        {
            Directory.CreateDirectory(TestDir);
            Assert.IsTrue(Directory.Exists(TestDir));

            directoryWrapper.Delete(TestDir);

            Assert.IsFalse(Directory.Exists(TestDir));
        }

        [Test]
        public void delete_directory_should_delete_subfolders_and_files()
        {
            Directory.CreateDirectory(TestDir);
            File.WriteAllText(TestFile, "asdf");
            Directory.CreateDirectory(Path.Combine(TestDir, "dir2", "dir3"));

            directoryWrapper.Delete(TestDir);

            Assert.IsFalse(Directory.Exists(TestDir));
        }

        [Test]
        public void delete_directory_should_throw_if_recursive_is_false_and_dir_is_not_empty()
        {
            Directory.CreateDirectory(TestDir);
            File.WriteAllText(TestFile, "asdf");

            AssertThat.ExceptionIsThrown<IOException>(() => directoryWrapper.Delete(TestDir, false));
        }

        [Test]
        public void delete_directory_should_not_throw_if_the_directory_does_not_exist()
        {
            Assert.IsFalse(Directory.Exists(TestDir));

            directoryWrapper.Delete(TestDir);

            Assert.Pass("No exception was thrown.");
        }

        [Test]
        public void exists()
        {
            Assert.IsFalse(directoryWrapper.Exists(TestDir));

            Directory.CreateDirectory(TestDir);

            Assert.IsTrue(directoryWrapper.Exists(TestDir));
        }

        [Test]
        public void get_current_directory()
        {
            Assert.AreEqual(Directory.GetCurrentDirectory(), directoryWrapper.GetCurrentDirectory());
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

            Assert.AreEqual(new[] {a, d}, directoryWrapper.GetDirectories(TestDir));
            Assert.AreEqual(new[] {a}, directoryWrapper.GetDirectories(TestDir, "*a*"));
            Assert.AreEqual(new[] {a, d, b, c}, directoryWrapper.GetDirectories(TestDir, "*", SearchOption.AllDirectories));
            Assert.AreEqual(new[] {c}, directoryWrapper.GetDirectories(TestDir, "*c*", SearchOption.AllDirectories));
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

            Assert.AreEqual(new[] {a, d}, directoryWrapper.GetFiles(TestDir));
            Assert.AreEqual(new[] {a}, directoryWrapper.GetFiles(TestDir, "*a*"));
            Assert.AreEqual(new[] {a, d, b, c}, directoryWrapper.GetFiles(TestDir, "*", SearchOption.AllDirectories));
            Assert.AreEqual(new[] {c}, directoryWrapper.GetFiles(TestDir, "*c*", SearchOption.AllDirectories));
        }

        [Test]
        public void move_should_move_an_empty_directory()
        {
            Directory.CreateDirectory(TestDir);
            var destPath = Path.Combine(ROOT_TEST_DIRECTORY, "new_folder");

            directoryWrapper.Move(TestDir, destPath);

            Assert.IsTrue(Directory.Exists(destPath));
            Assert.IsFalse(Directory.Exists(TestDir));
        }

        [Test]
        public void move_should_move_a_directory_with_files_and_subfolders()
        {
            Directory.CreateDirectory(TestDir);
            Directory.CreateDirectory(Path.Combine(TestDir, "asdf"));
            File.WriteAllText(Path.Combine(TestDir, "a.txt"), ";asldkfj");
            var destPath = Path.Combine(ROOT_TEST_DIRECTORY, "new_folder");

            directoryWrapper.Move(TestDir, destPath);

            Assert.IsTrue(Directory.Exists(destPath));
            Assert.IsFalse(Directory.Exists(TestDir));
        }

        [Test]
        public void move_should_throw_if_overwrite_is_false_and_directory_exists()
        {
            var destPath = Path.Combine(ROOT_TEST_DIRECTORY, "new_folder");
            Directory.CreateDirectory(TestDir);
            Directory.CreateDirectory(destPath);

            AssertThat.ExceptionIsThrown<IOException>(() => directoryWrapper.Move(TestDir, destPath));
        }

        [Test]
        public void move_should_be_able_to_overwrite()
        {
            Directory.CreateDirectory(TestDir);
            Directory.CreateDirectory(Path.Combine(TestDir, "asdf"));
            File.WriteAllText(Path.Combine(TestDir, "a.txt"), ";asldkfj");
            var destPath = Path.Combine(ROOT_TEST_DIRECTORY, "new_folder");

            Directory.CreateDirectory(destPath);
            directoryWrapper.Move(TestDir, destPath, true);

            Assert.IsTrue(Directory.Exists(destPath));
            Assert.IsFalse(Directory.Exists(TestDir));
        }
    }
}