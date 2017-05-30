using System;

namespace SystemExtensions
{
    public static class JaggedArray
    {
        //===============================================================================
        //                                1D ARRAYS
        //===============================================================================


        /// <summary>
        /// Returns a new 1D array of length x. Each element is initialized to T's default value.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="x">The length of the array.</param>
        public static T[] Create<T>(int x)
        {
            return new T[x];
        }

        /// <summary>
        /// Returns a new 1D array of length x. Each element is initialized to either val, if value type, or with new instances from the type's default constructor, if reference type.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="x">The length of the array.</param>
        /// <param name="val">The initialization value.</param>
        public static T[] Create<T>(int x, T val)
        {
            T[] output = new T[x];
            if (typeof(T).IsValueType)
                for (int i = 0; i < x; i++)
                    output[i] = val;
            else
                for (int i = 0; i < x; i++)
                    output[i] = Activator.CreateInstance<T>();
            return output;
        }

        /// <summary>
        /// Returns a new array of length x. Each element is initialized to the return value of the given func delegate.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="x">The length of the array.</param>
        /// <param name="func">A delegate to initialize each element.</param>
        /// <returns></returns>
        public static T[] Create<T>(int x, Func<T> func)
        {
            T[] output = new T[x];
            for (int i = 0; i < x; i++)
                output[i] = func.Invoke();
            return output;
        }

        /// <summary>
        /// Returns a new array of length x. Each element is initialized to the return value of the given func delegate, which is given funcArgs as input.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <typeparam name="TFuncArgs">The type of the input parameter for the func delegate.</typeparam>
        /// <param name="x">The length of the array.</param>
        /// <param name="funcArgs">The input given to the func delegate.</param>
        /// <param name="func">A delegate to initialize each element.</param>
        /// <returns></returns>
        public static T[] Create<T, TFuncArgs>(int x, TFuncArgs funcArgs, Func<TFuncArgs, T> func)
        {
            T[] output = new T[x];
            for (int i = 0; i < x; i++)
                output[i] = func.Invoke(funcArgs);
            return output;
        }











        //===============================================================================
        //                                2D ARRAYS
        //===============================================================================
        
        /// <summary>
        /// Returns a new 2D array of lengths x, y. Each element is initialized to T's default value.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="x">The length of the first array.</param>
        /// <param name="y">The length of each secondary array.</param>
        /// <returns></returns>
        public static T[][] Create<T>(int x, int y)
        {
            T[][] output = new T[x][];
            for (int i = 0; i < x; i++)
                output[i] = new T[y];
            return output;
        }

        /// <summary>
        /// Returns a new 2D array of lengths x, y.  Each element is initialized to either val, if value type, or with new instances from the type's default constructor, if reference type.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="x">The length of the first array.</param>
        /// <param name="y">The length of each secondary array.</param>
        /// <param name="val">The initialization value.</param>
        /// <returns></returns>
        public static T[][] Create<T>(int x, int y, T val)
        {
            T[][] output = new T[x][];

            if (typeof(T).IsValueType)
                for (int i = 0; i < x; i++)
                {
                    output[i] = new T[y];
                    for (int j = 0; j < y; j++)
                        output[i][j] = val;
                }
            else
                for (int i = 0; i < x; i++)
                {
                    output[i] = new T[y];
                    for (int j = 0; j < y; j++)
                        output[i][j] = Activator.CreateInstance<T>();
                }
            return output;
        }

        /// <summary>
        /// Returns a 2D array of lengths x, y. Each element is initialized to the return value of the given func delegate.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="x">The length of the first array.</param>
        /// <param name="y">The length of each secondary array.</param>
        /// <param name="func">A delegate to initialize each element.</param>
        /// <returns></returns>
        public static T[][] Create<T>(int x, int y, Func<T> func)
        {
            T[][] output = new T[x][];
            for (int i = 0; i < x; i++)
            {
                output[i] = new T[y];
                for (int j = 0; j < y; j++)
                    output[i][j] = func.Invoke();
            }
            return output;
        }

        /// <summary>
        /// Returns a new 2D array of lengths x, y. Each element is initialized to the return value of the given func delegate, which is given funcArgs as input.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <typeparam name="TFuncArgs">The type of the input parameter for the func delegate.</typeparam>
        /// <param name="x">The length of the first array.</param>
        /// <param name="y">The length of each secondary array.</param>
        /// <param name="funcArgs">The input given to the func delegate.</param>
        /// <param name="func">A delegate to initialize each element.</param>
        /// <returns></returns>
        public static T[][] Create<T, TFuncArgs>(int x, int y, TFuncArgs funcArgs, Func<TFuncArgs, T> func)
        {
            T[][] output = new T[x][];
            for (int i = 0; i < x; i++)
            {
                output[i] = new T[y];
                for (int j = 0; j < y; j++)
                    output[i][j] = func.Invoke(funcArgs);
            }
            return output;
        }












