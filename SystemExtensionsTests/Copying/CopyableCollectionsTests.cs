using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystemExtensions.Copying;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemExtensions.Copying.Tests
{
    [TestClass()]
    public class CopyableCollectionsTests
    {
        private static readonly Dictionary<int, int> DictionaryIntInt = new Dictionary<int, int>(5)
        {
            { 1, 10 },
            { 2, 20 },
            { 3, 30 },
            { 4, 40 },
            { 5, 50 }
        };

        private static readonly Dictionary<int, int>[] ArrayOfDictionaryIntInt = new Dictionary<int, int>[3]
        {
            DictionaryIntInt,
            new Dictionary<int, int>()
            {
                { 6, 60 },
                { 7, 70 },
                { 8, 80 },
                { 9, 90 },
                { 10, 100 }
            },
            DictionaryIntInt
        };

        [TestMethod()]
        public void DeepCopyDictionaryIntIntContainsSameKeyValuePairs()
        {
            if (DictionaryIntInt.Except(DictionaryIntInt.DeepCopy()).Any()) Assert.Fail();
        }

        [TestMethod()]
        public void DeepCopy1DArrayWorksWithDictionaryOfIntInt()
        {
            Dictionary<int, int>[] copy = ArrayOfDictionaryIntInt.DeepCopy();

            for (int i = 0; i < ArrayOfDictionaryIntInt.Length; i++)
                if (ArrayOfDictionaryIntInt[i]
                    .Except(copy[i])
                    .Any())
                    Assert.Fail();
        }


        private class NotCopyable { }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void DeepCopy1DArrayOfNonCopyableClassThrowsNotImplementedException()
        {
            NotCopyable[] array = new NotCopyable[5]
            {
                new NotCopyable(),
                new NotCopyable(),
                new NotCopyable(),
                new NotCopyable(),
                new NotCopyable()
            };

            NotCopyable[] copy = array.DeepCopy();
        }


        [TestMethod()]
        public void DeepCopy1DArrayWorksWithHashSetOfInts()
        {
            HashSet<int>[] array = new HashSet<int>[3]
            {
                new HashSet<int>()
                {
                    1, 2, 3
                },

                new HashSet<int>()
                {
                    4, 5, 6
                },

                new HashSet<int>()
                {
                    7, 8, 9
                }
            };


            HashSet<int>[] copy = array.DeepCopy();

            for (int i = 0; i < 3; i++)
            {
                List<int> originalInts = array[i].ToList();
                List<int> copyInts = copy[i].ToList();
                for (int j = 0; j < 3; j++)
                {
                    if (originalInts[j] != copyInts[j])
                    {
                        Assert.Fail();
                    }
                }
            }

        }

        [TestMethod()]
        public void DeepCopyListOfListOfInts()
        {
            List<List<int>> list = new List<List<int>>(3)
            {
                new List<int>(3) {1, 2, 3 },
                new List<int>(3) {4, 5, 6 },
                new List<int>(3) {7, 8, 9 }
            };

            List<List<int>> copy = list.DeepCopy();

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (list[i][j] != copy[i][j])
                        Assert.Fail();
        }

        [TestMethod()]
        public void DeepCopyListOfArrayOfInts()
        {
            List<int[]> list = new List<int[]>(3)
            {
                new int[3] {1, 2, 3 },
                new int[3] {4, 5, 6 },
                new int[3] {7, 8, 9 }
            };

            List<int[]> copy = list.DeepCopy();

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (list[i][j] != copy[i][j])
                        Assert.Fail();
        }

        [TestMethod()]
        public void DeepCopy1DArrayOfListOfInt()
        {
            List<int>[] array = new List<int>[3]
            {
                new List<int>(3) {1, 2, 3 },
                new List<int>(3) {4, 5, 6 },
                new List<int>(3) {7, 8, 9 }
            };

            List<int>[] copy = array.DeepCopy();

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (array[i][j] != copy[i][j])
                        Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void DeepCopy1DArrayOfListOfNonCopyableClassThrowsNotImplementedException()
        {
            List<NotCopyable>[] array = new List<NotCopyable>[3]
            {
                new List<NotCopyable>(3) {new NotCopyable(), new NotCopyable(), new NotCopyable() },
                new List<NotCopyable>(3) {new NotCopyable(), new NotCopyable(), new NotCopyable() },
                new List<NotCopyable>(3) {new NotCopyable(), new NotCopyable(), new NotCopyable() }
            };

            array.DeepCopy();
        }


    }
}