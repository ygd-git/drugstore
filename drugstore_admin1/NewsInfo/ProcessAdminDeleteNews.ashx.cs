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

namespace drugstore_admin1.NewsInfo
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProcessAdminDeleteNews : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session["id"] != null)
            {
                context.Response.ContentType = "text/html";
                string news_id = context.Request.QueryString["news_id"];

                int i = NewsBLL.DeleteNews(Convert.ToInt32(news_id));
                if (i>0)
                {
                    context.Response.Write("删除成功! <a href='ProcessAdminNews.ashx'>返回新闻首页</a>");
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
