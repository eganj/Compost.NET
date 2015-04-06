using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Compost.Reflection;

namespace Compost.InputOutput
{
    /// <summary>
    ///     A static wrapper around the <seealso cref="IIOWrapper" /> class to allow static use of methods.
    /// </summary>
    public static class IO
    {
        private static IIOWrapper wrapper;

        /// <summary>
        ///     The implementation of the <seealso cref="IIOWrapper" /> that will be used to make the method calls.
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        public static IIOWrapper Wrapper
        {
            get
            {
                if (wrapper != null) return wrapper;

                throw new NullReferenceException("You must assign an implementation of the " + typeof (IIOWrapper).FullName + " to the " +
                                                 Reflector.MemberName(() => Wrapper) + " property in " + typeof (IO).FullName);
            }
            set { wrapper = value; }
        }

        /// <summary>
        ///     Combines an array of strings into a path.
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        public static string Combine(params string[] paths)
        {
            return Wrapper.Combine(paths);
        }

        /// <summary>
        ///     Returns the full path of the containing directory of the <paramref name="path" />.
        ///     For example, "C:\some\file\path.txt" will return "C:\some\file" and
        ///     "C:\some\dir" will return "C:\some"
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetDirectoryName(string path)
        {
            return Wrapper.GetDirectoryName(path);
        }

        /// <summary>
        ///     Returns the file extension of the <paramref name="filePath" />. (e.g. ".txt", ".jpg")
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetExtension(string filePath)
        {
            return Wrapper.GetExtension(filePath);
        }

        /// <summary>
        ///     Returns the file name and extension from the <paramref name="filePath" />.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetFileName(string filePath)
        {
            return Wrapper.GetFileName(filePath);
        }

        /// <summary>
        ///     Returns the file name without the extension from the <paramref name="filePath" />.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetFileNameWithoutExtension(string filePath)
        {
            return Wrapper.GetFileNameWithoutExtension(filePath);
        }

        /// <summary>
        ///     Returns the full path of the <paramref name="path" />.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetFullPath(string path)
        {
            return Wrapper.GetFullPath(path);
        }

        /// <summary>
        ///     Appends lines to a file. The file is created if it does not already exist.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="lines"></param>
        public static void AppendAllLines(string filePath, IEnumerable<string> lines)
        {
            Wrapper.AppendAllLines(filePath, lines);
        }

        /// <summary>
        ///     Appends text to a file. The file is created if it does not already exist.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="text"></param>
        public static void AppendAllText(string filePath, string text)
        {
            Wrapper.AppendAllText(filePath, text);
        }

        /// <summary>
        ///     Copies an existing file to a new file.
        /// </summary>
        /// <param name="sourceFilePath"></param>
        /// <param name="destFilePath"></param>
        /// <param name="overwrite"></param>
        public static void Copy(string sourceFilePath, string destFilePath, bool overwrite = true)
        {
            Wrapper.Copy(sourceFilePath, destFilePath, overwrite);
        }

        /// <summary>
        ///     Deletes the specified file.
        /// </summary>
        /// <param name="filePath"></param>
        public static void DeleteFile(string filePath)
        {
            Wrapper.DeleteFile(filePath);
        }

        /// <summary>
        ///     Determines whether the specified file exists.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool FileExists(string filePath)
        {
            return Wrapper.FileExists(filePath);
        }

        /// <summary>
        ///     Move a file to a new location.
        /// </summary>
        /// <param name="sourceFilePath"></param>
        /// <param name="destFilePath"></param>
        /// <param name="overwrite"></param>
        public static void MoveFile(string sourceFilePath, string destFilePath, bool overwrite = false)
        {
            Wrapper.MoveFile(sourceFilePath, destFilePath, overwrite);
        }

        /// <summary>
        ///     Reads the bytes from a file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static byte[] ReadAllBytes(string filePath)
        {
            return Wrapper.ReadAllBytes(filePath);
        }

        /// <summary>
        ///     Reads all of the lines from a file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string[] ReadAllLines(string filePath)
        {
            return Wrapper.ReadAllLines(filePath);
        }

        /// <summary>
        ///     Reads all of the text from a file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string ReadAllText(string filePath)
        {
            return Wrapper.ReadAllText(filePath);
        }

        /// <summary>
        ///     Writes the bytes to the specified file. If the file does not exist, it will be created. If the file does exist, it
        ///     will be overwritten.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="bytes"></param>
        public static void WriteAllBytes(string filePath, IEnumerable<byte> bytes)
        {
            Wrapper.WriteAllBytes(filePath, bytes as byte[] ?? bytes.ToArray());
        }

        /// <summary>
        ///     Writes the lines to the specified file. If the file does not exist, it will be created. If the file does exist, it
        ///     will be overwritten.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="lines"></param>
        public static void WriteAllLines(string filePath, IEnumerable<string> lines)
        {
            Wrapper.WriteAllLines(filePath, lines);
        }

        /// <summary>
        ///     Writes the text to the specified file. If the file does not exist, it will be created. If the file does exist, it
        ///     will be overwritten.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="text"></param>
        public static void WriteAllText(string filePath, string text)
        {
            Wrapper.WriteAllText(filePath, text);
        }

        /// <summary>
        ///     Creates all directories and subdirectories in the specified <paramref name="directoryPath" />.
        /// </summary>
        /// <param name="directoryPath"></param>
        public static void CreateDirectory(string directoryPath)
        {
            Wrapper.CreateDirectory(directoryPath);
        }

        /// <summary>
        ///     Deletes the specified <paramref name="directoryPath" />. If <paramref name="recursive" /> is true, all
        ///     subdirectories and files in the <paramref name="directoryPath" /> will also be deleted.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="recursive"></param>
        public static void DeleteDirectory(string directoryPath, bool recursive = true)
        {
            Wrapper.DeleteDirectory(directoryPath, recursive);
        }

        /// <summary>
        ///     Determines whether the specified directory exists.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        public static bool DirectoryExists(string directoryPath)
        {
            return Wrapper.DirectoryExists(directoryPath);
        }

        /// <summary>
        ///     Gets the current working directory of the application.
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentDirectory()
        {
            return Wrapper.GetCurrentDirectory();
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
        public static string[] GetDirectories(string directoryPath, string searchPattern = "*",
            SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            return Wrapper.GetDirectories(directoryPath, searchPattern, searchOption);
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
        public static string[] GetFiles(string directoryPath, string searchPattern = "*",
            SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            return Wrapper.GetFiles(directoryPath, searchPattern, searchOption);
        }

        /// <summary>
        ///     Moves the directory to a new location.
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destPath"></param>
        /// <param name="overwrite"></param>
        public static void MoveDirectory(string sourcePath, string destPath, bool overwrite = false)
        {
            Wrapper.MoveDirectory(sourcePath, destPath, overwrite);
        }
    }
}