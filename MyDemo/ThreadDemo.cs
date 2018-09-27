using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace MyDemo
{
    public partial class ThreadDemo : Form
    {
        private ThreadStart threadStart;

        public ThreadDemo()
        {
            InitializeComponent();
        }



        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Thread_Load(object sender, EventArgs e)
        {
            string strinfo = string.Empty;//定义一个字符串，用来记录线程的相关信息
            Thread thread = new Thread(new ThreadStart(threadOut));//实例化一个新线程
            thread.Start();///启动主进程
                           ///获取县城相关信息
            strinfo = "线程的唯一标识符：" + thread.ManagedThreadId;
            strinfo += "\n线程名称：" + thread.Name;
            strinfo += "\n线程的状态：" + thread.ThreadState.ToString();
            strinfo += "\n线程的优先级：" + thread.Priority.ToString();
            strinfo += "\n是否为后台线程：" + thread.IsBackground;
            Thread.Sleep(1000);//使主线程休眠1分钟
            thread.Abort("退出");//通过主线程阻止新开的线程
            thread.Join();//等待新开的线程结束
            MessageBox.Show("线程运行结束");
            richTextBox1.Text = strinfo;
        }
        private void threadOut()
        {

            MessageBox.Show("主线程开始运行！");
        }
    }
}
