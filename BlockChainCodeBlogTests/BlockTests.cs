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
    public class BlockTests
    {
        [TestMethod()]
        public void SerializeTest()
        {
            var block = new Block();
            var json = "{\"Created\":\"\\/Date(1535749200000+0300)\\/\",\"Data\":\"Hello World\",\"Hash\":\"16427663af5387b29ec58ce9a32f89b3311b2677d48a141a63cff35b57826683\",\"PrevHash\":\"111111\",\"User\":\"admin\"}";

            var resultJson = block.Serialize();
            var resultBlock = Block.Deserialize(resultJson);
            Assert.AreEqual(json, resultJson);
            Assert.AreEqual(block.Created, resultBlock.Created);
            Assert.AreEqual(block.Data, resultBlock.Data);
            Assert.AreEqual(block.Hash, resultBlock.Hash);
            Assert.AreEqual(block.PrevHash, resultBlock.PrevHash);

        }
    }
}