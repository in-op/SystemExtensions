using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void DeepCopyArrayWorksWithClass()
        {
            CopyableClass[] array = new CopyableClass[3]
            {
                new CopyableClass(1), new CopyableClass(2), new CopyableClass(3)
            };
            CopyableClass[] copy;
            copy = array.DeepCopy();
            for (int i = 0; i < 3; i++)
                if (array[i].x != copy[i].x)
                    Assert.Fail();
        }


        [TestMethod()]
        public void DeepCopyArrayWorksWithValues()
        {
            int[] array = new int[3] { 1, 2, 3 };
            int[] copy;
            copy = array.DeepCopy();
            for (int i = 0; i < 3; i++)
                if (array[i] != copy[i])
                    Assert.Fail();
        }
    }
}