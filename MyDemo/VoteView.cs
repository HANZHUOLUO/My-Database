using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;

namespace MyDemo
{
    public partial class VoteView : Form
    {
        public VoteView()
        {
            InitializeComponent();
        }
        private int sum;
        SqlConnection con;
        private void VoteView_Load(object sender, EventArgs e)
        {

        }
        ///绘制图形
        private void CreateImage()
        {

            con = new SqlConnection("server=kingdee;database=db_CSharp;uid=sa;pwd=123123 ");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT sum(票数) FROM tb_vote",con);
            ///使用ExeciteScalar方法取的总票数
            sum = (int)cmd.ExecuteScalar();
            //实例化SQLdataadapter对象
            SqlDataAdapter sda = new SqlDataAdapter("select * FROM TB_VOTE",con);
            DataSet ds = new DataSet();///实例化dataset对象
            sda.Fill(ds);
            int TP1 = Convert.ToInt32(ds.Tables[0].Rows[0][2].ToString());///第一项票数
            int TP2 = Convert.ToInt32(ds.Tables[0].Rows[1][2].ToString());///第二项票数
            int TP3 = Convert.ToInt32(ds.Tables[0].Rows[2][2].ToString());///第三项票数
            int TP4 = Convert.ToInt32(ds.Tables[0].Rows[3][2].ToString());///第四项票数
            ///计算每个占比
            float tp1 = Convert.ToSingle(Convert.ToSingle(TP1) * 100 / Convert.ToSingle(sum));
            float tp2 = Convert.ToSingle(Convert.ToSingle(TP2)*100/Convert.ToSingle(sum));
            float tp3 = Convert.ToSingle(Convert.ToSingle(TP3)*100/Convert.ToSingle(sum));
            float tp4 = Convert.ToSingle(Convert.ToSingle(TP4) * 100 / Convert.ToSingle(sum));
            //声明宽和高
            int width = 300, height = 300;
            //创建一个bitmp对象
            Bitmap bitmap = new Bitmap(width,height);
            Graphics graphics = Graphics.FromImage(bitmap);
            try
            {
                graphics.Clear(Color.White);///使用Clear方法画布为白色
                                            ///创建6个beush对象
                Brush brush1 = new SolidBrush(Color.White);
                Brush brush2 = new SolidBrush(Color.Black);
                Brush brush3 = new SolidBrush(Color.Red);
                Brush brush4 = new SolidBrush(Color.Green);
                Brush brush5 = new SolidBrush(Color.Orange);
                Brush brush6 = new SolidBrush(Color.DarkBlue);
                //创建两个Font对象用于设置字体
                Font font1 = new Font("楷体",16,FontStyle.Bold);
                Font font2 = new Font("楷体", 8);
                graphics.FillRectangle(brush1, 0, 0, width, height);
                graphics.DrawString("投票结果",font1,brush2,new Point(90,20));///绘制标题
                //设置坐标
                Point p1 = new Point(70,50);
                Point p2 = new Point(230, 50);
                graphics.DrawLine(new Pen(Color.Black),p1,p2);///绘制直线
                ///绘制文字
                graphics.DrawString("用一生下载你",font2,brush2,new Point(10,80));
                graphics.DrawString("一生所爱：", font2, brush2, new Point(32, 110));
                graphics.DrawString("芸烨湘枫：", font2, brush2, new Point(32, 140));
                graphics.DrawString("情茧：", font2, brush2, new Point(54, 170));
                ///绘制柱状图
                graphics.FillRectangle(brush3, 95, 80, tp1, 17);
                graphics.FillRectangle(brush4, 95, 110, tp2, 17);
                graphics.FillRectangle(brush5, 95, 140, tp3, 17);
                graphics.FillRectangle(brush6, 95, 170, tp4, 17);
                ///绘制所有选项的票数显示
                graphics.DrawRectangle(new Pen(Color.Green), 10, 210, 280, 80);///绘制范围框
                graphics.DrawString("用一生下载你:"+TP1.ToString()+"票",font2,brush2,new Point(15,220));
                graphics.DrawString("一生所爱:" + TP2.ToString() + "票", font2, brush2, new Point(150, 220));
                graphics.DrawString("芸烨湘枫:" + TP3.ToString() + "票", font2, brush2, new Point(15, 260));
                graphics.DrawString("情茧:" + TP4.ToString() + "票", font2, brush2, new Point(150, 260));
                pictureBox1.Image = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void VoteView_Paint(object sender, PaintEventArgs e)
        {
            CreateImage();
        }
    }
}
