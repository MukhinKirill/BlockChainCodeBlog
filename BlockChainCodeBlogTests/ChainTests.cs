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
            Assert.AreEqual(2, chain.Blocks.Count);
            Assert.AreEqual("Code Blog", chain.Last.Data);
            Assert.AreEqual("admin", chain.Last.User);
        }
    }
}