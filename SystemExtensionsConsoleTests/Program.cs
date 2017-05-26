using System;
using System.Collections.Generic;
using SystemExtensions.Copying;

namespace CSharpExtrasConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>(3) { 1, 2, 3 };
            Console.WriteLine("Created new list. Elements: ");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(" " + list[i]);
            }
            List<int> copy = list.DeepCopy();
            Console.WriteLine("Created deep copy of list");

            Console.ReadLine();
        }
    }
}
