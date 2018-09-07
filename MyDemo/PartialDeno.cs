using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDemo
{
    public partial class PartialDeno : Form
    {
        public PartialDeno()
        {
            InitializeComponent();
        }

        private void PartialDeno_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Str = comboBox1.Text;
            Input INP = new Input();
            switch (Str)
            {
                case "A":
                    textBox1.Text =INP.str("1").ToString();
                        break;
                case "B":
                    textBox1.Text = INP.str1("1").ToString();
                    break;


            }
        }
    }
    partial class Input
    {
        public string str(string ss)
        {
            ss = "用一生下载你";
            return ss;
        }
    }
    partial class Input
    {
        public string str1(string ss)
        {
            ss = "YU";
            return ss;
        }
    }
}
