using System;
using System.Collections.Generic;
using SystemExtensions.Copying;
using System.Diagnostics;
using SystemExtensions;
using System.Linq;
using System.Reflection;

namespace CSharpExtrasConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestingDeepCopy();
            //TestingReflection<int[]>();
            //PrintGenericTs();
        }

        private static void PrintGenericTs()
        {
            foreach (Type t in GetGenericT())
                Console.WriteLine(t.ToString());
            Console.ReadKey();
        }

        private static List<Type> GetGenericT()
        {
            List<Type> output = new List<Type>(10);

            var methods = from method in typeof(CopyableCollections).GetMethods()
                          let parameters = method.GetParameters()
                          let genParams = method.GetGenericArguments()
                          where method.Name == "DeepCopy" &&
                          method.ContainsGenericParameters //&&
                          //method.GetGenericArguments() == new[] {typeof(T) }
                          select method;
            
            foreach (MethodInfo method in methods)
            {
                foreach (Type genericArg in method.GetGenericArguments())
                    output.Add(genericArg);
            }

            return output;
        }

        private static void TestingReflection<T>()
        {
            var methods = from method in typeof(CopyableCollections).GetMethods()
                          let parameters = method.GetParameters()
                          let genParams = method.GetGenericArguments()
                          where method.Name == "DeepCopy"
                          //&& method.GetParameters().First().ParameterType.GetGenericTypeDefinition() == typeof(T).GetGenericTypeDefinition()


                          //&& method.GetParameters()[0].ParameterType == typeof(List<>)
                          select method;



            Console.WriteLine("typeof(List<>) :                              {0}", typeof(List<>));
            Console.WriteLine("typeof(List<>).ContainsGenericParameters :    {0}", typeof(List<>).ContainsGenericParameters);
            Console.WriteLine("typeof(List<int>).ContainsGenericParameters : {0}", typeof(List<int>).ContainsGenericParameters);
            Console.WriteLine("typeof(List<>) == typeof(List<>):             {0}", typeof(List<>) == typeof(List<>));
            Console.WriteLine("typeof(List<int>) == typeof(List<>):          {0}", typeof(List<int>) == typeof(List<>));
            Console.WriteLine("typeof(int[]).UnderlyingSystemType:           {0}", typeof(int[]).UnderlyingSystemType);
            Console.WriteLine();
            Console.WriteLine();

            
            Console.WriteLine("Total methods found: {0}", methods.Count());
            Console.WriteLine();
            int i = 1;
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine("   Method {0}:  ", i);
                Console.WriteLine("      signature: {0}", method.ToString());
                Console.WriteLine("      contains unassigned generic params: {0}", method.ContainsGenericParameters);
                Console.WriteLine();

                Console.WriteLine("      generic arguments: ");
                foreach (Type genericArg in method.GetGenericArguments())
                {
                    Console.WriteLine("         generic arg: {0}", genericArg.ToString());
                    Console.WriteLine("            Name:                    {0} ", genericArg.Name);
                    Console.WriteLine("            Contains generic params: {0} ", genericArg.ContainsGenericParameters);
                    Console.WriteLine("            Reflected type:          {0} ", genericArg.ReflectedType);
                    Console.WriteLine("            Underlying system type:  {0} ", genericArg.UnderlyingSystemType);
                }
                    
                Console.WriteLine();


                Console.WriteLine("      parameters: ");
                foreach (var param in method.GetParameters())
                {
                    Console.WriteLine("         {0} ", param.ToString());
                    Console.WriteLine("            Name:                                                      {0}", param.Name);
                    Console.WriteLine("            Type:                                                      {0}", param.ParameterType);
                    Console.WriteLine("            Underlying System Type:                                    {0}", param.ParameterType.UnderlyingSystemType);
                    Console.WriteLine("            Type is generic:                                           {0}", param.ParameterType.IsGenericType);
                    Console.WriteLine("            Type is generic type definition:                           {0}", param.ParameterType.IsGenericTypeDefinition);
                    //Console.WriteLine("            Type's generic type def:                     {0}", param.ParameterType.GetGenericTypeDefinition()); // There is no generic type definition of T[]
                    Console.WriteLine("            Equals typeof(List<>):                                     {0}", (param.ParameterType == typeof(List<>)));
                    Console.WriteLine("            Equals typeof(List<>).GetGenericType:                      {0}", (param.ParameterType == typeof(List<>).GetGenericTypeDefinition()));
                    Console.WriteLine("            IsArray:                                                   {0}", param.ParameterType.IsArray);
                    Console.WriteLine("            Type contains unassigned generic params:                   {0}", param.ParameterType.ContainsGenericParameters);
                }
                Console.WriteLine();


                Console.WriteLine();
                i++;
            }

            Console.ReadKey();
        }


        private static void TestingDeepCopy()
        {
            List<int>[] array = new List<int>[3]
            {
                new List<int>(3) { 1, 2, 3 },
                new List<int>(3) { 4, 5, 6 },
                new List<int>(3) { 7, 8, 9 }
            };

            List<int>[] copy = array.DeepCopy();

            bool failure = false;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (copy[i][j] != array[i][j])
                        failure = true;
            Console.WriteLine("Failed?: " + failure);
            Console.ReadKey();
        }

        
    }
}
