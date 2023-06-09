﻿namespace ProyectoCurso.Shared.ROP
{
    public static class EnumerableUtils
    {
        public static string JoinStrings(this IEnumerable<string> strings, string separator)
        {
            return string.Join(separator, strings);
        }

        public static List<T> ListOrEmpty<T>(this IEnumerable<T> list)
        {
            return list.Any() ? list.ToList() : new List<T>();
        }
    }
}
