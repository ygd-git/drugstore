using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.IO;
using System.Data.SqlClient;
using drugstore_admin1.DAL;

namespace drugstore_admin1.UsersInfo
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProcessPassword : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            if (context.Session["users_id"] != null)
            {
                string userId = context.Session["users_id"].ToString();
                
                string temp = File.ReadAllText(context.Server.MapPath("drugstore_password.html"));
                string sqlText = "SELECT users_account from	 Users WHERE users_id = @users_id";
                SqlParameter para = new SqlParameter("@users_id", userId);
                string userAccount = SQLHelper.ExecuteScalar(sqlText, para).ToString();
                temp = temp.Replace("@name", userAccount);
                context.Response.Write(temp);
               
                
            }
            else
            {
                context.Response.Write("请先登录后再来修改密码<a href='../drugstore_login.html'>登录界面</a>");
            }
            
            
            
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
