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

namespace drugstore_admin1.ShopCartInfo
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProcessShopCartDelete : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            if (context.Session["users_id"] != null)
            {
                int cartId = context.Request.QueryString["cart_id"] == null ? 0 : Int32.Parse(context.Request.QueryString["cart_id"]);
                if (cartId != 0)
                {
                    
                    int i = ShopCartBLL.Cart11(cartId);
                    context.Response.Write("删除成功<a href='ProcessShoppingIndex.ashx'>购物车页</a>");

                }
                else {
                    context.Response.Write("删除购物车异常...<a href='ProcessShoppingIndex.ashx'>购物车页</a>");
                }        
            }
            else
            {
                context.Response.Redirect("~/drugstore_login.html");
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
