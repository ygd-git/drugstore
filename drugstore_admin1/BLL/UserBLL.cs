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
using drugstore_admin1.DAL;
using System.Data.SqlClient;

namespace drugstore_admin1.BLL
{
    public class UserBLL
    {
        public static void User1(string id) {
            string sqlText1 = "UPDATE Users set users_available = '0' WHERE users_id=@users_id";
            SqlParameter[] paras = new SqlParameter[]{
                        new SqlParameter("@users_id",id)
                    };
            SQLHelper.ExecuteNonQuery(sqlText1, paras);
        }
        public static DataTable User2(string name,string type) {
            string sqlText = "select * from users where users_name LIKE @users_name and users_available=@users_available";
            SqlParameter[] paras1 = new SqlParameter[]{
                        new SqlParameter("@users_name","%"+name+"%"),
                        new SqlParameter("@users_available",type)
                    };

            return SQLHelper.ExecuteDataTable(sqlText, paras1);
        }
        public static DataTable User3() {
            string sqlText = "select * from users";
            return SQLHelper.ExecuteDataTable(sqlText);
        }
        public static DataTable User4(string id)
        {
            string sql1 = "select * from Users where Users_id=@users_id";
            SqlParameter[] spa1 = new SqlParameter[]
            {
                new SqlParameter("@users_id",id)
            };
            return SQLHelper.ExecuteDataTable(sql1, spa1);
        }
        public static int User5(string newPsw,string id) {
            string sql2 = "update Users set Users_password =@psw where Users_id=@users_id";
            SqlParameter[] spa2 = new SqlParameter[]
                    {
                         new  SqlParameter("@psw",newPsw),
                          new SqlParameter("@users_id",id)
                    };
            return SQLHelper.ExecuteNonQuery(sql2, spa2);
        }
        public static int User6(string account,string name,string pwd,string time) {
            string sql = "insert into Users (Users_account,Users_name,Users_password,Users_login_time) values(@id,@name,@psw,@time)";
            SqlParameter[] spa = new SqlParameter[]
                {
                    new SqlParameter("@id",account),
                    new SqlParameter("@name",name),
                    new SqlParameter("@psw",pwd),
                    new SqlParameter("@time",time)
                };
            return SQLHelper.ExecuteNonQuery(sql, spa);
        }
        public static DataTable User7(string account,string password) {
            string sql = "select * from Users where users_account=@users_account and users_password=@users_psw";
            SqlParameter[] spa = new SqlParameter[]
            {
                new SqlParameter("@users_account",account),
               new SqlParameter("@users_psw",password)
            };
            return SQLHelper.ExecuteDataTable(sql, spa);
        }
        public static DataTable User8(string user_id) {
            string sql = "select * from Users where Users_id=@users_id";
            SqlParameter[] spa = new SqlParameter[]
            {
                new SqlParameter("@users_id",user_id)

            };
            return SQLHelper.ExecuteDataTable(sql, spa);
        }
    }
}
