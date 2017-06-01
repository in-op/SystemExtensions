using System;

namespace SystemExtensions.Copying
{
    /// <summary>
    /// A method class implementing a DeepCopy() extension method for arrays and jagged arrays up to 5 dimensions.
    /// </summary>
    public static class CopyableArrays
    {
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
            int x = array.Length;
            T[] copy = new T[x];
            if (typeof(T).IsValueType)
                for (int i = 0; i < x; i++)
                    copy[i] = array[i];
            else
                for (int i = 0; i < x; i++)
                    if (array[i] == null) copy[i] = default(T);
                    else
                        try
                        {
                            object item = array[i];
                            var deepCopy = item.GetType().GetMethod("DeepCopy");
                            copy[i] = (T)deepCopy.Invoke(item, new object[0]);
                        }
                        catch (ArgumentNullException)
                        {
                            throw new Exception("The array type " + typeof(T).Name + " must implement a parameterless instance method DeepCopy() which returns a deep copy of the instance.");
                        }
            return copy;
        }


        /// <summary>
        /// Returns a deep copy of the calling array utilizing multithreading.
        /// If the array type T is a reference type it
        /// must implement a parameterless instance
        /// method DeepCopy(), which returns a deep
        /// copy of the instance. If T is a value type,
        /// it must be immutable.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="array">The calling array.</param>
        /// <returns>A deep copy of the calling array.</returns>
        public static T[] ParallelDeepCopy<T>(this T[] array)
        {
            int x = array.Length;
            T[] copy = new T[x];

            if (typeof(T).IsValueType)
                System.Threading.Tasks.Parallel.For(0, x, (i) =>
                {
                    copy[i] = array[i];
                });
            else
                System.Threading.Tasks.Parallel.For(0, x, (i) =>
                {
                    if (array[i] == null) copy[i] = default(T);
                    else
                        try
                        {
                            object item = array[i];
                            var deepCopy = item.GetType().GetMethod("DeepCopy");
                            copy[i] = (T)deepCopy.Invoke(item, new object[0]);
                        }
                        catch (ArgumentNullException)
                        {
                            throw new Exception("The array type " + typeof(T).Name + " must implement a parameterless instance method DeepCopy() which returns a deep copy of the instance.");
                        }
                });

            return copy;
        }


        /// <summary>
        /// Returns a deep copy of the calling array.
        /// If the array type T is a reference type it
        /// must implement a parameterless instance
        /// method DeepCopy(), which returns a deep
        /// copy of the instance. If T is a value type,
        /// it must be immutable.
        /// </summary>
        public static T[][] DeepCopy<T>(this T[][] array)
        {
            int x = array.Length;
            T[][] copy = new T[x][];
            if (typeof(T).IsValueType)
                for (int i = 0; i < x; i++)
                {
                    int y = array[i].Length;
                    copy[i] = new T[y];
                    for (int j = 0; j < y; j++)
                        copy[i][j] = array[i][j];
                }
            else
                for (int i = 0; i < x; i++)
                {
                    int y = array[i].Length;
                    copy[i] = new T[y];
                    for (int j = 0; j < y; j++)
                        if (array[i][j] == null) copy[i][j] = default(T);
                        else
                            try
                            {
                                object item = array[i][j];
                                var deepCopy = item.GetType().GetMethod("DeepCopy");
                                copy[i][j] = (T)deepCopy.Invoke(item, new object[0]);
                            }
                            catch (ArgumentNullException)
                            {
                                throw new Exception("The array type " + typeof(T).Name + " must implement a parameterless instance method DeepCopy() which returns a deep copy of the instance.");
                            }
                }
            return copy;
        }


        /// <summary>
        /// Returns a deep copy of the calling array.
        /// If the array type T is a reference type it
        /// must implement a parameterless instance
        /// method DeepCopy(), which returns a deep
        /// copy of the instance. If T is a value type,
        /// it must be immutable.
        /// </summary>
        public static T[][] ParallelDeepCopy<T>(this T[][] array)
        {
            int x = array.Length;
            T[][] copy = new T[x][];
            if (typeof(T).IsValueType)
                System.Threading.Tasks.Parallel.For(0, x, (i) =>
                {
                    int y = array[i].Length;
                    copy[i] = new T[y];
                    for (int j = 0; j < y; j++)
                        copy[i][j] = array[i][j];
                });
            else
                System.Threading.Tasks.Parallel.For(0, x, (i) =>
                {
                    int y = array[i].Length;
                    copy[i] = new T[y];
                    for (int j = 0; j < y; j++)
                        if (array[i][j] == null) copy[i][j] = default(T);
                        else
                            try
                            {
                                object item = array[i][j];
                                var deepCopy = item.GetType().GetMethod("DeepCopy");
                                copy[i][j] = (T)deepCopy.Invoke(item, new object[0]);
                            }
                            catch (ArgumentNullException)
                            {
                                throw new Exception("The array type " + typeof(T).Name + " must implement a parameterless instance method DeepCopy() which returns a deep copy of the instance.");
                            }
                });
            return copy;
        }




