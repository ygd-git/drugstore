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
using System.Text;
using drugstore_admin1.BLL;
using drugstore_admin1.Models;

namespace drugstore_admin1
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProcessNewsDetail : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int newsId = context.Request.QueryString["news_id"] == null ? 0 : Int32.Parse(context.Request.QueryString["news_id"]);
            string temp=File.ReadAllText(context.Server.MapPath("drugstore_news_detail.html"));
            //点击数加1
            int i = NewsBLL.UpdateNewsView(newsId);


            NewsModel news = NewsBLL.GetANews(newsId.ToString());
            temp = temp.Replace("@title", news.NewsTitle);
            temp = temp.Replace("@datetime", news.NewsTime.ToString());
            temp = temp.Replace("@source", news.NewsSource);
            temp = temp.Replace("@content", news.NewsContent);


            if (context.Session["users_id"] != null)
            {
                temp = temp.Replace("@user_name", context.Session["user_name"].ToString());
            }
            else
            {
                temp = temp.Replace("@user_name", "游客");
            }
            context.Response.Write(temp);
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
