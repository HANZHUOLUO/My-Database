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
using System.Reflection;
using Kingdee.BOS.DeskClient;
using Kingdee.BOS.DeskClient.WinService;

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
            //    try
            //    {
            //        Type t = System.Type.GetTypeFromProgID("K3Login.ClsLogin");

            //        if (t == null)
            //        {
            //            MessageBox.Show("加载金蝶登录器失败,需要安装金蝶客户端.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }

            //        object loginer = Activator.CreateInstance(t);

            //        if (loginer == null)
            //        {
            //            return;
            //        }
            //        object o = t.InvokeMember("CheckLogin", BindingFlags.Default | BindingFlags.InvokeMethod, null, loginer, null);             
            //        if (Convert.ToBoolean(o))
            //            MessageBox.Show("OK");
            //        else
            //            MessageBox.Show("NOK");
            //        //获取指定属性的数据
            //        MessageBox.Show(t.InvokeMember("PropsString", BindingFlags.GetProperty, null, loginer, null).ToString());

            //    }
            //    catch(Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
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
    }
}
