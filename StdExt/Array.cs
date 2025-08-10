namespace StdExt
{
    public static class ArrayExtender
    {
        public static bool IsNullOrEmpty<T>(this T[]? array)
        {
            return (array?.Length ?? 0) == 0;
        }
    }
}