        /// <summary>
        /// Returns a deep copy of the calling array.
        /// If the array type T is a reference type it
        /// must implement a parameterless instance
        /// method DeepCopy(), which returns a deep
        /// copy of the instance. If T is a value type,
        /// it must be immutable.
        /// </summary>
        public static T[][][] DeepCopy<T>(this T[][][] array)
        {
            int x = array.Length;
            T[][][] copy = new T[x][][];
            if (typeof(T).IsValueType)
                for (int i = 0; i < x; i++)
                {
                    int y = array[i].Length;
                    copy[i] = new T[y][];
                    for (int j = 0; j < y; j++)
                    {
                        int z = array[i][j].Length;
                        copy[i][j] = new T[z];
                        for (int k = 0; k < z; k++)
                            copy[i][j][k] = array[i][j][k];
                    }
                }
            else
                for (int i = 0; i < x; i++)
                {
                    int y = array[i].Length;
                    copy[i] = new T[y][];
                    for (int j = 0; j < y; j++)
                    {
                        int z = array[i][j].Length;
                        copy[i][j] = new T[z];
                        for (int k = 0; k < z; k++)
                            if (array[i][j][k] == null) copy[i][j][k] = default(T);
                            else
                                try
                                {
                                    object item = array[i][j][k];
                                    var deepCopy = item.GetType().GetMethod("DeepCopy");
                                    copy[i][j][k] = (T)deepCopy.Invoke(item, new object[0]);
                                }
                                catch (ArgumentNullException)
                                {
                                    throw new Exception("The array type " + typeof(T).Name + " must implement a parameterless instance method DeepCopy() which returns a deep copy of the instance.");
                                }
                    }
                }
            return copy;
        }


        /// <summary>
        /// Returns a deep copy of the calling array.
        /// If the array type T is a reference type it
        /// must implement a parameterless instance
        /// method DeepCopy(), which returns a deep
        /// copy of the instance. If T is a value type,
        /// it must be immutable.
        /// </summary>
        public static T[][][] ParallelDeepCopy<T>(this T[][][] array)
        {
            int x = array.Length;
            T[][][] copy = new T[x][][];
            if (typeof(T).IsValueType)
                System.Threading.Tasks.Parallel.For(0, x, (i) =>
                {
                    int y = array[i].Length;
                    copy[i] = new T[y][];
                    for (int j = 0; j < y; j++)
                    {
                        int z = array[i][j].Length;
                        copy[i][j] = new T[z];
                        for (int k = 0; k < z; k++)
                            copy[i][j][k] = array[i][j][k];
                    }
                });
            else
                System.Threading.Tasks.Parallel.For(0, x, (i) =>
                {
                    int y = array[i].Length;
                    copy[i] = new T[y][];
                    for (int j = 0; j < y; j++)
                    {
                        int z = array[i][j].Length;
                        copy[i][j] = new T[z];
                        for (int k = 0; k < z; k++)
                            if (array[i][j][k] == null) copy[i][j][k] = default(T);
                            else
                                try
                                {
                                    object item = array[i][j][k];
                                    var deepCopy = item.GetType().GetMethod("DeepCopy");
                                    copy[i][j][k] = (T)deepCopy.Invoke(item, new object[0]);
                                }
                                catch (ArgumentNullException)
                                {
                                    throw new Exception("The array type " + typeof(T).Name + " must implement a parameterless instance method DeepCopy() which returns a deep copy of the instance.");
                                }
                    }
                });
            return copy;
        }