        //===============================================================================
        //                                3D ARRAYS
        //===============================================================================

        /// <summary>
        /// Returns a new 3D array of lengths x, y, z. Each element is initialized to T's default value.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="x">The length of the first array.</param>
        /// <param name="y">The length of each secondary array.</param>
        /// <param name="z">The length of each tertiary array.</param>
        /// <returns></returns>
        public static T[][][] Create<T>(int x, int y, int z)
        {
            T[][][] output = new T[x][][];
            for (int i = 0; i < x; i++)
            {
                output[i] = new T[y][];
                for (int j = 0; j < y; j++)
                    output[i][j] = new T[z];
            }
            return output;
        }

        /// <summary>
        /// Returns a new 3D array of lengths x, y, z.  Each element is initialized to either val, if value type, or with new instances from the type's default constructor, if reference type.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="x">The length of the first array.</param>
        /// <param name="y">The length of each secondary array.</param>
        /// <param name="z">The length of each tertiary array.</param>
        /// <param name="val">The initialization value.</param>
        /// <returns></returns>
        public static T[][][] Create<T>(int x, int y, int z, T val)
        {
            T[][][] output = new T[x][][];
            if (typeof(T).IsValueType)
                for (int i = 0; i < x; i++)
                {
                    output[i] = new T[y][];
                    for (int j = 0; j < y; j++)
                    {
                        output[i][j] = new T[z];
                        for (int k = 0; k < z; k++)
                            output[i][j][k] = val;
                    }
                }
            else
                for (int i = 0; i < x; i++)
                {
                    output[i] = new T[y][];
                    for (int j = 0; j < y; j++)
                    {
                        output[i][j] = new T[z];
                        for (int k = 0; k < z; k++)
                            output[i][j][k] = Activator.CreateInstance<T>();
                    }
                }
            return output;
        }

        /// <summary>
        /// Returns a 3D array of lengths x, y, z. Each element is initialized to the return value of the given func delegate.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="x">The length of the first array.</param>
        /// <param name="y">The length of each secondary array.</param>
        /// <param name="z">The length of each tertiary array.</param>
        /// <param name="func">A delegate to initialize each element.</param>
        /// <returns></returns>
        public static T[][][] Create<T>(int x, int y, int z, Func<T> func)
        {
            T[][][] output = new T[x][][];
            for (int i = 0; i < x; i++)
            {
                output[i] = new T[y][];
                for (int j = 0; j < y; j++)
                {
                    output[i][j] = new T[z];
                    for (int k = 0; k < z; k++)
                        output[i][j][k] = func.Invoke();
                }
                    
            }
            return output;
        }

        /// <summary>
        /// Returns a new 3D array of lengths x, y, z. Each element is initialized to the return value of the given func delegate, which is given funcArgs as input.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <typeparam name="TFuncArgs">The type of the input parameter for the func delegate.</typeparam>
        /// <param name="x">The length of the first array.</param>
        /// <param name="y">The length of each secondary array.</param>
        /// <param name="z">The length of each tertiary array.</param>
        /// <param name="funcArgs">The input given to the func delegate.</param>
        /// <param name="func">A delegate to initialize each element.</param>
        /// <returns></returns>
        public static T[][][] Create<T, TFuncArgs>(int x, int y, int z, TFuncArgs funcArgs, Func<TFuncArgs, T> func)
        {
            T[][][] output = new T[x][][];
            for (int i = 0; i < x; i++)
            {
                output[i] = new T[y][];
                for (int j = 0; j < y; j++)
                {
                    output[i][j] = new T[z];
                    for (int k = 0; k < z; k++)
                        output[i][j][k] = func.Invoke(funcArgs);
                }
            }
            return output;
        }
















        //===============================================================================
        //                                4D ARRAYS
        //===============================================================================

        /// <summary>
        /// Returns a new 4D array of lengths x, y, z, a. Each element is initialized to T's default value.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="x">The length of the first array.</param>
        /// <param name="y">The length of each secondary array.</param>
        /// <param name="z">The length of each tertiary array.</param>
        /// <param name="a">The length of each 4th array.</param>
        /// <returns></returns>
        public static T[][][][] Create<T>(int x, int y, int z, int a)
        {
            T[][][][] output = new T[x][][][];
            for (int i = 0; i < x; i++)
            {
                output[i] = new T[y][][];
                for (int j = 0; j < y; j++)
                {
                    output[i][j] = new T[z][];
                    for (int k = 0; k < z; k++)
                        output[i][j][k] = new T[a];
                }
            }
            return output;
        }

