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

        private Chain _chain = new Chain();
        private void AddBtn_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            _chain.Add(textBox.Text, "admin");
            textBox.Clear();
            foreach (var block in _chain.Blocks)
            {
                listBox.Items.Add(block);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var block in _chain.Blocks)
            {
                listBox.Items.Add(block);
            }
        }
    }
}
