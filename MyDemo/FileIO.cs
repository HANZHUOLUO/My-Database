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
                MessageBox.Show("文件已复制！");
            }
        }
        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty && textBox3.Text == string.Empty)
            {
                MessageBox.Show("文件名不能为空！");
            }
            else
            {

                File.Move(textBox1.Text,textBox3.Text);
                MessageBox.Show("文件移动成功！");
            }

        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty && textBox3.Text == string.Empty)
            {
                MessageBox.Show("文件名不能为空！");
            }
            else
            {
                File.Delete(textBox1.Text);
                MessageBox.Show("文件删除成功！");
            }
        }
        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==string.Empty && textBox3.Text==string.Empty)
            {
                MessageBox.Show("文件名不能为空！");
            }
            else
            {
               File.Open(textBox1.Text,FileMode.Open);
                MessageBox.Show("文件已打开！");
            }
        }
        /// <summary>
        /// 创建一个文件用于写入UTF-8格式的文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==string.Empty)
            {
                MessageBox.Show("文件名不能为空!");
            }
            else
            {
                if (File.Exists(textBox1.Text))
                {
                    MessageBox.Show("文件已存在");

                }
                else
                {
                    File.CreateText(textBox1.Text);
                }

            }

        }
        /// <summary>
        /// 返回创建时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString( File.GetCreationTime(textBox1.Text));
        }
        /// <summary>
        /// 打开现有文件进行读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("文件名不能为空!");
            }
            else
            {
                if (File.Exists(textBox1.Text))
                {
                    File.OpenRead(textBox1.Text);

                }
                else
                {
                    MessageBox.Show("文件不存在");
                }

            }
        }
        /// <summary>
        /// 把文件夹移动到新位置
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("文件夹名称不能为空！");
            }
            else
            {
                if (Directory.Exists(textBox2.Text))
                {
                    Directory.Move(textBox2.Text.Trim(),textBox4.Text.Trim());///textbox4是新建文件夹名称
                    
                }
                else
                {
                    MessageBox.Show("文件夹不存在！");
                }
            }
        }
        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox2.Text==string.Empty)
            {
                MessageBox.Show("文件夹名不能为空！");
            }
            else
            {
                Directory.Delete(textBox2.Text.Trim(),true);
            }

        }
    }
}
