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

namespace MyDemo
{
    public partial class CreateRegedit : Form
    {
        public CreateRegedit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 新建注册表信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ///创建registrykey实例
                RegistryKey hklm = Registry.LocalMachine;
                //使用opensubkey方法打开HKEY_LOCAL_MACHINE/SOFTWARE键
                RegistryKey reg = hklm.OpenSubKey("HARDWARE",true);
                //使用CreateSubKey方法创建名为LS的子键
                RegistryKey main1 = reg.CreateSubKey("LS");
                //使用CreateSubKey方法再LS键下创建一个名为SHJ的子键
                RegistryKey ddd = main1.CreateSubKey("SHJ");
                //再子键SHJ下建立一个名为VALUE的值，数据值为1234
                ddd.SetValue("value","1234");
                MessageBox.Show("创建成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 修改注册表信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ///创建registrykey实例
                RegistryKey hklm = Registry.LocalMachine;
                //使用opensubkey方法打开HKEY_LOCAL_MACHINE/SOFTWARE键
                RegistryKey reg = hklm.OpenSubKey("HARDWARE", true);
                //使用opensubkey方法创建名为LS的子键
                RegistryKey main1 = reg.OpenSubKey("LS",true);
                //使用opensubkey方法再LS键下创建一个名为SHJ的子键
                RegistryKey ddd = main1.OpenSubKey("SHJ",true);
                //再子键SHJ下建立一个名为VALUE的值，数据值为1234
                ddd.SetValue("value", "abcd");
                MessageBox.Show("修改成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// 删除注册表信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //创建RegistryKey实例
                RegistryKey registry = Registry.LocalMachine;
                //使用OpenSubKey方法打开HKEY_LOCAL_MACHINE/SOFTWARE键
                RegistryKey key = registry.OpenSubKey("HARDWARE", true);
                //打开LS子键
                RegistryKey key2 = key.OpenSubKey("LS", true);
                ///使用DeleteSubKey方法删除名称为SHJ的子键
                key2.DeleteSubKey("SHJ",false);
                MessageBox.Show("删除成功！");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 删除注册表所有信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //创建RegistryKey实例
                RegistryKey registry = Registry.LocalMachine;
                //使用OpenSubKey方法打开HKEY_LOCAL_MACHINE/SOFTWARE键
                RegistryKey key = registry.OpenSubKey("HARDWARE", true);
                //打开LS子键
                RegistryKey key2 = key.OpenSubKey("LS", true);
                ///使用DeleteSubKey方法删除名称为SHJ的子键
                key2.DeleteSubKeyTree("SHJ");
                MessageBox.Show("删除成功！");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 删除注册表指定键的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                //创建RegistryKey实例
                RegistryKey registry = Registry.LocalMachine;
                //使用OpenSubKey方法打开HKEY_LOCAL_MACHINE/SOFTWARE键
                RegistryKey key = registry.OpenSubKey("HARDWARE", true);
                //打开LS子键
                RegistryKey key2 = key.OpenSubKey("LS", true);
                ///打开SHJ子键
                RegistryKey key3 = key2.OpenSubKey("SHJ",true);
                ///使用DeleteSubKey方法删除名称为VALUE的子键
                key3.DeleteValue("value");
                MessageBox.Show("删除键值成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }


}
