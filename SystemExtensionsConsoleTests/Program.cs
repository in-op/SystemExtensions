using System;
using System.Collections.Generic;
using SystemExtensions.Copying;
using System.Diagnostics;
using SystemExtensions;

namespace CSharpExtrasConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //Array5DPerformanceTest();
            //Array1DPerformanceTest();
            TestingDeepCopy();
        }


        private static void TestingDeepCopy()
        {
            var array = new List<int>[3]
            {
                new List<int>() { 1, 2, 3 },
                new List<int>() { 4, 5, 6 },
                new List<int>() { 7, 8, 9 }
            };

            var copy = array.DeepCopy();

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (copy[i][j] != array[i][j])
                        Console.WriteLine("Failed");

            Console.ReadKey();
        }


        private static void Array1DPerformanceTest()
        {
            Stopwatch sw = new Stopwatch();

            int size = 1000000;
            long val = 42L;

            long[] ints = JaggedArray.Create(size, val);
            long[] holder;

            sw.Reset();
            sw.Start();
            for (int i = 0; i < 200; i++)
            {
                holder = ints.DeepCopy();
            }
            sw.Stop();

            sw.Reset();
            sw.Start();
            for (int i = 0; i < 200; i++)
            {
                holder = ints.ParallelDeepCopy();
            }
            sw.Stop();





            sw.Reset();
            sw.Start();
            holder = ints.DeepCopy();
            sw.Stop();
            Console.WriteLine("Single-Threaded: " + sw.ElapsedTicks);

            sw.Reset();
            sw.Start();
            holder = ints.ParallelDeepCopy();
            sw.Stop();
            Console.WriteLine("Multi-Threaded: " + sw.ElapsedTicks);

            Console.ReadLine();
        }

        private static void Array5DPerformanceTest()
        {
            Stopwatch sw = new Stopwatch();

            int size = 14;
            int val = 42;

            int[][][][][] ints = JaggedArray.Create(size, size, size, size, size, val);
            int[][][][][] holder;

            sw.Reset();
            sw.Start();
            holder = ints.ParallelDeepCopy();
            sw.Stop();
            Console.WriteLine("Multi-Threaded: " + sw.ElapsedTicks);

            sw.Reset();
            sw.Start();
            holder = ints.DeepCopy();
            sw.Stop();
            Console.WriteLine("Single-Threaded: " + sw.ElapsedTicks);


            Console.ReadLine();
        }
    }
}
