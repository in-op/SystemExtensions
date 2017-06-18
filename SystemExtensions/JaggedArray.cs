using System;

namespace SystemExtensions
{
    /// <summary>
    /// A class of static generic methods for initializing jagged arrays
    /// of multiple dimensions.
    /// </summary>
    public static class JaggedArray
    {
        /// <summary>
        /// Returns a new 1D array of the specified length.
        /// Each element is initialized to T's default value.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="length">The length of the array.</param>
        public static T[] Create<T>(
            int length)
        {
            return new T[length];
        }

        /// <summary>
        /// Returns a new 1D array of the specified length.
        /// Each element is initialized to val.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="length">The length of the array.</param>
        /// <param name="val">The initialization value.</param>
        public static T[] Create<T>(
            int length,
            T val)
            where T : struct
        {
            T[] output = new T[length];
            for (int i = 0; i < length; i++)
                output[i] = val;
            return output;
        }

        /// <summary>
        /// Returns a new array of the specified length.
        /// Each element is initialized to
        /// the return value of the given func delegate.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="length">The length of the array.</param>
        /// <param name="func">A delegate to initialize each element.</param>
        /// <returns></returns>
        public static T[] Create<T>(
            int length,
            Func<T> func)
        {
            T[] output = new T[length];
            for (int i = 0; i < length; i++)
                output[i] = func.Invoke();
            return output;
        }
        
        
        
        
        
        
        /// <summary>
        /// Returns a new 2D array of the specified lengths.
        /// Each element is initialized to T's default value.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="length1D">The length of array in the 1st dimension.</param>
        /// <param name="length2D">The length of all arrays in the 2nd dimension.</param>
        /// <returns></returns>
        public static T[][] Create<T>(
            int length1D,
            int length2D)
        {
            T[][] output = new T[length1D][];
            for (int i = 0; i < length1D; i++)
                output[i] = new T[length2D];
            return output;
        }

        /// <summary>
        /// Returns a new 2D array of the specified lengths,
        /// where the length of each array in the 2nd dimension is specified individually.
        /// Each element is initialized to T's default value.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="length1D">The length of the array in the 1st dimension.</param>
        /// <param name="lengths2D">The length of each individual array in the 2nd dimension.</param>
        /// <returns></returns>
        public static T[][] Create<T>(
            int length1D,
            int[] lengths2D)
        {
            T[][] output = new T[length1D][];
            for (int i = 0; i < length1D; i++)
                output[i] = new T[lengths2D[i]];
            return output;
        }

        /// <summary>
        /// Returns a new 2D array of the specified lengths.
        /// Each element is initialized to val.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="length1D">The length of the array in the 1st dimension.</param>
        /// <param name="length2D">The length of all arrays in the 2nd dimension.</param>
        /// <param name="val">The initialization value.</param>
        /// <returns></returns>
        public static T[][] Create<T>(
            int length1D,
            int length2D,
            T val)
            where T : struct
        {
            T[][] output = new T[length1D][];
            for (int i = 0; i < length1D; i++)
            {
                output[i] = new T[length2D];
                for (int j = 0; j < length2D; j++)
                    output[i][j] = val;
            }
            return output;
        }

        /// <summary>
        /// Returns a new 2D array of the specified lengths,
        /// where the length of each array in the 2nd dimension is specified individually.
        /// Each element is initialized to val.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="length1D">The length of the array in the 1st dimension.</param>
        /// <param name="lengths2D">The length of each individual array in the 2nd dimension.</param>
        /// <param name="val">The initialization value.</param>
        /// <returns></returns>
        public static T[][] Create<T>(
            int length1D,
            int[] lengths2D,
            T val)
            where T : struct
        {
            T[][] output = new T[length1D][];
            for (int i = 0; i < length1D; i++)
            {
                output[i] = new T[lengths2D[i]];
                for (int j = 0; j < lengths2D[i]; j++)
                    output[i][j] = val;
            }
            return output;
        }

