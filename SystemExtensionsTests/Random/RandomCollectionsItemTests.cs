using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SystemExtensions.Random.Tests
{
    [TestClass()]
    public class RandomCollectionsItemTests
    {
        private List<int> listInt = new List<int>(3) { 1, 2, 3 };

        [TestMethod()]
        public void RandomListItemIsWithinList()
        {
            if (!listInt.Contains(
                listInt.RandomItem(new System.Random())))
                Assert.Fail();
        }

        [TestMethod()]
        public void RandomListItemCanProduceAllValues()
        {
            List<int> list = new List<int>(3) { 1, 2, 3 };

            System.Random rng = new System.Random();
            bool failure = true;
            for (int i = 0; i < 3000; i++)
            {
                if (list.RandomItem(rng) == 1)
                {
                    failure = false;
                    break;
                }
            }
            if (failure) Assert.Fail("Couldnt find 1");

            failure = true;
            for (int i = 0; i < 3000; i++)
            {
                if (list.RandomItem(rng) == 2)
                {
                    failure = false;
                    break;
                }
            }
            if (failure) Assert.Fail("Couldnt find 2");

            failure = true;
            for (int i = 0; i < 3000; i++)
            {
                if (list.RandomItem(rng) == 3)
                {
                    failure = false;
                    break;
                }
            }
            if (failure) Assert.Fail("Couldnt find 3");

        }

        [TestMethod()]
        public void RandomDictionaryItemIsInTheDictionary()
        {
            System.Random rng = new System.Random();
            Dictionary<int, string> dict = new Dictionary<int, string>
            {
                { 0, "zero" },
                { 1, "one" },
                { 2, "two" },
                { 3, "three" }
            };

            for (int i = 0; i < 500; i++)
                if (!dict.ContainsValue(dict.RandomItem(rng)))
                    Assert.Fail();
        }


        [TestMethod()]
        public void RandomDictionaryItemCanProduceAllValues()
        {
            System.Random rng = new System.Random();
            Dictionary<int, int> dict = new Dictionary<int, int>
            {
                { 1, 1 },
                { 2, 2 },
                { 3, 3 }
            };

            bool failure = true;
            for (int i = 0; i < 3000; i++)
            {
                if (dict.RandomItem(rng) == 1)
                {
                    failure = false;
                    break;
                }
            }
            if (failure) Assert.Fail("Couldnt find 1");

            failure = true;
            for (int i = 0; i < 3000; i++)
            {
                if (dict.RandomItem(rng) == 2)
                {
                    failure = false;
                    break;
                }
            }
            if (failure) Assert.Fail("Couldnt find 2");

            failure = true;
            for (int i = 0; i < 3000; i++)
            {
                if (dict.RandomItem(rng) == 3)
                {
                    failure = false;
                    break;
                }
            }
            if (failure) Assert.Fail("Couldnt find 3");

        }
    }
}