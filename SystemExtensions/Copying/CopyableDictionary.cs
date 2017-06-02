using System;
using System.Collections.Generic;
using System.Reflection;

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
                if (typeof(TKey).IsValueType)
                    if (typeof(TValue).IsValueType)
                        copy.Add(kvp.Key, kvp.Value);
                    else
                        try
                        {
                            object value = kvp.Value;
                            MethodInfo deepcopy = value.GetType().GetMethod("DeepCopy");
                            copy.Add(kvp.Key, (TValue)deepcopy.Invoke(value, new object[0]));
                        }
                        catch (ArgumentNullException)
                        {
                            throw new NotImplementedException("The value type " + typeof(TValue).Name + " must implement a parameterless instance method DeepCopy() that returns a deep copy of the instance.");
                        }
                else
                    if (typeof(TValue).IsValueType)
                        try
                        {
                            object key = kvp.Key;
                            MethodInfo deepcopy = key.GetType().GetMethod("DeepCopy");
                            copy.Add((TKey)deepcopy.Invoke(key, new object[0]), kvp.Value);
                        }
                        catch (ArgumentNullException)
                        {
                            throw new NotImplementedException("The key type " + typeof(TKey).Name + " must implement a parameterless instance method DeepCopy() that returns a deep copy of the instance.");
                        }
                    else
                        try
                        {
                            object key = kvp.Key;
                            object value = kvp.Value;
                            MethodInfo keyDeepCopy = key.GetType().GetMethod("DeepCopy");
                            MethodInfo valueDeepCopy = value.GetType().GetMethod("DeepCopy");
                            copy.Add((TKey)keyDeepCopy.Invoke(key, new object[0]),
                                (TValue)valueDeepCopy.Invoke(value, new object[0]));
                        }
                        catch (ArgumentNullException)
                        {
                            throw new NotImplementedException("Both the key type " + typeof(TKey).Name + " and the value type " + typeof(TValue).Name + " must implement a parameterless instance method DeepCopy() that returns a deep copy of the instance.");
                        }

            return copy;
        }








    }
}
