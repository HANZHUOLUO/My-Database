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
    public partial class DatacontrolReprt : Form
    {
        public DatacontrolReprt()
        {
            InitializeComponent();
        }
        SqlHelp sqlh = new SqlHelp();
        SqlDataAdapter sda;
        DataSet DS;
        private void DatacontrolReprt_Load(object sender, EventArgs e)
        {
            string bgndate = "2017/01/01";
            string enddate =Convert.ToString( DateTime.Now.ToShortDateString());
            sqlh.ConDB();
            string exsql = string.Format("EXEC REPORT '{0}','{1}',' ',' '",bgndate,enddate);
            SqlCommand cmd = new SqlCommand(exsql, sqlh.ConDB());
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlh.ConDB();
            sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DS = new DataSet();
            sda.Fill(DS, "test");
            
            gridControl1.DataSource = DS.Tables[0];
           
            ///设置单元格颜色
            //gridView1. = DataGridViewSelectionMode.FullColumnSelect;


            toolStripStatusLabel1.Text = "一共："+gridView1.RowCount+"行数据";
          
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //string bgndate = "2017/01/01";
            //string enddate = Convert.ToString(DateTime.Now.ToShortDateString());
            sqlh.ConDB();
            string exsql = string.Format("EXEC REPORT '{0}','{1}','{2} ','{3} '", this.FBGNDATE.Value, this.FENDDATE.Value,this.FITEMNUMBER.Text,this.FSUPPLYNAME.Text);
            SqlCommand cmd = new SqlCommand(exsql, sqlh.ConDB());
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlh.ConDB();
            sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DS = new DataSet();
            sda.Fill(DS, "test");
            gridControl1.DataSource = DS.Tables[0];
            toolStripStatusLabel1.Text = "一共：" + gridView1.RowCount + "行数据";

        }
    }
}