        /// <summary>
        /// Returns a 2D array of the specified lengths.
        /// Each element is initialized to the return value of the given func delegate.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="length1D">The length of the array in the 1st dimension.</param>
        /// <param name="length2D">The length of all arrays in the 2nd dimension.</param>
        /// <param name="func">A delegate to initialize each element.</param>
        /// <returns></returns>
        public static T[][] Create<T>(
            int length1D,
            int length2D,
            Func<T> func)
        {
            T[][] output = new T[length1D][];
            for (int i = 0; i < length1D; i++)
            {
                output[i] = new T[length2D];
                for (int j = 0; j < length2D; j++)
                    output[i][j] = func.Invoke();
            }
            return output;
        }

        /// <summary>
        /// Returns a 2D array of the specified lengths,
        /// where the length of each array in the 2nd dimension is specified individually.
        /// Each element is initialized to the return value of the given func delegate.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="length1D">The length of the array in the 1st dimension.</param>
        /// <param name="lengths2D">The length of each individual array in the 2nd dimension.</param>
        /// <param name="func">A delegate to initialize each element.</param>
        /// <returns></returns>
        public static T[][] Create<T>(
            int length1D,
            int[] lengths2D,
            Func<T> func)
        {
            T[][] output = new T[length1D][];
            for (int i = 0; i < length1D; i++)
            {
                output[i] = new T[lengths2D[i]];
                for (int j = 0; j < lengths2D[i]; j++)
                    output[i][j] = func.Invoke();
            }
            return output;
        }









        /// <summary>
        /// Returns a new 3D array of the specified lengths.
        /// Each element is initialized to T's default value.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="length1D">The length of the array in the 1st dimension.</param>
        /// <param name="length2D">The length of all arrays in the 2nd dimension.</param>
        /// <param name="length3D">The length of all arrays in the 3rd dimension.</param>
        /// <returns></returns>
        public static T[][][] Create<T>(
            int length1D,
            int length2D,
            int length3D)
        {
            T[][][] output = new T[length1D][][];
            for (int i = 0; i < length1D; i++)
            {
                output[i] = new T[length2D][];
                for (int j = 0; j < length2D; j++)
                    output[i][j] = new T[length3D];
            }
            return output;
        }

        /// <summary>
        /// Returns a 3D array of the specified lengths,
        /// where the length of each array in the 3rd dimension is specified individually.
        /// Each element is initialized to T's default value.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="length1D">The length of the array in the 1st dimension.</param>
        /// <param name="length2D">The length of all arrays in the 2nd dimension.</param>
        /// <param name="lengths3D">The length of each individual array in the 3rd dimension.</param>
        /// <returns></returns>
        public static T[][][] Create<T>(
            int length1D,
            int length2D,
            int[] lengths3D)
        {
            T[][][] output = new T[length1D][][];
            for (int i = 0; i < length1D; i++)
            {
                output[i] = new T[length2D][];
                for (int j = 0; j < length2D; j++)
                    output[i][j] = new T[lengths3D[j]];
            }
            return output;
        }

        /// <summary>
        /// Returns a new 3D array with the specified lengths.
        /// Each element is initialized to val.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="length1D">The length of the array in the 1st dimension.</param>
        /// <param name="length2D">The length of all arrays in the 2nd dimension.</param>
        /// <param name="length3D">The length of all arrays in the 3rd dimension.</param>
        /// <param name="val">The initialization value.</param>
        /// <returns></returns>
        public static T[][][] Create<T>(
            int length1D,
            int length2D,
            int length3D,
            T val)
            where T : struct
        {
            T[][][] output = new T[length1D][][];
            for (int i = 0; i < length1D; i++)
            {
                output[i] = new T[length2D][];
                for (int j = 0; j < length2D; j++)
                {
                    output[i][j] = new T[length3D];
                    for (int k = 0; k < length3D; k++)
                        output[i][j][k] = val;
                }
            }
            return output;
        }

        /// <summary>
        /// Returns a 3D array with the specified lengths,
        /// where the length of each array in the 3rd dimension is specified individually.
        /// Each element is initialized to val.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="length1D">The length of the array in the 1st dimension.</param>
        /// <param name="length2D">The length of all arrays in the 2nd dimension.</param>
        /// <param name="lengths3D">The length of each individual array in the 3rd dimension.</param>
        /// <param name="val">The initialization value.</param>
        /// <returns></returns>
        public static T[][][] Create<T>(
            int length1D,
            int length2D,
            int[] lengths3D,
            T val)
            where T : struct
        {
            T[][][] output = new T[length1D][][];
            for (int i = 0; i < length1D; i++)
            {
                output[i] = new T[length2D][];
                for (int j = 0; j < length2D; j++)
                {
                    output[i][j] = new T[lengths3D[j]];
                    for (int k = 0; k < lengths3D[j]; k++)
                        output[i][j][k] = val;
                }
            }
            return output;
        }

