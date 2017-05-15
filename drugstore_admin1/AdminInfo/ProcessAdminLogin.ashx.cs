using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
using drugstore_admin1.DAL;
using System.IO;
using drugstore_admin1.Models;
using drugstore_admin1.BLL;

namespace drugstore_admin1
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProcessAdminLogin : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            
            string id = context.Request.Form["id"];
            string pwd = context.Request.Form["pwd"];

            AdminModel newAdmin = new AdminModel();
            newAdmin.AdminId = Int32.Parse(id);
            newAdmin.AdminPwd = pwd;
            int i = AdminBLL.AdminLogin(newAdmin);
            
            //context.Response.Write(i);
            if (i > 0)
            {
                AdminBLL.UpdataLoginTime(Int32.Parse(id));
                string name = AdminBLL.GetNameById(Int32.Parse(id));

                context.Session["admin_name"] = name;
                context.Session["id"] = id;
                context.Response.Redirect("ProcessAdminIndex.ashx");

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
