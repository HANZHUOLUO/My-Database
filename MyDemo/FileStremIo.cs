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
    public partial class FileStremIo : Form
    {
        public FileStremIo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 使用FileSTream类对象打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button1_Click(object sender, EventArgs e)
        {
            ///实例化FileStream类
            FileStream fileStream = new FileStream(textBox1.Text,FileMode.OpenOrCreate,FileAccess.ReadWrite);
        
        }
        /// <summary>
        /// /写入操作StreamWriter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("要写入到内容为空！");
            }
            else
            {

                saveFileDialog1.Filter = "文本文件(*.txt)|*.txt";///设置保存文本格式！
                if (saveFileDialog1.ShowDialog()==DialogResult.OK)
                {
                    ///使用另存为中的对话框输入的文件名实例化StreamWriter对象
                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName,true);
                    sw.WriteLine(textBox2.Text);//向创建的文件中写入流
                    sw.Close();///关闭当前文件的写入流
                    textBox2.Text = string.Empty;
                }
            }

        }
        /// <summary>
        /// 读取操作StreamReader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "文本文件(*.txt)|*.txt";///设置保存文本格式！
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {

                textBox2.Text = string.Empty;
                ///使用打开对话框中选择的文件实例化StreamReader对象
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                textBox2.Text = sr.ReadToEnd();///调用ReadtoEnd方法读取选中的文件的全部内容
                sr.Close();
            }

        }
    }
}
