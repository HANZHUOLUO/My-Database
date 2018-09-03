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
    public partial class Linq : Form
    {
        public Linq()
        {
            InitializeComponent();
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            groupBox1.Location = new Point(Convert.ToInt32(panel1.Width-groupBox1.Width)/2,Convert.ToInt32(panel1.Height-groupBox1.Height)/2);
        }
        ///声明连接字符串
        string strCon = "Data Source=kingdee;Database=AIS20170527144859;Uid=sa;Pwd=123123;";
        LinqToSqlDataContext linq;//声明Linq对象
        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Linq_Load(object sender, EventArgs e)
        {
            SelectData();//调用查询数据方法
            //列表行选中变色
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.YellowGreen;
           


        }
        /// <summary>
        /// 查询点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.cbOne.Text == "" || this.txt1.Text == "")
            {
                MessageBox.Show("请选择查询条件以及填写查询关键字", "警告");
            }
            else
            {
                SelectData();///调用查询数据方法

            }

        }
        /// <summary>
        /// 查询数据方法
        /// </summary>
        private void SelectData()
        {
            linq =new LinqToSqlDataContext(strCon);
            ///如果查询条件或者关键字为空的话则查询所有部门
            if (this.cbOne.Text == "" || this.txt1.Text == "")
            {

                var result = from info in linq.t_Department
                             select new
                             {
                                 部门编号 = info.FNumber,
                                 部门名称 = info.FName,
                                 备注 = info.FNote
                             };
                dataGridView1.DataSource = result;
                gridControl1.DataSource = result;


            }
            else
            {
                switch(this.cbOne.Text)
                    {

                    case "部门编号":
                        var resultid = from info in linq.t_Department
                                       where info.FNumber == this.txt1.Text
                                       select new {
                                           部门编号 = info.FNumber,
                                           部门名称 = info.FName,
                                           备注 = info.FNote
                                       };
                        dataGridView1.DataSource = resultid;
                        gridControl1.DataSource = resultid;
                        break;
                    case "部门名称":
                        var resultname = from info in linq.t_Department
                                             //where info.FName.Contains(this.txt1.Text) 参数是否包含，精确查询
                                         where info.FName.IndexOf(this.txt1.Text)>=0 //类似于like关键字，模糊查询
                                         select new
                                         {
                                             部门编号=info.FNumber,
                                             部门名称=info.FName,
                                             备注=info.FNote
                                         };
                        dataGridView1.DataSource = resultname;
                        gridControl1.DataSource = resultname;
                        break;
                }
                
                   


            }

        }
    }
}
