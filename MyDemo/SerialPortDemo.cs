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
    public partial class SerialPortDemo : Form
    {
        SerialPort sp = null;//声明一个串口类
        bool isOpen = false;//声明打开串口标志位
        bool isSetProperty = false;//属性设置标志位
        bool isHex = false;//十六进制显示标志位
        public SerialPortDemo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialPort_Load(object sender, EventArgs e)
        {
            ///循环添加串口
            for (int i=0;i<10;i++)
            {
                cbxComport.Items.Add("COM"+(i+1).ToString());

            }
            cbxComport.SelectedIndex = 0;//默认COM1
            ///列出常用波特率
            cbxBaudRate.Items.Add("1200");
            cbxBaudRate.Items.Add("2400");
            cbxBaudRate.Items.Add("4800");
            cbxBaudRate.Items.Add("9600");     
            cbxBaudRate.Items.Add("19200");
            cbxBaudRate.Items.Add("38400");
            cbxBaudRate.SelectedIndex = 3;//默认9600
            //列出停止位
            cbxStopBits.Items.Add("0");
            cbxStopBits.Items.Add("1");
            cbxStopBits.Items.Add("1.5");
            cbxStopBits.Items.Add("2");
            cbxStopBits.SelectedIndex = 1; //默认1
            //列出奇偶校验
            cbxParity.Items.Add("None");
            cbxParity.Items.Add("Odd");
            cbxParity.Items.Add("Even");
            cbxParity.SelectedIndex = 0;//默认None
            //列出数据位
            cbxDataBits.Items.Add("5");
            cbxDataBits.Items.Add("6");
            cbxDataBits.Items.Add("7");
            cbxDataBits.Items.Add("8");
            //默认字符显示
            rbnChar.Checked = true;

        }
        //检测哪些串口可以使用
        private void btnCheckCom_Click(object sender, EventArgs e)
        {
            bool comExistence = false;//有可用串口标志位
            cbxComport.Items.Clear();//清楚当前串口号中的所有窗口名称
            for (int i=0;i<10;i++)
            {
                try
                {
                    SerialPort sp = new SerialPort("COM" + (i + 1).ToString());
                    sp.Open();
                    sp.Close();
                    cbxComport.Items.Add("COM"+(i+1).ToString());
                    comExistence = true;
                  }
                catch (Exception ex)
                {
                    continue;
                }
            }
            if (comExistence)
            {
                cbxComport.SelectedIndex = 0;//使ListBox显示第一个添加的索引
            }
            else
            {
                MessageBox.Show("没有找到可用的串口！","错误提示");

            }
        }
        ///检查串口时候设置
        private bool CheckPortSetting()
        {
            if (cbxComport.Text.Trim() == "") return false;
            if (cbxBaudRate.Text.Trim() == "") return false;
            if (cbxDataBits.Text.Trim() == "") return false;
            if (cbxParity.Text.Trim() == "") return false;
            if (cbxStopBits.Text.Trim() == "") return false;
            return true;
        }
        /// <summary>
        /// 判断发出框是否为空
        /// </summary>
        /// <returns></returns>
        private bool CheckSendData()
        {
            if (tbxSendData.Text.Trim() == "") return false;
            return true;
        }
        //设置串口属性
        private void SetPortpery()
        {
            sp = new SerialPort();
            sp.PortName = cbxComport.Text.Trim();//设置窗口名称
            sp.BaudRate = Convert.ToInt32(cbxBaudRate.Text.Trim());///设置串口波特率
            float f = Convert.ToSingle(cbxStopBits.Text.Trim());//设置停止位
            if (f == 0)
            {
                sp.StopBits = StopBits.None;
            }
            else if (f == 1.5)
            {
                sp.StopBits = StopBits.OnePointFive;
            }
            else if (f == 1)
            {
                sp.StopBits = StopBits.One;
            }
            else if (f == 2)
            {
                sp.StopBits = StopBits.Two;
            }
            else
            {
                sp.StopBits = StopBits.One;
            }
            sp.DataBits = Convert.ToInt16(cbxDataBits.Text.Trim());//设置数据位
            string s = cbxParity.Text.Trim();//设置奇偶校验
            sp.ReadTimeout = -1;//设置超时读取时间
            sp.RtsEnable = true;
            //设置DataRecetive事件，当串口收到数据后触发事件
            sp.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
            if (rbnHex.Checked)
            {
                isHex = true;
            }
            else
            {
                isHex = false;
            }

        }

        //设置DataRecetive事件，当串口收到数据后触发事件
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            System.Threading.Thread.Sleep(100);//延迟100ms等待收完数据
            //this.Invoke跨线程访问ui的方法，
            this.Invoke((EventHandler)(delegate
            {
                if (isHex == false)
                {
                    tbtRecvData.Text += sp.ReadLine();///
                    //tbtRecvData.Text += sp.ReadChar();////
                    //tbtRecvData.Text += sp.ReadExisting();
                }
                else
                {
                    Byte[] ReceivedData = new Byte[sp.BytesToRead];//创建接受字节数组
                    sp.Read(ReceivedData, 0, ReceivedData.Length);///读取所接收到的数据
                    String RecvDataText = null;
                    for (int i = 0; i < ReceivedData.Length - 1; i++)
                    {
                        RecvDataText += ("0x" + ReceivedData[i].ToString("X2") + "");
                    }
                    tbtRecvData.Text += RecvDataText;
                }
                sp.DiscardInBuffer();//丢弃接收缓冲区数据
            }));

        }
        /// <summary>
        /// 发送串口数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            //写串口数据
            if (isOpen)
            {
                try
                {
                    sp.WriteLine(tbxSendData.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("发送数据时发生错误！", "错误提示");
                    return;
                }

            }
            else
            {
                MessageBox.Show("串口未打开！","错误提示");
                return;
            }
            if (!CheckSendData())//检测要发送的数据
            {
                MessageBox.Show("请输入要发送的数据!","错误提示");
                return;
             }
        }
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenCom_Click(object sender, EventArgs e)
        {
            if (isOpen == false)
            {
                ///检测串口设置
                if (!CheckPortSetting())
                {
                    MessageBox.Show("串口未设置！", "错误提示");
                    return;

                }
                if (!isSetProperty)//串口未设置则设置串口
                {
                    SetPortpery();
                    isSetProperty = true;
                }
                try//打开串口
                {
                    sp.Open();
                    isOpen = true;
                    //窗口打开后则相关设置便不可用
                    cbxComport.Enabled = false;
                    cbxBaudRate.Enabled = false;
                    cbxDataBits.Enabled = false;
                    cbxParity.Enabled = false;
                    cbxStopBits.Enabled = false;
                    rbnChar.Enabled = false;
                    rbnHex.Enabled = false;
                }
                catch (Exception)
                {
                    //打开串口失败后，相应标志位取消
                    isSetProperty = false;
                    isOpen = false;
                    MessageBox.Show("串口无效或已被占用！", "错误提示");

                }
            }
    
        }
        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseCom_Click(object sender, EventArgs e)
        {
            if (isOpen==true)
            {
                try
                {
                    sp.Close();
                    isOpen = false;
                    isSetProperty = false;
                    cbxComport.Enabled = true;
                    cbxBaudRate.Enabled = true;
                    cbxDataBits.Enabled = true;
                    cbxParity.Enabled = true;
                    cbxStopBits.Enabled = true;
                    rbnChar.Enabled = true;
                    rbnHex.Enabled = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("关闭时发生错误！","错误提示");
                }
            }

        }
        /// <summary>
        /// 清空数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCleanData_Click(object sender, EventArgs e)
        {
            tbtRecvData.Text = "";
            tbxSendData.Text = "";
        }
    }
}
