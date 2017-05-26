using System;

namespace SystemExtensions.Random
{
    public static class RandomLong
    {
        /// <summary>
        /// Returns a random long number.
        /// </summary>
        public static long NextInt64(this System.Random rng)
        {
            byte[] buffer = new byte[sizeof(Int64)];
            rng.NextBytes(buffer);
            long output = BitConverter.ToInt64(buffer, 0);
            if (rng.Next(0, 100) < 50) return output;
            else return -output;
        }
    }
}
