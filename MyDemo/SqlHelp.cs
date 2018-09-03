using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MyDemo
{
    class SqlHelp
    {
        SqlConnection con;
        /// <summary>
        /// 打开数据库连接
        /// </summary>
        /// <returns></returns>
        public SqlConnection ConDB()
        {
            string str = "server=kingdee;database=MYDATABASE;uid=sa;pwd=123123";
            con = new SqlConnection(str);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();

            }
            return con;
         

        }

        public SqlConnection UConDB()
        {
            string str = "server=kingdee;database=MYDATABASE;uid=sa;pwd=123123";
            con = new SqlConnection(str);
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();

            }
            return con;


        }
    }
}
