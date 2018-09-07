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
    public partial class Partial : Form
    {
        public Partial()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Partial_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        partial class account
        {
            public int add(int a, int b)
            {
                return a + b;
            }
        }
        partial class account
        {
            public int mulitiplication(int a,int b)
            {
                return a * b;

            }

        }
        partial class account
        {
            public int subtraction(int a,int b)
            {
                return a - b;
            }


        }
        partial class account
        {

            public int division(int a, int b)
            {
                return a / b;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
                {
                account at = new account();
                int a = int.Parse(textBox1.Text.Trim());
                int b = int.Parse(textBox2.Text.Trim());
                string str = comboBox1.Text;
                switch (str)
                {
                    case "加":
                        textBox3.Text = at.add(a,b).ToString();
                        break;
                    case "减":
                        textBox3.Text = at.subtraction(a, b).ToString();
                        break;
                    case "乘":
                        textBox3.Text = at.mulitiplication(a, b).ToString();
                        break;
                    case "除":
                        textBox3.Text = at.division(a, b).ToString();
                        break;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
