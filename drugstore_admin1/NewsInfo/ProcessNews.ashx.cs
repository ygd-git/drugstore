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
using System.Collections.Generic;
using drugstore_admin1.Models;
using drugstore_admin1.BLL;
using System.Web.UI.MobileControls;

namespace drugstore_admin1
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProcessNews : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string type = "全部新闻";
            string temp = File.ReadAllText(context.Server.MapPath("drugstore_news.html"));
           
            //
            List<NewsModel> newsList = new List<NewsModel>();
            if (context.Request.QueryString["type"] !=null)
            {
                int newsType =  Int32.Parse(context.Request.QueryString["type"] .ToString());
                newsList = NewsBLL.GetNewsListByType(newsType);

            }
            else
            {

                newsList = NewsBLL.GetHotNewsList();
            }
            
            StringBuilder sb = new StringBuilder();
             
            int count = 1;
            if (newsList != null)
            {
                foreach (NewsModel item in newsList)
                {
                    //item["News_newstype"]

                    string newsTypeName = NewsTypeBLL.GetNameById(item.NewsType);
                    sb.AppendFormat("<tr><td>{0}</td><td><a href='ProcessNewsDetail.ashx?news_id={1}'>{2}</a></td><td>{3}</td><td>{4}</td></tr>", count, item.NewsId, item.NewsTitle, item.NewsViewCount.ToString(), newsTypeName);
                    count++;
                }
            }
            

            List<NewsTypeModel> newsTypeList = NewsTypeBLL.GetNewsList();
            StringBuilder sb3 = new StringBuilder();
            foreach (NewsTypeModel item in newsTypeList)
            {
                sb3.AppendFormat("<a href='ProcessNews.ashx?type={0}' class='list-group-item'>{1}</a>", item.NewsTypeid, item.NewsTypename);

            }


            temp = temp.Replace("@news_type", sb3.ToString());
            temp = temp.Replace("@type", type);
            temp = temp.Replace("@content", sb.ToString());
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
