using System.IO;

namespace Compost.InputOutput
{
    /// <summary>
    ///     A wrapper around the <seealso cref="Directory" /> class that allows for easy unit testing.
    /// </summary>
    public class DirectoryWrapper : IDirectory
    {
        /// <summary>
        ///     Creates all directories and subdirectories in the specified <paramref name="directoryPath" />.
        /// </summary>
        /// <param name="directoryPath"></param>
        public void Create(string directoryPath)
        {
            Directory.CreateDirectory(directoryPath);
        }

        /// <summary>
        ///     Deletes the specified <paramref name="directoryPath" /> including and all
        ///     subdirectories and files contained in the <paramref name="directoryPath" />.
        /// </summary>
        /// <param name="directoryPath"></param>
        public void Delete(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
                Directory.Delete(directoryPath, true);
        }

        /// <summary>
        ///     Deletes the specified <paramref name="directoryPath" />. If <paramref name="recursive" /> is false, the directory
        ///     will not be deleted recursively and an exception will be thrown if the directory is not empty.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="recursive"></param>
        public void Delete(string directoryPath, bool recursive)
        {
            if (Directory.Exists(directoryPath))
                Directory.Delete(directoryPath, recursive);
        }

        /// <summary>
        ///     Determines whether the specified directory exists.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        public bool Exists(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }

        /// <summary>
        ///     Gets the current working directory of the application.
        /// </summary>
        /// <returns></returns>
        public string GetCurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        /// <summary>
        ///     Gets the paths of all the subdirectories within the <paramref name="directoryPath" />.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        public string[] GetDirectories(string directoryPath)
        {
            return Directory.GetDirectories(directoryPath);
        }

        /// <summary>
        ///     Gets the paths of subdirectories within the <paramref name="directoryPath" /> that match the provided
        ///     <paramref name="searchPattern" />.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="searchPattern"></param>
        /// <returns></returns>
        public string[] GetDirectories(string directoryPath, string searchPattern)
        {
            return Directory.GetDirectories(directoryPath, searchPattern);
        }

        /// <summary>
        ///     Gets the paths of subdirectories within the <paramref name="directoryPath" /> that match the provided
        ///     <paramref name="searchPattern" />. The <paramref name="searchOption" /> allows for searching the top direcotry only
        ///     or all subdirectories.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="searchPattern"></param>
        /// <param name="searchOption"></param>
        /// <returns></returns>
        public string[] GetDirectories(string directoryPath, string searchPattern, SearchOption searchOption)
        {
            return Directory.GetDirectories(directoryPath, searchPattern, searchOption);
        }

        /// <summary>
        ///     Gets the paths of all the files within the <paramref name="directoryPath" />.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        public string[] GetFiles(string directoryPath)
        {
            return Directory.GetFiles(directoryPath);
        }

        /// <summary>
        ///     Gets the paths of files within the <paramref name="directoryPath" /> that match the provided
        ///     <paramref name="searchPattern" />.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="searchPattern"></param>
        /// <returns></returns>
        public string[] GetFiles(string directoryPath, string searchPattern)
        {
            return Directory.GetFiles(directoryPath, searchPattern);
        }

        /// <summary>
        ///     Gets the paths of files within the <paramref name="directoryPath" /> that match the provided
        ///     <paramref name="searchPattern" />. The <paramref name="searchOption" /> allows for searching the top direcotry only
        ///     or all subdirectories.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="searchPattern"></param>
        /// <param name="searchOption"></param>
        /// <returns></returns>
        public string[] GetFiles(string directoryPath, string searchPattern, SearchOption searchOption)
        {
            return Directory.GetFiles(directoryPath, searchPattern, searchOption);
        }

        /// <summary>
        ///     Moves the directory to a new location.
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destPath"></param>
        public void Move(string sourcePath, string destPath)
        {
            Directory.Move(sourcePath, destPath);
        }

        /// <summary>
        ///     Moves the directory to a new location.
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destPath"></param>
        /// <param name="overwrite"></param>
        public void Move(string sourcePath, string destPath, bool overwrite)
        {
            if (Directory.Exists(destPath))
                if (overwrite) Delete(destPath);
                else throw new IOException("The destination directory already exists!");

            Directory.Move(sourcePath, destPath);
        }
    }
}