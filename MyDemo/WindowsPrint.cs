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
            e.Graphics.DrawString("蝶恋花",new Font("宋体",15),Brushes.Black,350,80);
            e.Graphics.DrawLine(new Pen(Color.Black,(float)3.00),100,185,720,185);
            e.Graphics.DrawString("伫倚危楼风细细，望极春愁，黯黯生天际。", new Font("宋体", 12), Brushes.Black, 110, 195);
            e.Graphics.DrawString("草色烟光残照里,无言谁会凭阑意。", new Font("宋体", 12), Brushes.Black, 110, 220);
            e.Graphics.DrawString("拟把疏狂图一醉,对酒当歌，强乐还无味。", new Font("宋体", 12), Brushes.Black, 110, 245);
            e.Graphics.DrawString("衣带渐宽终不悔。为伊消得人憔悴。", new Font("宋体", 12), Brushes.Black, 110, 270);
            e.Graphics.DrawLine(new Pen(Color.Black, (float)3.00), 100, 300, 720, 300);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要预览打印文档", "打印文档", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.printPreviewDialog1.UseAntiAlias = true;//开启操作系统的防锯齿功能
                this.printPreviewDialog1.Document = this.printDocument1;//设置要预览的窗口
                printPreviewDialog1.ShowDialog();///打开预览窗口
             
            }
            else
            {

                this.printDocument1.Print();
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
