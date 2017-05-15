using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.IO;
using drugstore_admin1.DAL;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using drugstore_admin1.Models;
using drugstore_admin1.BLL;

namespace drugstore_admin1
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProcessAdminNews : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html"; 
            if (context.Session["id"] != null)
            {
                string temp = File.ReadAllText(context.Server.MapPath("drugstore_admin_news.html"));

                List<NewsModel> newsList = NewsBLL.GetNewsList();
                StringBuilder sb = new StringBuilder();
                foreach (NewsModel item in newsList)
                {

                    string newsTypeName = NewsTypeBLL.GetNameById(item.NewsType);
                    sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td><a href='ProcessAdminDeleteNews.ashx?news_id={0}' class='btn btn-danger'>删除</a>&nbsp;<a href='ProcessAdminNewsSaveIndex.ashx?news_id={0}' class='btn btn-primary'>修改</a>&nbsp;<a href='ProcessAdminNewsPreview.ashx?news_id={0}' class='btn btn-warning'>预览</a></td></tr>", item.NewsId, item.NewsTitle, item.NewsViewCount, item.NewsSource, newsTypeName);
                }
                temp = temp.Replace("@content", sb.ToString());
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
