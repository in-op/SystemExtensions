using System;

namespace SystemExtensions
{
    public static class JaggedArray
    {
        /// <summary>
        /// Returns a 1D array of size X.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array</typeparam>
        /// <param name="x">The size of the array</param>
        public static T[] Create<T>(int x)
        {
            return new T[x];
        }

        /// <summary>
        /// Returns an array of size X. Every element is initialized to either VAL, if value type,
        /// or with new instances from the type's default constructor, if reference type.
        /// </summary>
        public static T[] Create<T>(int x, T val)
        {
            T[] output = new T[x];
            if (typeof(T).IsValueType || val == null)
                for (int i = 0; i < x; i++)
                    output[i] = val;
            else
                for (int i = 0; i < x; i++)
                    output[i] = Activator.CreateInstance<T>();
            return output;
        }






        /// <summary>
        /// Returns a 2D array of size X, Y.
        /// </summary>
        public static T[][] Create<T>(int x, int y)
        {
            T[][] output = new T[x][];
            for (int i = 0; i < x; i++)
                output[i] = new T[y];
            return output;
        }
        /// <summary>
        /// Returns a 2D array of size X, Y.  Every element is initialized to either VAL, if value type,
        /// or with new instances from the type's default constructor, if reference type.
        /// </summary>
        public static T[][] Create<T>(int x, int y, T val)
        {
            T[][] output = new T[x][];

            if (typeof(T).IsValueType || val == null)
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
        /// Returns a 3D array of size X, Y, Z
        /// </summary>
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
        /// Returns a 3D array of size X, Y, Z.  Every element is initialized to either VAL, if value type,
        /// or with new instances from the type's default constructor, if reference type.
        /// </summary>
        public static T[][][] Create<T>(int x, int y, int z, T val)
        {
            T[][][] output = new T[x][][];
            if (typeof(T).IsValueType || val == null)
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
        /// Returns a 4D array of size X, Y, Z, A
        /// </summary>
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
        /// Returns a 4D array of size X, Y, Z, A. Every element is initialized to either VAL, if value type,
        /// or with new instances from the type's default constructor, if reference type.
        /// </summary>
        public static T[][][][] Create<T>(int x, int y, int z, int a, T val)
        {
            T[][][][] output = new T[x][][][];
            if (typeof(T).IsValueType || val == null)
                for (int i = 0; i < x; i++)
                {
                    output[i] = new T[y][][];
                    for (int j = 0; j < y; j++)
                    {
                        output[i][j] = new T[z][];
                        for (int k = 0; k < z; k++)
                        {
                            output[i][j][k] = new T[a];
                            for (int l = 0; l < z; l++)
                                output[i][j][k][l] = val;
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
                            for (int l = 0; l < z; l++)
                                output[i][j][k][l] = Activator.CreateInstance<T>();
                        }
                    }
                }
            return output;
        }


        /// <summary>
        /// Returns a 5D array of size X, Y, Z, A, B
        /// </summary>
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






    }
}
