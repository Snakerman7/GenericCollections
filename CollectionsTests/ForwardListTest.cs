using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericCollections;

namespace CollectionsTests
{
    [TestClass]
    public class ForwardListTest
    {
        ForwardList<string> list;

        public ForwardListTest()
        {
            list = new ForwardList<string>();
            list.Add("Item1");
            list.Add("Item2");
            list.Add("Item3");
        }

        [TestMethod]
        public void TestAdd()
        {
            int count = list.Count;
            list.Add("Item4");
            Assert.AreEqual(count + 1, list.Count);
        }
    }
}
