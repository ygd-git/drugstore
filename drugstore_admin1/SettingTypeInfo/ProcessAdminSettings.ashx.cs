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
using drugstore_admin1.Models;
using System.Collections.Generic;
using drugstore_admin1.BLL;

namespace drugstore_admin1
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProcessAdminSettings : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            
            if (context.Session["id"] != null)
            {
                string temp = File.ReadAllText(context.Server.MapPath("drugstore_admin_settings.html"));
                List<GoodsTypeModel> dt = GoodsTypeBLL.GetGoodsTypeList();
                StringBuilder sb = new StringBuilder();
                if (dt != null)
                {
                    foreach (GoodsTypeModel item in dt)
                    {
                        sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td><a href='ProcessAdminSettingsForm.ashx?goods_id_delete={0}'class='btn btn-danger'>删除</a></td></tr>", item.GoodsTypeid, item.GoodsTypename);

                    }
                }
                

                temp = temp.Replace("@product_content", sb.ToString());

                List<NewsTypeModel> dt2 = NewsTypeBLL.GetNewsList();
                StringBuilder sb2 = new StringBuilder();
                foreach (NewsTypeModel item in dt2)
                {
                    sb2.AppendFormat("<tr><td>{0}</td><td>{1}</td><td><a href='ProcessAdminSettingsForm.ashx?news_id_delete={0}'class='btn btn-danger'>删除</a></td></tr>", item.NewsTypeid, item.NewsTypename);
                }
                temp = temp.Replace("@admin", context.Session["admin_name"].ToString());
                temp = temp.Replace("@news_content", sb2.ToString());
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
