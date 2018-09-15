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
    public partial class GDIGraphics : Form
    {
        public GDIGraphics()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GDIGraphics_Paint(object sender, PaintEventArgs e)
        {
            //创建Graphics对象
            Graphics graphics = e.Graphics;
        }

        private void GDIGraphics_Load(object sender, EventArgs e)
        {
            Graphics g;
            g = this.CreateGraphics();
            //Bitmap bitmap = new Bitmap(@"C:\Is.bmp");
            ///通过FromImage方法创建Graphics
            //Graphics g = Graphics.FromImage(bitmap);
            Brush brush = new SolidBrush(Color.Red);
            Rectangle rt = new Rectangle(10,10,100,100);
            g.FillRectangle(brush,rt);
        }

    }
}
