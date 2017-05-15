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
using System.Text;
using drugstore_admin1.Models;
using drugstore_admin1.BLL;
using System.Web.UI.MobileControls;
using System.Collections.Generic;

namespace drugstore_admin1.NewsInfo
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProcessAdminNewsSaveIndex : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session["id"] != null)
            {
                context.Response.ContentType = "text/html";
                string news_id = context.Request.QueryString["news_id"];
                string temp = File.ReadAllText(context.Server.MapPath("drugstore_admin_news_save.html"));
                NewsModel news = NewsBLL.GetANews(news_id);
                int newsType = news.NewsType;
                temp = temp.Replace("@news_title", news.NewsTitle);
                temp = temp.Replace("@news_content", news.NewsContent);


                List<NewsTypeModel> newsTypeList = NewsTypeBLL.GetNewsList();
                StringBuilder sb = new StringBuilder();
                string selectedHtml = "";
                foreach (NewsTypeModel item in newsTypeList)
                {
                    if (newsType == item.NewsTypeid)
                    {
                        selectedHtml = "selected = 'true'";
                    }
                    sb.AppendFormat("<option value='{0}' {2}>{1}</option>", item.NewsTypeid.ToString(), item.NewsTypename,selectedHtml);
                    selectedHtml = "";
                }
                temp = temp.Replace("@newstype_content", sb.ToString());
                temp = temp.Replace("@News_id", news_id);
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
