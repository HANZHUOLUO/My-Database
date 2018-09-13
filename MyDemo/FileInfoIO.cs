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
                    //fileInfo.CopyTo();
                    //fileInfo.MoveTo();
                    //fileInfo.Delete();
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
                    //directoryInfo.
                }

            }

        }
        /// <summary>
        /// 打开文件目录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)//浏览文件控件
            {
                textBox3.Text = openFileDialog1.FileName; ///获取文件路径
                FileInfo info = new FileInfo(textBox3.Text);
                string strCTime, strLATime, strLWTime, strName, strFName, strDName, strISRead;
                long lgLength;
                strCTime = info.CreationTime.ToShortDateString();///获取创建时间
                strLATime = info.LastAccessTime.ToShortDateString();///获取上次访问时间
                strLWTime = info.LastWriteTime.ToShortDateString();///获取上次写入时间
                strName = info.Name;//获取文件名称
                strFName = info.FullName;//获取文件完整目录
                strDName = info.DirectoryName;//获取文件完整路径
                strISRead = info.IsReadOnly.ToString();//获取文件只读属性
                lgLength = info.Length;//获取文件长度
                MessageBox.Show("文件信息：\n创建时间："+strCTime+"，上次访问时间："+strLATime+",上次写入时间："+strLWTime+",文件名称："+strName+",\n完整目录："+strFName+",\n完整路径："+strDName+"\n是否只读"+strISRead+",文件长度："+lgLength);
            }
        }
        /// <summary>
        /// 移动文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("文件夹名不能为空");
            }
            else
            {
                DirectoryInfo directory = new DirectoryInfo(textBox2.Text);
                if (directory.Exists)
                {
                    directory.MoveTo(textBox4.Text);
                }
                else
                {
                    MessageBox.Show("文件夹不存在！");
                }
            }
        }
        /// <summary>
        /// 永久性删除文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text==string.Empty)
            {
                MessageBox.Show("文件夹名不能为空！");
            }
            else
            {
                DirectoryInfo directory1 = new DirectoryInfo(textBox2.Text);
                directory1.Delete(true);
            }
        }
    }
}
