using System;
using System.Collections.Generic;
using System.Reflection;

namespace SystemExtensions.Copying
{
    // ~ DO NOT CHANGE THE ORDER OF PUBLIC METHODS ~

    public static class CopyableCollections
    {
        private static readonly MethodInfo[] methods = typeof(CopyableCollections).GetMethods();

        private static MethodInfo ArrayMethodInfo
        {
            get
            {
                return methods[0];
            }
        }

        private static MethodInfo GetMethodInfo(Type genericType)
        {
            switch (genericType.GetGenericTypeDefinition().FullName)
            {
                case "System.Collections.Generic.List`1":
                    return methods[1];
                case "System.Collections.Generic.HashSet`1":
                    return methods[2];
                case "System.Collections.Generic.Dictionary`2":
                    return methods[3];
                default:
                    return null;
            }
        }

        




        /// <summary>
        /// Returns a deep copy of the calling array.
        /// If the array type T is a reference type it
        /// must implement a parameterless instance
        /// method DeepCopy(), which returns a deep
        /// copy of the instance. If T is a value type,
        /// it must be immutable.
        /// </summary>
        public static T[] DeepCopy<T>(this T[] array)
        {
            Type typeofT = typeof(T);
            int x = array.Length;
            T[] copy = new T[x];

            if (typeofT.IsValueType)
                for (int i = 0; i < x; i++)
                    copy[i] = array[i];
            else
            {
                MethodInfo deepCopy = typeofT.GetMethod("DeepCopy"); // defined in T class definition

                if (deepCopy == null)
                {
                    if (typeofT.IsGenericType) //anything but arrays
                        deepCopy = GetMethodInfo(typeofT).MakeGenericMethod(typeofT.GetGenericArguments());
                    else if (typeofT.IsArray) //arrays 
                        deepCopy = ArrayMethodInfo.MakeGenericMethod(new[] { typeofT.GetElementType() });
                    try
                    {
                        for (int i = 0; i < x; i++)
                            if (array[i] == null) copy[i] = default(T);
                            else copy[i] = (T)deepCopy.Invoke(null, new object[] { array[i] });
                    }
                    catch (Exception)
                    {
                        throw new NotImplementedException("The " + typeofT.Name + " class must implement a parameterless instance method DeepCopy() that returns a deep copy of the instance.");
                    }
                }
                else
                    for (int i = 0; i < x; i++)
                        if (array[i] == null) copy[i] = default(T);
                        else copy[i] = (T)deepCopy.Invoke(array[i], new object[0]);
            }

            return copy;
        }







        /// <summary>
        /// Returns a deep copy of the List.
        /// If the List type T is a reference
        /// type, it must implement a parameterless
        /// instance method DeepCopy(), which returns
        /// a deep copy of the instance. If T is
        /// a value type, it must be immutable.
        /// </summary>
        public static List<T> DeepCopy<T>(this List<T> list)
        {
            List<T> copy = new List<T>(list.Count);
            int count = list.Count;
            Type typeofT = typeof(T);

            if (typeofT.IsValueType)
                for (int i = 0; i < count; i++)
                    copy.Add(list[i]);
            else
            {
                MethodInfo deepCopy = typeofT.GetMethod("DeepCopy"); // defined in T class definition

                if (deepCopy == null)
                {
                    if (typeofT.IsGenericType) //anything but arrays
                        deepCopy = GetMethodInfo(typeofT).MakeGenericMethod(typeofT.GetGenericArguments());
                    else if (typeofT.IsArray) //arrays 
                        deepCopy = ArrayMethodInfo.MakeGenericMethod(new[] { typeofT.GetElementType() });
                    try
                    {
                        for (int i = 0; i < count; i++)
                            if (list[i] == null) copy.Add(default(T));
                            else copy.Add((T)deepCopy.Invoke(null, new object[] { list[i] }));
                    }
                    catch (Exception)
                    {
                        throw new NotImplementedException("The List type " + typeofT.Name + " must implement a parameterless instance method DeepCopy() that returns a deep copy of the instance.");
                    }
                }
                else
                    for (int i = 0; i < count; i++)
                        if (list[i] == null) copy.Add(default(T));
                        else copy.Add((T)deepCopy.Invoke(list[i], new object[0]));
            }
            return copy;
        }




