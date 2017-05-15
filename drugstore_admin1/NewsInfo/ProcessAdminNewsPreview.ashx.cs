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
using drugstore_admin1.Models;
using drugstore_admin1.BLL;

namespace drugstore_admin1
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProcessAdminNewsPreview : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            if (context.Session["id"] != null)
            {
                string newsId = context.Request.QueryString["news_id"];
                string temp = File.ReadAllText(context.Server.MapPath("drugstore_admin_news_preview.html"));
                string sqlText = "SELECT TOP(1) * FROM News WHERE News_id=@News_id";
                NewsModel news = NewsBLL.GetANews(newsId);
                temp = temp.Replace("@news_title", news.NewsTitle);
                temp = temp.Replace("@news_time", news.NewsTime.ToString());
                temp = temp.Replace("@news_source", news.NewsSource);
                temp = temp.Replace("@news_content", news.NewsContent);

                temp = temp.Replace("@admin", context.Session["admin_name"].ToString());
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
