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
    public class ProcessAdminNewsAddIndex : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            if (context.Session["id"] != null)
            {
                string temp = File.ReadAllText(context.Server.MapPath("drugstore_admin_news_add.html"));

                List<NewsTypeModel> newsTypeList = NewsTypeBLL.GetNewsList();
                StringBuilder sb = new StringBuilder();
                foreach (NewsTypeModel item in newsTypeList)
                {
                    sb.AppendFormat("<option value='{0}'>{1}</option>",item.NewsTypeid.ToString(),item.NewsTypename);
                }
                temp = temp.Replace("@newstype_content", sb.ToString());
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