        /// <summary>
        /// Returns a deep copy of the HashSet. T must be an immutable value type, else implement an instance method DeepCopy().
        /// </summary>
        /// <typeparam name="T">The type of the HashSet items.</typeparam>
        /// <param name="hashset">The calling HashSet.</param>
        /// <returns>A deep copy of the HashSet.</returns>
        public static HashSet<T> DeepCopy<T>(this HashSet<T> hashset)
        {
            var copy = new HashSet<T>();
            Type typeofT = typeof(T);

            if (typeofT.IsValueType)
                foreach (T item in hashset)
                    copy.Add(item);
            else
            {
                MethodInfo deepCopy = typeofT.GetMethod("DeepCopy"); // defined in T class definition

                if (deepCopy == null)
                {
                    if (typeofT.IsGenericType) //anything but arrays
                        deepCopy = GetMethodInfo(typeofT).MakeGenericMethod(typeofT.GetGenericArguments());
                    else if (typeofT.IsArray) //arrays 
                        deepCopy = ArrayMethodInfo.MakeGenericMethod(new[] { typeofT.GetElementType() });
                    try
                    {
                        foreach (T element in hashset)
                            if (element == null) copy.Add(default(T));
                            else copy.Add((T)deepCopy.Invoke(null, new object[] { element }));
                    }
                    catch (Exception)
                    {
                        throw new NotImplementedException("The List type " + typeofT.Name + " must implement a parameterless instance method DeepCopy() that returns a deep copy of the instance.");
                    }
                }
                else
                    foreach (T element in hashset)
                        if (element == null) copy.Add(default(T));
                        else copy.Add((T)deepCopy.Invoke(element, new object[0]));
            }
            return copy;
        }








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
            Type typeofKey = typeof(TKey);
            Type typeofValue = typeof(TValue);

            if (typeofKey.IsValueType)

                if (typeofValue.IsValueType)
                    foreach (KeyValuePair<TKey, TValue> kvp in dict)
                        copy.Add(kvp.Key, kvp.Value);

                else
                {
                    MethodInfo valueDeepCopy = typeofValue.GetMethod("DeepCopy"); // defined in TValue class definition
                    if (valueDeepCopy == null)
                        if (typeofValue.IsGenericType) //anything but arrays
                            valueDeepCopy = GetMethodInfo(typeofValue).MakeGenericMethod(typeofValue.GetGenericArguments());
                        else if (typeofValue.IsArray) //arrays 
                            valueDeepCopy = ArrayMethodInfo.MakeGenericMethod(new[] { typeofValue.GetElementType() });
                    foreach (KeyValuePair<TKey, TValue> kvp in dict)
                        try
                        {
                            copy.Add(kvp.Key, (TValue)valueDeepCopy.Invoke(null, new object[] { kvp.Value }));
                        }
                        catch (Exception)
                        {
                            throw new NotImplementedException("The value type " + typeofValue.Name + " must implement a parameterless instance method DeepCopy() that returns a deep copy of the instance.");
                        }
                }

            else
            {
                if (typeofValue.IsValueType)
                {
                    MethodInfo keyDeepCopy = typeofKey.GetMethod("DeepCopy"); // defined in TKey class definition
                    if (keyDeepCopy == null)
                        if (typeofValue.IsGenericType) //anything but arrays
                            keyDeepCopy = GetMethodInfo(typeofKey).MakeGenericMethod(typeofKey.GetGenericArguments());
                        else if (typeofValue.IsArray) //arrays 
                            keyDeepCopy = ArrayMethodInfo.MakeGenericMethod(new[] { typeofKey.GetElementType() });
                    foreach (KeyValuePair<TKey, TValue> kvp in dict)
                        try
                        {
                            copy.Add((TKey)keyDeepCopy.Invoke(null, new object[] { kvp.Key }), kvp.Value);
                        }
                        catch (Exception)
                        {
                            throw new NotImplementedException("The key type " + typeofValue.Name + " must implement a parameterless instance method DeepCopy() that returns a deep copy of the instance.");
                        }
                }

                else
                {
                    MethodInfo valueDeepCopy = typeofValue.GetMethod("DeepCopy"); // defined in TValue class definition
                    if (valueDeepCopy == null)
                        if (typeofValue.IsGenericType) //anything but arrays
                            valueDeepCopy = GetMethodInfo(typeofValue).MakeGenericMethod(typeofValue.GetGenericArguments());
                        else if (typeofValue.IsArray) //arrays 
                            valueDeepCopy = ArrayMethodInfo.MakeGenericMethod(new[] { typeofValue.GetElementType() });

                    MethodInfo keyDeepCopy = typeofKey.GetMethod("DeepCopy"); // defined in TKey class definition
                    if (keyDeepCopy == null)
                        if (typeofValue.IsGenericType) //anything but arrays
                            keyDeepCopy = GetMethodInfo(typeofKey).MakeGenericMethod(typeofKey.GetGenericArguments());
                        else if (typeofValue.IsArray) //arrays 
                            keyDeepCopy = ArrayMethodInfo.MakeGenericMethod(new[] { typeofKey.GetElementType() });

                    foreach (KeyValuePair<TKey, TValue> kvp in dict)
                        try
                        {
                            copy.Add(
                                (TKey)keyDeepCopy.Invoke(null, new object[] { kvp.Key }),
                                (TValue)valueDeepCopy.Invoke(null, new object[] { kvp.Value }));
                        }
                        catch (Exception)
                        {
                            throw new NotImplementedException("Both the key type " + typeofKey.Name + " and the value type " + typeofValue.Name + " must implement a parameterless instance method DeepCopy() that returns a deep copy of the instance.");
                        }
                }
            }



            return copy;
        }






















        








    }
}
