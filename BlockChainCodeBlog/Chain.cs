using System;
using System.Collections.Generic;
using System.Linq;

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
            Blocks = LoadChainFromDB();
            if (Blocks.Count == 0)
            {
                var genesisBlock = new Block();
                Blocks.Add(genesisBlock);
                Last = genesisBlock;
                Save(Last);
            }
            else
            {
                if (Check())
                {
                    Last = Blocks.Last();
                }
                else
                {
                    throw new Exception("Ошибка получения блоков из базы данных. Цепочка не прошла проверку целостности.");
                }
            }
        }
        public void Add(string data, string user)
        {
            var block = new Block(data, user, Last);
            Blocks.Add(block);
            Last = block;
            Save(Last);
        }
        /// <summary>
        /// chtcking correct of chain
        /// </summary>
        /// <returns></returns>
        public bool Check()
        {
            var genesisBlock = new Block();
            var prevHash = genesisBlock.Hash;
            foreach (var block in Blocks.Skip(1))
            {
                var hash = block.PrevHash;

                if (prevHash != hash)
                {
                    return false;
                }
                prevHash = block.Hash;
            }
            return true;
        }
        private void Save(Block block)
        {
            using (var db = new BlockChainContext())
            {
                db.Blocks.Add(block);
                db.SaveChanges();
            }
        }
        private List<Block> LoadChainFromDB()
        {
            List<Block> result;
            using (var db = new BlockChainContext())
            {
                var count = db.Blocks.Count();
                result = new List<Block>(count * 2);
                result.AddRange(db.Blocks);
            }

            return result;
        }
    }
}
