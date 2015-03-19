namespace Compost.FileSystem
{
    public static class IO
    {
        public static IIOWrapper Wrapper;

        public static string Combine(params string[] paths)
        {
            return Wrapper.Combine(paths);
        }
    }
}