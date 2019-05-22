using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockChainCodeBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainCodeBlog.Tests
{
    [TestClass()]
    public class ChainTests
    {
        [TestMethod()]
        public void ChainTest()
        {
            var chain = new Chain();
            chain.Add("Code Blog", "admin");
            Assert.AreEqual("Code Blog", chain.Last.Data);
            Assert.AreEqual("admin", chain.Last.User);
        }

        [TestMethod()]
        public void CheckTest()
        {
            var chain = new Chain();
            chain.Add("hello world", "admin");
            chain.Add("code blog", "kirill");

            Assert.IsTrue(chain.Check());
        }
    }
}