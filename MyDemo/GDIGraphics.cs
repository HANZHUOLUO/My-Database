﻿using System;
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
            //Graphics graphics = e.Graphics;
        }

        private void GDIGraphics_Load(object sender, EventArgs e)
        {
            //Graphics g;
            //g = this.CreateGraphics();
            ////Bitmap bitmap = new Bitmap(@"C:\Is.bmp");
            /////通过FromImage方法创建Graphics
            ////Graphics g = Graphics.FromImage(bitmap);
            //Brush brush = new SolidBrush(Color.Red); 
            //Rectangle rt = new Rectangle(10,10,100,100);
            //g.FillRectangle(brush,rt);
        }
        /// <summary>
        /// 绘制红色图形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();///创建Grapics对象
            Brush brush = new SolidBrush(Color.Red);//使用SolidBrushl类创建一个Brush对象
            Rectangle rt = new Rectangle(10,10,100,100);//绘制一个矩形
            graphics.FillRectangle(brush,rt);
        }
        /// <summary>
        /// 绘制长条图示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();//创建Grapics对象
            for (int i=1;i<6;i++)
            {
                HatchStyle hs = (HatchStyle)(5+i); //设置HatchStyle的值
                HatchBrush hatch = new HatchBrush(hs,Color.White);
                Rectangle rtl = new Rectangle(10,50*i,50*i,50);//根据i的值绘制矩形
                graphics.FillRectangle(hatch,rtl);///填充矩形
                
            }

        }
        /// <summary>
        /// 渐变图形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button3_Click(object sender, EventArgs e)
        {
            ///实例化Point类
            Point p1 = new Point(100,100);
            Point p2 = new Point(150,150);
            ///实例化LineGradientBrush类，设置其使用黑色和白色进行渐变
            LinearGradientBrush lgb = new LinearGradientBrush(p1,p2,Color.Black,Color.White);
            ///实例化Graphics类
            Graphics graphics = this.CreateGraphics();
            ///设置WrapMode属性指示该LinearGradientBrush的环绕模式
            lgb.WrapMode = WrapMode.TileFlipX;
            graphics.FillRectangle(lgb,15,15,150,150);
        }
        /// <summary>
        /// GDI绘图水平直线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            ///实例化Pen类
            Pen blackpen = new Pen(Color.Black,3);
            ///实例化一个Point类
            Point point1 = new Point(10,50);
            Point point2 = new Point(100,50);
            Graphics graphics = this.CreateGraphics();
            graphics.DrawLine(blackpen,point1,point2);

        }
        /// <summary>
        /// 垂直直线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
            Pen mypen = new Pen(Color.Black,3);
            graphics.DrawLine(mypen,150,30,150,100);
        }
        /// <summary>
        /// 绘制矩形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {

            Graphics graphics = this.CreateGraphics();
            Pen pen = new Pen(Color.Black,3);
            //调用DrawRectangle方法绘制矩形
            graphics.DrawRectangle(pen,10,10,150,100);


        }
        /// <summary>
        /// 绘制椭圆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
            Pen pen = new Pen(Color.Black,3);
            graphics.DrawEllipse(pen,100,50,100,50);
        }
        /// <summary>
        /// 绘制圆弧
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {

            Graphics graphics = this.CreateGraphics();
            Pen pen = new Pen(Color.Black,3);
            Rectangle rectangle = new Rectangle(70,20,100,600);
            graphics.DrawArc(pen,rectangle,220,220);
        }
        /// <summary>
        /// 绘制扇形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
            Pen pen = new Pen(Color.Black,3);
            graphics.DrawPie(pen,50,50,120,100,210,120);
        }
        /// <summary>
        /// 绘制多边形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
            Pen pen = new Pen(Color.Black,3);
            Point point1 = new Point(80, 20);
            Point point2 = new Point(40, 50);
            Point point3 = new Point(80, 80);
            Point point4 = new Point(160, 80);
            Point point5 = new Point(200, 50);
            Point point6 = new Point(160, 20);
            Point[] points = { point1,point2,point3,point4,point5,point6};
            graphics.DrawPolygon(pen ,points);
        }
    }
}
