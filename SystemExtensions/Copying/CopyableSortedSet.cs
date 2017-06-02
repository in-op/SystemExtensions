using System;
using System.Collections.Generic;

namespace SystemExtensions.Copying
{
    /// <summary>
    /// A method class for implementing DeepCopy() on generic SortedSet.
    /// </summary>
    public static class CopyableSortedSet
    {
        /// <summary>
        /// Returns a deep copy of the calling SortedSet.
        /// </summary>
        /// <typeparam name="T">The type of items in the SortedSet.</typeparam>
        /// <param name="set">The calling SortedSet.</param>
        /// <returns>A deep copy of the SortedSet.</returns>
        public static SortedSet<T> DeepCopy<T>(this SortedSet<T> set)
        {
            var copy = new SortedSet<T>();

            if (typeof(T).IsValueType)
                foreach (T item in set)
                    copy.Add(item);
            else
                foreach (T item in set)
                    if (item == null) copy.Add(default(T));
                    else
                        try
                        {
                            object itemwrap = item;
                            var deepCopy = itemwrap.GetType().GetMethod("DeepCopy");
                            copy.Add((T)deepCopy.Invoke(itemwrap, new object[0]));
                        }
                        catch (ArgumentNullException)
                        {
                            throw new NotImplementedException("The List type " + typeof(T).Name + " must implement a parameterless instance method DeepCopy() that returns a deep copy of the instance.");
                        }

            return copy;
        }
    }
}
