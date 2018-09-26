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
            label5.Text = String.Empty;
            IPAddress[] iPs = Dns.GetHostAddresses(textBox1.Text);
            foreach (IPAddress ips in iPs)
            {
                label5.Text = "网际协议地址" + ips.Address + "\nIP地址的地质族：" + ips.AddressFamily.ToString() + "\n是否IPV6连接本地地址：" + ips.IsIPv6LinkLocal;

            }
            ///实例化IPENDPoint对象
            IPEndPoint iPEnd = new IPEndPoint(IPAddress.Parse(textBox1.Text),80);
            //使用IPENDPOINT类对象获取终点的IP地址和端口号
            label6.Text = "IP地址： " + iPEnd.Address.ToString() + "\n 端口号：" + iPEnd.Port;
        }
        


    }
}
