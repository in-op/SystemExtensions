using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SystemExtensions.Copying.Tests
{
    [TestClass()]
    public class DeepCopyArraysTests
    {
        private class CopyableClass : ICopyable<CopyableClass>
        {
            public int x;

            public CopyableClass(int x)
            {
                this.x = x;
            }

            public CopyableClass DeepCopy()
            {
                return new CopyableClass(x);
            }
        }

        [TestMethod()]
        public void DeepCopy1DArrayWorksWithClass()
        {
            CopyableClass[] array = new CopyableClass[3]
            {
                new CopyableClass(1), new CopyableClass(2), new CopyableClass(3)
            };
            CopyableClass[] copy = array.DeepCopy();
            for (int i = 0; i < 3; i++)
                if (array[i].x != copy[i].x)
                    Assert.Fail();
        }

        [TestMethod()]
        public void DeepCopyArrayWorksWithListOfInt()
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
                        Assert.Fail();
        }


        [TestMethod()]
        public void DeepCopyArrayWorksWithValues()
        {
            int[] array = new int[3] { 1, 2, 3 };
            int[] copy = array.DeepCopy();
            for (int i = 0; i < 3; i++)
                if (array[i] != copy[i])
                    Assert.Fail();
        }


        [TestMethod()]
        public void DeepCopy2DArrayWorksWithClass()
        {
            CopyableClass[][] array = new CopyableClass[3][]
            {
                new CopyableClass[1] { new CopyableClass(1) },
                new CopyableClass[1] { new CopyableClass(2) },
                new CopyableClass[1] { new CopyableClass(3) }
            };
            CopyableClass[][] copy = array.DeepCopy();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 1; j++)
                    if (array[i][j].x != copy[i][j].x)
                        Assert.Fail();
        }
    }
}