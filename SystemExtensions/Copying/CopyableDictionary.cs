using System;
using System.Collections.Generic;

namespace SystemExtensions.Copying
{
    /// <summary>
    /// A method class implementing a DeepCopy() extension method for the generic Dictionary type.
    /// </summary>
    public static class CopyableDictionary
    {
        /// <summary>
        /// Returns a deep copy of the calling Dictionary.
        /// </summary>
        /// <typeparam name="TKey">The key type.</typeparam>
        /// <typeparam name="TValue">The value type.</typeparam>
        /// <param name="dict">The calling Dictionary.</param>
        /// <returns>A deep copy of the calling Dictionary.</returns>
        public static Dictionary<TKey, TValue> DeepCopy<TKey, TValue>(this Dictionary<TKey, TValue> dict)
        {
            var copy = new Dictionary<TKey, TValue>(dict.Count);
            foreach (KeyValuePair<TKey, TValue> kvp in dict)
                copy.Add(kvp.Key, kvp.Value);
            return copy;
        }
    }
}
