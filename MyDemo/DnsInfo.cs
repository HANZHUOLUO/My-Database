using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO.Ports;
namespace MyDemo
{
    public partial class DnsInfo : Form
    {
        public DnsInfo()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("请输入IP");
            }
            else
            {
                textBox2.Text = string.Empty;
                IPAddress[] ips = Dns.GetHostAddresses(textBox1.Text);//获取主机ip
                foreach (IPAddress ip in ips)
                {
                    textBox2.Text = ip.ToString();
                }
                textBox3.Text = Dns.GetHostName();///获取本机名称
                textBox4.Text = Dns.GetHostByName(Dns.GetHostName()).HostName;
            }
        }
        


    }
}
