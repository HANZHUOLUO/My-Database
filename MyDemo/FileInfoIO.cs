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
    public partial class FileInfoIO : Form
    {
        public FileInfoIO()
        {
            InitializeComponent();
        }

        /// <summary>
        /// FileInfo类创建文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("文件名称不能为空！");
            }
            else
            {
                FileInfo fileInfo = new FileInfo(textBox1.Text);
                if (fileInfo.Exists)
                {
                    MessageBox.Show("文件已经存在！");
                }
                else
                {
                    fileInfo.Create();
                }

            }



        }
        /// <summary>
        /// 使用DirectoryInfo创建文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {

                MessageBox.Show("文件夹名称不能为空！");
            }
            else
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(textBox2.Text);
                if (directoryInfo.Exists)
                {
                    MessageBox.Show("该文件夹已经存在！");
                }
                else
                {
                    directoryInfo.Create();
                }

            }

        }
    }
}
