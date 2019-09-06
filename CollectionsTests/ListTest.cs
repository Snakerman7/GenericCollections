using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericCollections;

namespace CollectionsTests
{
    [TestClass]
    public class ListTest
    {
        List<string> list;

        public ListTest()
        {
            list = new List<string>();
            list.Add("Item1");
            list.Add("Item2");
            list.Add("Item3");
        }

        [TestMethod]
        public void TestAdd()
        {
            list.Add("Item4");
            Assert.AreEqual(4, list.Count);
        }

        [TestMethod]
        public void TestInsert()
        {
            int index = list.Count;
            list.Insert(index - 1, "Item5");

            Assert.AreEqual(index + 1, list.Count);
        }

        [TestMethod]
        public void TestContains()
        {
            Assert.AreEqual(true, list.Contains("Item2"));
            Assert.AreEqual(false, list.Contains("Item7"));
        }

        [TestMethod]
        public void TestRemove()
        {
            Assert.IsTrue(list.Contains("Item1"));
            list.Remove("Item1");
            Assert.IsTrue(!list.Contains("Item1"));
        }
    }
}
