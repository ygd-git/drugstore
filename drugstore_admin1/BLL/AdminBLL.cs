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
using drugstore_admin1.Models;
using drugstore_admin1.DAL;
using System.Data.SqlClient;
using System.Web.UI.MobileControls;
using System.Collections.Generic;

namespace drugstore_admin1.BLL
{
    public class AdminBLL
    {
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="admin"></param>
        /// <returns>搜索到记录的行数</returns>
        public static int AdminLogin(AdminModel admin) {
            string sqlText = "select count(*) from admin where admin_id=@id and admin_pwd=@pwd";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@id",admin.AdminId),
                new SqlParameter("@pwd",admin.AdminPwd)
            };

            int i = (int)SQLHelper.ExecuteScalar(sqlText, paras);
            return i;
        }
        /// <summary>
        /// 显示最近访问记录根据时间
        /// </summary>
        /// <returns>管理员列表</returns>
        public static List<AdminModel> GetVisitedAdmin() {
            string sqlText = "select * from admin order by admin_lasttime desc";
            SqlDataReader sdr = SQLHelper.ExecuteReader(sqlText);
            List<AdminModel> adminsList = new List<AdminModel>();

            if (sdr != null)
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        AdminModel admin = new AdminModel();
                        admin.AdminId = Convert.ToInt32(sdr["admin_id"]);
                        admin.AdminName = sdr["admin_name"].ToString();
                        admin.AdminPwd = sdr["admin_pwd"].ToString();
                        admin.AdminName = sdr["admin_name"].ToString();
                        admin.AdminLastting = Convert.ToDateTime(sdr["admin_lasttime"]);
                        admin.AdminQuanxian = Convert.ToInt32(sdr["admin_quanxian"]);
                        admin.AdminPhone = sdr["admin_phone"].ToString();                        
                        adminsList.Add(admin);
                    }
                    sdr.Close();
                    return adminsList;
                }
                else
                    return null;
            }
            else
                return null;
        }
        /// <summary>
        /// 登录时同步登录时间
        /// </summary>
        /// <param name="adminId">管理员ID</param>
        /// <returns>结果</returns>
        public static int UpdataLoginTime(int adminId)
        { 
            string sqlText = "UPDATE admin SET admin_lasttime = @admin_lasttime where admin_id = @admin_id";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@admin_lasttime",DateTime.Now),
                new SqlParameter("@admin_id",adminId)
            };
            int i = SQLHelper.ExecuteNonQuery(sqlText, paras);
            return i;
        }
        /// <summary>
        /// 根据admin表主键  获得管理员姓名
        /// </summary>
        /// <param name="adminId">管理员ID</param>
        /// <returns></returns>
        public static string GetNameById(int adminId) {
            string sqlText = "SELECT admin_name FROM admin WHERE admin_id=@admin_id";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@admin_id",adminId)
            };
            string name = SQLHelper.ExecuteScalar(sqlText, paras).ToString();
            return name;
        }
    }
}
