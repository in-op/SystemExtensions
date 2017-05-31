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
           // Array5DPerformanceTest();
        }
        

        private static void Array5DPerformanceTest()
        {
            Stopwatch sw = new Stopwatch();

            int[][][][][] ints = JaggedArray.Create(10, 10, 10, 10, 10, 42);
            int[][][][][] holder = JaggedArray.Create<int>(10, 10, 10, 10, 50);

            sw.Reset();
            sw.Start();
            holder = ints.DeepCopy();
            sw.Stop();

            sw.Reset();
            sw.Start();
            holder = ints.ParallelDeepCopy();
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
    }
}
