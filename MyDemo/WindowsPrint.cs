using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MyDemo
{
    public partial class WindowsPrint : Form
    {
        public WindowsPrint()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 打印按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            ///设置PageSetupDialog控件的Document属性,设置操作文档

            pageSetupDialog1.Document = printDocument1;
            this.pageSetupDialog1.AllowMargins = true;//启用边距
            this.pageSetupDialog1.AllowOrientation = true;//启用对话框的方向部分
            this.pageSetupDialog1.AllowPaper = true;//启用对话框纸张部分
            this.pageSetupDialog1.AllowPrinter = true;//启用打印机按钮
            this.pageSetupDialog1.ShowDialog();
        }
        /// <summary>
        /// 选择打印机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            ///设置PrintDialog属性
            printDialog1.Document = printDocument1;
            this.printDialog1.AllowCurrentPage = true;//启用当前页属性
            this.printDialog1.AllowPrintToFile = true;//启用打印到文件属性
            this.printDialog1.AllowSelection = true;//启用选择选项按钮
            this.printDialog1.AllowSomePages = true;//启用页按钮
            this.printDialog1.ShowDialog();

        }
        /// <summary>
        /// 设置打印文档属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //通过GDI+绘制打印文档

        }
    }
}
