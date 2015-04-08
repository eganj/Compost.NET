using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Compost.InputOutput
{
    /// <summary>
    ///     A wrapper around the <seealso cref="File" /> class that allows for easy unit testing.
    /// </summary>
    public class FileWrapper : IFile
    {
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
            // TODO - for all methods that are providing default values, create overloads instead. This makes testing easier.
            // TODO - Break apart IIOWrapper into IPath, IFile, and IDirectory. Implement using PathWrapper, FileWrapper, and DirectoryWrapper
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
        public void Move(string sourceFilePath, string destFilePath, bool overwrite = false)
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