        /// <summary>
        /// Returns a deep copy of the calling array.
        /// If the array type T is a reference type it
        /// must implement a parameterless instance
        /// method DeepCopy(), which returns a deep
        /// copy of the instance. If T is a value type,
        /// it must be immutable.
        /// </summary>
        public static T[][][][] DeepCopy<T>(this T[][][][] array)
        {
            int x = array.Length;
            T[][][][] copy = new T[x][][][];
            if (typeof(T).IsValueType)
                for (int i = 0; i < x; i++)
                {
                    int y = array[i].Length;
                    copy[i] = new T[y][][];
                    for (int j = 0; j < y; j++)
                    {
                        int z = array[i][j].Length;
                        copy[i][j] = new T[z][];
                        for (int k = 0; k < z; k++)
                        {
                            int a = array[i][j][k].Length;
                            copy[i][j][k] = new T[a];
                            for (int m = 0; m < a; m++)
                                copy[i][j][k][m] = array[i][j][k][m];
                        }
                    }
                }
            else
                for (int i = 0; i < x; i++)
                {
                    int y = array[i].Length;
                    copy[i] = new T[y][][];
                    for (int j = 0; j < y; j++)
                    {
                        int z = array[i][j].Length;
                        copy[i][j] = new T[z][];
                        for (int k = 0; k < z; k++)
                        {
                            int a = array[i][j][k].Length;
                            copy[i][j][k] = new T[a];
                            for (int m = 0; m < a; m++)
                                if (array[i][j][k][m] == null) copy[i][j][k][m] = default(T);
                                else
                                    try
                                    {
                                        object item = array[i][j][k][m];
                                        var deepCopy = item.GetType().GetMethod("DeepCopy");
                                        copy[i][j][k][m] = (T)deepCopy.Invoke(item, new object[0]);
                                    }
                                    catch (ArgumentNullException)
                                    {
                                        throw new Exception("The array type " + typeof(T).Name + " must implement a parameterless instance method DeepCopy() which returns a deep copy of the instance.");
                                    }
                        }
                    }
                }
            return copy;
        }


        /// <summary>
        /// Returns a deep copy of the calling array.
        /// If the array type T is a reference type it
        /// must implement a parameterless instance
        /// method DeepCopy(), which returns a deep
        /// copy of the instance. If T is a value type,
        /// it must be immutable.
        /// </summary>
        public static T[][][][] ParallelDeepCopy<T>(this T[][][][] array)
        {
            int x = array.Length;
            T[][][][] copy = new T[x][][][];
            if (typeof(T).IsValueType)
                System.Threading.Tasks.Parallel.For(0, x, (i) =>
                {
                    int y = array[i].Length;
                    copy[i] = new T[y][][];
                    for (int j = 0; j < y; j++)
                    {
                        int z = array[i][j].Length;
                        copy[i][j] = new T[z][];
                        for (int k = 0; k < z; k++)
                        {
                            int a = array[i][j][k].Length;
                            copy[i][j][k] = new T[a];
                            for (int m = 0; m < a; m++)
                                copy[i][j][k][m] = array[i][j][k][m];
                        }
                    }
                });
            else
                System.Threading.Tasks.Parallel.For(0, x, (i) =>
                {
                    int y = array[i].Length;
                    copy[i] = new T[y][][];
                    for (int j = 0; j < y; j++)
                    {
                        int z = array[i][j].Length;
                        copy[i][j] = new T[z][];
                        for (int k = 0; k < z; k++)
                        {
                            int a = array[i][j][k].Length;
                            copy[i][j][k] = new T[a];
                            for (int m = 0; m < a; m++)
                                if (array[i][j][k][m] == null) copy[i][j][k][m] = default(T);
                                else
                                    try
                                    {
                                        object item = array[i][j][k][m];
                                        var deepCopy = item.GetType().GetMethod("DeepCopy");
                                        copy[i][j][k][m] = (T)deepCopy.Invoke(item, new object[0]);
                                    }
                                    catch (ArgumentNullException)
                                    {
                                        throw new Exception("The array type " + typeof(T).Name + " must implement a parameterless instance method DeepCopy() which returns a deep copy of the instance.");
                                    }
                        }
                    }
                });
            return copy;
        }



