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
using System.Web.UI.MobileControls;
using drugstore_admin1.Models;
using drugstore_admin1.BLL;
using System.Collections.Generic;

namespace drugstore_admin1
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProcessAdminIndex : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string rootDirectorey = context.Server.MapPath("/");
            if (context.Session["id"] != null)
            {                
                List<AdminModel> adminsList = AdminBLL.GetVisitedAdmin();
                string temp = File.ReadAllText(context.Server.MapPath("admin_index.html"));                
                StringBuilder sb = new StringBuilder();
                foreach (AdminModel item in adminsList)
                {
                    sb.AppendFormat(@"<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td></tr>",
                        item.AdminId, item.AdminName, item.AdminQuanxian, item.AdminPhone, item.AdminLastting);
                }
               
                
                //对模板页内容的替换
                temp = temp.Replace("@admin", context.Session["admin_name"].ToString());
                temp = temp.Replace("@content", sb.ToString());
                context.Response.Write(temp);
                context.Response.Write(context.Session["id"]);  
            }
            else
            {
                context.Response.Redirect(rootDirectorey+"admin_login.html");
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