        /// <summary>
        /// Returns a new 4D array of lengths x, y, z, a.  Each element is initialized to either val, if value type, or with new instances from the type's default constructor, if reference type.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="x">The length of the first array.</param>
        /// <param name="y">The length of each secondary array.</param>
        /// <param name="z">The length of each tertiary array.</param>
        /// <param name="a">The length of each 4th array.</param>
        /// <param name="val">The initialization value.</param>
        /// <returns></returns>
        public static T[][][][] Create<T>(int x, int y, int z, int a, T val)
        {
            T[][][][] output = new T[x][][][];
            if (typeof(T).IsValueType)
                for (int i = 0; i < x; i++)
                {
                    output[i] = new T[y][][];
                    for (int j = 0; j < y; j++)
                    {
                        output[i][j] = new T[z][];
                        for (int k = 0; k < z; k++)
                        {
                            output[i][j][k] = new T[a];
                            for (int m = 0; m < a; m++)
                                output[i][j][k][m] = val;
                        }
                    }
                }
            else
                for (int i = 0; i < x; i++)
                {
                    output[i] = new T[y][][];
                    for (int j = 0; j < y; j++)
                    {
                        output[i][j] = new T[z][];
                        for (int k = 0; k < z; k++)
                        {
                            output[i][j][k] = new T[a];
                            for (int m = 0; m < a; m++)
                                output[i][j][k][m] = Activator.CreateInstance<T>();
                        }
                    }
                }
            return output;
        }

        /// <summary>
        /// Returns a 4D array of lengths x, y, z, a. Each element is initialized to the return value of the given func delegate.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="x">The length of the first array.</param>
        /// <param name="y">The length of each secondary array.</param>
        /// <param name="z">The length of each tertiary array.</param>
        /// <param name="a">The length of each 4th array.</param>
        /// <param name="func">A delegate to initialize each element.</param>
        /// <returns></returns>
        public static T[][][][] Create<T>(int x, int y, int z, int a, Func<T> func)
        {
            T[][][][] output = new T[x][][][];
            for (int i = 0; i < x; i++)
            {
                output[i] = new T[y][][];
                for (int j = 0; j < y; j++)
                {
                    output[i][j] = new T[z][];
                    for (int k = 0; k < z; k++)
                    {
                        output[i][j][k] = new T[a];
                        for (int m = 0; m < a; m++)
                            output[i][j][k][m] = func.Invoke();
                    }
                }

            }
            return output;
        }

        /// <summary>
        /// Returns a new 4D array of lengths x, y, z, a. Each element is initialized to the return value of the given func delegate, which is given funcArgs as input.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <typeparam name="TFuncArgs">The type of the input parameter for the func delegate.</typeparam>
        /// <param name="x">The length of the first array.</param>
        /// <param name="y">The length of each secondary array.</param>
        /// <param name="z">The length of each tertiary array.</param>
        /// <param name="a">The length of each 4th array.</param>
        /// <param name="funcArgs">The input given to the func delegate.</param>
        /// <param name="func">A delegate to initialize each element.</param>
        /// <returns></returns>
        public static T[][][][] Create<T, TFuncArgs>(int x, int y, int z, int a, TFuncArgs funcArgs, Func<TFuncArgs, T> func)
        {
            T[][][][] output = new T[x][][][];
            for (int i = 0; i < x; i++)
            {
                output[i] = new T[y][][];
                for (int j = 0; j < y; j++)
                {
                    output[i][j] = new T[z][];
                    for (int k = 0; k < z; k++)
                    {
                        output[i][j][k] = new T[a];
                        for (int m = 0; m < a; m++)
                            output[i][j][k][m] = func.Invoke(funcArgs);
                    }
                }
            }
            return output;
        }












        //===============================================================================
        //                                5D ARRAYS
        //===============================================================================


        /// <summary>
        /// Returns a new 5D array of lengths x, y, z, a, b. Each element is initialized to T's default value.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="x">The length of the first array.</param>
        /// <param name="y">The length of each secondary array.</param>
        /// <param name="z">The length of each tertiary array.</param>
        /// <param name="a">The length of each 4th array.</param>
        /// <param name="b">The length of each 5th array.</param>
        /// <returns></returns>
        public static T[][][][][] Create<T>(int x, int y, int z, int a, int b)
        {
            T[][][][][] output = new T[x][][][][];
            for (int i = 0; i < x; i++)
            {
                output[i] = new T[y][][][];
                for (int j = 0; j < y; j++)
                {
                    output[i][j] = new T[z][][];
                    for (int k = 0; k < z; k++)
                    {
                        output[i][j][k] = new T[a][];
                        for (int l = 0; l < a; l++)
                            output[i][j][k][l] = new T[b];
                    }
                }
            }
            return output;
        }

