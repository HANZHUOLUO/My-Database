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

namespace MyDemo
{
    public partial class vote : Form
    {
        public vote()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vote_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
        }
        /// <summary>
        /// 投票
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string sql = "server=kingdee;database=db_CSharp;uid=sa;pwd=123123 ";
                SqlConnection con = new SqlConnection(sql);
                string Sqlstr = "";
                if (radioButton1.Checked)
                {
                    Sqlstr= "update tb_vote set 票数=票数+1 where 选项='" + radioButton1.Text + "'";
                }
                if (radioButton2.Checked)
                {

                    Sqlstr = "update tb_vote set 票数=票数+1 where 选项='" + radioButton2.Text + "'";
                }
                if (radioButton3.Checked)
                {
                    Sqlstr = "update tb_vote set 票数=票数+1 where 选项='" + radioButton3.Text + "'";
                }
                if (radioButton4.Checked)
                {
                    Sqlstr = "update tb_vote set 票数=票数+1 where 选项='" + radioButton4.Text + "'";
                }
                con.Open();
                SqlCommand cmd = new SqlCommand(Sqlstr,con);
                int i = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (i > 0)
                {
                    MessageBox.Show("投票成功！");
                    con.Close();
                }
                else {
                    MessageBox.Show("请选择需要投票的项！");
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// 查看结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            VoteView voteView = new VoteView();
            voteView.Show();

        }
    }
}
