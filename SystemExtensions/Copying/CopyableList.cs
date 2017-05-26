using System;
using System.Collections.Generic;

namespace SystemExtensions.Copying
{
    public static class CopyableList
    {
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
            if (typeof(T).IsValueType)
                for (int i = 0; i < count; i++)
                    copy.Add(list[i]);
            else
                for (int i = 0; i < count; i++)
                    if (list[i] == null) copy.Add(default(T));
                    else
                        try
                        {
                            object item = list[i];
                            var deepCopy = item.GetType().GetMethod("DeepCopy");
                            copy.Add((T)deepCopy.Invoke(item, new object[0]));
                        }
                        catch
                        {
                            throw new Exception("The List type " + typeof(T).Name + " must implement a parameterless instance method DeepCopy() that returns a deep copy of the instance.");
                        }
            return copy;
        }
    }
}
