using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace SystemExtensions.Copying.Tests
{
    [TestClass()]
    public class CopyableListTests
    {
        private class CopyableClass : ICopyable<CopyableClass>, IEquatable<CopyableClass>
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

            public bool Equals(CopyableClass other)
            {
                if (other == null) return false;
                return x == other.x;
            }

            public static bool operator ==(CopyableClass first, CopyableClass second)
            {
                if ((object)first == null) return (object)second == null;
                else if ((object)second == null) return false;
                else return first.x == second.x;
            }

            public static bool operator !=(CopyableClass first, CopyableClass second)
            {
                return !(first == second);
            }
        }

        [TestMethod()]
        public void CopyableListWorksWithValues()
        {
            List<int> list = new List<int>(3) { 1, 2, 3 };
            List<int> copy = list.DeepCopy();
            for (int i = 0; i < list.Count; i++)
                if (list[i] != copy[i])
                    Assert.Fail();
            if (list.Count != copy.Count)
                Assert.Fail("Copy and original do not have the same Count");
        }

        [TestMethod()]
        public void CopyableListWorksWithClass()
        {
            List<CopyableClass> list = new List<CopyableClass>(3)
            {
                new CopyableClass(1), new CopyableClass(2), new CopyableClass(3)
            };
            List<CopyableClass> copy = list.DeepCopy();
            for (int i = 0; i < 3; i++)
                if (list[i] != copy[i])
                    Assert.Fail();
            if (list.Count != copy.Count)
                Assert.Fail("Copy and original do not have the same Count");
        }



        [TestMethod()]
        public void CopyableListWorksWithClassWithNulls()
        {
            List<CopyableClass> list = new List<CopyableClass>(5)
            {
                new CopyableClass(1), null, null, new CopyableClass(3), null
            };
            List<CopyableClass> copy = list.DeepCopy();
            for (int i = 0; i < 3; i++)
                if (list[i] != copy[i])
                    Assert.Fail("Item " + i + " was not the same");
            if (list.Count != copy.Count)
                Assert.Fail("Copy and original do not have the same Count");
        }

    }
}