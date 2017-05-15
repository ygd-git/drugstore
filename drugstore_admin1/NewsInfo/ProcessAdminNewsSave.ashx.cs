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
using drugstore_admin1.Models;
using drugstore_admin1.BLL;

namespace drugstore_admin1.NewsInfo
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProcessAdminNewsSave : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session["id"] != null)
            {
                context.Response.ContentType = "text/html";
                string newsId = context.Request.QueryString["News_id"];

                string title = context.Request.Form["title"];
                string type = context.Request.Form["type"];
                string content = context.Request.Form["content"];

                NewsModel news = new NewsModel(Convert.ToInt32( newsId), title, content, DateTime.Now, 0, "", Convert.ToInt32(type), "");


                int i = NewsBLL.UpdateNews(news);
                if (i > 0)
                {
                    context.Response.Write("新闻修改成功<a href='ProcessAdminNews.ashx'>回到新闻首页</a>");
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
