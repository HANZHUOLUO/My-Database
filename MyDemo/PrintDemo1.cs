using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDemo
{
    public partial class PrintDemo1 : Form
    {
        public PrintDemo1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 设置需要打印的文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(lblName.Text,new Font("宋体",10,FontStyle.Regular),Brushes.Black,0,0);
            e.Graphics.DrawString(txtName.Text,new Font("宋体",10,FontStyle.Regular),Brushes.Black,60,0);
            e.Graphics.DrawString(lblJob.Text,new Font("宋体",10,FontStyle.Regular),Brushes.Black,0,20);
            e.Graphics.DrawString(txtJob.Text,new Font("宋体",10,FontStyle.Regular),Brushes.Black,60,20);
        }

        private void tbPrint_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();//弹出打印对话框
            printPreviewDialog1.Document = this.printDocument1;//设置打印文档
            printPreviewDialog1.ShowDialog();//弹出预览对话框
        }
    }
}
