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
    public partial class AddGridView : Form
    {
        public AddGridView()
        {
            InitializeComponent();
        }

        private void AddGridView_Load(object sender, EventArgs e)
        {
            ///指定列显示的行数
            dataGridView1.ColumnCount = 4;
            dataGridView1.ColumnHeadersVisible = true;
            ///控制列标题样式
            DataGridViewCellStyle dgcs = new DataGridViewCellStyle();
            dgcs.BackColor = Color.Blue;///设置背景色
            dgcs.Font = new Font("楷体",10,FontStyle.Bold);//设置字体样式
            dataGridView1.ColumnHeadersDefaultCellStyle = dgcs;//将设置参数赋给dataGridView1
            //设置下拉列表
            DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
            col.Name = "编号";
            this.dataGridView1.Columns.Add(col);
            //设置按钮
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "测试";
            dataGridView1.Columns.Add(btn);
            
            ///设置列标题
            //dataGridView1.Columns[0].Name = "编号";
            dataGridView1.Columns[1].Name = "姓名";
            dataGridView1.Columns[2].Name = "年龄";
            dataGridView1.Columns[3].Name = "性别";
            //填充行数据
            string[] rows1 = new string[] {"001","a","12","男" };
            string[] rows2 = new string[] { "002","b","13","男"};
            string[] rows3 = new string[] { "003","c","14","男"};
            object[] strRows = new object[] { rows1,rows2,rows3};
            //遍历OBJECT数组,讲数据添加到datagridview数据中
            foreach (string[] str in strRows)
            {
                dataGridView1.Rows.Add(str);

             }
            //设置单元格颜色
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.YellowGreen;
            dataGridView1.AllowUserToAddRows = false;//禁止添加行
            dataGridView1.AllowUserToDeleteRows = false;//禁止删除行
            dataGridView1.ReadOnly = true;//控件中的数据为只读
            ///asda
        }
    }
}
