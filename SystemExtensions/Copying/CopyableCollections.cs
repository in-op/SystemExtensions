using System;
using System.Collections.Generic;
using System.Reflection;

namespace SystemExtensions.Copying
{
    // ~ DO NOT CHANGE THE ORDER OF PUBLIC METHODS ~

    public static class CopyableCollections
    {

        private static readonly MethodInfo[] methods = typeof(CopyableCollections).GetMethods();
        

        private static MethodInfo GetDeepCopy(Type type)
        {
            if (type.IsArray &&
                type.GetArrayRank() == 1)
                return methods[0].MakeGenericMethod(new[] { type.GetElementType() });

            if (type.IsGenericType)
            {
                Type genericType = type.GetGenericTypeDefinition();

                if (genericType == typeof(List<>))
                    return methods[1].MakeGenericMethod(type.GetGenericArguments());
                if (genericType == typeof(HashSet<>))
                    return methods[2].MakeGenericMethod(type.GetGenericArguments());
                if (genericType == typeof(Dictionary<,>))
                    return methods[3].MakeGenericMethod(type.GetGenericArguments());

                return null;
            }

            return null;
        }






        /// <summary>
        /// Returns a deep copy of the calling array T[].
        /// T must implement ICopyable&lt;T&gt;,
        /// be a value type, or be a type supporting
        /// the DeepCopy() extension.
        /// </summary>
        public static T[] DeepCopy<T>(this T[] array)
        {
            int length = array.Length;
            T[] copy = new T[length];

            if (typeof(ICopyable<T>).IsAssignableFrom(typeof(T)))
                for (int i = 0; i < length; i++)
                    if (array[i] == null) copy[i] = array[i];
                    else copy[i] = ((ICopyable<T>)array[i]).DeepCopy();

            else if (typeof(T).IsValueType)
                for (int i = 0; i < length; i++)
                    copy[i] = array[i];

            else
            {
                MethodInfo deepCopy = GetDeepCopy(typeof(T));
                if (deepCopy != null)
                    try
                    {
                        for (int i = 0; i < length; i++)
                            if (array[i] == null) copy[i] = array[i];
                            else copy[i] = (T)deepCopy.Invoke(null, new object[] { array[i] });
                    }
                    catch (Exception)
                    {
                        throw new NotImplementedException("A class within " + typeof(T).Name + " did not implement ICopyable<T>.");
                    }

                else throw new NotImplementedException("The " + typeof(T).Name + " class did not implement ICopyable<" + typeof(T).Name + ">.");
            }

            return copy;
        }







        /// <summary>
        /// Returns a deep copy of the calling List&lt;T&gt;.
        /// T must implement ICopyable&lt;T&gt;, be a value type,
        /// or be a type supporting the DeepCopy() extension.
        /// </summary>
        public static List<T> DeepCopy<T>(this List<T> list)
        {
            int count = list.Count;
            List<T> copy = new List<T>(count);

            if (typeof(ICopyable<T>).IsAssignableFrom(typeof(T)))
                for (int i = 0; i < count; i++)
                    if (list[i] == null) copy.Add(list[i]);
                    else copy.Add(((ICopyable<T>)list[i]).DeepCopy());

            else if (typeof(T).IsValueType)
                for (int i = 0; i < count; i++)
                    copy.Add(list[i]);

            else
            {
                MethodInfo deepCopy = GetDeepCopy(typeof(T));

                if (deepCopy != null)
                    try
                    {
                        for (int i = 0; i < count; i++)
                            if (list[i] == null) copy.Add(list[i]);
                            else copy.Add((T)deepCopy.Invoke(null, new object[] { list[i] }));
                    }
                    catch (Exception)
                    {
                        throw new NotImplementedException("A class within " + typeof(T).Name + " did not implement ICopyable<T>.");
                    }

                else throw new NotImplementedException("The " + typeof(T).Name + " class did not implement ICopyable<" + typeof(T).Name + ">.");
            }

            return copy;
        }




        /// <summary>
        /// Returns a deep copy of the HashSet&lt;T&gt;.
        /// T must implement ICopyable&lt;T&gt;, be a value type,
        /// or be a type supporting the DeepCopy() extension.
        /// </summary>
        /// <typeparam name="T">The type of the HashSet&lt;T&gt; items.</typeparam>
        /// <param name="hashset">The calling HashSet&lt;T&gt;.</param>
        /// <returns>A deep copy of the HashSet&lt;T&gt;.</returns>
        public static HashSet<T> DeepCopy<T>(this HashSet<T> hashset)
        {
            int count = hashset.Count;
            HashSet<T> copy = new HashSet<T>();

            if (typeof(ICopyable<T>).IsAssignableFrom(typeof(T)))
                foreach (T element in hashset)
                    if (element == null) copy.Add(element);
                    else copy.Add(((ICopyable<T>)element).DeepCopy());

            else if (typeof(T).IsValueType)
                foreach (T element in hashset)
                    copy.Add(element);

            else
            {
                MethodInfo deepCopy = GetDeepCopy(typeof(T));

                if (deepCopy != null)
                    try
                    {
                        foreach (T element in hashset)
                            if (element == null) copy.Add(element);
                            else copy.Add((T)deepCopy.Invoke(null, new object[] { element }));
                    }
                    catch (Exception)
                    {
                        throw new NotImplementedException("A class within " + typeof(T).Name + " did not implement ICopyable<T>.");
                    }

                else throw new NotImplementedException("The " + typeof(T).Name + " class did not implement ICopyable<" + typeof(T).Name + ">.");
            }

            return copy;
        }








