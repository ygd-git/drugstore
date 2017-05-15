using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using drugstore_admin1.DAL;
using System.Data.SqlClient;
using System.IO;
using drugstore_admin1.BLL;

namespace drugstore_admin1
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProcessUsersLogin : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string account = context.Request.Form["account"];
            string password = context.Request.Form["password"];
            
            DataTable dt = UserBLL.User7(account,password);
           
            
                if (dt.Rows.Count>0)
                {
                    if (dt.Rows[0][4].ToString() == "1")
                       
                    {
                        context.Session["users_id"] = dt.Rows[0]["users_id"];
                        context.Session["user_name"] = dt.Rows[0]["users_name"];
                        context.Response.Redirect("../GoodsInfo/ProcessDrugIndex.ashx");
                    }
                   else
                     {
                       // context.Response.Write("<script>alert('该用户已被屏蔽')</script>");
                        context.Response.Redirect("~/drugstore_login.html");
                     }
                }
                else
                {
                    //context.Response.Write("<script>alert('用户名或密码错误')</script>");
                    context.Response.Redirect("~/drugstore_login.html");
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
