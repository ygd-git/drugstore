using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using drugstore_admin1.DAL;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using drugstore_admin1.BLL;

namespace drugstore_admin1
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProcessAdminUsers : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            if (context.Session["id"] != null)
            {
                if (context.Request.Params["users_id"] != null)
                {
                    UserBLL.User1(context.Request.Params["users_id"].ToString());
                }
                string sqlText = "";
                DataTable dt ;
                if (context.Request.Form["name"] != null || context.Request.Form["class"] != null )
                {
                    
                   

                    dt = UserBLL.User2(context.Request.Form["name"].ToString(), context.Request.Form["class"].ToString());

                }
                else
                {

                    dt = UserBLL.User3();
                }                
               
                string temp = File.ReadAllText(context.Server.MapPath("drugstore_admin_user.html"));
                StringBuilder sb = new StringBuilder();
                foreach (DataRow item in dt.Rows)
                {
                    if ( item["users_available"].ToString() == "1")
                    {
                        sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td><a href='ProcessAdminUsers.ashx?users_id={0}' class='btn btn-danger'>屏蔽</a></td></tr>", item["users_id"], item["users_name"]);
                    }
                    else
                    {
                        sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td><a href='ProcessAdminUsers.ashx?users_id={0}'  class='btn btn-danger disabled'>屏蔽</a></td></tr>", item["users_id"], item["users_name"]);
                    }
                }
                temp = temp.Replace("@admin", context.Session["admin_name"].ToString());
                temp = temp.Replace("@content", sb.ToString());
                context.Response.Write(temp);
            }
            else
            {
                context.Response.Redirect("~/admin_login.html");
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
