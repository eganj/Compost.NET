using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Compost.InputOutput
{
    /// <summary>
    ///     Provides an interface for <seealso cref="System.IO" /> methods that can be mocked and tested.
    /// </summary>
    public interface IIOWrapper
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

        /// <summary>
        ///     Appends lines to a file. The file is created if it does not already exist.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="lines"></param>
        void AppendAllLines(string filePath, IEnumerable<string> lines);

        /// <summary>
        ///     Appends text to a file. The file is created if it does not already exist.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="text"></param>
        void AppendAllText(string filePath, string text);

        /// <summary>
        ///     Copies an existing file to a new file.
        /// </summary>
        /// <param name="sourceFilePath"></param>
        /// <param name="destFilePath"></param>
        /// <param name="overwrite"></param>
        void Copy(string sourceFilePath, string destFilePath, bool overwrite = true);

        /// <summary>
        ///     Deletes the specified file.
        /// </summary>
        /// <param name="filePath"></param>
        void Delete(string filePath);

        /// <summary>
        ///     Determines whether the specified file exists.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        bool Exists(string filePath);

        /// <summary>
        ///     Move a file to a new location.
        /// </summary>
        /// <param name="sourceFilePath"></param>
        /// <param name="destFilePath"></param>
        /// <param name="overwrite"></param>
        void Move(string sourceFilePath, string destFilePath, bool overwrite = true);

        /// <summary>
        ///     Reads the bytes from a file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        byte[] ReadAllBytes(string filePath);

        /// <summary>
        ///     Reads all of the lines from a file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        string[] ReadAllLines(string filePath);

        /// <summary>
        ///     Reads all of the text from a file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        string ReadAllText(string filePath);

        /// <summary>
        ///     Writes the bytes to the specified file. If the file does not exist, it will be created. If the file does exist, it
        ///     will be overwritten.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="bytes"></param>
        void WriteAllBytes(string filePath, IEnumerable<byte> bytes);

        /// <summary>
        ///     Writes the lines to the specified file. If the file does not exist, it will be created. If the file does exist, it
        ///     will be overwritten.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="lines"></param>
        void WriteAllLines(string filePath, IEnumerable<string> lines);

        /// <summary>
        ///     Writes the text to the specified file. If the file does not exist, it will be created. If the file does exist, it
        ///     will be overwritten.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="text"></param>
        void WriteAllText(string filePath, string text);
    }

    /// <summary>
    ///     A wrapper for <seealso cref="System.IO" /> methods.
    /// </summary>
    public class IOWrapper : IIOWrapper
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

        /// <summary>
        ///     Appends lines to a file. The file is created if it does not already exist.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="lines"></param>
        public void AppendAllLines(string filePath, IEnumerable<string> lines)
        {
            File.AppendAllLines(filePath, lines);
        }

        /// <summary>
        ///     Appends text to a file. The file is created if it does not already exist.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="text"></param>
        public void AppendAllText(string filePath, string text)
        {
            File.AppendAllText(filePath, text);
        }

        /// <summary>
        ///     Copies an existing file to a new file.
        /// </summary>
        /// <param name="sourceFilePath"></param>
        /// <param name="destFilePath"></param>
        /// <param name="overwrite"></param>
        public void Copy(string sourceFilePath, string destFilePath, bool overwrite = true)
        {
            File.Copy(sourceFilePath, destFilePath, overwrite);
        }

        /// <summary>
        ///     Deletes the specified file.
        /// </summary>
        /// <param name="filePath"></param>
        public void Delete(string filePath)
        {
            File.Delete(filePath);
        }

        /// <summary>
        ///     Determines whether the specified file exists.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool Exists(string filePath)
        {
            return File.Exists(filePath);
        }

        /// <summary>
        ///     Move a file to a new location.
        /// </summary>
        /// <param name="sourceFilePath"></param>
        /// <param name="destFilePath"></param>
        /// <param name="overwrite"></param>
        public void Move(string sourceFilePath, string destFilePath, bool overwrite = true)
        {
            File.Copy(sourceFilePath, destFilePath, overwrite);
            File.Delete(sourceFilePath);
        }

        /// <summary>
        ///     Reads the bytes from a file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public byte[] ReadAllBytes(string filePath)
        {
            return File.ReadAllBytes(filePath);
        }

        /// <summary>
        ///     Reads all of the lines from a file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string[] ReadAllLines(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        /// <summary>
        ///     Reads all of the text from a file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string ReadAllText(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        /// <summary>
        ///     Writes the bytes to the specified file. If the file does not exist, it will be created. If the file does exist, it
        ///     will be overwritten.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="bytes"></param>
        public void WriteAllBytes(string filePath, IEnumerable<byte> bytes)
        {
            File.WriteAllBytes(filePath, bytes as byte[] ?? bytes.ToArray());
        }

        /// <summary>
        ///     Writes the lines to the specified file. If the file does not exist, it will be created. If the file does exist, it
        ///     will be overwritten.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="lines"></param>
        public void WriteAllLines(string filePath, IEnumerable<string> lines)
        {
            File.WriteAllLines(filePath, lines);
        }

        /// <summary>
        ///     Writes the text to the specified file. If the file does not exist, it will be created. If the file does exist, it
        ///     will be overwritten.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="text"></param>
        public void WriteAllText(string filePath, string text)
        {
            File.WriteAllText(filePath, text);
        }
    }
}