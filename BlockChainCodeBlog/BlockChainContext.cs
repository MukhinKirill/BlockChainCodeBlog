using System;
using System.Data.Entity;

namespace BlockChainCodeBlog
{
    public class BlockChainContext:DbContext
    {
        public BlockChainContext():base("blockChainDBconnection")
        {

        }
        public DbSet<Block> Blocks { get; set; }
    }
}
