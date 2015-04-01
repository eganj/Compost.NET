using System.IO;

namespace Compost.InputOutput
{
    /// <summary>
    ///     Provides an interface for <seealso cref="System.IO" /> methods that can be mocked and tested.
    /// </summary>
    public interface IIOWrapper
    {
        /// <summary>
        ///     Wrapper for the <seealso cref="Path.Combine(string[])" /> method.
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        string Combine(params string[] paths);

        /// <summary>
        ///     Wrapper for the <seealso cref="Path.GetExtension" /> method.
        ///     Returns the file extension of the <paramref name="filePath" />. (e.g. ".txt", ".jpg")
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        string GetFileExtension(string filePath);

        /// <summary>
        ///     Wrapper for the <seealso cref="Path.GetFileName" /> method.
        ///     Returns the file name and extension from the <paramref name="filePath" />.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        string GetFileName(string filePath);

        /// <summary>
        ///     Wrapper for the <seealso cref="Path.GetFileNameWithoutExtension" /> method.
        ///     Returns the file name without the extension from the <paramref name="filePath" />.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        string GetFileNameWithoutExtension(string filePath);
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
    }
}