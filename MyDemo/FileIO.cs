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
        /// 按钮事件创建文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)///表示空字符串
            {
                MessageBox.Show("文件名不能为空！");
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
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text==string.Empty)//判断文件夹名称是否为空
            {
                MessageBox.Show("文件夹名称不能为空!");
            }
            else
            {
                if (Directory.Exists(textBox2.Text))///判断此文件夹是否已存在
                {
                    MessageBox.Show("该文件夹已存在");
                }
                else
                {
                    Directory.CreateDirectory(textBox2.Text);//调用Dirextory类的CreateDirectory方法创建文件夹
                }



            }


        }
        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty && textBox3.Text == string.Empty)
            {
                MessageBox.Show("文件名不能为空！");
            }
            else
            {
                File.Copy(textBox1.Text,textBox3.Text);
            }
        }
    }
}
