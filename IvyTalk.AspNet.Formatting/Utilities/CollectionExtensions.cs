using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;

namespace IvyTalk.AspNet.Formatting.Utilities
{
    internal static class CollectionExtensions
    {
        /// <summary>
        /// Return the enumerable as a Collection of T, copying if required. Optimized for the common case where it is 
        /// a Collection of T and avoiding a copy if it implements IList of T. Avoid mutating the return value.
        /// </summary>
        public static Collection<T> AsCollection<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable is Collection<T> collection)
            {
                return collection;
            }
            // Check for IList so that collection can wrap it instead of copying
            IList<T> list = enumerable as IList<T>;
            if (list == null)
            {
                list = new List<T>(enumerable);
            }
            return new Collection<T>(list);
        }
    }
}