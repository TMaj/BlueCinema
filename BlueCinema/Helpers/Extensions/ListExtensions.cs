using System.Collections.Generic;

namespace BlueCinema.Helpers.Extensions
{
    public static class ListExtensions
    {
        public static void AddRange<T>(this IList<T> list, IList<T> newList)
        {
            foreach (var element in newList)
            {
                list.Add(element);
            }
        }
    }
}
