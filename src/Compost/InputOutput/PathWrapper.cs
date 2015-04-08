using System.IO;

namespace Compost.InputOutput
{
    /// <summary>
    ///     A wrapper around the <seealso cref="Path" /> class that allows for easy unit testing.
    /// </summary>
    public class PathWrapper : IPath
    {
        /// <summary>
        ///     Combines an array of strings into a path.
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        public string Combine(params string[] paths)
        {
            return Path.Combine(paths);
        }

        /// <summary>
        ///     Wrapper for the <seealso cref="Path.GetDirectoryName" /> method.
        ///     Returns the full path of the containing directory of the <paramref name="path" />.
        ///     For example, "C:\some\file\path.txt" will return "C:\some\file" and
        ///     "C:\some\dir" will return "C:\some"
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetDirectoryName(string path)
        {
            return Path.GetDirectoryName(path);
        }

        /// <summary>
        ///     Wrapper for the <seealso cref="Path.GetExtension" /> method.
        ///     Returns the file extension of the <paramref name="filePath" />. (e.g. ".txt", ".jpg")
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string GetExtension(string filePath)
        {
            return Path.GetExtension(filePath);
        }

        /// <summary>
        ///     Wrapper for the <seealso cref="Path.GetFileName" /> method.
        ///     Returns the file name and extension from the <paramref name="filePath" />.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string GetFileName(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        /// <summary>
        ///     Wrapper for the <seealso cref="Path.GetFileNameWithoutExtension" /> method.
        ///     Returns the file name without the extension from the <paramref name="filePath" />.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string GetFileNameWithoutExtension(string filePath)
        {
            return Path.GetFileNameWithoutExtension(filePath);
        }

        /// <summary>
        ///     Wrapper for the <seealso cref="Path.GetFullPath" /> method.
        ///     Returns the full path of the <paramref name="path" />.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetFullPath(string path)
        {
            return Path.GetFullPath(path);
        }
    }
}