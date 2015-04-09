using System.IO;

namespace Compost.InputOutput
{
    /// <summary>
    ///     Provides an interface for <seealso cref="Directory" /> methods that can be easily mocked and tested.
    /// </summary>
    public interface IDirectory
    {
        /// <summary>
        ///     Creates all directories and subdirectories in the specified <paramref name="directoryPath" />.
        /// </summary>
        /// <param name="directoryPath"></param>
        void Create(string directoryPath);

        /// <summary>
        ///     Deletes the specified <paramref name="directoryPath" /> including and all
        ///     subdirectories and files contained in the <paramref name="directoryPath" />.
        /// </summary>
        /// <param name="directoryPath"></param>
        void Delete(string directoryPath);

        /// <summary>
        ///     Deletes the specified <paramref name="directoryPath" />. If <paramref name="recursive" /> is false, the directory
        ///     will not be deleted recursively and an exception will be thrown if the directory is not empty.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="recursive"></param>
        void Delete(string directoryPath, bool recursive);

        /// <summary>
        ///     Determines whether the specified directory exists.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        bool Exists(string directoryPath);

        /// <summary>
        ///     Gets the current working directory of the application.
        /// </summary>
        /// <returns></returns>
        string GetCurrentDirectory();

        /// <summary>
        ///     Gets the paths of all the subdirectories within the <paramref name="directoryPath" />.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        string[] GetDirectories(string directoryPath);

        /// <summary>
        ///     Gets the paths of subdirectories within the <paramref name="directoryPath" /> that match the provided
        ///     <paramref name="searchPattern" />.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="searchPattern"></param>
        /// <returns></returns>
        string[] GetDirectories(string directoryPath, string searchPattern);

        /// <summary>
        ///     Gets the paths of subdirectories within the <paramref name="directoryPath" /> that match the provided
        ///     <paramref name="searchPattern" />. The <paramref name="searchOption" /> allows for searching the top direcotry only
        ///     or all subdirectories.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="searchPattern"></param>
        /// <param name="searchOption"></param>
        /// <returns></returns>
        string[] GetDirectories(string directoryPath, string searchPattern, SearchOption searchOption);

        /// <summary>
        ///     Gets the paths of all files within the <paramref name="directoryPath" />.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        string[] GetFiles(string directoryPath);

        /// <summary>
        ///     Gets the paths of files within the <paramref name="directoryPath" /> that match the provided
        ///     <paramref name="searchPattern" />.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="searchPattern"></param>
        /// <returns></returns>
        string[] GetFiles(string directoryPath, string searchPattern);

        /// <summary>
        ///     Gets the paths of files within the <paramref name="directoryPath" /> that match the provided
        ///     <paramref name="searchPattern" />. The <paramref name="searchOption" /> allows for searching the top direcotry only
        ///     or all subdirectories.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="searchPattern"></param>
        /// <param name="searchOption"></param>
        /// <returns></returns>
        string[] GetFiles(string directoryPath, string searchPattern, SearchOption searchOption);

        /// <summary>
        ///     Moves the directory to a new location.
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destPath"></param>
        void Move(string sourcePath, string destPath);

        /// <summary>
        ///     Moves the directory to a new location.
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destPath"></param>
        /// <param name="overwrite"></param>
        void Move(string sourcePath, string destPath, bool overwrite);
    }
}