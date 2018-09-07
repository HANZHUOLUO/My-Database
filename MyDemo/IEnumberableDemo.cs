using System;
using System.Collections;
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
    public partial class IEnumberableDemo : Form
    {
        public IEnumberableDemo()
        {
            InitializeComponent();
        }

        private void IEnumberableDemo_Load(object sender, EventArgs e)
        {
            IeClass ie = new IeClass();
            foreach (string str in ie)
            {
                richTextBox1.Text += str + "\n";
            }

        }

    }
    public class IeClass : System.Collections.IEnumerable
    {
        string[] Jj ={"春","夏","秋","冬" };
        public IEnumerator GetEnumerator()
        {
            for (int i=0;i<Jj.Length;i++)
            {
              yield return  Jj[i];
            }
        }
    }
}
