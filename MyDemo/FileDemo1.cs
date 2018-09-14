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
    public partial class FileDemo1 : Form
    {
        public FileDemo1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 打开目录
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;
            DirectoryInfo dr = new DirectoryInfo(textBox1.Text);
            FileSystemInfo[] files = dr.GetFiles();
            for (int i=0;i<files.Length;i++)
            {
                listBox1.Items.Add(files[i]);
            }

        }
        /// <summary>
        /// 目标位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox2.Text = folderBrowserDialog1.SelectedPath;
        }
        /// <summary>
        /// 批量复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            foreach (object o in listBox1.SelectedItems)
            {
                File.Copy(textBox1.Text+"\\"+o.ToString(),textBox2.Text+"\\"+o.ToString());
            }

        }
    }
}
