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
using drugstore_admin1.BLL;
using drugstore_admin1.Models;

namespace drugstore_admin1
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProcessAdminAddNews : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            if (context.Session["id"] != null)
            {
                string title = context.Request.Form["title"];
                string type = context.Request.Form["type"];
                string content = context.Request.Form["content"];

                string adminName = AdminBLL.GetNameById(Convert.ToInt32(context.Session["id"]));                

                
                NewsModel news = new NewsModel(0, title, content, DateTime.Now, 0, "", Convert.ToInt32(type), adminName);
                int i = NewsBLL.AddNews(news);
                if (i>0)
                {
                    context.Response.Write("新闻添加成功<a href='ProcessAdminNews.ashx'>回到新闻首页</a>");
                }
                
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
