using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dungen_crawl_test
{
    [TestClass]
    public class ElixerTest
    {
        [TestMethod]
        public void ElixerConstructorTest()
        {
            int cost = 200;
            int rarety = 5;
            int effect = 100;
            string name = "Elixer";
            string description = "A blue glistening potion that opon consumtion enhance the knowledge of one self. (its an exp potion)";
            Dungen_crawl.Elixer elixer = new Dungen_crawl.Elixer();
            Assert.AreEqual(cost, elixer.cost);
        }
    }
}
