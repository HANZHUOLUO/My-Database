using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using k3Login;
using Kingdee.K3.Forms;
using Kingdee.K3.Share;
using System.Reflection;///复杂方法引用类库
using Kingdee.BOS.DeskClient;
using Kingdee.BOS.DeskClient.WinService;
using EBCGL;
using EBCGLView;
using SystemServer;

namespace MyDemo
{
    public partial class 调用K3登录界面 : Form
    {
        public 调用K3登录界面()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 调用K3wise登录界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ///简单方法
            k3Login.ClsLogin login = new k3Login.ClsLoginClass();
            login.CheckLogin();
            if (login.CheckLogin())
            {
                string str = "帐套信息："+login.AcctName+"用户名："+login.UserName+"密码:"+login.IsDemo+login.IsIndustry+login.PropsString+login.ServerMgr;
            }

            #region 复杂方法
            try
            {
                Type t = System.Type.GetTypeFromProgID("K3Login.ClsLogin");

                if (t == null)
                {
                    MessageBox.Show("加载金蝶登录器失败,需要安装金蝶客户端.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                object loginer = Activator.CreateInstance(t);

                if (loginer == null)
                {
                    return;
                }
                object o = t.InvokeMember("CheckLogin", BindingFlags.Default | BindingFlags.InvokeMethod, null, loginer, null);
                if (Convert.ToBoolean(o))
                    MessageBox.Show("OK");
                else
                    MessageBox.Show("NO");
                //获取指定属性的数据
                MessageBox.Show(t.InvokeMember("PropsString", BindingFlags.GetProperty, null, loginer, null).ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion

        }
        /// <summary>
        /// 调用金蝶云登录界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            K3CloudDeskAppActiveXLib.K3CloudDeskAppActiveX k3Cloud = new K3CloudDeskAppActiveXLib.K3CloudDeskAppActiveXClass();
            //k3Cloud.OpenDeskApp("127.0.0.1");
            K3CloudDeskAppActiveXLib._DK3CloudDeskAppActiveX _DK3Cloud = new K3CloudDeskAppActiveXLib.K3CloudDeskAppActiveXClass();
            //_DK3Cloud.OpenDeskApp("127.0.0.1");

           
              
        }
        /// <summary>
        /// 调用物料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //EBCGLView.GLView gLView = new  EBCGLView.GLViewClass();
            //gLView.ItemShowList();
          
            #region 复杂方法
            try
            {
                Type t = System.Type.GetTypeFromProgID("EBCGLView.GLView");

                if (t == null)
                {
                    MessageBox.Show("未安装客户端,系统无法继续");
                    return;
                }

                object loginer = Activator.CreateInstance(t);

                if (loginer == null)
                {
                    return;
                }
                object[] obj = new object[] { 4 };//物料的索引为4.修改此处的索引就可以获取不同的查询
                object o = t.InvokeMember("ItemLookup", BindingFlags.Default | BindingFlags.InvokeMethod, null, loginer, obj) as object;

                object ret = o.GetType().InvokeMember("ReturnObject", BindingFlags.GetProperty, null, o, null) as object;
                if (ret == null)
                {
                    return;
                }

                //this.txtName.Text = ret.GetType().InvokeMember("Name", BindingFlags.GetProperty, null, ret, null).ToString();//获取名陈
                //this.txtItemID.Text = ret.GetType().InvokeMember("itemid", BindingFlags.GetProperty, null, ret, null).ToString();//获取内码id
                //this.txtNumber.Text = ret.GetType().InvokeMember("Number", BindingFlags.GetProperty, null, ret, null).ToString();//获取代码
            }
            catch
            {

            }
            #endregion
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            SystemServer.Form1 form1 = new SystemServer.Form1();
            form1.Show();
        }
    }
}
