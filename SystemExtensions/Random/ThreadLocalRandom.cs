using System;
using System.Threading;

/// <summary>
/// CITATION for this class:
/// https://codeblog.jonskeet.uk/2009/11/04/revisiting-randomness/
/// </summary>

namespace SystemExtensions.Random
{
    /// <summary> 
    /// Convenience class for dealing with randomness. 
    /// </summary> 
    public static class ThreadLocalRandom
    {
        /// <summary> 
        /// Random number generator used to generate seeds, 
        /// which are then used to create new random number 
        /// generators on a per-thread basis. 
        /// </summary> 
        private static readonly System.Random globalRandom = new System.Random();
        private static readonly object globalLock = new object();

        /// <summary> 
        /// Random number generator 
        /// </summary> 
        private static readonly ThreadLocal<System.Random> threadRandom = new ThreadLocal<System.Random>(NewRandom);

        /// <summary> 
        /// Creates a new instance of Random. The seed is derived 
        /// from a global (static) instance of Random, rather 
        /// than time. 
        /// </summary> 
        public static System.Random NewRandom()
        {
            lock (globalLock)
            {
                return new System.Random(globalRandom.Next());
            }
        }

        /// <summary> 
        /// Returns an instance of Random which can be used freely 
        /// within the current thread. 
        /// </summary> 
        public static System.Random Instance { get { return threadRandom.Value; } }

        /// <summary>See <see cref="System.Random.Next()" /></summary> 
        public static int Next()
        {
            return Instance.Next();
        }

        /// <summary>See <see cref="System.Random.Next(int)" /></summary> 
        public static int Next(int maxValue)
        {
            return Instance.Next(maxValue);
        }

        /// <summary>See <see cref="System.Random.Next(int, int)" /></summary> 
        public static int Next(int minValue, int maxValue)
        {
            return Instance.Next(minValue, maxValue);
        }

        /// <summary>See <see cref="System.Random.NextDouble()" /></summary> 
        public static double NextDouble()
        {
            return Instance.NextDouble();
        }

        /// <summary>See <see cref="System.Random.NextBytes(byte[])" /></summary> 
        public static void NextBytes(byte[] buffer)
        {
            Instance.NextBytes(buffer);
        }
    }
}