        /// <summary>
        /// Returns a 3D array of the specified lengths.
        /// Each element is initialized to the return value of the given func delegate.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="length1D">The length of the array in the 1st dimension.</param>
        /// <param name="length2D">The length of all arrays in the 2nd dimension.</param>
        /// <param name="length3D">The length of all arrays in the 3rd dimension.</param>
        /// <param name="func">A delegate to initialize each element.</param>
        /// <returns></returns>
        public static T[][][] Create<T>(
            int length1D,
            int length2D,
            int length3D,
            Func<T> func)
        {
            T[][][] output = new T[length1D][][];
            for (int i = 0; i < length1D; i++)
            {
                output[i] = new T[length2D][];
                for (int j = 0; j < length2D; j++)
                {
                    output[i][j] = new T[length3D];
                    for (int k = 0; k < length3D; k++)
                        output[i][j][k] = func.Invoke();
                }
                    
            }
            return output;
        }

        /// <summary>
        /// Returns a 3D array of the specified lengths,
        /// where the length of each array in the 3rd dimension is specified individually.
        /// Each element is initialized to the return value of the given func delegate.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="length1D">The length of the array in the 1st dimension.</param>
        /// <param name="length2D">The length of all arrays in the 2nd dimension.</param>
        /// <param name="lengths3D">The length of each individual array in the 3rd dimension.</param>
        /// <param name="func">A delegate to initialize each element.</param>
        /// <returns></returns>
        public static T[][][] Create<T>(
            int length1D,
            int length2D,
            int[] lengths3D,
            Func<T> func)
        {
            T[][][] output = new T[length1D][][];
            for (int i = 0; i < length1D; i++)
            {
                output[i] = new T[length2D][];
                for (int j = 0; j < length2D; j++)
                {
                    output[i][j] = new T[lengths3D[j]];
                    for (int k = 0; k < lengths3D[j]; k++)
                        output[i][j][k] = func.Invoke();
                }
            }
            return output;
        }








        /// <summary>
        /// Returns a new 4D array of the specified lengths.
        /// Each element is initialized to T's default value.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="length1D">The length of the array in the 1st dimension.</param>
        /// <param name="length2D">The length of all arrays in the 2nd dimension.</param>
        /// <param name="length3D">The length of all arrays in the 3rd dimension.</param>
        /// <param name="length4D">The length of all arrays in the 4th dimension.</param>
        /// <returns></returns>
        public static T[][][][] Create<T>(
            int length1D,
            int length2D,
            int length3D,
            int length4D)
        {
            T[][][][] output = new T[length1D][][][];
            for (int i = 0; i < length1D; i++)
            {
                output[i] = new T[length2D][][];
                for (int j = 0; j < length2D; j++)
                {
                    output[i][j] = new T[length3D][];
                    for (int k = 0; k < length3D; k++)
                        output[i][j][k] = new T[length4D];
                }
            }
            return output;
        }

        /// <summary>
        /// Returns a 4D array of the specified lengths,
        /// where the length of each array in the 4th dimension is specified individually.
        /// Each element is initialized to T's default value.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="length1D">The length of the array of the 1st dimension.</param>
        /// <param name="length2D">The length of all arrays in the 2nd dimension.</param>
        /// <param name="length3D">The length of all arrays in the 3rd dimension.</param>
        /// <param name="lengths4D">The length of each individual array in the 4th dimension.</param>
        /// <returns></returns>
        public static T[][][][] Create<T>(
            int length1D,
            int length2D,
            int length3D,
            int[] lengths4D)
        {
            T[][][][] output = new T[length1D][][][];
            for (int i = 0; i < length1D; i++)
            {
                output[i] = new T[length2D][][];
                for (int j = 0; j < length2D; j++)
                {
                    output[i][j] = new T[length3D][];
                    for (int k = 0; k < length3D; k++)
                        output[i][j][k] = new T[lengths4D[k]];
                }
            }
            return output;
        }

