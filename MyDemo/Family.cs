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
    public partial class Family : Form
    {
        public Family()
        {
            InitializeComponent();
        }

        private void Family_Load(object sender, EventArgs e)
        {
            FamilyClass family = new FamilyClass();
            foreach (string str in family)
            {
                richTextBox1.Text
                    += str + "\n";
                
            }

        }
    }
    public class FamilyClass : System.Collections.IEnumerable
    {
        string[] Myfamily = {"父亲","母亲","姐姐","弟弟" };
        public System.Collections.IEnumerator GetEnumerator()
        {
            for (int i=0;i<Myfamily.Length;i++)
            {
                yield return Myfamily[i];
            }
        }
    }
}