        /// <summary>
        /// Returns a deep copy of the calling Dictionary&lt;TKey, TValue&gt;.
        /// Both TKey and TValue must implement ICopyable, be a value type,
        /// or be a type supporting the DeepCopy() extension.
        /// </summary>
        /// <typeparam name="TKey">The key type.</typeparam>
        /// <typeparam name="TValue">The value type.</typeparam>
        /// <param name="dict">The calling Dictionary.</param>
        /// <returns>A deep copy of the calling Dictionary.</returns>
        public static Dictionary<TKey, TValue> DeepCopy<TKey, TValue>(this Dictionary<TKey, TValue> dict)
        {
            var copy = new Dictionary<TKey, TValue>(dict.Count);


            if (typeof(ICopyable<TKey>).IsAssignableFrom(typeof(TKey)))

                if (typeof(ICopyable<TValue>).IsAssignableFrom(typeof(TValue)))

                    foreach (KeyValuePair<TKey, TValue> kvp in dict)
                        copy.Add(
                            ((ICopyable<TKey>)kvp.Key).DeepCopy(),
                            ((ICopyable<TValue>)kvp.Value).DeepCopy());

                else if (typeof(TValue).IsValueType)

                    foreach (KeyValuePair<TKey, TValue> kvp in dict)
                        copy.Add(
                            ((ICopyable<TKey>)kvp.Key).DeepCopy(),
                            kvp.Value);

                else
                {
                    MethodInfo deepCopy = GetDeepCopy(typeof(TValue));

                    if (deepCopy != null)
                        try
                        {
                            foreach (KeyValuePair<TKey, TValue> kvp in dict)
                                copy.Add(
                                    ((ICopyable<TKey>)kvp.Key).DeepCopy(),
                                    (TValue)deepCopy.Invoke(null, new object[1] { kvp.Value }));
                        }
                        catch (Exception)
                        {
                            throw new NotImplementedException("One of the types within the Dictionary did not implement ICopyable<T>.");
                        }

                    else throw new NotImplementedException("The " + typeof(TValue).Name + " class did not implement ICopyable<" + typeof(TValue).Name + ">.");
                }


            else if (typeof(TKey).IsValueType)

                if (typeof(ICopyable<TValue>).IsAssignableFrom(typeof(TValue)))

                    foreach (KeyValuePair<TKey, TValue> kvp in dict)
                        copy.Add(
                            kvp.Key,
                            ((ICopyable<TValue>)kvp.Value).DeepCopy());

                else if (typeof(TValue).IsValueType)

                    foreach (KeyValuePair<TKey, TValue> kvp in dict)
                        copy.Add(
                            kvp.Key,
                            kvp.Value);

                else
                {
                    MethodInfo deepCopy = GetDeepCopy(typeof(TValue));

                    if (deepCopy != null)
                        try
                        {
                            foreach (KeyValuePair<TKey, TValue> kvp in dict)
                                copy.Add(
                                    kvp.Key,
                                    (TValue)deepCopy.Invoke(null, new object[1] { kvp.Value }));
                        }
                        catch (Exception)
                        {
                            throw new NotImplementedException("One of the types within the Dictionary did not implement ICopyable<T>.");
                        }

                    else throw new NotImplementedException("The " + typeof(TValue).Name + " class did not implement ICopyable<" + typeof(TValue).Name + ">.");
                }
            
            else //TKey has DeepCopy() extension (or not)
            {
                MethodInfo keyDeepCopy = GetDeepCopy(typeof(TKey));

                if (keyDeepCopy != null)
                    try
                    {
                        if (typeof(ICopyable<TValue>).IsAssignableFrom(typeof(TValue)))

                            foreach (KeyValuePair<TKey, TValue> kvp in dict)
                                copy.Add(
                                    (TKey)keyDeepCopy.Invoke(null, new object[1] { kvp.Key }),
                                    ((ICopyable<TValue>)kvp.Value).DeepCopy());

                        else if (typeof(TValue).IsValueType)

                            foreach (KeyValuePair<TKey, TValue> kvp in dict)
                                copy.Add(
                                    (TKey)keyDeepCopy.Invoke(null, new object[1] { kvp.Key }),
                                    kvp.Value);

                        else
                        {
                            MethodInfo deepCopy = GetDeepCopy(typeof(TValue));

                            if (deepCopy != null)
                                try
                                {
                                    foreach (KeyValuePair<TKey, TValue> kvp in dict)
                                        copy.Add(
                                            (TKey)keyDeepCopy.Invoke(null, new object[1] { kvp.Key }),
                                            (TValue)deepCopy.Invoke(null, new object[1] { kvp.Value }));
                                }
                                catch (Exception)
                                {
                                    throw new NotImplementedException("One of the types within the Dictionary did not implement ICopyable<T>.");
                                }

                            else throw new NotImplementedException("The " + typeof(TValue).Name + " class did not implement ICopyable<" + typeof(TValue).Name + ">.");
                        }
                    }
                    catch (Exception)
                    {
                        throw new NotImplementedException("One of the types within the Dictionary did not implement ICopyable<T>.");
                    }

                else throw new NotImplementedException("The " + typeof(TKey).Name + " class did not implement ICopyable<" + typeof(TKey).Name + ">.");

            }


            return copy;
        }






















        








    }
}