        /// <summary>
        /// Returns a new 4D array of the specified lengths.
        /// Each element is initialized to val.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="length1D">The length of the array in the 1st dimension.</param>
        /// <param name="length2D">The length of all arrays in the 2nd dimension.</param>
        /// <param name="length3D">The length of all arrays in the 3rd dimension.</param>
        /// <param name="length4D">The length of all arrays in the 4th dimension.</param>
        /// <param name="val">The initialization value.</param>
        /// <returns></returns>
        public static T[][][][] Create<T>(
            int length1D,
            int length2D,
            int length3D,
            int length4D,
            T val)
            where T : struct
        {
            T[][][][] output = new T[length1D][][][];
            for (int i = 0; i < length1D; i++)
            {
                output[i] = new T[length2D][][];
                for (int j = 0; j < length2D; j++)
                {
                    output[i][j] = new T[length3D][];
                    for (int k = 0; k < length3D; k++)
                    {
                        output[i][j][k] = new T[length4D];
                        for (int m = 0; m < length4D; m++)
                            output[i][j][k][m] = val;
                    }
                }
            }
            return output;
        }

        /// <summary>
        /// Returns a 4D array with the specified lengths,
        /// where the length of each array in the 4th dimension is specified individually.
        /// Each element is initialized to val.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="length1D">The length of the array in the 1st dimension</param>
        /// <param name="length2D">The length of all arrays in the 2nd dimension</param>
        /// <param name="length3D">The length of all arrays in the 3rd dimension</param>
        /// <param name="lengths4D">The length of each individual array in the 4th dimension</param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static T[][][][] Create<T>(
            int length1D,
            int length2D,
            int length3D,
            int[] lengths4D,
            T val)
            where T : struct
        {
            T[][][][] output = new T[length1D][][][];
            for (int i = 0; i < length1D; i++)
            {
                output[i] = new T[length2D][][];
                for (int j = 0; j < length2D; j++)
                {
                    output[i][j] = new T[length3D][];
                    for (int k = 0; k < length3D; k++)
                    {
                        output[i][j][k] = new T[lengths4D[k]];
                        for (int m = 0; m < lengths4D[k]; m++)
                            output[i][j][k][m] = val;
                    }
                }
            }
            return output;
        }

        /// <summary>
        /// Returns a 4D array with the specified lengths.
        /// Each element is initialized to the return value of the given func delegate.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="length1D">The length of the first array.</param>
        /// <param name="length2D">The length of each secondary array.</param>
        /// <param name="length3D">The length of each tertiary array.</param>
        /// <param name="length4D">The length of each 4th array.</param>
        /// <param name="func">A delegate to initialize each element.</param>
        /// <returns></returns>
        public static T[][][][] Create<T>(
            int length1D,
            int length2D,
            int length3D,
            int length4D,
            Func<T> func)
        {
            T[][][][] output = new T[length1D][][][];
            for (int i = 0; i < length1D; i++)
            {
                output[i] = new T[length2D][][];
                for (int j = 0; j < length2D; j++)
                {
                    output[i][j] = new T[length3D][];
                    for (int k = 0; k < length3D; k++)
                    {
                        output[i][j][k] = new T[length4D];
                        for (int m = 0; m < length4D; m++)
                            output[i][j][k][m] = func.Invoke();
                    }
                }

            }
            return output;
        }

        /// <summary>
        /// Returns a 4D array with the specified lengths,
        /// where the length of each array in the 4th dimension is specified individually.
        /// Each element is initialized to the return value of the given func delegate.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="length1D">The length of the array in the 1st dimension.</param>
        /// <param name="length2D">The length of all arrays in the 2nd dimension</param>
        /// <param name="length3D">The length of all arrays in the 3rd dimension</param>
        /// <param name="lengths4D">The length of each individual array in the 4th dimension.</param>
        /// <param name="func">A delegate to initialize each element.</param>
        /// <returns></returns>
        public static T[][][][] Create<T>(
            int length1D,
            int length2D,
            int length3D,
            int[] lengths4D,
            Func<T> func)
            where T : struct
        {
            T[][][][] output = new T[length1D][][][];
            for (int i = 0; i < length1D; i++)
            {
                output[i] = new T[length2D][][];
                for (int j = 0; j < length2D; j++)
                {
                    output[i][j] = new T[length3D][];
                    for (int k = 0; k < length3D; k++)
                    {
                        output[i][j][k] = new T[lengths4D[k]];
                        for (int m = 0; m < lengths4D[k]; m++)
                            output[i][j][k][m] = func.Invoke();
                    }
                }
            }
            return output;
        }









