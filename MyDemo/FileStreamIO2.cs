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
    public partial class FileStreamIO2 : Form
    {
        public FileStreamIO2()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 写入二进制BinaryWrite方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("要写入的文件内容不能为空！");
            }
            else
            {
                saveFileDialog1.Filter = "二进制文件(*.dat)|*.dat";
                if (saveFileDialog1.ShowDialog()==DialogResult.OK)
                {
                    ///使用另存为对话框输入的文件夹名实例化FileStream对象
                    FileStream fileStream = new FileStream(saveFileDialog1.FileName,FileMode.OpenOrCreate,FileAccess.ReadWrite);
                    ///使用FileStream 对象实例化BinaryWriter 二进制写入流对象
                    BinaryWriter binary = new BinaryWriter(fileStream);
                    binary.Write  (textBox1.Text);//以二进制方式向创建的文件中写入内容
                    binary.Close();
                    fileStream.Close();
                    textBox1.Text = string.Empty;

                }
            }



        }
        /// <summary>
        /// 读取操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
        openFileDialog1.Filter = "二进制文件(*.dat)|*.dat";
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = string.Empty;
                FileStream file = new FileStream(openFileDialog1.FileName,FileMode.Open,FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader(file);
                if (binaryReader.PeekChar()!=-1)
                {
                    textBox1.Text = Convert.ToString(binaryReader.ReadInt32());
                }
                binaryReader.Close();
                file.Close();
            }
        }
    }
}
