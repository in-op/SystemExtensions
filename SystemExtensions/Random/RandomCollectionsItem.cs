using System;
using System.Collections.Generic;

namespace SystemExtensions.Random
{
    /* NOTE:
     * never call these methods in a loop
     * and give it a new Random() each time,
     * make one single new Random() before
     * the loop and pass the reference in.
     */
    public static class RandomCollectionsItem
    {
        /// <summary>
        /// Returns a random element from the List. O(1) time.
        /// </summary>
        /// <typeparam name="T">The type of elements of the List.</typeparam>
        /// <param name="list">The calling List.</param>
        /// <param name="rng">An instance of the Random class.</param>
        public static T RandomItem<T>(this List<T> list, System.Random rng)
        {
            return list[rng.Next(0, list.Count)];
        }

        /// <summary>
        /// Returns a random element from the Array. O(1) time.
        /// </summary>
        /// <typeparam name="T">The type of elements of the array.</typeparam>
        /// <param name="array">The calling array.</param>
        /// <param name="rng">An instance of the Random class.</param>
        public static T RandomItem<T>(this T[] array, System.Random rng)
        {
            return array[rng.Next(0, array.Length)];
        }

        /// <summary>
        /// Returns a random element from the Dictionary. O(n) time.
        /// </summary>
        /// <typeparam name="T1">The Key type.</typeparam>
        /// <typeparam name="T2">The Value type.</typeparam>
        /// <param name="dict">The calling Dictionary.</param>
        /// <param name="rng">An instance of the Random class.</param>
        public static T2 RandomItem<T1, T2>(this Dictionary<T1, T2> dict, System.Random rng)
        {
            int itemIndex = rng.Next(0, dict.Count);
            int i = 0;
            foreach (KeyValuePair<T1, T2> kvp in dict)
            {
                if (i == itemIndex) return kvp.Value;
                i++;
            }
            throw new Exception();
        }

        /// <summary>
        /// Returns a random element from the HashSet. O(n) time.
        /// </summary>
        /// <typeparam name="T">The type of elements of the HashSet.</typeparam>
        /// <param name="set">The calling HashSet.</param>
        /// <param name="rng">An instance of the Random class.</param>
        public static T RandomItem<T>(this HashSet<T> set, System.Random rng)
        {
            int itemIndex = rng.Next(0, set.Count);
            int i = 0;
            foreach (T item in set)
            {
                if (i == itemIndex) return item;
                i++;
            }
            throw new Exception();
        }
    }
}