        /// <summary>
        /// Returns a new 5D array with the specified lengths.
        /// Each element is initialized to T's default value.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="length1D">The length of the array in the 1st dimension.</param>
        /// <param name="length2D">The length of all arrays in the 2nd dimension.</param>
        /// <param name="length3D">The length of all arrays in the 3rd dimension.</param>
        /// <param name="length4D">The length of all arrays in the 4th dimension.</param>
        /// <param name="length5D">The length of all arrays in the 5th dimension.</param>
        /// <returns></returns>
        public static T[][][][][] Create<T>(
            int length1D,
            int length2D,
            int length3D,
            int length4D,
            int length5D)
        {
            T[][][][][] output = new T[length1D][][][][];
            for (int i = 0; i < length1D; i++)
            {
                output[i] = new T[length2D][][][];
                for (int j = 0; j < length2D; j++)
                {
                    output[i][j] = new T[length3D][][];
                    for (int k = 0; k < length3D; k++)
                    {
                        output[i][j][k] = new T[length4D][];
                        for (int l = 0; l < length4D; l++)
                            output[i][j][k][l] = new T[length5D];
                    }
                }
            }
            return output;
        }

        /// <summary>
        /// Returns a new 5D array with the specified lengths,
        /// where the length of each array in the 5th dimension is specified individually.
        /// Each element is initialized to T's default value.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="length1D">The length of the array in the 1st dimension.</param>
        /// <param name="length2D">The length of all arrays in the 2nd dimension.</param>
        /// <param name="length3D">The length of all arrays in the 3rd dimension.</param>
        /// <param name="length4D">The length of all arrays in the 4th dimension.</param>
        /// <param name="lengths5D">The length of each individual array in the 5th dimension.</param>
        /// <returns></returns>
        public static T[][][][][] Create<T>(
            int length1D,
            int length2D,
            int length3D,
            int length4D,
            int[] lengths5D)
        {
            T[][][][][] output = new T[length1D][][][][];
            for (int i = 0; i < length1D; i++)
            {
                output[i] = new T[length2D][][][];
                for (int j = 0; j < length2D; j++)
                {
                    output[i][j] = new T[length3D][][];
                    for (int k = 0; k < length3D; k++)
                    {
                        output[i][j][k] = new T[length4D][];
                        for (int m = 0; m < length4D; m++)
                            output[i][j][k][m] = new T[lengths5D[m]];
                    }
                }
            }
            return output;
        }

        /// <summary>
        /// Returns a new 5D array with the specified lengths.
        /// Each element is initialized to val.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="length1D">The length of the array in the 1st dimension.</param>
        /// <param name="length2D">The length of all arrays in the 2nd dimension.</param>
        /// <param name="length3D">The length of all arrays in the 3rd dimension.</param>
        /// <param name="length4D">The length of all arrays in the 4th dimension.</param>
        /// <param name="length5D">The length of all arrays in the 5th dimension.</param>
        /// <param name="val">The initialization value.</param>
        /// <returns></returns>
        public static T[][][][][] Create<T>(
            int length1D,
            int length2D,
            int length3D,
            int length4D,
            int length5D,
            T val)
            where T : struct
        {
            T[][][][][] output = new T[length1D][][][][];
            for (int i = 0; i < length1D; i++)
            {
                output[i] = new T[length2D][][][];
                for (int j = 0; j < length2D; j++)
                {
                    output[i][j] = new T[length3D][][];
                    for (int k = 0; k < length3D; k++)
                    {
                        output[i][j][k] = new T[length4D][];
                        for (int m = 0; m < length3D; m++)
                        {
                            output[i][j][k][m] = new T[length5D];
                            for (int n = 0; n < length5D; n++)
                                output[i][j][k][m][n] = val;
                        }
                    }
                }
            }
            return output;
        }

