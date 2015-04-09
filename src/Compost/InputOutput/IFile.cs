using System.Collections.Generic;
using System.IO;

namespace Compost.InputOutput
{
    /// <summary>
    ///     Provides an interface for <seealso cref="File" /> methods that can be easily mocked and tested.
    /// </summary>
    public interface IFile
    {
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
        void Copy(string sourceFilePath, string destFilePath);

        /// <summary>
        ///     Copies an existing file to a new file.
        /// </summary>
        /// <param name="sourceFilePath"></param>
        /// <param name="destFilePath"></param>
        /// <param name="overwrite"></param>
        void Copy(string sourceFilePath, string destFilePath, bool overwrite);

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
        void Move(string sourceFilePath, string destFilePath);

        /// <summary>
        ///     Move a file to a new location.
        /// </summary>
        /// <param name="sourceFilePath"></param>
        /// <param name="destFilePath"></param>
        /// <param name="overwrite"></param>
        void Move(string sourceFilePath, string destFilePath, bool overwrite);

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
}