        /// <summary>
        /// Returns a new 5D array of lengths x, y, z, a, b.  Each element is initialized to either val, if value type, or with new instances from the type's default constructor, if reference type.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="x">The length of the first array.</param>
        /// <param name="y">The length of each secondary array.</param>
        /// <param name="z">The length of each tertiary array.</param>
        /// <param name="a">The length of each 4th array.</param>
        /// <param name="b">The length of each 5th array.</param>
        /// <param name="val">The initialization value.</param>
        /// <returns></returns>
        public static T[][][][][] Create<T>(int x, int y, int z, int a, int b, T val)
        {
            T[][][][][] output = new T[x][][][][];
            if (typeof(T).IsValueType)
                for (int i = 0; i < x; i++)
                {
                    output[i] = new T[y][][][];
                    for (int j = 0; j < y; j++)
                    {
                        output[i][j] = new T[z][][];
                        for (int k = 0; k < z; k++)
                        {
                            output[i][j][k] = new T[a][];
                            for (int m = 0; m < z; m++)
                            {
                                output[i][j][k][m] = new T[b];
                                for (int n = 0; n < b; n++)
                                    output[i][j][k][m][n] = val;
                            } 
                        }
                    }
                }
            else
                for (int i = 0; i < x; i++)
                {
                    output[i] = new T[y][][][];
                    for (int j = 0; j < y; j++)
                    {
                        output[i][j] = new T[z][][];
                        for (int k = 0; k < z; k++)
                        {
                            output[i][j][k] = new T[a][];
                            for (int m = 0; m < a; m++)
                            {
                                output[i][j][k][m] = new T[b];
                                for (int n = 0; n < b; n++)
                                    output[i][j][k][m][n] = Activator.CreateInstance<T>();
                            }  
                        }
                    }
                }
            return output;
        }

        /// <summary>
        /// Returns a 5D array of lengths x, y, z, a, b. Each element is initialized to the return value of the given func delegate.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="x">The length of the first array.</param>
        /// <param name="y">The length of each secondary array.</param>
        /// <param name="z">The length of each tertiary array.</param>
        /// <param name="a">The length of each 4th array.</param>
        /// <param name="b">The length of each 5th array.</param>
        /// <param name="func">A delegate to initialize each element.</param>
        /// <returns></returns>
        public static T[][][][][] Create<T>(int x, int y, int z, int a, int b, Func<T> func)
        {
            T[][][][][] output = new T[x][][][][];
            for (int i = 0; i < x; i++)
            {
                output[i] = new T[y][][][];
                for (int j = 0; j < y; j++)
                {
                    output[i][j] = new T[z][][];
                    for (int k = 0; k < z; k++)
                    {
                        output[i][j][k] = new T[a][];
                        for (int m = 0; m < a; m++)
                        {
                            output[i][j][k][m] = new T[b];
                            for (int n = 0; n < b; n++)
                                output[i][j][k][m][n] = func.Invoke();
                        }  
                    }
                }

            }
            return output;
        }

        /// <summary>
        /// Returns a new 5D array of lengths x, y, z, a, b. Each element is initialized to the return value of the given func delegate, which is given funcArgs as input.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <typeparam name="TFuncArgs">The type of the input parameter for the func delegate.</typeparam>
        /// <param name="x">The length of the first array.</param>
        /// <param name="y">The length of each secondary array.</param>
        /// <param name="z">The length of each tertiary array.</param>
        /// <param name="a">The length of each 4th array.</param>
        /// <param name="b">The length of each 5th array.</param>
        /// <param name="funcArgs">The input given to the func delegate.</param>
        /// <param name="func">A delegate to initialize each element.</param>
        /// <returns></returns>
        public static T[][][][][] Create<T, TFuncArgs>(int x, int y, int z, int a, int b, TFuncArgs funcArgs, Func<TFuncArgs, T> func)
        {
            T[][][][][] output = new T[x][][][][];
            for (int i = 0; i < x; i++)
            {
                output[i] = new T[y][][][];
                for (int j = 0; j < y; j++)
                {
                    output[i][j] = new T[z][][];
                    for (int k = 0; k < z; k++)
                    {
                        output[i][j][k] = new T[a][];
                        for (int m = 0; m < a; m++)
                        {
                            output[i][j][k][m] = new T[b];
                            for (int n = 0; n < b; n++)
                                output[i][j][k][m][n] = func.Invoke(funcArgs);
                        }
                    }
                }
            }
            return output;
        }













    }
}