        /// <summary>
        /// Returns a new 5D array with the specified lengths,
        /// where the length of each array in the 5th dimension is specified individually.
        /// Each element is initialized to val.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="length1D">The length of the array in the 1st dimension.</param>
        /// <param name="length2D">The length of all arrays in the 2nd dimension.</param>
        /// <param name="length3D">The length of all arrays in the 3rd dimension.</param>
        /// <param name="length4D">The length of all arrays in the 4th dimension.</param>
        /// <param name="lengths5D">The length of each individual array in the 5th dimension.</param>
        /// <param name="val">The initialization value.</param>
        /// <returns></returns>
        public static T[][][][][] Create<T>(
            int length1D,
            int length2D,
            int length3D,
            int length4D,
            int[] lengths5D,
            T val)
            where T : struct
        {
            T[][][][][] output = new T[length1D][][][][];
            for (int i = 0; i < length1D; i++)
            {
                output[i] = new T[length2D][][][];
                for (int j = 0; j < length2D; j++)
                {
                    output[i][j] = new T[length3D][][];
                    for (int k = 0; k < length3D; k++)
                    {
                        output[i][j][k] = new T[length4D][];
                        for (int m = 0; m < length3D; m++)
                        {
                            output[i][j][k][m] = new T[lengths5D[m]];
                            for (int n = 0; n < lengths5D[m]; n++)
                                output[i][j][k][m][n] = val;
                        }
                    }
                }
            }
            return output;
        }
        /// <summary>
        /// Returns a 5D array of with the specified lengths.
        /// Each element is initialized to the return value of the given func delegate.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="length1D">The length of the array in the 1st dimension.</param>
        /// <param name="length2D">The length of all arrays in the 2nd dimension.</param>
        /// <param name="length3D">The length of all arrays in the 3rd dimension.</param>
        /// <param name="length4D">The length of all arrays in the 4th dimension.</param>
        /// <param name="length5D">The length of all arrays in the 5th dimension.</param>
        /// <param name="func">A delegate to initialize each element.</param>
        /// <returns></returns>
        public static T[][][][][] Create<T>(
            int length1D,
            int length2D,
            int length3D,
            int length4D,
            int length5D,
            Func<T> func)
        {
            T[][][][][] output = new T[length1D][][][][];
            for (int i = 0; i < length1D; i++)
            {
                output[i] = new T[length2D][][][];
                for (int j = 0; j < length2D; j++)
                {
                    output[i][j] = new T[length3D][][];
                    for (int k = 0; k < length3D; k++)
                    {
                        output[i][j][k] = new T[length4D][];
                        for (int m = 0; m < length4D; m++)
                        {
                            output[i][j][k][m] = new T[length5D];
                            for (int n = 0; n < length5D; n++)
                                output[i][j][k][m][n] = func.Invoke();
                        }  
                    }
                }

            }
            return output;
        }

        /// <summary>
        /// Returns a 5D array of with the specified lengths,
        /// where the length of each array in the 5th dimension is individually specified.
        /// Each element is initialized to the return value of the given func delegate.
        /// </summary>
        /// <typeparam name="T">The array type.</typeparam>
        /// <param name="length1D">The length of the array in the 1st dimension.</param>
        /// <param name="length2D">The length of all arrays in the 2nd dimension.</param>
        /// <param name="length3D">The length of all arrays in the 3rd dimension.</param>
        /// <param name="length4D">The length of all arrays in the 4th dimension.</param>
        /// <param name="lengths5D">The length of each individual array in the 5th dimension.</param>
        /// <param name="func">A delegate to initialize each element.</param>
        /// <returns></returns>
        public static T[][][][][] Create<T>(
            int length1D,
            int length2D,
            int length3D,
            int length4D,
            int[] lengths5D,
            Func<T> func)
        {
            T[][][][][] output = new T[length1D][][][][];
            for (int i = 0; i < length1D; i++)
            {
                output[i] = new T[length2D][][][];
                for (int j = 0; j < length2D; j++)
                {
                    output[i][j] = new T[length3D][][];
                    for (int k = 0; k < length3D; k++)
                    {
                        output[i][j][k] = new T[length4D][];
                        for (int m = 0; m < length3D; m++)
                        {
                            output[i][j][k][m] = new T[lengths5D[m]];
                            for (int n = 0; n < lengths5D[m]; n++)
                                output[i][j][k][m][n] = func.Invoke();
                        }
                    }
                }
            }
            return output;
        }











    }
}
