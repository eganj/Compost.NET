using System;
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
    }
}