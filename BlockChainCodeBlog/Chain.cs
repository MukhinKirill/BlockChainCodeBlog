using System;
using System.Collections.Generic;

namespace BlockChainCodeBlog
{
    /// <summary>
    /// chain of block
    /// </summary>
    public class Chain
    {
        /// <summary>
        /// our list of block
        /// </summary>
        public List<Block> Blocks { get; private set; }
        public Block Last { get; private set; }//несмотря на private мы можем изменить извне. необходимо использовать IReadonlyList
        //или конвертировать в массив
        public Chain()
        {
            Blocks = new List<Block>();
           var genesisBlock = new Block();
            Blocks.Add(genesisBlock);
            Last = genesisBlock;
        }
        public void Add(string data, string user)
        {
            var block = new Block(data, user, Last);
            Blocks.Add(block);
            Last = block;
        }
    }
}
