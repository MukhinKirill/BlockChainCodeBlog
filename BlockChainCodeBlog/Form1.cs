using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockChainCodeBlog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Chain _chain;
        private void AddBtn_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            _chain.Add(textBox.Text, "User");
            textBox.Clear();
            listBox.Items.AddRange(_chain.Blocks.ToArray());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _chain = new Chain();
            listBox.Items.AddRange(_chain.Blocks.ToArray());
        }
    }
}
