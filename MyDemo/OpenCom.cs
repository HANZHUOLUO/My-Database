using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace MyDemo
{
    public partial class OpenCom : Form
    {
        public OpenCom()
        {
            InitializeComponent();
        }
        SerialPort sp = null;
        /// <summary>
        /// 打开com1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            sp = new SerialPort();
            sp.PortName = "COM1";//窗口编号
            sp.BaudRate = 9600;//波特率
            sp.StopBits = StopBits.One;//停止位数
            sp.DataBits = 8;//每个字节的标准长度
            sp.Parity = Parity.Even;//设置串口属性
            sp.Open();//打开串口
        }
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
      
            sp.WriteLine(textBox1.Text);//往串口写数据
           
        }
        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            
            string Data = sp.ReadExisting();//读取数据
            textBox2.Text = Data;

        }
    }
}
