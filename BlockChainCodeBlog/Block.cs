using System;
using System.Security.Cryptography;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace BlockChainCodeBlog
{
    /// <summary>
    /// Block of Data, smallest bit of data for work
    /// </summary>
    [DataContract]
    public class Block
    {
        public int Id { get; private set; }
        [DataMember]
        public string Data { get; private set; }
        /// <summary>
        /// the creation date of the block
        /// </summary>
        [DataMember]
        public DateTime Created { get; private set; }
        /// <summary>
        /// current's block hash
        /// </summary>
        [DataMember]
        public string Hash { get; private set; }
        /// <summary>
        /// Previously block's hash
        /// </summary>
        [DataMember]
        public string PrevHash { get; private set; }
        /// <summary>
        /// Name of user
        /// </summary>
        [DataMember]
        public string User { get; private set; }
        /// <summary>
        /// Constructor of genesis block
        /// </summary>
        public Block()
        {
            Id = 1;
            Data = "Hello World";
            Created = DateTime.Parse("01.09.2018 00:00:00.000");
            PrevHash = "111111";
            User = "admin";
            var data = GetData();
            Hash = GetHash(data);
        }
        /// <summary>
        /// constructor default block
        /// </summary>
        /// <param name="data"></param>
        /// <param name="user"></param>
        /// <param name="block"></param>
        public Block(string data, string user, Block block)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentNullException("Пустой аргумент data", nameof(data));
            }
            if (block == null)
            {
                throw new ArgumentNullException("Пустой аргумент block", nameof(block));
            }
            if (string.IsNullOrWhiteSpace(user))
            {
                throw new ArgumentNullException("Пустой аргумент user", nameof(user));
            }
            Data = data;
            User = user;
            PrevHash = block.Hash;
            Created = DateTime.UtcNow;
            Id = block.Id + 1;
            var blockData = GetData();
            Hash = GetHash(blockData);

        }

        private string GetData()
        {
            string result = "";

            result += Data.ToString();
            result += Created.ToString("dd.MM.yyyy HH:mm:ss.fff");
            result += PrevHash;
            result += User;
            return result;
        }
        /// <summary>
        /// hashing data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string GetHash(string data)
        {
            //calculate hash for input data
            var message = Encoding.ASCII.GetBytes(data);
            SHA256Managed hashString = new SHA256Managed();
            string hex = "";
            var hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }
        public override string ToString()
        {
            return Data;
        }
        public string Serialize()
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(Block));

            using (var ms = new MemoryStream())
            {
                jsonSerializer.WriteObject(ms, this);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        public static Block Deserialize(string json)
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(Block));

            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var result = jsonSerializer.ReadObject(ms);
                return result as Block;
            }
        }
    }
}
