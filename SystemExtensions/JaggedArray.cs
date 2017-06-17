using System;
using System.Collections.Generic;

namespace SystemExtensions
{
    /// <summary>
    /// A class of static generic methods for initializing jagged arrays
    /// of multiple dimensions.
    /// </summary>
    public static class JaggedArray
    {
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
        /// Returns a new 1D array of length x. Each element is initialized to val.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="x">The length of the array.</param>
        /// <param name="val">The initialization value.</param>
        public static T[] Create<T>(int x, T val) where T : struct
        {
            T[] output = new T[x];
            for (int i = 0; i < x; i++)
                output[i] = val;
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
        /// Returns a new 2D array of lengths x, y.  Each element is initialized to val.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="x">The length of the first array.</param>
        /// <param name="y">The length of each secondary array.</param>
        /// <param name="val">The initialization value.</param>
        /// <returns></returns>
        public static T[][] Create<T>(int x, int y, T val) where T : struct
        {
            T[][] output = new T[x][];
            for (int i = 0; i < x; i++)
            {
                output[i] = new T[y];
                for (int j = 0; j < y; j++)
                    output[i][j] = val;
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
        /// Returns a new 3D array of lengths x, y, z.  Each element is initialized to val.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="x">The length of the first array.</param>
        /// <param name="y">The length of each secondary array.</param>
        /// <param name="z">The length of each tertiary array.</param>
        /// <param name="val">The initialization value.</param>
        /// <returns></returns>
        public static T[][][] Create<T>(int x, int y, int z, T val) where T : struct
        {
            T[][][] output = new T[x][][];
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
        /// Returns a new 4D array of lengths x, y, z, a.  Each element is initialized to val.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="x">The length of the first array.</param>
        /// <param name="y">The length of each secondary array.</param>
        /// <param name="z">The length of each tertiary array.</param>
        /// <param name="a">The length of each 4th array.</param>
        /// <param name="val">The initialization value.</param>
        /// <returns></returns>
        public static T[][][][] Create<T>(int x, int y, int z, int a, T val) where T : struct
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
                            output[i][j][k][m] = val;
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
        /// Returns a new 5D array of lengths x, y, z, a, b.  Each element is initialized to val.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="x">The length of the first array.</param>
        /// <param name="y">The length of each secondary array.</param>
        /// <param name="z">The length of each tertiary array.</param>
        /// <param name="a">The length of each 4th array.</param>
        /// <param name="b">The length of each 5th array.</param>
        /// <param name="val">The initialization value.</param>
        /// <returns></returns>
        public static T[][][][][] Create<T>(int x, int y, int z, int a, int b, T val) where T : struct
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
                        for (int m = 0; m < z; m++)
                        {
                            output[i][j][k][m] = new T[b];
                            for (int n = 0; n < b; n++)
                                output[i][j][k][m][n] = val;
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
        










    }
}
