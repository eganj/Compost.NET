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
        ///     Deletes the specified <paramref name="directoryPath" />. If <paramref name="recursive" /> is true, all
        ///     subdirectories and files in the <paramref name="directoryPath" /> will also be deleted.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="recursive"></param>
        public void Delete(string directoryPath, bool recursive = true)
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
        ///     Gets the paths of subdirectories within the <paramref name="directoryPath" /> that match the provided
        ///     <paramref name="searchPattern" />. The <paramref name="searchOption" /> allows for searching the top direcotry only
        ///     or all subdirectories.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="searchPattern"></param>
        /// <param name="searchOption"></param>
        /// <returns></returns>
        public string[] GetDirectories(string directoryPath, string searchPattern = "*",
            SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            return Directory.GetDirectories(directoryPath, searchPattern, searchOption);
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
        public string[] GetFiles(string directoryPath, string searchPattern = "*", SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            return Directory.GetFiles(directoryPath, searchPattern, searchOption);
        }

        /// <summary>
        ///     Moves the directory to a new location.
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destPath"></param>
        /// <param name="overwrite"></param>
        public void Move(string sourcePath, string destPath, bool overwrite = false)
        {
            if (Directory.Exists(destPath))
                if (overwrite) Delete(destPath);
                else throw new IOException("The destination directory already exists!");

            Directory.Move(sourcePath, destPath);
        }
    }
}