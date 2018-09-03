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
    public partial class LinqAdd : Form
    {
        public LinqAdd()
        {
            InitializeComponent();
        }
        string strsql = "server=kingdee;database=mydatabase;uid=sa;pwd=123123";
        MydatabaseDataContext linq;
        /// <summary>
        /// 首次加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinqAdd_Load(object sender, EventArgs e)
        {
            SelectInfo();
            ///点击行还色
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.YellowGreen;

        }
        /// <summary>
        /// 添加信息事件
        /// </summary>
         private void button1_Click(object sender, EventArgs e)
        {
            linq = new MydatabaseDataContext(strsql);
            T_LoginInfo LoInFo = new T_LoginInfo();//创建员工信息表实体
            LoInFo.fnumber = Convert.ToInt32( this.Fnumber.Text);
            LoInFo.FNAME = this.Fname.Text;
            LoInFo.FSEX = Convert.ToChar( this.FSEX.Text);
            LoInFo.FTEL = this.FTEL.Text;
            LoInFo.FADRESS = this.FADRESS.Text;
            linq.T_LoginInfo.InsertOnSubmit(LoInFo);//添加实体
            linq.SubmitChanges();//提交操作
            SelectInfo();
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        private void SelectInfo()
        {
            linq = new MydatabaseDataContext(strsql);
            //获取所有员工信息
            var result = from info in linq.T_LoginInfo
                         select new
                         {
                             员工编码=info.fnumber,
                             员工姓名=info.FNAME,
                             性别=info.FSEX,
                             联系方式=info.FTEL,
                             家庭住址=info.FADRESS

                         };

            dataGridView1.DataSource = result;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            linq = new MydatabaseDataContext(strsql);
            //获取选中的员工编号
            Fnumber.Text = Convert.ToString(dataGridView1[0, e.RowIndex].Value).Trim();
            //根据员工编号获取其详细信息，并重新生成一个表
            var result = from info in linq.T_LoginInfo
                         where info.fnumber == Convert.ToInt32(Fnumber.Text)
                         select new
                         {
                             员工编码 = info.fnumber,
                             员工姓名 = info.FNAME,
                             性别 = info.FSEX,
                             联系方式 = info.FTEL,
                             家庭住址 = info.FADRESS
                         };
            ///相应的文本框及下拉列表中显示选中的员工信息
            foreach (var item in result)
            {
                Fname.Text = item.员工姓名;
                FSEX.Text = Convert.ToString(item.性别);
                FTEL.Text = item.联系方式;
                FADRESS.Text = item.家庭住址;

            }
            //用datagridview属性
            //Fnumber.Text = dataGridView1.SelectedCells[0].Value.ToString();
            //Fname.Text = dataGridView1.SelectedCells[1].Value.ToString();
            //FSEX.Text = dataGridView1.SelectedCells[2].Value.ToString();
            //FTEL.Text = dataGridView1.SelectedCells[3].Value.ToString();
            //FADRESS.Text = dataGridView1.SelectedCells[4].Value.ToString();

        }
        /// <summary>
        /// 修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (Fnumber.Text=="")
            {
                MessageBox.Show("请选择要修改的记录","警告");
                return;
            }
            linq = new MydatabaseDataContext(strsql);
            var result = from info in linq.T_LoginInfo
                         where info.fnumber == Convert.ToInt32(Fnumber.Text)
                         select info;
            //用foreach进行循环
            foreach (T_LoginInfo info in result)
            {
                info.FNAME = Fname.Text;
                info.FSEX = Convert.ToChar(FSEX.Text);
                info.FTEL = FTEL.Text;
                info.FADRESS = FADRESS.Text;
                linq.SubmitChanges();

            }
        
            MessageBox.Show("修改成功！","提示");
            SelectInfo();
        }
        /// <summary>
        /// 右键审核操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Fnumber.Text == "")
            {
                MessageBox.Show("请选择要删除的记录","警告");
                return;
            }
            linq = new MydatabaseDataContext(strsql);
            var result = from info in linq.T_LoginInfo
                         where info.fnumber == Convert.ToInt32(Fnumber.Text)
                         select info;
            linq.T_LoginInfo.DeleteAllOnSubmit(result);
            linq.SubmitChanges();
            MessageBox.Show("删除成功！","提示");
            SelectInfo();
        }
    }
}
