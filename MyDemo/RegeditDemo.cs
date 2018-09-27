using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Threading;
namespace MyDemo
{
    public partial class RegeditDemo : Form
    {
        public RegeditDemo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 使用OpenSubKey打开子键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegeditDemo_Load(object sender, EventArgs e)
        {
            RegistryKey registry = Registry.LocalMachine;//创建RegistryKey实例
            ///使用OpenSubKey方法打开HKEY_LOCAL_MACHINE/SOFTWARE键
            RegistryKey reg = registry.OpenSubKey(@"SOFTWARE");
            ///使用foreach语句读取HKEY_LOCAL_MACHINE/SOFTWARE键的所有项目
            foreach (string str in reg.GetSubKeyNames())
            {
                richTextBox1.Text += str + "\n";
            }
            ///清空ListBox中的项
            listBox1.Items.Clear();
            ///使用两个foreach语句读取HKEY_LOCAL_MACHINE/SOFTWARE键的所有项目
            foreach (string strr in reg.GetSubKeyNames())
            {
                this.listBox1.Items.Add("子项名："+strr);
                //打开子键
                RegistryKey sikey = reg.OpenSubKey(strr);
                foreach (string sVName in sikey.GetValueNames()) 
                {
                    this.listBox1.Items.Add(sVName+sikey.GetValue(sVName));
                }
            }
        }
    }
}
