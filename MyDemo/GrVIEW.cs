﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyDemo
{
    public partial class GrVIEW : DevExpress.XtraEditors.XtraForm
    {
        public GrVIEW()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            // Fill a SqlDataSource
            sqlDataSource1.Fill();
        }
        SqlHelp sqlh = new SqlHelp();
        DataSet DS;
        SqlDataAdapter sda;
        private void GrVIEW_Load(object sender, EventArgs e)
        {
            sqlh.ConDB();
            SqlCommand cmd = new SqlCommand("SELECT * FROM T_LoginInfo",sqlh.ConDB());
            cmd.Connection = sqlh.ConDB();
             sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DS= new DataSet();
            sda.Fill(DS,"test");
            dataGridView1.DataSource = DS.Tables[0];
            dataGridView1.Columns[0].HeaderText = "编码";
            dataGridView1.Columns[1].HeaderText = "姓名";
            dataGridView1.Columns[2].HeaderText = "性别";
            dataGridView1.Columns[3].HeaderText = "电话";
            dataGridView1.Columns[4].HeaderText = "籍贯";
            label6.Visible = false;
            ///设置单元格选项的颜色
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.YellowGreen;

        }
        /// <summary>
        /// 复制单据体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
         

            DataSet DS1 = DS.Copy();
            dataGridView2.DataSource = DS.Tables[0];
            dataGridView2.RowHeadersVisible = false;//禁止显示行标题
            //用FOR循环控制控件的列宽
            for (int i=0;i<dataGridView1.ColumnCount;i++)
            {
                dataGridView1.Columns[i].Width = 84;
            }

            simpleButton1.Enabled = false;
            //将控件设置成只读
            dataGridView1.ReadOnly = true;

        }
        /// <summary>
        /// 合并数据表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
     
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM T_LOGININFO",sqlh.ConDB());
            SqlDataAdapter sda1 = new SqlDataAdapter("SELECT * FROM T_LOGININFO1", sqlh.ConDB());
            sda.Fill(ds);
            SqlCommandBuilder SQLCOM = new SqlCommandBuilder(sda1);
            sda1.Fill(ds1);
            //使用merge方法合并
            ds1.Merge(ds,true,MissingSchemaAction.AddWithKey);
            dataGridView1.DataSource = ds1.Tables[0];
        }
        /// <summary>
        /// datagridview选中当前行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FBILLNO.Text = dataGridView1.SelectedCells[0].Value.ToString();
            FNAME.Text = dataGridView1.SelectedCells[1].Value.ToString();
            FSEX.Text = dataGridView1.SelectedCells[2].Value.ToString();
            FTEL.Text = dataGridView1.SelectedCells[3].Value.ToString();
            FARRESS.Text = dataGridView1.SelectedCells[4].Value.ToString();


        }
        /// <summary>
        /// 更改单元格中的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DataTable dt = DS.Tables["test"];///创建一个datatable
            sda.FillSchema(dt, SchemaType.Mapped);///吧数据加载到内存表中
            DataRow dw = dt.Rows.Find(FBILLNO.Text);//
            //设置datarow中的值
            dw["FNAME"] = FNAME.Text.Trim();
            dw["FSEX"] = FSEX.Text.Trim();
            dw["FTEL"] = FTEL.Text.Trim();
            dw["FADRESS"] = FARRESS.Text.Trim();
            SqlCommandBuilder sqlCommand = new SqlCommandBuilder(sda);
            sda.Update(dt);
        }
        /// <summary>
        /// 获取当前行信息事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string msg = string.Format("第{0}行，第{1}列", dataGridView1.CurrentCell.RowIndex+1,dataGridView1.CurrentCell.ColumnIndex+1);
            this.label6.Visible = true;
            label6.Text = "当前选中的单元格：" + msg;
        }
        ///datatable方法
        private DataTable dbcon(string mysql)
        {
            sqlh.ConDB();
            sda = new SqlDataAdapter(mysql,sqlh.ConDB());
            DataTable dtselect = new DataTable();
            int rnt = this.sda.Fill(dtselect); //填充datatable对象
            sqlh.UConDB();//关闭连接
            return dtselect;//返回datatable对象

        }
        /// <summary>
        /// 直接在gridview中修改数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (dbUPDATE())
            {
                MessageBox.Show("修改成功！");
            }
        }
        //boolean类型的方法dbUpdata用于更改数据
        public Boolean dbUPDATE()
        {
            string sql = "SELECT * FROM T_LoginInfo";
            DataTable dtUPDATE1 = new DataTable();
            dtUPDATE1 = this.dbcon(sql);
            dtUPDATE1.Rows.Clear();
            DataTable dtSHOW = new DataTable();
            dtSHOW = (DataTable)this.dataGridView1.DataSource;
            for (int I = 0; I < dtSHOW.Rows.Count; I++)
            {
                dtUPDATE1.ImportRow(dtSHOW.Rows[I]);
              
            }
            try
            {
                sqlh.ConDB();
                SqlCommandBuilder sqlA = new SqlCommandBuilder(sda);
                sda.Update(dtUPDATE1);
                sqlh.UConDB();
            }
            catch(Exception EX)
            {
                MessageBox.Show(EX.Message.ToString());
                return false;
            }
            dtUPDATE1.AcceptChanges();//提交更改
            return true;
            
        }
    }
}
