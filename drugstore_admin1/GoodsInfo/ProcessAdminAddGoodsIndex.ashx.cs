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
    public class ProcessAdminAddGoodsIndex : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            if (context.Session["id"] != null)
            {
                string temp = File.ReadAllText(context.Server.MapPath("drugstore_admin_product_add.html"));

                List<GoodsTypeModel> goodsTypeList = GoodsTypeBLL.GetGoodsTypeList();
                StringBuilder sb = new StringBuilder();
                foreach (GoodsTypeModel item in goodsTypeList)
                {
                    sb.AppendFormat(@"<option value='{0}'>{1}</option>", item.GoodsTypeid, item.GoodsTypename);
                }
                temp = temp.Replace("@product_type", sb.ToString());
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
