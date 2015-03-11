namespace Compost.Reflection
{
    public static class Reflector
    {
        public static string ClassName<T>()
        {
            return (typeof (T)).Name;
        }
    }
}