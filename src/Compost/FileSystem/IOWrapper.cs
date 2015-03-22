using System.IO;

namespace Compost.FileSystem
{
    /// <summary>
    ///     Provides an interface for <seealso cref="System.IO" /> methods that can be mocked and tested.
    /// </summary>
    public interface IIOWrapper
    {
        /// <summary>
        ///     Wrapper for the <seealso cref="System.IO.Path.Combine(string[])" /> method.
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        string Combine(params string[] paths);
    }

    /// <summary>
    ///     A wrapper for <seealso cref="System.IO" /> methods.
    /// </summary>
    public class IOWrapper : IIOWrapper
    {
        /// <summary>
        ///     Wrapper for the <seealso cref="Path.Combine(string[])" /> method.
        ///     Combines an array of strings into a path.
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        public string Combine(params string[] paths)
        {
            return Path.Combine(paths);
        }

        /// <summary>
        ///     Wrapper for the <seealso cref="Path.GetExtension" /> method.
        ///     Returns the file extension of the <paramref name="filePath" />. (e.g. ".txt", ".jpg")
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string GetFileExtension(string filePath)
        {
            return Path.GetExtension(filePath);
        }
    }
}