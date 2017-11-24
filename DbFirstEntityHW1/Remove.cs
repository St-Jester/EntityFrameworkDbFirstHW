using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbFirstEntityHW1
{
    public partial class Remove : Form
    {
        public string title;
        public Remove()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            title = textBox1.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