        /// <summary>
        /// Returns a deep copy of the calling array.
        /// If the array type T is a reference type it
        /// must implement a parameterless instance
        /// method DeepCopy(), which returns a deep
        /// copy of the instance. If T is a value type,
        /// it must be immutable.
        /// </summary>
        public static T[][][][][] DeepCopy<T>(this T[][][][][] array)
        {
            int x = array.Length;
            T[][][][][] copy = new T[x][][][][];
            if (typeof(T).IsValueType)
                for (int i = 0; i < x; i++)
                {
                    int y = array[i].Length;
                    copy[i] = new T[y][][][];
                    for (int j = 0; j < y; j++)
                    {
                        int z = array[i][j].Length;
                        copy[i][j] = new T[z][][];
                        for (int k = 0; k < z; k++)
                        {
                            int a = array[i][j][k].Length;
                            copy[i][j][k] = new T[a][];
                            for (int m = 0; m < a; m++)
                            {
                                int b = array[i][j][k][m].Length;
                                copy[i][j][k][m] = new T[b];
                                for (int n = 0; n < b; n++)
                                    copy[i][j][k][m][n] = array[i][j][k][m][n];
                            }
                        }
                    }
                }
            else
                for (int i = 0; i < x; i++)
                {
                    int y = array[i].Length;
                    copy[i] = new T[y][][][];
                    for (int j = 0; j < y; j++)
                    {
                        int z = array[i][j].Length;
                        copy[i][j] = new T[z][][];
                        for (int k = 0; k < z; k++)
                        {
                            int a = array[i][j][k].Length;
                            copy[i][j][k] = new T[a][];
                            for (int m = 0; m < a; m++)
                            {
                                int b = array[i][j][k][m].Length;
                                copy[i][j][k][m] = new T[b];
                                for (int n = 0; n < b; n++)
                                    if (array[i][j][k][m][n] == null) copy[i][j][k][m][n] = default(T);
                                    else
                                        try
                                        {
                                            object item = array[i][j][k][m][n];
                                            var deepCopy = item.GetType().GetMethod("DeepCopy");
                                            copy[i][j][k][m][n] = (T)deepCopy.Invoke(item, new object[0]);
                                        }
                                        catch (ArgumentNullException)
                                        {
                                            throw new Exception("The array type " + typeof(T).Name + " must implement a parameterless instance method DeepCopy() which returns a deep copy of the instance.");
                                        }
                            }
                        }
                    }
                }
            return copy;
        }











        /// <summary>
        /// Returns a deep copy of the calling array, creating multiple parts of the output array in parallel.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="array">The calling array.</param>
        /// <returns>A deep copy of the array.</returns>
        public static T[][][][][] ParallelDeepCopy<T>(this T[][][][][] array)
        {
            int x = array.Length;
            T[][][][][] copy = new T[x][][][][];

            if (typeof(T).IsValueType)
                System.Threading.Tasks.Parallel.For(0, x, (i) =>
                {
                    int y = array[i].Length;
                    copy[i] = new T[y][][][];
                    for (int j = 0; j < y; j++)
                    {
                        int z = array[i][j].Length;
                        copy[i][j] = new T[z][][];
                        for (int k = 0; k < z; k++)
                        {
                            int a = array[i][j][k].Length;
                            copy[i][j][k] = new T[a][];
                            for (int m = 0; m < a; m++)
                            {
                                int b = array[i][j][k][m].Length;
                                copy[i][j][k][m] = new T[b];
                                for (int n = 0; n < b; n++)
                                    copy[i][j][k][m][n] = array[i][j][k][m][n];
                            }
                        }
                    }
                });

            else
                System.Threading.Tasks.Parallel.For(0, x, (i) =>
                {
                    int y = array[i].Length;
                    copy[i] = new T[y][][][];
                    for (int j = 0; j < y; j++)
                    {
                        int z = array[i][j].Length;
                        copy[i][j] = new T[z][][];
                        for (int k = 0; k < z; k++)
                        {
                            int a = array[i][j][k].Length;
                            copy[i][j][k] = new T[a][];
                            for (int m = 0; m < a; m++)
                            {
                                int b = array[i][j][k][m].Length;
                                copy[i][j][k][m] = new T[b];
                                for (int n = 0; n < b; n++)
                                    if (array[i][j][k][m][n] == null) copy[i][j][k][m][n] = default(T);
                                    else
                                        try
                                        {
                                            object item = array[i][j][k][m][n];
                                            var deepCopy = item.GetType().GetMethod("DeepCopy");
                                            copy[i][j][k][m][n] = (T)deepCopy.Invoke(item, new object[0]);
                                        }
                                        catch (ArgumentNullException)
                                        {
                                            throw new Exception("The array type " + typeof(T).Name + " must implement a parameterless instance method DeepCopy() which returns a deep copy of the instance.");
                                        }
                            }
                        }
                    }
                });

            return copy;
        }





    }
}
