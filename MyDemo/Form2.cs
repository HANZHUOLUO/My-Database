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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        #region //全局变量
        string str = "server=kingdee;database=mydatabase;uid=sa;pwd=123123";
        SqlConnection con;
        DataSet ds;
        SqlCommand cmd;
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            string proc = " Create Proc demo "
                + " AS "
                + " BEGIN "
                + " SELECT * FROM T_LoginInfo "
                + " END ";

            con = new SqlConnection(str);
            con.Open();
            cmd = new SqlCommand(proc,con);
           int i= cmd.ExecuteNonQuery();
            if (i>0)
            {
                MessageBox.Show("创建成功！","提示");
            }

        }
    }
}
