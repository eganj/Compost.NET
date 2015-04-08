using System.IO;

namespace Compost.InputOutput
{
    /// <summary>
    ///     Provides an interface for <seealso cref="Path" /> methods that can be easily mocked and tested.
    /// </summary>
    public interface IPath
    {
        /// <summary>
        ///     Combines an array of strings into a path.
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        string Combine(params string[] paths);

        /// <summary>
        ///     Returns the full path of the containing directory of the <paramref name="path" />.
        ///     For example, "C:\some\file\path.txt" will return "C:\some\file" and
        ///     "C:\some\dir" will return "C:\some"
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        string GetDirectoryName(string path);

        /// <summary>
        ///     Returns the file extension of the <paramref name="filePath" />. (e.g. ".txt", ".jpg")
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        string GetExtension(string filePath);

        /// <summary>
        ///     Returns the file name and extension from the <paramref name="filePath" />.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        string GetFileName(string filePath);

        /// <summary>
        ///     Returns the file name without the extension from the <paramref name="filePath" />.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        string GetFileNameWithoutExtension(string filePath);

        /// <summary>
        ///     Returns the full path of the <paramref name="path" />.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        string GetFullPath(string path);
    }
}