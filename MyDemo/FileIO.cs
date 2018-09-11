using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MyDemo
{
    public partial class FileIO : Form
    {
        public FileIO()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)///表示空字符串
            {
                MessageBox.Show("文件夹名不能为空！");
            }
            else
            {
                if (File.Exists(textBox1.Text))
                {
                    MessageBox.Show("该文件已经存在！");
                }
                else {
                    File.Create(textBox1.Text);//使用File类的Create方法创建文件
                }
            }

        }
    }
}
