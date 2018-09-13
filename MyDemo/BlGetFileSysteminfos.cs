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
    public partial class BlGetFileSysteminfos : Form
    {
        public BlGetFileSysteminfos()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 选择文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear(); ///清空ListView控件中的项
            if (folderBrowserDialog1.ShowDialog()==DialogResult.OK)///选择文件夹
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;///获取文件夹路径
                DirectoryInfo directoryInfo = new DirectoryInfo(textBox1.Text);
                ///获取制定目录下的所有子目录及文件类型
                FileSystemInfo[] fileSystems = directoryInfo.GetFileSystemInfos();
                foreach (FileSystemInfo FSIN in fileSystems)
                {
                    if (FSIN is DirectoryInfo)///判断是否为文件夹
                    {
                        ////使用获取文件夹名称实例化DIr对象
                        DirectoryInfo info = new DirectoryInfo(FSIN.FullName);
                        listView1.Items.Add(info.Name);//为listview控件添加文件夹信息
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(info.FullName);
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add("");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(info.CreationTime.ToShortDateString());
                    }
                    else
                    {
                        //使用获取文件名称实例化Filedinfo对象
                        FileInfo fileInfo = new FileInfo(FSIN.FullName);
                        listView1.Items.Add(fileInfo.Name);
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(fileInfo.FullName);
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(fileInfo.Length.ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(fileInfo.CreationTime.ToShortDateString());
                       
                    }
                }
            }
        }
    }
}
