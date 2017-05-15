using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace drugstore_admin1.DAL
{
    public class SQLHelper
    {
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
        /// <summary>
        /// 执行变更操作（INSERT、UPDATE或INSERT语句）
        /// </summary>
        /// <param name="sqlText">SQL语句</param>
        /// <param name="paras">SQL语句的参数集合</param>
        /// <returns>执行成功则返回执行命令所影响的行数，失败则返回0，类型为int。</returns>
        
        public static int ExecuteNonQuery(string sqlText, params SqlParameter[] paras)
        {
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlText, conn))
                {
                    if (paras != null)
                    {
                        cmd.Parameters.AddRange(paras);
                    }
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// 多条sql语句
        /// </summary>
        /// <param name="sqlText"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sqlText, params SqlParameter[] paras)
        {
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlText, conn))
                {
                    if (paras != null)
                    {
                        cmd.Parameters.AddRange(paras);
                    }
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
        /// <summary>
        /// 执行SELECT查询操作，返回DataReader集合
        /// </summary>
        /// <param name="sqlText">SQL语句</param>
        /// <param name="paras">SQL语句的参数集合</param>
        /// <returns>返回DataReader集合</returns>
        public static SqlDataReader ExecuteReader(string sqlText, params SqlParameter[] paras)
        {
            SqlConnection conn = new SqlConnection(conStr);
            using (SqlCommand cmd = new SqlCommand(sqlText, conn))
            {
                if (paras != null)
                {
                    cmd.Parameters.AddRange(paras);
                }
                try
                {
                    conn.Open();
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch (System.Exception ex)
                {
                    conn.Close();
                    conn.Dispose();
                    throw;
                }
            }
        }

        public static DataTable ExecuteDataTable(string sqlText, params SqlParameter[] paras)
        {
            using (SqlDataAdapter da = new SqlDataAdapter(sqlText, conStr))
            {
                if (paras != null)
                {
                    da.SelectCommand.Parameters.AddRange(paras);
                }
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
