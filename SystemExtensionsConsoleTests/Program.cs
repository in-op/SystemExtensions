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
            Array5DPerformanceTest();
            //Array1DPerformanceTest();
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

            int size = 30;
            long val = 42L;

            long[][][][][] ints = JaggedArray.Create(size, size, size, size, size, val);
            long[][][][][] holder;

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
