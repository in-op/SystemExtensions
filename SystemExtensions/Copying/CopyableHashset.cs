using System;
using System.Collections.Generic;

namespace SystemExtensions.Copying
{
    /// <summary>
    /// A method class providing a DeepCopy() method for generic HashSets.
    /// </summary>
    public static class CopyableHashSet
    {
        /// <summary>
        /// Returns a deep copy of the HashSet. T must be an immutable value type, else implement an instance method DeepCopy().
        /// </summary>
        /// <typeparam name="T">The type of the HashSet items.</typeparam>
        /// <param name="hashset">The calling HashSet.</param>
        /// <returns>A deep copy of the HashSet.</returns>
        public static HashSet<T> DeepCopy<T>(this HashSet<T> hashset)
        {
            var copy = new HashSet<T>();

            if (typeof(T).IsValueType)
                foreach (T item in hashset)
                    copy.Add(item);
            else
                foreach (T item in hashset)
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
