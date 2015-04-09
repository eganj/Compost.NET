using System;
using System.Linq.Expressions;
using Compost.Reflection;

namespace Compost.InputOutput
{
    /// <summary>
    ///     A collection of statically available implementations of file system wrappers.
    /// </summary>
    public static class IO
    {
        private static IPath path;
        private static IFile file;
        private static IDirectory directory;

        /// <summary>
        ///     A statically available implementation of <seealso cref="IPath" />.
        /// </summary>
        public static IPath Path
        {
            get { return path ?? Throw(() => Path); }
            set { path = value; }
        }

        /// <summary>
        ///     A statically available implementation of <seealso cref="IFile" />.
        /// </summary>
        public static IFile File
        {
            get { return file ?? Throw(() => File); }
            set { file = value; }
        }

        /// <summary>
        ///     A statically available implementation of <seealso cref="IDirectory" />.
        /// </summary>
        public static IDirectory Directory
        {
            get { return directory ?? Throw(() => Directory); }
            set { directory = value; }
        }

        private static T Throw<T>(Expression<Func<T>> expression)
        {
            var propertyInfo = Reflector.PropertyInfo(expression);
            throw new NullReferenceException("You must assign an implementation of " + propertyInfo.PropertyType.FullName + " to " +
                                             typeof (IO).FullName + "." + propertyInfo.Name);
        }
    }
}