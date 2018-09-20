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
       StringBuilder builder = new StringBuilder();
        delegate void HandleInterfaceUpdateDelegate(string text);  //委托，此为重点
        HandleInterfaceUpdateDelegate interfaceUpdateHandle;
        public void InitClient()  //窗体控件已在初始化
        {
            interfaceUpdateHandle = new HandleInterfaceUpdateDelegate(UpdateTextBox);  //实例化委托对象
            //spSend.Open();  //SerialPort对象在程序结束前必须关闭，在此说明
            //spReceive.DataReceived += Ports.SerialDataReceivedEventHandler(spReceive_DataReceived);
            //spReceive.ReceivedBytesThreshold = 1;
            //spReceive.Open();
        }
        /// <summary>
        /// 打开com1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            SerialPort spReceive=new SerialPort();
            sp = new SerialPort();
            sp.PortName = "COM1";//窗口编号
            sp.BaudRate = 9600;//波特率
            sp.StopBits = StopBits.One;//停止位数
            sp.DataBits = 8;//每个字节的标准长度
            sp.Parity = Parity.Even;//设置串口属性
            //sp.Open();//打开串口
                      //准备就绪
            sp.DtrEnable = true;
            sp.RtsEnable = true;
            //设置数据读取超时为1秒
            sp.ReadTimeout = 1000;
            sp.DataReceived +=serialPort1_DataReceived;
            sp.ReceivedBytesThreshold = 1;
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
            //sp.wr
           
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
        

        private void OpenCom_Load(object sender, EventArgs e)
        {
           
           
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = sender as SerialPort;
            //readBuffer 就是接收到的数据。
            byte[] readBuffer = new byte[sp.ReadBufferSize];//扩大接收数据量
            sp.Read(readBuffer, 0, readBuffer.Length);
            this.Invoke(interfaceUpdateHandle, new string[] { Encoding.Unicode.GetString(readBuffer) });
        }

        private void UpdateTextBox(string text)
        {
            textBox2.Text = text;
        }

    }

  
}
