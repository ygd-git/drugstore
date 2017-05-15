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
using System.Threading;
using drugstore_admin1.BLL;

namespace drugstore_admin1
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class DeleteGoods : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            if (context.Session["id"] != null)
            {
                int id = context.Request.QueryString["goods_id"] == null ? 0 : Int32.Parse(context.Request.QueryString["goods_id"]);
                //context.Response.Write("Hello World"+id);

                if (id>0)
                {
                    int i = GoodsBLL.DeleteGoodsById(id);
                    if (i > 0) {
                        context.Response.Write("删除成功!");
                    }
                    else
                    {
                        context.Response.Write("删除失败");
                    }
                    context.Response.Write("<a href='ProcessAdminProduct.ashx'>回到商品首页</a>");
                    
                    
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
